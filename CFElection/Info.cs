using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFElection
{
  // Wrapper object for settings
  public class Info
  {
    private string _drive;
    private string _path;
    private bool _loop;
    private bool _md5;

    public Info()
    {
      // Load up the user settings
      _drive = Properties.Settings.Default.Drive;
      _path = Properties.Settings.Default.Path;
      _loop = Properties.Settings.Default.Loop;
      _md5 = Properties.Settings.Default.Md5;
    }

    public string Drive
    {
      get { return _drive; }
      set { _drive = value; }
    }

    public string Path
    {
      get { return _path; }
      set { _path = value; }
    }

    public bool Loop
    {
      get { return _loop; }
      set { _loop = value; }
    }

    public bool Md5
    {
      get { return _md5; }
      set { _md5 = value; }
    }

    public char DriveLetter
    {
      get { return _drive[0]; }
    }

    public void Zap()
    {
      _drive = "";
      _path = "";
      _loop = false;
      _md5 = false;
    }

    public void Save()
    {
      Properties.Settings.Default.Drive = _drive;
      Properties.Settings.Default.Path = _path;
      Properties.Settings.Default.Loop = _loop;
      Properties.Settings.Default.Md5 = _md5;

      Properties.Settings.Default.Save();
    }
  }
}
