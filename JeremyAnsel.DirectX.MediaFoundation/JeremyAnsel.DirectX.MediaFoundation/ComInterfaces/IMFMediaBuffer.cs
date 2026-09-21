using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;

[Guid(Guid)]
internal unsafe readonly struct IMFMediaBuffer
{
    public const string Guid = "045FA593-8799-42b8-BC8D-8968C6453507";

    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, uint*, uint*, int> Lock;
    public readonly delegate* unmanaged[Stdcall]<nint, int> Unlock;
    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetCurrentLength;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, int> SetCurrentLength;
    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetMaxLength;
}
