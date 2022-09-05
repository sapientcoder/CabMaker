namespace CabMaker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonTargetBrowse = new System.Windows.Forms.Button();
            this.TextOutput = new System.Windows.Forms.TextBox();
            this.ButtonRun = new System.Windows.Forms.Button();
            this.LabelOutputFile = new System.Windows.Forms.Label();
            this.TextOutputFile = new System.Windows.Forms.TextBox();
            this.LabelCompressionType = new System.Windows.Forms.Label();
            this.LabelCompressionMemory = new System.Windows.Forms.Label();
            this.DropdownCompressType = new System.Windows.Forms.ComboBox();
            this.DropdownCompressMemory = new System.Windows.Forms.ComboBox();
            this.GroupBoxFiles = new System.Windows.Forms.GroupBox();
            this.FilesListBox = new System.Windows.Forms.CheckedListBox();
            this.SelectAllFiles = new System.Windows.Forms.Button();
            this.ClearFiles = new System.Windows.Forms.Button();
            this.AddFile = new System.Windows.Forms.Button();
            this.AddFolder = new System.Windows.Forms.Button();
            this.GroupBoxCompressor = new System.Windows.Forms.GroupBox();
            this.ButtonBrowseRoot = new System.Windows.Forms.Button();
            this.txtRootDir = new System.Windows.Forms.TextBox();
            this.LabelRootDirectory = new System.Windows.Forms.Label();
            this.CheckSaveSettings = new System.Windows.Forms.CheckBox();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonExport = new System.Windows.Forms.Button();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.LabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelOutputStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.GroupBoxFiles.SuspendLayout();
            this.GroupBoxCompressor.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonTargetBrowse
            // 
            this.ButtonTargetBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonTargetBrowse.Location = new System.Drawing.Point(459, 16);
            this.ButtonTargetBrowse.Name = "ButtonTargetBrowse";
            this.ButtonTargetBrowse.Size = new System.Drawing.Size(75, 23);
            this.ButtonTargetBrowse.TabIndex = 9;
            this.ButtonTargetBrowse.Text = "Browse...";
            this.ButtonTargetBrowse.UseVisualStyleBackColor = true;
            this.ButtonTargetBrowse.Click += new System.EventHandler(this.ButtonTargetBrowse_Click);
            // 
            // TextOutput
            // 
            this.TextOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextOutput.BackColor = System.Drawing.Color.White;
            this.TextOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextOutput.Location = new System.Drawing.Point(4, 121);
            this.TextOutput.Multiline = true;
            this.TextOutput.Name = "TextOutput";
            this.TextOutput.ReadOnly = true;
            this.TextOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextOutput.Size = new System.Drawing.Size(531, 124);
            this.TextOutput.TabIndex = 13;
            this.TextOutput.WordWrap = false;
            // 
            // ButtonRun
            // 
            this.ButtonRun.Location = new System.Drawing.Point(163, 93);
            this.ButtonRun.Name = "ButtonRun";
            this.ButtonRun.Size = new System.Drawing.Size(75, 23);
            this.ButtonRun.TabIndex = 11;
            this.ButtonRun.Text = "Make CAB";
            this.ButtonRun.UseVisualStyleBackColor = true;
            this.ButtonRun.Click += new System.EventHandler(this.ButtonRun_Click);
            // 
            // LabelOutputFile
            // 
            this.LabelOutputFile.AutoSize = true;
            this.LabelOutputFile.Location = new System.Drawing.Point(5, 21);
            this.LabelOutputFile.Name = "LabelOutputFile";
            this.LabelOutputFile.Size = new System.Drawing.Size(61, 13);
            this.LabelOutputFile.TabIndex = 7;
            this.LabelOutputFile.Text = "Output File:";
            // 
            // TextOutputFile
            // 
            this.TextOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextOutputFile.Location = new System.Drawing.Point(72, 18);
            this.TextOutputFile.Name = "TextOutputFile";
            this.TextOutputFile.Size = new System.Drawing.Size(383, 20);
            this.TextOutputFile.TabIndex = 8;
            // 
            // LabelCompressionType
            // 
            this.LabelCompressionType.AutoSize = true;
            this.LabelCompressionType.Location = new System.Drawing.Point(4, 70);
            this.LabelCompressionType.Name = "LabelCompressionType";
            this.LabelCompressionType.Size = new System.Drawing.Size(97, 13);
            this.LabelCompressionType.TabIndex = 17;
            this.LabelCompressionType.Text = "Compression Type:";
            // 
            // LabelCompressionMemory
            // 
            this.LabelCompressionMemory.AutoSize = true;
            this.LabelCompressionMemory.Location = new System.Drawing.Point(223, 70);
            this.LabelCompressionMemory.Name = "LabelCompressionMemory";
            this.LabelCompressionMemory.Size = new System.Drawing.Size(110, 13);
            this.LabelCompressionMemory.TabIndex = 18;
            this.LabelCompressionMemory.Text = "Compression Memory:";
            // 
            // DropdownCompressType
            // 
            this.DropdownCompressType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropdownCompressType.FormattingEnabled = true;
            this.DropdownCompressType.Location = new System.Drawing.Point(106, 67);
            this.DropdownCompressType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DropdownCompressType.Name = "DropdownCompressType";
            this.DropdownCompressType.Size = new System.Drawing.Size(111, 21);
            this.DropdownCompressType.TabIndex = 19;
            this.DropdownCompressType.SelectedIndexChanged += new System.EventHandler(this.DropdownCompressType_SelectedIndexChanged);
            // 
            // DropdownCompressMemory
            // 
            this.DropdownCompressMemory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropdownCompressMemory.Enabled = false;
            this.DropdownCompressMemory.FormattingEnabled = true;
            this.DropdownCompressMemory.Location = new System.Drawing.Point(338, 67);
            this.DropdownCompressMemory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DropdownCompressMemory.Name = "DropdownCompressMemory";
            this.DropdownCompressMemory.Size = new System.Drawing.Size(76, 21);
            this.DropdownCompressMemory.TabIndex = 20;
            // 
            // GroupBoxFiles
            // 
            this.GroupBoxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxFiles.Controls.Add(this.FilesListBox);
            this.GroupBoxFiles.Controls.Add(this.SelectAllFiles);
            this.GroupBoxFiles.Controls.Add(this.ClearFiles);
            this.GroupBoxFiles.Controls.Add(this.AddFile);
            this.GroupBoxFiles.Controls.Add(this.AddFolder);
            this.GroupBoxFiles.Location = new System.Drawing.Point(8, 8);
            this.GroupBoxFiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GroupBoxFiles.Name = "GroupBoxFiles";
            this.GroupBoxFiles.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GroupBoxFiles.Size = new System.Drawing.Size(540, 170);
            this.GroupBoxFiles.TabIndex = 0;
            this.GroupBoxFiles.TabStop = false;
            this.GroupBoxFiles.Text = "Files";
            // 
            // FilesListBox
            // 
            this.FilesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilesListBox.FormattingEnabled = true;
            this.FilesListBox.Location = new System.Drawing.Point(4, 43);
            this.FilesListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FilesListBox.Name = "FilesListBox";
            this.FilesListBox.ScrollAlwaysVisible = true;
            this.FilesListBox.Size = new System.Drawing.Size(531, 124);
            this.FilesListBox.TabIndex = 5;
            // 
            // SelectAllFiles
            // 
            this.SelectAllFiles.Location = new System.Drawing.Point(83, 16);
            this.SelectAllFiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SelectAllFiles.Name = "SelectAllFiles";
            this.SelectAllFiles.Size = new System.Drawing.Size(75, 23);
            this.SelectAllFiles.TabIndex = 2;
            this.SelectAllFiles.Text = "Deselect All";
            this.SelectAllFiles.UseVisualStyleBackColor = true;
            this.SelectAllFiles.Click += new System.EventHandler(this.SelectAllFiles_Click);
            // 
            // ClearFiles
            // 
            this.ClearFiles.Location = new System.Drawing.Point(4, 16);
            this.ClearFiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ClearFiles.Name = "ClearFiles";
            this.ClearFiles.Size = new System.Drawing.Size(75, 23);
            this.ClearFiles.TabIndex = 1;
            this.ClearFiles.Text = "Clear All";
            this.ClearFiles.UseVisualStyleBackColor = true;
            this.ClearFiles.Click += new System.EventHandler(this.ClearFiles_Click);
            // 
            // AddFile
            // 
            this.AddFile.Location = new System.Drawing.Point(243, 16);
            this.AddFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddFile.Name = "AddFile";
            this.AddFile.Size = new System.Drawing.Size(75, 23);
            this.AddFile.TabIndex = 4;
            this.AddFile.Text = "Add File";
            this.AddFile.UseVisualStyleBackColor = true;
            this.AddFile.Click += new System.EventHandler(this.AddFile_Click);
            // 
            // AddFolder
            // 
            this.AddFolder.Location = new System.Drawing.Point(163, 16);
            this.AddFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddFolder.Name = "AddFolder";
            this.AddFolder.Size = new System.Drawing.Size(75, 23);
            this.AddFolder.TabIndex = 3;
            this.AddFolder.Text = "Add Folder";
            this.AddFolder.UseVisualStyleBackColor = true;
            this.AddFolder.Click += new System.EventHandler(this.AddFolder_Click);
            // 
            // GroupBoxCompressor
            // 
            this.GroupBoxCompressor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxCompressor.Controls.Add(this.ButtonBrowseRoot);
            this.GroupBoxCompressor.Controls.Add(this.txtRootDir);
            this.GroupBoxCompressor.Controls.Add(this.LabelRootDirectory);
            this.GroupBoxCompressor.Controls.Add(this.CheckSaveSettings);
            this.GroupBoxCompressor.Controls.Add(this.ButtonClear);
            this.GroupBoxCompressor.Controls.Add(this.ButtonExport);
            this.GroupBoxCompressor.Controls.Add(this.DropdownCompressMemory);
            this.GroupBoxCompressor.Controls.Add(this.ButtonTargetBrowse);
            this.GroupBoxCompressor.Controls.Add(this.TextOutput);
            this.GroupBoxCompressor.Controls.Add(this.LabelCompressionMemory);
            this.GroupBoxCompressor.Controls.Add(this.TextOutputFile);
            this.GroupBoxCompressor.Controls.Add(this.DropdownCompressType);
            this.GroupBoxCompressor.Controls.Add(this.LabelOutputFile);
            this.GroupBoxCompressor.Controls.Add(this.ButtonRun);
            this.GroupBoxCompressor.Controls.Add(this.LabelCompressionType);
            this.GroupBoxCompressor.Location = new System.Drawing.Point(8, 182);
            this.GroupBoxCompressor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GroupBoxCompressor.Name = "GroupBoxCompressor";
            this.GroupBoxCompressor.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GroupBoxCompressor.Size = new System.Drawing.Size(540, 250);
            this.GroupBoxCompressor.TabIndex = 6;
            this.GroupBoxCompressor.TabStop = false;
            this.GroupBoxCompressor.Text = "Compressor";
            // 
            // ButtonBrowseRoot
            // 
            this.ButtonBrowseRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonBrowseRoot.Location = new System.Drawing.Point(459, 41);
            this.ButtonBrowseRoot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonBrowseRoot.Name = "ButtonBrowseRoot";
            this.ButtonBrowseRoot.Size = new System.Drawing.Size(75, 23);
            this.ButtonBrowseRoot.TabIndex = 26;
            this.ButtonBrowseRoot.Text = "Browse...";
            this.ButtonBrowseRoot.UseVisualStyleBackColor = true;
            this.ButtonBrowseRoot.Click += new System.EventHandler(this.ButtonBrowseRoot_Click);
            // 
            // txtRootDir
            // 
            this.txtRootDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRootDir.Location = new System.Drawing.Point(88, 43);
            this.txtRootDir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRootDir.Name = "txtRootDir";
            this.txtRootDir.Size = new System.Drawing.Size(367, 20);
            this.txtRootDir.TabIndex = 25;
            // 
            // LabelRootDirectory
            // 
            this.LabelRootDirectory.AutoSize = true;
            this.LabelRootDirectory.Location = new System.Drawing.Point(5, 46);
            this.LabelRootDirectory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelRootDirectory.Name = "LabelRootDirectory";
            this.LabelRootDirectory.Size = new System.Drawing.Size(79, 13);
            this.LabelRootDirectory.TabIndex = 24;
            this.LabelRootDirectory.Text = "CAB Root DIR:";
            // 
            // CheckSaveSettings
            // 
            this.CheckSaveSettings.AutoSize = true;
            this.CheckSaveSettings.Location = new System.Drawing.Point(243, 97);
            this.CheckSaveSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheckSaveSettings.Name = "CheckSaveSettings";
            this.CheckSaveSettings.Size = new System.Drawing.Size(92, 17);
            this.CheckSaveSettings.TabIndex = 23;
            this.CheckSaveSettings.Text = "Save Settings";
            this.CheckSaveSettings.UseVisualStyleBackColor = true;
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(4, 93);
            this.ButtonClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(75, 23);
            this.ButtonClear.TabIndex = 22;
            this.ButtonClear.Text = "Clear Log";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // ButtonExport
            // 
            this.ButtonExport.Location = new System.Drawing.Point(83, 93);
            this.ButtonExport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonExport.Name = "ButtonExport";
            this.ButtonExport.Size = new System.Drawing.Size(75, 23);
            this.ButtonExport.TabIndex = 21;
            this.ButtonExport.Text = "Export Log";
            this.ButtonExport.UseVisualStyleBackColor = true;
            this.ButtonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelVersion,
            this.LabelOutputStatus});
            this.StatusStrip.Location = new System.Drawing.Point(0, 434);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.StatusStrip.Size = new System.Drawing.Size(556, 22);
            this.StatusStrip.TabIndex = 23;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // LabelVersion
            // 
            this.LabelVersion.Name = "LabelVersion";
            this.LabelVersion.Size = new System.Drawing.Size(0, 17);
            // 
            // LabelOutputStatus
            // 
            this.LabelOutputStatus.Name = "LabelOutputStatus";
            this.LabelOutputStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 456);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.GroupBoxFiles);
            this.Controls.Add(this.GroupBoxCompressor);
            this.MinimumSize = new System.Drawing.Size(453, 495);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CabMaker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBoxFiles.ResumeLayout(false);
            this.GroupBoxCompressor.ResumeLayout(false);
            this.GroupBoxCompressor.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonTargetBrowse;
        private System.Windows.Forms.TextBox TextOutput;
        private System.Windows.Forms.Button ButtonRun;
        private System.Windows.Forms.Label LabelOutputFile;
        private System.Windows.Forms.TextBox TextOutputFile;
        private System.Windows.Forms.Label LabelCompressionType;
        private System.Windows.Forms.Label LabelCompressionMemory;
        private System.Windows.Forms.ComboBox DropdownCompressType;
        private System.Windows.Forms.ComboBox DropdownCompressMemory;
        private System.Windows.Forms.GroupBox GroupBoxFiles;
        private System.Windows.Forms.Button AddFolder;
        private System.Windows.Forms.Button SelectAllFiles;
        private System.Windows.Forms.Button ClearFiles;
        private System.Windows.Forms.Button AddFile;
        private System.Windows.Forms.GroupBox GroupBoxCompressor;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel LabelOutputStatus;
        private System.Windows.Forms.ToolStripStatusLabel LabelVersion;
        private System.Windows.Forms.CheckedListBox FilesListBox;
        private System.Windows.Forms.Button ButtonExport;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.CheckBox CheckSaveSettings;
        private System.Windows.Forms.Button ButtonBrowseRoot;
        private System.Windows.Forms.TextBox txtRootDir;
        private System.Windows.Forms.Label LabelRootDirectory;
    }
}

