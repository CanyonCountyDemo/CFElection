using System;
using System.Collections;
using System.IO;

namespace CC.Common.Utils
{
  public static partial class Disk
  {
    public static String[] GetDrives(DiskType opt)
    {
      ArrayList ret = new ArrayList(26); // only 26 drives - lol
      DriveInfo[] drives = DriveInfo.GetDrives();

      foreach (DriveInfo drive in drives)
      {
        if ((opt & DiskType.All) == DiskType.All)
        {
          ret.Add(drive.ToString());
        }
        else
        {
          if ((opt & DiskType.CDRom) == DiskType.CDRom)
            if (drive.DriveType == DriveType.CDRom)
              ret.Add(drive.ToString());

          if ((opt & DiskType.Fixed) == DiskType.Fixed)
            if (drive.DriveType == DriveType.Fixed)
              ret.Add(drive.ToString());

          if ((opt & DiskType.Network) == DiskType.Network)
            if (drive.DriveType == DriveType.Network)
              ret.Add(drive.ToString());

          if ((opt & DiskType.NoRootDirectory) == DiskType.NoRootDirectory)
            if (drive.DriveType == DriveType.NoRootDirectory)
              ret.Add(drive.ToString());

          if ((opt & DiskType.Ram) == DiskType.Ram)
            if (drive.DriveType == DriveType.Ram)
              ret.Add(drive.ToString());

          if ((opt & DiskType.Removable) == DiskType.Removable)
            if (drive.DriveType == DriveType.Removable)
              ret.Add(drive.ToString());

          if ((opt & DiskType.Unknown) == DiskType.Unknown)
            if (drive.DriveType == DriveType.Unknown)
              ret.Add(drive.ToString());
        }
      }

      ret.Sort();
      return (string[])ret.ToArray(typeof(string));
    }

    public static bool IsType(char driveLetter, DiskType opt)
    {
      DriveInfo info = new DriveInfo(driveLetter.ToString());
      DriveType type = DriveType.Unknown;
      bool ret = true;
      switch (opt)
      {
        case DiskType.Unknown:
          type = DriveType.Unknown;
          break;
        case DiskType.NoRootDirectory:
          type = DriveType.NoRootDirectory;
          break;
        case DiskType.Removable:
          type = DriveType.Removable;
          break;
        case DiskType.Fixed:
          type = DriveType.Fixed;
          break;
        case DiskType.Network:
          type = DriveType.Network;
          break;
        case DiskType.CDRom:
          type = DriveType.CDRom;
          break;
        case DiskType.Ram:
          type = DriveType.Ram;
          break;
      }

      if (opt == DiskType.All)
        ret = true; // If they don't care what type, nor do I
      else
        ret = info.DriveType == type;
      return ret;
    }

    public static bool Exists(char driveLetter)
    {
      DriveInfo[] drives = DriveInfo.GetDrives();
      bool ret = false;
      foreach (DriveInfo drive in drives)
      {
        if (drive.RootDirectory.Name.ToLower()[0] == Char.ToLower(driveLetter))
        {
          ret = true;
          break;
        }
      }

      return ret;
    }
  }
  
  // The DriveType Attribute doesn't include ALL
  [FlagsAttribute]
  public enum DiskType
  {
    // Summary:
    //     The type of drive is unknown.
    Unknown = 0,
    //
    // Summary:
    //     The drive does not have a root directory.
    NoRootDirectory = 2,
    //
    // Summary:
    //     The drive is a removable storage device, such as a floppy disk drive or a
    //     USB flash drive.
    Removable = 4,
    //
    // Summary:
    //     The drive is a fixed disk.
    Fixed = 8,
    //
    // Summary:
    //     The drive is a network drive.
    Network = 16,
    //
    // Summary:
    //     The drive is an optical disc device, such as a CD or DVD-ROM.
    CDRom = 32,
    //
    // Summary:
    //     The drive is a RAM disk.
    Ram = 64,
    //
    // Summary:
    //     The drive exists in some fashon.
    All = 128,
  }
}
