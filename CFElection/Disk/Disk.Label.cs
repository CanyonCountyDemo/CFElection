using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CC.Common.Utils
{
  public static partial class Disk
  {
    public static string GetVolumeLabel(char driveLetter)
    {
      string ret = "";
      DriveInfo info = new DriveInfo(driveLetter.ToString());
      if (info.IsReady)
        ret = info.VolumeLabel;
      return ret;
    }
  }
}
