using System;
using System.Runtime.InteropServices;

namespace CC.Common.Utils
{
  // Partial Class - handles formating a disk - only checked on a CF drive with FAT
  public static partial class Disk
  {
    [DllImport("shell32.dll")]
    static extern uint SHFormatDrive(IntPtr hwnd, uint drive, uint fmtID,
       uint options);

    private enum SHFormatFlags : uint
    {
      SHFMT_ID_DEFAULT = 0xFFFF, // Default format (fat16, etc)
      SHFMT_OPT_FULL = 0x1,
      SHFMT_OPT_SYSONLY = 0x2,
      SHFMT_ERROR = 0xFFFFFFFF,
      SHFMT_CANCEL = 0xFFFFFFFE,
      SHFMT_NOFORMAT = 0xFFFFFFD,
    }

    private static string _drives = "abcdefghijklmnopqrstuvwxyz";

    public static bool Format(char driveLetter, bool quickFormat)
    {
      bool ret = true;
      // redicerous! char can't be converted toLower by default!!@!@!???
      //string tmp = driveLetter.ToString();
      //driveLetter = tmp.ToLower()[0];
      uint format = 0;
      if (quickFormat) format = 1;
      int drive = _drives.IndexOf(Char.ToLower(driveLetter));
      uint result = SHFormatDrive(IntPtr.Zero, //this.Handle,
              (uint)drive, // formatting drive:
              (uint)SHFormatFlags.SHFMT_ID_DEFAULT,
              format); // full format of drive: 0 // Quick 1

      if (result == (uint)SHFormatFlags.SHFMT_ERROR) ret = false;
      if (result == (uint)SHFormatFlags.SHFMT_CANCEL) ret = false;
      if (result == (uint)SHFormatFlags.SHFMT_NOFORMAT) ret = false;

      return ret;
    }

  }
}
