using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;

[Guid(Guid)]
internal unsafe readonly struct IMFSourceReader
{
    public const string Guid = "70ae66f2-c809-4e4f-8915-bdcb406b7993";

    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint*, int> GetStreamSelection;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, int> SetStreamSelection;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, int> GetNativeMediaType;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, int> GetCurrentMediaType;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint*, nint, int> SetCurrentMediaType;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, void*, int> SetCurrentPosition;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, uint*, uint*, ulong*, nint*, int> ReadSample;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, int> Flush;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, Guid*, Guid*, nint*, int> GetServiceForStream;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, Guid*, void*, int> GetPresentationAttribute;
}
