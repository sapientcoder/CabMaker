using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using System.Windows.Forms;

namespace CabMaker
{
    public partial class Form1 : Form
    {
        private const int EXIT_CODE_SUCCESS = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSourceBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtSourceFolder.Text = dialog.SelectedPath;
            }
        }

        private void btnTargetBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = txtSourceFolder.Text;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtTargetFolder.Text = dialog.SelectedPath;
            }
        }

        private List<DdfFileRow> GetFiles(string sDir)
        {
            List<DdfFileRow> list = new List<DdfFileRow>();
            string srcPath = txtSourceFolder.Text;

            foreach (string f in Directory.GetFiles(sDir))
            {
                list.Add(new DdfFileRow()
                {
                    FullName = f,
                    Path = f.Replace(srcPath, "").TrimStart('\\')
                });
            }

            if (chkRecursive.Checked)
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    list.AddRange(GetFiles(d));
                }
            }

            return list;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            btnRun.Enabled = false;

            lblOutputStatus.Text = "";
            lblOutputStatus.ForeColor = SystemColors.WindowText;

            txtOutput.Clear();
            txtOutput.ForeColor = SystemColors.WindowText;

            if (StringUtil.IsNullOrWhiteSpace(txtSourceFolder.Text) ||
                StringUtil.IsNullOrWhiteSpace(txtTargetFolder.Text) ||
                StringUtil.IsNullOrWhiteSpace(txtFileName.Text))
            {
                txtOutput.AppendText("Error: Source path, target path, and target file name must be specified.");
                txtOutput.ForeColor = Color.Red;
            }
            else
            {
                try
                {
                    string ddfPath = Path.Combine(txtTargetFolder.Text, txtFileName.Text + ".ddf");

                    StringBuilder ddf = new StringBuilder();
                    ddf.AppendFormat(@";*** MakeCAB Directive file;
.OPTION EXPLICIT
.Set CabinetNameTemplate={0}
.Set DiskDirectory1={1}
.Set MaxDiskSize=0
.Set Cabinet=on
.Set Compress=on
", txtFileName.Text, txtTargetFolder.Text);

                    List<DdfFileRow> ddfFiles = GetFiles(txtSourceFolder.Text);

                    foreach (var ddfFile in ddfFiles)
                    {
                        ddf.AppendFormat("\"{0}\" \"{1}\"{2}", ddfFile.FullName, ddfFile.Path, Environment.NewLine);
                    }

                    File.WriteAllText(ddfPath, ddf.ToString());

                    string cmd = String.Format("/f {0}", ddfPath);

                    Process process = new Process();

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.CreateNoWindow = true;
                    startInfo.FileName = "makecab.exe";
                    startInfo.Arguments = cmd;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.RedirectStandardError = true;
                    startInfo.UseShellExecute = false;
                    process.StartInfo = startInfo;

                    process.ErrorDataReceived += Process_ErrorDataReceived;
                    process.OutputDataReceived += Process_OutputDataReceived;

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();

                    txtOutput.AppendText("Exit code: " + process.ExitCode);

                    if (process.ExitCode == EXIT_CODE_SUCCESS)
                    {
                        File.SetLastWriteTime(Path.Combine(txtTargetFolder.Text, txtFileName.Text), DateTime.Now);
                        lblOutputStatus.Text = "CAB file successfully created.";
                        lblOutputStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblOutputStatus.Text = "CAB file not created. See output for details.";
                        lblOutputStatus.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblOutputStatus.Text = "CAB file not created. See output for details.";
                    lblOutputStatus.ForeColor = Color.Red;

                    txtOutput.AppendText("Error: " + ex.ToString());
                    txtOutput.ForeColor = Color.Red;
                }
            }

            btnRun.Enabled = true;
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                if (e.Data != null)
                {
                    txtOutput.AppendText(e.Data + Environment.NewLine);
                }
            });
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                if (e.Data != null)
                {
                    txtOutput.AppendText(e.Data + Environment.NewLine);
                    txtOutput.ForeColor = Color.Red;
                }
            });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetStore(
                IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            bool save = chkRecursive.Checked;

            UserSettings settings = new UserSettings()
            {
                SourcePath = (save ? txtSourceFolder.Text : ""),
                TargetPath = (save ? txtTargetFolder.Text : ""),
                FileName = (save ? txtFileName.Text : ""),
                IncludeSubfolders = (save ? chkRecursive.Checked : true)
            };

            storage.SaveObject(settings, String.Format("{0}.dat", Application.ProductName));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetStore(
                IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            UserSettings settings = storage.LoadObject<UserSettings>(String.Format("{0}.dat", Application.ProductName));

            if (settings != null)
            {
                txtSourceFolder.Text = settings.SourcePath;
                txtTargetFolder.Text = settings.TargetPath;
                txtFileName.Text = settings.FileName;
            }
        }
    }
}
