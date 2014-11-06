using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CC.Common.Utils;

namespace CFElection
{
  public partial class frmMain : Form, ICheckCancel
  {
    private Info info;
    private Font baseFont;
    private bool _cancel;

    public frmMain()
    {
      InitializeComponent();
      info = new Info();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      cboDrive.Items.AddRange(Disk.GetDrives(DiskType.Removable));

      txtPath.Text = info.Path;
      cboDrive.SelectedItem = info.Drive;
      cbLoop.Checked = info.Loop;
      cbMD5.Checked = info.Md5;
      cbCopyData.Checked = info.Copy;
      cbBackup.Checked = info.Backup;
      txtBackupPath.Text = info.BackupPath;

      SetStatus("");
      timer.Enabled = true;
      baseFont = lblDirectory.Font;
    }

    private void btnGo_Click(object sender, EventArgs e)
    {
      btnGo.Enabled = false;
      // This is now handled by the timer
      //if (info.Loop)
      //{
      //  bool ret = true;
      //  while (ret)
      //  {
      //    ret = CopyData();
      //    //if (ret)
      //    //{
      //    //  DialogResult res = MessageBox.Show(this, "Enter a disk in Drive " + info.DriveLetter, "New Disk", MessageBoxButtons.OKCancel);
      //    //  ret = res != DialogResult.Cancel;
      //    //}
      //  }
      //}
      //else
      {
        CopyData();
      }
      btnGo.Enabled = true;
    }

    private void cboDrive_SelectedIndexChanged(object sender, EventArgs e)
    {
      info.Drive = (string)cboDrive.SelectedItem;
      CheckGo();
    }

    private void txtPath_TextChanged(object sender, EventArgs e)
    {
      info.Path = txtPath.Text;
      CheckGo();
    }

    private void cbLoop_CheckedChanged(object sender, EventArgs e)
    {
      // Don't need or care for the CheckGo here
      info.Loop = cbLoop.Checked;
      // This flag is not needed with a working CheckGo() method
      //_cancel = !cbLoop.Checked; // Cancel if WaitForReady is active
    }
    
    private void cbMD5_CheckedChanged(object sender, EventArgs e)
    {
      // Don't need or care for the CheckGo here
      info.Md5 = cbMD5.Checked;
    }

    private void cbCopyData_CheckedChanged(object sender, EventArgs e)
    {
      info.Copy = cbCopyData.Checked;
      CheckGo();
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      //info.Zap(); // Clears any settings / revert to defaults / used for testing
      info.Save();
      // With this flag missing the app will not close quickly if it's waiting for a drive
      _cancel = true;
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      timer.Enabled = false;
      CheckGo();
      if (cbLoop.Checked)
        if (btnGo.Enabled)
          btnGo_Click(null, null);

      timer.Enabled = true;
    }
    
    private void lblDirectory_MouseEnter(object sender, EventArgs e)
    {
      this.Cursor = Cursors.Hand;
      lblDirectory.Font = new Font(baseFont, baseFont.Style | FontStyle.Underline);
      lblDirectory.ForeColor = SystemColors.Highlight;
    }

    private void lblDirectory_MouseLeave(object sender, EventArgs e)
    {
      this.Cursor = Cursors.Default;
      lblDirectory.Font = new Font(baseFont, baseFont.Style);
      lblDirectory.ForeColor = SystemColors.ControlText;
    }

    private void lblDirectory_MouseUp(object sender, MouseEventArgs e)
    {
      fldBrowse.SelectedPath = txtPath.Text;
      if (fldBrowse.ShowDialog() == DialogResult.OK)
        txtPath.Text = fldBrowse.SelectedPath;
    }

    // Methods

    private void CheckGo()
    {
      // Make sure the Go Button Can be enabled
      int err = 0;

      // Check for a valid disk
      if (info.DriveLetter != '\0')
      {
        if (!Disk.IsReady(info.DriveLetter)) err++;
      }
      if (_cancel) err++;
      if (cbCopyData.Checked)
      {
        try
        {
          string[] dirs = Directory.GetDirectories(info.Path);
          //if (!dirs.Contains("ElectionData")) err++;
          err++;
          foreach (String dir in dirs)
          {
            if (dir.Contains("ElectionData")) err--;
          }
        }
        catch
        {
          err++;
        }
      }

      if (cbBackup.Checked)
      {
        if (!Directory.Exists(txtBackupPath.Text)) err++;
      }

      txtPath.Enabled = info.Copy;
      cbMD5.Enabled = info.Copy || info.Backup;
      txtBackupPath.Enabled = info.Backup;

      btnGo.Enabled = err == 0;
    }

