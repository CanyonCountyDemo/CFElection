using System;
using System.Runtime.InteropServices;

namespace CFElection
{
  // Partial Class - handles formating a disk - only checked on a CF drive with FAT
  public static partial class Disk
  {
    [DllImport("shell32.dll")]
    static extern uint SHFormatDrive(IntPtr hwnd, uint drive, uint fmtID,
       uint options);

    public enum SHFormatFlags : uint
    {
      SHFMT_ID_DEFAULT = 0xFFFF,
      SHFMT_OPT_FULL = 0x1,
      SHFMT_OPT_SYSONLY = 0x2,
      SHFMT_ERROR = 0xFFFFFFFF,
      SHFMT_CANCEL = 0xFFFFFFFE,
      SHFMT_NOFORMAT = 0xFFFFFFD,
    }

    public static string _drives = "abcdefghijklmnopqrstuvwxyz";

    public static bool Format(char driveLetter)
    {
      bool ret = true;
      // redicerous! char can't be converted toLower by default!!@!@!???
      //string tmp = driveLetter.ToString();
      //driveLetter = tmp.ToLower()[0];
      int drive = _drives.IndexOf(Char.ToLower(driveLetter));
      uint result = SHFormatDrive(IntPtr.Zero, //this.Handle,
              (uint)drive, // formatting drive:
              (uint)SHFormatFlags.SHFMT_ID_DEFAULT,
              0); // full format of drive:

      if (result == (uint)SHFormatFlags.SHFMT_ERROR) ret = false;
      if (result == (uint)SHFormatFlags.SHFMT_CANCEL) ret = false;
      if (result == (uint)SHFormatFlags.SHFMT_NOFORMAT) ret = false;

      return ret;
    }

  }
}
