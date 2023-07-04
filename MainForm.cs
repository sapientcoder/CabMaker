using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CabMaker
{
    public partial class MainForm : Form
    {
        private const int EXIT_CODE_SUCCESS = 0;

        public MainForm()
        {
            InitializeComponent();
        }

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

                    // Build DDF file

                    DdfFileBuilder ddfBuilder = new DdfFileBuilder(
                        txtSourceFolder.Text,
                        chkRecursive.Checked,
                        txtTargetFolder.Text,
                        txtFileName.Text,
                        EnumUtil.SafeParse(cboCompressType.SelectedItem as string, Constants.DefaultCompressionType),
                        cboCompressMemory.SelectedItem as CompressionWindowSize);

                    ddfBuilder.BuildAndSave();

                    // Run "makecab.exe"

                    string cmd = String.Format("/f {0}", ddfBuilder.DdfFilePath.EnsureQuoted());

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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chkRemember.Checked)
            {
                UserSettings.Save(
                    txtSourceFolder.Text,
                    chkRecursive.Checked,
                    txtTargetFolder.Text,
                    txtFileName.Text,
                    EnumUtil.SafeParse(cboCompressType.SelectedItem as string, Constants.DefaultCompressionType),
                    cboCompressMemory.SelectedItem as CompressionWindowSize);
            }
            else
            {
                UserSettings.Clear();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initialize drop-downs

            cboCompressType.Items.AddRange(Enum.GetNames(typeof(CompressionType)));
            cboCompressMemory.DataSource = Constants.CompressionWindowSizes;
            cboCompressMemory.DisplayMember = "Description";
            cboCompressMemory.ValueMember = "Exponent";

            // Set field values

            UserSettings settings = UserSettings.FetchWithDefaults();

            txtSourceFolder.Text = settings.SourcePath;
            chkRecursive.Checked = settings.IncludeSubfolders;
            txtTargetFolder.Text = settings.TargetPath;
            txtFileName.Text = settings.FileName;

            cboCompressType.SelectedItem = Enum.GetName(typeof(CompressionType), settings.CompressionType);
            cboCompressMemory.SelectedValue = settings.CompressionWindowSize;

            lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
        }

        private void cboCompressType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompressionType compressionType = EnumUtil.SafeParse(
                cboCompressType.SelectedItem as string, Constants.DefaultCompressionType);

            cboCompressMemory.Enabled = DdfFileBuilder.IsCompressionWindowSizeIncluded(compressionType);
        }
    }
}
