using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;

[Guid(Guid)]
internal unsafe readonly struct IMFSinkWriter
{
    public const string Guid = "3137f1cd-fe5e-4805-a5d8-fb477448cb3d";

    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint*, int> AddStream;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint, nint, int> SetInputMediaType;
    public readonly delegate* unmanaged[Stdcall]<nint, int> BeginWriting;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint, int> WriteSample;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, ulong, int> SendStreamTick;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, void*, int> PlaceMarker;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, int> NotifyEndOfSegment;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, int> Flush;
    public readonly delegate* unmanaged[Stdcall]<nint, int> Finalize;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, Guid*, Guid*, nint*, int> GetServiceForStream;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, void*, int> GetStatistics;
}
