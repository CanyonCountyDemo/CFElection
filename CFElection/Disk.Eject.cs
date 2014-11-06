using System;
using System.Threading;
using System.Runtime.InteropServices;

namespace CFElection
{
  // Partial Class - handles ejecting a disk - only tested on a CF Drive
  public static partial class Disk
  {
    private const int INVALID_HANDLE_VALUE = -1;
    private const int GENERIC_READ = unchecked((int)0x80000000);
    private const int GENERIC_WRITE = unchecked((int)0x40000000);
    private const int FILE_SHARE_READ = unchecked((int)0x00000001);
    private const int FILE_SHARE_WRITE = unchecked((int)0x00000002);
    private const int OPEN_EXISTING = unchecked((int)3);
    private const int FSCTL_LOCK_VOLUME = unchecked((int)0x00090018);
    private const int FSCTL_DISMOUNT_VOLUME = unchecked((int)0x00090020);
    private const int IOCTL_STORAGE_EJECT_MEDIA = unchecked((int)0x002D4808);
    private const int IOCTL_STORAGE_MEDIA_REMOVAL = unchecked((int)0x002D4804);

    [DllImport("kernel32.dll", EntryPoint = "CreateFileW", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern IntPtr CreateFile(
      string lpFileName,
      int dwDesiredAccess,
      int dwShareMode,
      IntPtr lpSecurityAttributes,
      int dwCreationDisposition,
      int dwFlagsAndAttributes,
      IntPtr hTemplateFile);

    [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
    private static extern bool CloseHandle(IntPtr handle);

    [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
    private static extern bool DeviceIoControl(
      IntPtr hDevice,
      int dwIoControlCode,
      byte[] lpInBuffer,
      int nInBufferSize,
      byte[] lpOutBuffer,
      int nOutBufferSize,
      out int lpBytesReturned,
      IntPtr lpOverlapped);

    public static bool Eject(string disk)
    {
      string sPhysicalDrive = disk.Trim('\\');
      bool ok = false;
      bool DiskEjected = false;
      // Step 1: Volume open
      IntPtr h = CreateFile(@"\\.\" + sPhysicalDrive, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
      if (h.ToInt32() == -1)
        return false;

      while (true)
      {
        // Step 2: Volume locked
        for (int i = 0; i < 10; i++)
        {
          int nout = 0;
          ok = DeviceIoControl(h, FSCTL_LOCK_VOLUME,
          null, 0, null, 0, out nout, IntPtr.Zero);
          if (ok)
            break;
          Thread.Sleep(500);
        }

        if (!ok)
          break;

        // Step 3: Volume unmount
        int xout = 0;
        ok = DeviceIoControl(h, FSCTL_DISMOUNT_VOLUME, null, 0, null, 0, out xout, IntPtr.Zero);
        if (!ok)
          break;
        // From here the disk can be removed
        // without loss of data
        DiskEjected = true;
        // Step 4: Prevent Removal Of Volume
        byte[] flg = new byte[1];
        flg[0] = 0; // 0 = false
        int yout = 0;
        ok = DeviceIoControl(h, IOCTL_STORAGE_MEDIA_REMOVAL, flg, 1, null, 0, out yout, IntPtr.Zero);
        if (!ok)
          break;
        // Step 5: Eject Media
        ok = DeviceIoControl(h, IOCTL_STORAGE_EJECT_MEDIA, null, 0, null, 0, out xout, IntPtr.Zero);
        break;
      }
      // Step 6: Close Handle
      ok = CloseHandle(h);
      return DiskEjected;
    }
  }
}
