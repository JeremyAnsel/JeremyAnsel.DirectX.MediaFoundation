using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;

[Guid(Guid)]
internal unsafe readonly struct IMF2DBuffer
{
    public const string Guid = "7DC9D5F9-9ED9-44ec-9BBF-0600BB589FBB";

    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, uint*, int> Lock2D;
    public readonly delegate* unmanaged[Stdcall]<nint, int> Unlock2D;
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, uint*, int> GetScanline0AndPitch;
    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> IsContiguousFormat;
    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetContiguousLength;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, int> ContiguousCopyTo;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, int> ContiguousCopyFrom;
}
