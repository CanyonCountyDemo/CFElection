using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CC.Common.Utils
{
  public static partial class Disk
  {
    private static int waitTime = 100;

    public static bool IsReady(char driveLetter)
    {
      DriveInfo info = new DriveInfo(driveLetter.ToString());
      return info.IsReady;
    }

    // Delegate
    public static void WaitForReady(char driveLetter, CheckCancel evt)
    {
      bool cancel = false;
      while (!Disk.IsReady(driveLetter))
      {
        Thread.Sleep(waitTime);
        Application.DoEvents();
        evt(ref cancel);
        if (cancel) break;
      }
    }

    // Interface
    public static void WaitForReady(char driveLetter, ICheckCancel iface)
    {
      bool cancel = false;
      while (!Disk.IsReady(driveLetter))
      {
        Thread.Sleep(waitTime);
        Application.DoEvents();
        iface.CheckCancel(ref cancel);
        if (cancel) break;
      }
    }
  }

  public delegate void CheckCancel(ref bool cancel);

  public interface ICheckCancel
  {
    void CheckCancel(ref bool cancel);
  }
}
