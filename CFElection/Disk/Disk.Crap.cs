using System.ComponentModel;

namespace CC.Common.Utils
{
  public static partial class Disk
  {
    // .NET is lovely except for when it sucks
    // A static class CAN NEVER be instantiated
    // therefore you can NEVER use Equals or ReferenceEquals
    // yet they show up in intellesense and you can't do anything with them
    // O' joy! - kwilcox 7-28-2010

    //[EditorBrowsable(EditorBrowsableState.Never)]
    //public override bool Equals(object obj)
    //{
    //  return false;// base.Equals(obj);
    //}

    //[EditorBrowsable(EditorBrowsableState.Never)]
    //public static new int GetHashCode()
    //{
    //  return 0;// base.GetHashCode();
    //}

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static new bool ReferenceEquals(object objA, object objB)
    {
      return object.ReferenceEquals(objA, objB);
    }
  }
}
