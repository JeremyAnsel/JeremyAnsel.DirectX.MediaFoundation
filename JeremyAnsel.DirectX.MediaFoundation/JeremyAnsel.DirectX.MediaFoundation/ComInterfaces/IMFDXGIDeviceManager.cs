using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;

[Guid(Guid)]
internal unsafe readonly struct IMFDXGIDeviceManager
{
    public const string Guid = "eb533d5d-2db6-40f8-97a9-494692014f07";

    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> CloseDeviceHandle;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, Guid*, nint*, int> GetVideoService;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, Guid*, nint*, uint, int> LockDevice;
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> OpenDeviceHandle;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, int> ResetDevice;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> TestDevice;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, int> UnlockDevice;
}
