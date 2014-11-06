namespace CFElection
{
  // Wrapper object for settings
  public class Info
  {
    private string _drive;
    private string _path;
    private bool _loop;
    private bool _md5;
    private bool _copy;
    private bool _backup;
    private string _backupPath;

    public Info()
    {
      // Load up the user settings
      _drive = Properties.Settings.Default.Drive;
      _path = Properties.Settings.Default.Path;
      _loop = Properties.Settings.Default.Loop;
      _md5 = Properties.Settings.Default.Md5;
      _copy = Properties.Settings.Default.Copy;
      _backup = Properties.Settings.Default.Backup;
      _backupPath = Properties.Settings.Default.BackupPath;
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

    public string BackupPath
    {
      get { return _backupPath; }
      set { _backupPath = value; }
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

    public bool Copy
    {
      get { return _copy; }
      set { _copy = value; }
    }

    public bool Backup
    {
      get { return _backup; }
      set { _backup = value; }
    }

    public char DriveLetter
    {
      get { return _drive[0]; }
    }

    public void Zap()
    {
      _drive = "";
      _path = "";
      _backupPath = "";
      _loop = false;
      _md5 = false;
      _copy = false;
      _backup = false;
    }

    public void Save()
    {
      Properties.Settings.Default.Drive = _drive;
      Properties.Settings.Default.Path = _path;
      Properties.Settings.Default.Loop = _loop;
      Properties.Settings.Default.Md5 = _md5;
      Properties.Settings.Default.Copy = _copy;
      Properties.Settings.Default.Backup = _backup;
      Properties.Settings.Default.BackupPath = _backupPath;

      Properties.Settings.Default.Save();
    }
  }
}
