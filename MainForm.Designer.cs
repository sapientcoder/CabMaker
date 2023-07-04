namespace CabMaker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.btnSourceBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTargetFolder = new System.Windows.Forms.TextBox();
            this.btnTargetBrowse = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.lblOutputStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCompressType = new System.Windows.Forms.ComboBox();
            this.cboCompressMemory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source folder:";
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Location = new System.Drawing.Point(23, 38);
            this.txtSourceFolder.Margin = new System.Windows.Forms.Padding(5);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(663, 26);
            this.txtSourceFolder.TabIndex = 1;
            // 
            // btnSourceBrowse
            // 
            this.btnSourceBrowse.Location = new System.Drawing.Point(696, 35);
            this.btnSourceBrowse.Margin = new System.Windows.Forms.Padding(5);
            this.btnSourceBrowse.Name = "btnSourceBrowse";
            this.btnSourceBrowse.Size = new System.Drawing.Size(113, 35);
            this.btnSourceBrowse.TabIndex = 2;
            this.btnSourceBrowse.Text = "Browse...";
            this.btnSourceBrowse.UseVisualStyleBackColor = true;
            this.btnSourceBrowse.Click += new System.EventHandler(this.btnSourceBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Target folder:";
            // 
            // txtTargetFolder
            // 
            this.txtTargetFolder.Location = new System.Drawing.Point(23, 163);
            this.txtTargetFolder.Margin = new System.Windows.Forms.Padding(5);
            this.txtTargetFolder.Name = "txtTargetFolder";
            this.txtTargetFolder.Size = new System.Drawing.Size(663, 26);
            this.txtTargetFolder.TabIndex = 5;
            // 
            // btnTargetBrowse
            // 
            this.btnTargetBrowse.Location = new System.Drawing.Point(696, 162);
            this.btnTargetBrowse.Margin = new System.Windows.Forms.Padding(5);
            this.btnTargetBrowse.Name = "btnTargetBrowse";
            this.btnTargetBrowse.Size = new System.Drawing.Size(113, 35);
            this.btnTargetBrowse.TabIndex = 6;
            this.btnTargetBrowse.Text = "Browse...";
            this.btnTargetBrowse.UseVisualStyleBackColor = true;
            this.btnTargetBrowse.Click += new System.EventHandler(this.btnTargetBrowse_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.White;
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(23, 469);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(5);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(784, 329);
            this.txtOutput.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 433);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Output:";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(696, 425);
            this.btnRun.Margin = new System.Windows.Forms.Padding(5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(113, 35);
            this.btnRun.TabIndex = 11;
            this.btnRun.Text = "Make CAB";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 232);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Target file name:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(23, 257);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(5);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(355, 26);
            this.txtFileName.TabIndex = 8;
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Checked = true;
            this.chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecursive.Location = new System.Drawing.Point(45, 78);
            this.chkRecursive.Margin = new System.Windows.Forms.Padding(5);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(375, 24);
            this.chkRecursive.TabIndex = 3;
            this.chkRecursive.Text = "Include all sub-folders beneath the source folder";
            this.chkRecursive.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(24, 394);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(785, 3);
            this.label5.TabIndex = 10;
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Checked = true;
            this.chkRemember.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemember.Location = new System.Drawing.Point(465, 260);
            this.chkRemember.Margin = new System.Windows.Forms.Padding(5);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(341, 24);
            this.chkRemember.TabIndex = 9;
            this.chkRemember.Text = "Remember these values next time app runs";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // lblOutputStatus
            // 
            this.lblOutputStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputStatus.Location = new System.Drawing.Point(128, 433);
            this.lblOutputStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblOutputStatus.Name = "lblOutputStatus";
            this.lblOutputStatus.Size = new System.Drawing.Size(560, 26);
            this.lblOutputStatus.TabIndex = 14;
            this.lblOutputStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 823);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Version:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(94, 823);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(129, 20);
            this.lblVersion.TabIndex = 16;
            this.lblVersion.Text = "(set at form load)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 333);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Compression Type:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(461, 333);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Compression Memory:";
            // 
            // cboCompressType
            // 
            this.cboCompressType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompressType.FormattingEnabled = true;
            this.cboCompressType.Location = new System.Drawing.Point(188, 330);
            this.cboCompressType.Name = "cboCompressType";
            this.cboCompressType.Size = new System.Drawing.Size(190, 28);
            this.cboCompressType.TabIndex = 19;
            this.cboCompressType.SelectedIndexChanged += new System.EventHandler(this.cboCompressType_SelectedIndexChanged);
            // 
            // cboCompressMemory
            // 
            this.cboCompressMemory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompressMemory.Enabled = false;
            this.cboCompressMemory.FormattingEnabled = true;
            this.cboCompressMemory.Location = new System.Drawing.Point(647, 330);
            this.cboCompressMemory.Name = "cboCompressMemory";
            this.cboCompressMemory.Size = new System.Drawing.Size(162, 28);
            this.cboCompressMemory.TabIndex = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 870);
            this.Controls.Add(this.cboCompressMemory);
            this.Controls.Add(this.cboCompressType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblOutputStatus);
            this.Controls.Add(this.chkRemember);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnTargetBrowse);
            this.Controls.Add(this.txtTargetFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSourceBrowse);
            this.Controls.Add(this.txtSourceFolder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CabMaker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Button btnSourceBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTargetFolder;
        private System.Windows.Forms.Button btnTargetBrowse;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.Label lblOutputStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCompressType;
        private System.Windows.Forms.ComboBox cboCompressMemory;
    }
}

