namespace CFElection
{
  partial class frmMain
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
      this.components = new System.ComponentModel.Container();
      this.btnGo = new System.Windows.Forms.Button();
      this.cboDrive = new System.Windows.Forms.ComboBox();
      this.lblDrive = new System.Windows.Forms.Label();
      this.txtPath = new System.Windows.Forms.TextBox();
      this.lblDirectory = new System.Windows.Forms.Label();
      this.lblInfo = new System.Windows.Forms.Label();
      this.cbLoop = new System.Windows.Forms.CheckBox();
      this.lblStatus = new System.Windows.Forms.Label();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.cbMD5 = new System.Windows.Forms.CheckBox();
      this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
      this.txtBackupPath = new System.Windows.Forms.TextBox();
      this.fldBrowse = new System.Windows.Forms.FolderBrowserDialog();
      this.cbCopyData = new System.Windows.Forms.CheckBox();
      this.cbBackup = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnGo
      // 
      this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnGo.Enabled = false;
      this.btnGo.Location = new System.Drawing.Point(205, 245);
      this.btnGo.Name = "btnGo";
      this.btnGo.Size = new System.Drawing.Size(75, 23);
      this.btnGo.TabIndex = 5;
      this.btnGo.Text = "Go";
      this.ToolTip.SetToolTip(this.btnGo, "Click here to format, copy and eject the ElectionData on the CF Drive");
      this.btnGo.UseVisualStyleBackColor = true;
      this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
      // 
      // cboDrive
      // 
      this.cboDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboDrive.FormattingEnabled = true;
      this.cboDrive.Location = new System.Drawing.Point(79, 12);
      this.cboDrive.Name = "cboDrive";
      this.cboDrive.Size = new System.Drawing.Size(121, 21);
      this.cboDrive.TabIndex = 1;
      this.ToolTip.SetToolTip(this.cboDrive, "Please Select the Compact Flash Drive");
      this.cboDrive.SelectedIndexChanged += new System.EventHandler(this.cboDrive_SelectedIndexChanged);
      // 
      // lblDrive
      // 
      this.lblDrive.AutoSize = true;
      this.lblDrive.Location = new System.Drawing.Point(25, 15);
      this.lblDrive.Name = "lblDrive";
      this.lblDrive.Size = new System.Drawing.Size(48, 13);
      this.lblDrive.TabIndex = 2;
      this.lblDrive.Text = "CF Drive";
      // 
      // txtPath
      // 
      this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPath.Location = new System.Drawing.Point(79, 117);
      this.txtPath.Name = "txtPath";
      this.txtPath.Size = new System.Drawing.Size(201, 20);
      this.txtPath.TabIndex = 2;
      this.ToolTip.SetToolTip(this.txtPath, "Please Enter the Path to copy the ElectionData from");
      this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
      // 
      // lblDirectory
      // 
      this.lblDirectory.AutoSize = true;
      this.lblDirectory.Location = new System.Drawing.Point(27, 120);
      this.lblDirectory.Name = "lblDirectory";
      this.lblDirectory.Size = new System.Drawing.Size(46, 13);
      this.lblDirectory.TabIndex = 4;
      this.lblDirectory.Text = "Root Dir";
      this.lblDirectory.MouseLeave += new System.EventHandler(this.lblDirectory_MouseLeave);
      this.lblDirectory.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDirectory_MouseUp);
      this.lblDirectory.MouseEnter += new System.EventHandler(this.lblDirectory_MouseEnter);
      // 
      // lblInfo
      // 
      this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblInfo.Location = new System.Drawing.Point(76, 140);
      this.lblInfo.Name = "lblInfo";
      this.lblInfo.Size = new System.Drawing.Size(204, 44);
      this.lblInfo.TabIndex = 5;
      this.lblInfo.Text = "The Root Dir is the directory that contains the  ElectionData Folder NOT the Elec" +
          "tionData folder itself";
      // 
      // cbLoop
      // 
      this.cbLoop.AutoSize = true;
      this.cbLoop.Location = new System.Drawing.Point(79, 188);
      this.cbLoop.Name = "cbLoop";
      this.cbLoop.Size = new System.Drawing.Size(76, 17);
      this.cbLoop.TabIndex = 3;
      this.cbLoop.Text = "Automagic";
      this.ToolTip.SetToolTip(this.cbLoop, "When this is selected the Go buttom will be clicked when the system notices a dis" +
              "k in the CF Drive");
      this.cbLoop.UseVisualStyleBackColor = true;
      this.cbLoop.CheckedChanged += new System.EventHandler(this.cbLoop_CheckedChanged);
      // 
      // lblStatus
      // 
      this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblStatus.Location = new System.Drawing.Point(18, 250);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(181, 18);
      this.lblStatus.TabIndex = 7;
      this.lblStatus.Text = "Status Text";
      // 
      // timer
      // 
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // cbMD5
      // 
      this.cbMD5.AutoSize = true;
      this.cbMD5.Location = new System.Drawing.Point(79, 212);
      this.cbMD5.Name = "cbMD5";
      this.cbMD5.Size = new System.Drawing.Size(102, 17);
      this.cbMD5.TabIndex = 4;
      this.cbMD5.Text = "MD5 Checksum";
      this.ToolTip.SetToolTip(this.cbMD5, "Verifies that the files are copied correctly (it takes a bit longer)");
      this.cbMD5.UseVisualStyleBackColor = true;
      this.cbMD5.CheckedChanged += new System.EventHandler(this.cbMD5_CheckedChanged);
      // 
      // txtBackupPath
      // 
      this.txtBackupPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtBackupPath.Location = new System.Drawing.Point(79, 68);
      this.txtBackupPath.Name = "txtBackupPath";
      this.txtBackupPath.Size = new System.Drawing.Size(201, 20);
      this.txtBackupPath.TabIndex = 10;
      this.ToolTip.SetToolTip(this.txtBackupPath, "Please Enter the Path to copy the ElectionData from");
      this.txtBackupPath.TextChanged += new System.EventHandler(this.txtBackupPath_TextChanged);
      // 
      // fldBrowse
      // 
      this.fldBrowse.ShowNewFolderButton = false;
      // 
      // cbCopyData
      // 
      this.cbCopyData.AutoSize = true;
      this.cbCopyData.Location = new System.Drawing.Point(79, 94);
      this.cbCopyData.Name = "cbCopyData";
      this.cbCopyData.Size = new System.Drawing.Size(117, 17);
      this.cbCopyData.TabIndex = 8;
      this.cbCopyData.Text = "Copy Election Data";
      this.cbCopyData.UseVisualStyleBackColor = true;
      this.cbCopyData.CheckedChanged += new System.EventHandler(this.cbCopyData_CheckedChanged);
      // 
      // cbBackup
      // 
      this.cbBackup.AutoSize = true;
      this.cbBackup.Location = new System.Drawing.Point(79, 45);
      this.cbBackup.Name = "cbBackup";
      this.cbBackup.Size = new System.Drawing.Size(124, 17);
      this.cbBackup.TabIndex = 9;
      this.cbBackup.Text = "Backup Source Disk";
      this.cbBackup.UseVisualStyleBackColor = true;
      this.cbBackup.CheckedChanged += new System.EventHandler(this.cbBackup_CheckedChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 71);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(60, 13);
      this.label1.TabIndex = 11;
      this.label1.Text = "Backup Dir";
      // 
      // frmMain
      // 
      this.AcceptButton = this.btnGo;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 280);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtBackupPath);
      this.Controls.Add(this.cbBackup);
      this.Controls.Add(this.cbCopyData);
      this.Controls.Add(this.cbMD5);
      this.Controls.Add(this.lblStatus);
      this.Controls.Add(this.cbLoop);
      this.Controls.Add(this.lblInfo);
      this.Controls.Add(this.lblDirectory);
      this.Controls.Add(this.txtPath);
      this.Controls.Add(this.lblDrive);
      this.Controls.Add(this.cboDrive);
      this.Controls.Add(this.btnGo);
      this.MaximizeBox = false;
      this.MinimumSize = new System.Drawing.Size(300, 216);
      this.Name = "frmMain";
      this.Text = "Elections CF Writer";
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnGo;
    private System.Windows.Forms.ComboBox cboDrive;
    private System.Windows.Forms.Label lblDrive;
    private System.Windows.Forms.TextBox txtPath;
    private System.Windows.Forms.Label lblDirectory;
    private System.Windows.Forms.Label lblInfo;
    private System.Windows.Forms.CheckBox cbLoop;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.CheckBox cbMD5;
    private System.Windows.Forms.ToolTip ToolTip;
    private System.Windows.Forms.FolderBrowserDialog fldBrowse;
    private System.Windows.Forms.CheckBox cbCopyData;
    private System.Windows.Forms.CheckBox cbBackup;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtBackupPath;
  }
}

