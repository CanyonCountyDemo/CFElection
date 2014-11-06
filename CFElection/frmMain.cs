using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CFElection
{
  public partial class frmMain : Form
  {
    private Info info;
    private Font baseFont;

    public frmMain()
    {
      InitializeComponent();
      info = new Info();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      DriveInfo[] drives = DriveInfo.GetDrives();
      foreach (DriveInfo drive in drives)
      {
        if (drive.DriveType == DriveType.Removable)
          cboDrive.Items.Add(drive.ToString());
      }

      txtPath.Text = info.Path;
      cboDrive.SelectedItem = info.Drive;
      cbLoop.Checked = info.Loop;
      cbMD5.Checked = info.Md5;

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
    }
    
    private void cbMD5_CheckedChanged(object sender, EventArgs e)
    {
      // Don't need or care for the CheckGo here
      info.Md5 = cbMD5.Checked;
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      //info.Zap(); // Clears any settings / revert to defaults / used for testing
      info.Save();
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
      try
      {
        DriveInfo drive = new DriveInfo(info.Drive);
        if (!drive.IsReady) err++;

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

      btnGo.Enabled = err == 0;
    }

    private bool CopyData()
    {
      SetStatus("Formatting Disk");
      bool ret = false;
      if (Disk.Format(info.DriveLetter))
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

    private void SetStatus(string status)
    {
      lblStatus.Text = status;
      Application.DoEvents();
    }

  }
}
