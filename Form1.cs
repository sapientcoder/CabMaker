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

        int jobFiles = 0;
        int compressedFiles = 0;
        string txtTargetDir = "";

        private bool IncludeCompressionWindowSize =>
            !Constants.DefaultCompressionType.ToString().Equals(DropdownCompressType.Items[DropdownCompressType.SelectedIndex]) &&
            !CompressionType.NONE.ToString().Equals(DropdownCompressType.SelectedItem);

        private void ButtonTargetBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "Cabinet Files|*.cab"
            };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                TextOutputFile.Text = saveFile.FileName;
            }
        }

        private void AddFile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFile;
            openFile = new OpenFileDialog
            {
                Multiselect = true
            };
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFile.FileNames)
                {
                    FilesListBox.Items.Add(fileName, true);
                    jobFiles += 1;
                }
                LabelOutputStatus.Text = "[JOB] " + jobFiles + " Files Imported";
                LabelOutputStatus.ForeColor = Color.Green;
            }
        }

        private void AddFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog;
            folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var files = Directory.GetFiles(folderDialog.SelectedPath, "*", SearchOption.AllDirectories);
                    foreach (string fileName in files)
                    {
                        FilesListBox.Items.Add(fileName, true);
                        jobFiles += 1;
                    }
                    LabelOutputStatus.Text = "[JOB] " + jobFiles + " Files Imported";
                    LabelOutputStatus.ForeColor = Color.Green;
                }
                catch { }
            }
            txtRootDir.Text = folderDialog.SelectedPath;
        }

        private List<DdfFileRow> GetFiles(string RootDir)
        {
            List<DdfFileRow> list = new List<DdfFileRow>();

            foreach (string filename in FilesListBox.CheckedItems)
            {
                list.Add(new DdfFileRow()
                {
                    FullName = filename,
                    Path = filename.Replace(RootDir, "").TrimStart('\\')
                });
            }
            return list;
        }

        private void ButtonRun_Click(object sender, EventArgs e)
        {
            DisableForm(true);

            jobFiles = FilesListBox.CheckedItems.Count;
            LabelOutputStatus.Text = "[JOB] Compressing " + jobFiles + " Files to CAB";
            LabelOutputStatus.ForeColor = Color.OrangeRed;

            TextOutput.ForeColor = SystemColors.WindowText;

            if (String.IsNullOrWhiteSpace(TextOutputFile.Text))
            {
                LabelOutputStatus.Text = "[ERROR] Please Specify a Target File";
                LabelOutputStatus.ForeColor = Color.Red;
            }
            else if (String.IsNullOrWhiteSpace(DropdownCompressType.Text))
            {
                LabelOutputStatus.Text = "[ERROR] Please Specify a Compression Type";
                LabelOutputStatus.ForeColor = Color.Red;
            }
            else
            {
                try
                {
                    string ddfPath = Path.Combine(TextOutputFile.Text + ".ddf");

                    // Build DDF file

                    bool compress = !CompressionType.NONE.ToString().Equals(DropdownCompressType.SelectedItem);
                    string compressValue = compress ? "on" : "off";

                    StringBuilder ddf = new StringBuilder();
                    ddf.AppendLine($@";*** MakeCAB Directive file;
.OPTION EXPLICIT
.Set CabinetNameTemplate={TextOutputFile.Text.EnsureQuoted()}
.Set DiskDirectory1={txtTargetDir.EnsureQuoted()}
.Set MaxDiskSize=0
.Set Cabinet=on
.Set Compress={compressValue}");

                    if (compress) {
                        ddf.AppendLine($".Set CompressionType={DropdownCompressType.SelectedItem ?? Constants.DefaultCompressionType}");
                    }

                    if (IncludeCompressionWindowSize) {
                        ddf.AppendFormat($".Set CompressionMemory={(DropdownCompressMemory.SelectedItem as CompressionWindowSize ?? Constants.DefaultCompressionWindowSize).Exponent}");
                        ddf.AppendLine();
                    }

                    ddf.AppendLine();

                    int ddfHeaderLines = ddf.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Length;
                    int maxFiles = MAX_LINES_IN_DDF - ddfHeaderLines; // only write enough files to hit the max # of lines allowed in a DDF (blank lines don't count)

                    List<DdfFileRow> ddfFiles = GetFiles(txtRootDir.Text);

                    foreach (var ddfFile in ddfFiles.Take(maxFiles))
                    {
                        ddf.AppendFormat("\"{0}\" \"{1}\"{2}", ddfFile.FullName, ddfFile.Path, Environment.NewLine);
                    }

                    File.WriteAllText(ddfPath, ddf.ToString(), Encoding.Default);

                    string cmd = String.Format("/f {0}", ddfPath.EnsureQuoted());

                    // Run "makecab.exe"

                    Process process = new Process();

                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        CreateNoWindow = true,
                        FileName = "makecab.exe",
                        Arguments = cmd,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false
                    };
                    process.StartInfo = startInfo;

                    process.ErrorDataReceived += Process_ErrorDataReceived;
                    process.OutputDataReceived += Process_OutputDataReceived;

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();

                    TextOutput.AppendText("Exit code: " + process.ExitCode);

                    if (process.ExitCode == EXIT_CODE_SUCCESS)
                    {
                        File.SetLastWriteTime((TextOutputFile.Text), DateTime.Now);
                        compressedFiles += jobFiles;
                        LabelOutputStatus.Text = "[CabMaker] " + jobFiles + " Files Added to CAB";
                        LabelOutputStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        LabelOutputStatus.Text = "[JOB] CAB File could not be created. Check the Log for Details";
                        LabelOutputStatus.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    LabelOutputStatus.Text = "[JOB] CAB File could not be created. Check the Log for Details";
                    LabelOutputStatus.ForeColor = Color.Red;

                    TextOutput.AppendText("Error: " + ex.ToString());
                    TextOutput.ForeColor = Color.Red;
                }
            }
            DisableForm(false);
        }

        private void DisableForm(bool disable)
        {
            GroupBoxFiles.Enabled = !disable;
            GroupBoxCompressor.Enabled = !disable;
        }

        // capture output from console stdout to output box on form
        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                if (e.Data != null)
                {
                    TextOutput.AppendText(e.Data + Environment.NewLine);
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
                    TextOutput.AppendText(e.Data + Environment.NewLine);
                    TextOutput.ForeColor = Color.Red;
                }
            });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetStore(
                IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            bool save = CheckSaveSettings.Checked;

            UserSettings settings = new UserSettings()
            {
                FileName = (save ? TextOutputFile.Text : ""),
                CompressionType = (save ? DropdownCompressType.SelectedItem : Constants.DefaultCompressionType),
                CompressionWindowSize = (save ? DropdownCompressMemory.SelectedValue : Constants.DefaultCompressionWindowSize.Exponent)
            };
            storage.SaveObject(settings, $"{Application.ProductName}.dat");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DropdownCompressType.Items.AddRange(Enum.GetNames(typeof(CompressionType)));
            DropdownCompressType.SelectedIndex = 0;
            DropdownCompressMemory.DataSource = Constants.CompressionWindowSizes;
            DropdownCompressMemory.DisplayMember = "Description";
            DropdownCompressMemory.ValueMember = "Exponent";

            IsolatedStorageFile storage = IsolatedStorageFile.GetStore(
                IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            UserSettings settings = storage.LoadObject<UserSettings>($"{Application.ProductName}.dat");

            if (settings != null)
            {
                TextOutputFile.Text = settings.FileName;
                DropdownCompressType.SelectedItem = settings.CompressionType ?? Constants.DefaultCompressionType;
                DropdownCompressMemory.SelectedValue = settings.CompressionWindowSize ?? Constants.DefaultCompressionWindowSize.Exponent;
            }
            else
            {
                DropdownCompressType.SelectedItem = Constants.DefaultCompressionType;
                DropdownCompressMemory.SelectedValue = Constants.DefaultCompressionWindowSize.Exponent;
            }

            LabelVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
            LabelOutputStatus.Text = "[JOB] " + jobFiles + " Files Imported";
            LabelOutputStatus.ForeColor = Color.Red;
        }

        private void DropdownCompressType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropdownCompressMemory.Enabled = IncludeCompressionWindowSize;
            DropdownCompressMemory.Visible = IncludeCompressionWindowSize;
            LabelCompressionMemory.Visible = IncludeCompressionWindowSize;
        }

        private void ClearFiles_Click(object sender, EventArgs e)
        {
            FilesListBox.Items.Clear();
            jobFiles = 0;
            LabelOutputStatus.Text = "[JOB] " + jobFiles + " Files Imported";
            LabelOutputStatus.ForeColor = Color.Red;
        }

        private void SelectAllFiles_Click(object sender, EventArgs e)
        {
            if (FilesListBox.Items.Count > 0)
            {
                bool AllFilesSelected = false;
                if (SelectAllFiles.Text == "Select All")
                {
                    AllFilesSelected = true;
                    SelectAllFiles.Text = "Deselect All";
                }
                else if (SelectAllFiles.Text == "Deselect All")
                {
                    AllFilesSelected = false;
                    SelectAllFiles.Text = "Select All";
                }
                int count = FilesListBox.Items.Count;
                for (int i = 0; i < count; i++)
                    FilesListBox.SetItemChecked(i, AllFilesSelected);
            }
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Text Files|*.txt"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, TextOutput.Text);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            TextOutput.Clear();
            txtTargetDir = "";
            TextOutputFile.Text = "";
            txtRootDir.Text = "";
            compressedFiles = 0;
            LabelOutputStatus.Text = "[JOB] " + jobFiles + " Files Imported";
        }

        private void ButtonBrowseRoot_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog;
            folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                txtRootDir.Text = folderDialog.SelectedPath;
            }
        }
    }
}
