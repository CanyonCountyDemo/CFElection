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
      this.fldBrowse = new System.Windows.Forms.FolderBrowserDialog();
      this.SuspendLayout();
      // 
      // btnGo
      // 
      this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnGo.Enabled = false;
      this.btnGo.Location = new System.Drawing.Point(205, 171);
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
      this.cboDrive.Location = new System.Drawing.Point(66, 12);
      this.cboDrive.Name = "cboDrive";
      this.cboDrive.Size = new System.Drawing.Size(121, 21);
      this.cboDrive.TabIndex = 1;
      this.ToolTip.SetToolTip(this.cboDrive, "Please Select the Compact Flash Drive");
      this.cboDrive.SelectedIndexChanged += new System.EventHandler(this.cboDrive_SelectedIndexChanged);
      // 
      // lblDrive
      // 
      this.lblDrive.AutoSize = true;
      this.lblDrive.Location = new System.Drawing.Point(12, 15);
      this.lblDrive.Name = "lblDrive";
      this.lblDrive.Size = new System.Drawing.Size(48, 13);
      this.lblDrive.TabIndex = 2;
      this.lblDrive.Text = "CF Drive";
      // 
      // txtPath
      // 
      this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPath.Location = new System.Drawing.Point(66, 50);
      this.txtPath.Name = "txtPath";
      this.txtPath.Size = new System.Drawing.Size(214, 20);
      this.txtPath.TabIndex = 2;
      this.ToolTip.SetToolTip(this.txtPath, "Please Enter the Path to copy the ElectionData from");
      this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
      // 
      // lblDirectory
      // 
      this.lblDirectory.AutoSize = true;
      this.lblDirectory.Location = new System.Drawing.Point(14, 53);
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
      this.lblInfo.Location = new System.Drawing.Point(63, 73);
      this.lblInfo.Name = "lblInfo";
      this.lblInfo.Size = new System.Drawing.Size(217, 44);
      this.lblInfo.TabIndex = 5;
      this.lblInfo.Text = "The Root Dir is the directory that contains the  ElectionData Folder NOT the Elec" +
          "tionData folder itself";
      // 
      // cbLoop
      // 
      this.cbLoop.AutoSize = true;
      this.cbLoop.Location = new System.Drawing.Point(66, 121);
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
      this.lblStatus.Location = new System.Drawing.Point(18, 176);
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
      this.cbMD5.Location = new System.Drawing.Point(66, 145);
      this.cbMD5.Name = "cbMD5";
      this.cbMD5.Size = new System.Drawing.Size(102, 17);
      this.cbMD5.TabIndex = 4;
      this.cbMD5.Text = "MD5 Checksum";
      this.ToolTip.SetToolTip(this.cbMD5, "Verifies that the files are copied correctly (it takes a bit longer)");
      this.cbMD5.UseVisualStyleBackColor = true;
      this.cbMD5.CheckedChanged += new System.EventHandler(this.cbMD5_CheckedChanged);
      // 
      // fldBrowse
      // 
      this.fldBrowse.ShowNewFolderButton = false;
      // 
      // frmMain
      // 
      this.AcceptButton = this.btnGo;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 206);
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
  }
}

