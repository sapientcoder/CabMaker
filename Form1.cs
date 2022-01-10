using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CabMaker
{
    public partial class Form1 : Form
    {
        private const int MAX_LINES_IN_DDF = 1024;
        private const int EXIT_CODE_SUCCESS = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private bool IncludeCompressionWindowSize => !Constants.DefaultCompressionType.ToString().Equals(cboCompressType.Items[cboCompressType.SelectedIndex]);

        private void btnSourceBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.SelectedPath = txtSourceFolder.Text;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtSourceFolder.Text = dialog.SelectedPath;
            }
        }

        private void btnTargetBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.SelectedPath = txtTargetFolder.Text;

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

            if (String.IsNullOrWhiteSpace(txtSourceFolder.Text) ||
                String.IsNullOrWhiteSpace(txtTargetFolder.Text) ||
                String.IsNullOrWhiteSpace(txtFileName.Text))
            {
                txtOutput.AppendText("Error: Source path, target path, and target file name must be specified.");
                txtOutput.ForeColor = Color.Red;
            }
            else
            {
                try
                {
                    // Create target folder if it doesn't already exist

                    if (!Directory.Exists(txtTargetFolder.Text))
                    {
                        Directory.CreateDirectory(txtTargetFolder.Text);
                    }

                    string ddfPath = Path.Combine(txtTargetFolder.Text, txtFileName.Text + ".ddf");

                    // Build DDF file

                    StringBuilder ddf = new StringBuilder();
                    ddf.AppendFormat($@";*** MakeCAB Directive file;
.OPTION EXPLICIT
.Set CabinetNameTemplate={txtFileName.Text.EnsureQuoted()}
.Set DiskDirectory1={txtTargetFolder.Text.EnsureQuoted()}
.Set MaxDiskSize=0
.Set Cabinet=on
.Set Compress=on
.Set CompressionType={cboCompressType.SelectedItem ?? Constants.DefaultCompressionType}");

                    ddf.AppendLine();

                    if (IncludeCompressionWindowSize) {
                        ddf.AppendFormat($".Set CompressionMemory={(cboCompressMemory.SelectedItem as CompressionWindowSize ?? Constants.DefaultCompressionWindowSize).Exponent}");
                        ddf.AppendLine();
                    }

                    int ddfHeaderLines = ddf.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Length;
                    int maxFiles = MAX_LINES_IN_DDF - ddfHeaderLines; // only write enough files to hit the max # of lines allowed in a DDF (blank lines don't count)

                    List<DdfFileRow> ddfFiles = GetFiles(txtSourceFolder.Text);

                    foreach (var ddfFile in ddfFiles.Take(maxFiles))
                    {
                        ddf.AppendFormat("\"{0}\" \"{1}\"{2}", ddfFile.FullName, ddfFile.Path, Environment.NewLine);
                    }

                    File.WriteAllText(ddfPath, ddf.ToString(), Encoding.Default);

                    string cmd = String.Format("/f {0}", ddfPath.EnsureQuoted());

                    // Run "makecab.exe"

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

        // capture output from console stdout to output box on form
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

        // capture output from console stderr to output box on form
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

            bool save = chkRemember.Checked;

            UserSettings settings = new UserSettings()
            {
                SourcePath = (save ? txtSourceFolder.Text : ""),
                TargetPath = (save ? txtTargetFolder.Text : ""),
                FileName = (save ? txtFileName.Text : ""),
                IncludeSubfolders = (save ? chkRecursive.Checked : true),
                CompressionType = (save ? cboCompressType.SelectedItem : Constants.DefaultCompressionType),
                CompressionWindowSize = (save ? cboCompressMemory.SelectedValue : Constants.DefaultCompressionWindowSize.Exponent)
            };

            storage.SaveObject(settings, $"{Application.ProductName}.dat");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboCompressType.Items.AddRange(Enum.GetNames(typeof(CompressionType)));

            cboCompressMemory.DataSource = Constants.CompressionWindowSizes;
            cboCompressMemory.DisplayMember = "Description";
            cboCompressMemory.ValueMember = "Exponent";

            IsolatedStorageFile storage = IsolatedStorageFile.GetStore(
                IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            UserSettings settings = storage.LoadObject<UserSettings>($"{Application.ProductName}.dat");

            if (settings != null)
            {
                txtSourceFolder.Text = settings.SourcePath;
                txtTargetFolder.Text = settings.TargetPath;
                txtFileName.Text = settings.FileName;
                cboCompressType.SelectedItem = settings.CompressionType ?? Constants.DefaultCompressionType;
                cboCompressMemory.SelectedValue = settings.CompressionWindowSize ?? Constants.DefaultCompressionWindowSize.Exponent;
            }
            else
            {
                cboCompressType.SelectedItem = Constants.DefaultCompressionType;
                cboCompressMemory.SelectedValue = Constants.DefaultCompressionWindowSize.Exponent;
            }

            lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
        }

        private void cboCompressType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCompressMemory.Enabled = IncludeCompressionWindowSize;
        }
    }
}
