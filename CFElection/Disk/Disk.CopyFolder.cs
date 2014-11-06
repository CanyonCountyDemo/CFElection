using System;
using System.IO;
using System.Security.Cryptography;

namespace CC.Common.Utils
{
  // Partial class - Handles copying a directory with MD5 checksum
  public static partial class Disk
  {
    public static void CopyFolder(string sourceFolder, string destFolder)
    {
      CopyFolder(sourceFolder, destFolder, false);
    }

    public static void CopyFolder(string sourceFolder, string destFolder, bool md5)
    {
      if (!Directory.Exists(destFolder))
        Directory.CreateDirectory(destFolder);
      string[] files = Directory.GetFiles(sourceFolder);
      foreach (string file in files)
      {
        string name = Path.GetFileName(file);
        string dest = Path.Combine(destFolder, name);
        File.Copy(file, dest);
        if (md5)
        {
          string f1 = GetMd5(file);
          string f2 = GetMd5(dest);
          if (!f1.Equals(f2))
            throw new Exception(String.Format("Copy file {0} to {1} failed", file, dest));
        }
      }
      string[] folders = Directory.GetDirectories(sourceFolder);
      foreach (string folder in folders)
      {
        string name = Path.GetFileName(folder);
        string dest = Path.Combine(destFolder, name);
        CopyFolder(folder, dest, md5);
      }
    }

    public static string GetMd5(string fileName)
    {
      using (MD5 md5 = new MD5CryptoServiceProvider())
      {
        using (FileStream file = new FileStream(fileName, FileMode.Open))
        {
          byte[] retVal = md5.ComputeHash(file);
          return BitConverter.ToString(retVal);//.Replace("-", ""); // hex string
        }
      }
    }

  }
}