    private bool CopyData()
    {
      SetStatus("Waiting for Disk");
      bool ret = false;
      
      // Dubious loop - woot!
      //while (!Disk.IsReady(info.DriveLetter))
      //{
      //  Thread.Sleep(1000);
      //  Application.DoEvents();
      //}

      // Delegate
      //Disk.WaitForReady(info.DriveLetter, CheckCancel);
      // Interface
      Disk.WaitForReady(info.DriveLetter, this);

      // Check to see if the user canceled
      if (_cancel)
      {
        SetStatus("");
        return false;
      }
      // Backup the disk first
      if (info.Backup)
      {
        string path = info.BackupPath + Path.DirectorySeparatorChar + GetDiskInfo(info.DriveLetter);
        string[] files = Directory.GetFiles(info.Drive);
        if (files.Length > 1) // .electinfo is 1
        {
          Directory.CreateDirectory(path.Trim());
          SetStatus("Backing up Disk");
          Disk.CopyFolder(info.Drive, path, info.Md5);
        }
      }

      SetStatus("Formatting Disk");

      if (Disk.Format(info.DriveLetter, true))
      {
        if (cbCopyData.Checked)
        {
          SetStatus("Copying ElectionData");
          try
          {
            Disk.CopyFolder(info.Path, info.Drive, info.Md5);
          }
          catch (Exception e)
          {
            MessageBox.Show(e.Message + "\n\nYou should replace this Compact Flash Card");
            //CopyData();
          }
        }
        SetStatus("Ejecting Disk");
        Disk.Eject(info.Drive);
        SetStatus("Done");
        ret = true;
      }
      else
      {
        // They canceled or an error remove the automagic
        cbLoop.Checked = false;
        SetStatus("");
      }
      return ret;
    }

    private void InputBox_Validating(object sender, InputBoxValidatingArgs e)
    {
      if (e.Text.Trim().Length == 0)
      {
        e.Cancel = true;
        e.Message = "You must enter a directory name for this disk";
      }
      if (Directory.Exists(info.BackupPath + Path.DirectorySeparatorChar + e.Text))
      {
        e.Cancel = true;
        e.Message = "Name already exists, enter a different one";
      }
    }

    private string GetDiskInfo(char driveLetter)
    {
      string ret = "";
      string file = driveLetter.ToString() + @":\.electinfo";
      if (File.Exists(file))
      {
        TextReader tr = new StreamReader(file);
        ret = tr.ReadToEnd().Trim();
        tr.Close();
      }
      
      if (String.IsNullOrEmpty(ret))
      {
        ret = Disk.GetVolumeLabel(driveLetter);
      }

      if (String.IsNullOrEmpty(ret))
      {
        InputBoxResult res = InputBox.Show("No Disk Info found\n\nPlease enter a name", 
          "No Disk Info", "default", new InputBoxValidatingHandler(InputBox_Validating));
        if (res.OK)
          ret = res.Text;
      }

      if (ret.Equals("BD")) ret = "Ballot Definition";
      if (ret.StartsWith("LC"))
      {
        string[] d = ret.Split(' ');
        ret = "L & A County " + d[1];
      }
      if (ret.StartsWith("LS"))
      {
        string[] d = ret.Split(' ');
        ret = "L & A State " + d[1];
      }
      return ret;
    }

    private void SetStatus(string status)
    {
      lblStatus.Text = status;
      Application.DoEvents();
    }

    // For an interface this has to be public
    // using it as a delegate it can be private
    public void CheckCancel(ref bool cancel)
    {
      cancel = _cancel;
    }

    private void cbBackup_CheckedChanged(object sender, EventArgs e)
    {
      info.Backup = cbBackup.Checked;
      CheckGo();
    }

    private void txtBackupPath_TextChanged(object sender, EventArgs e)
    {
      info.BackupPath = txtBackupPath.Text;
      CheckGo();
    }

  }
}
