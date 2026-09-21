using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;

[Guid(Guid)]
internal unsafe readonly struct IMFSample
{
    public const string Guid = "c40a00f2-b93a-4d80-ae8c-5a1c634f58e4";

    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetItem;
    private readonly nint GetItemType;
    private readonly nint CompareItem;
    private readonly nint Compare;
    private readonly nint GetUINT32;
    private readonly nint GetUINT64;
    private readonly nint GetDouble;
    private readonly nint GetGUID;
    private readonly nint GetStringLength;
    private readonly nint GetString;
    private readonly nint GetAllocatedString;
    private readonly nint GetBlobSize;
    private readonly nint GetBlob;
    private readonly nint GetAllocatedBlob;
    private readonly nint GetUnknown;
    private readonly nint SetItem;
    private readonly nint DeleteItem;
    private readonly nint DeleteAllItems;
    private readonly nint SetUINT32;
    private readonly nint SetUINT64;
    private readonly nint SetDouble;
    private readonly nint SetGUID;
    private readonly nint SetString;
    private readonly nint SetBlob;
    private readonly nint SetUnknown;
    private readonly nint LockStore;
    private readonly nint UnlockStore;
    private readonly nint GetCount;
    private readonly nint GetItemByIndex;
    private readonly nint CopyAllItems;

    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetSampleFlags;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, int> SetSampleFlags;
    public readonly delegate* unmanaged[Stdcall]<nint, ulong*, int> GetSampleTime;
    public readonly delegate* unmanaged[Stdcall]<nint, ulong, int> SetSampleTime;
    public readonly delegate* unmanaged[Stdcall]<nint, ulong*, int> GetSampleDuration;
    public readonly delegate* unmanaged[Stdcall]<nint, ulong, int> SetSampleDuration;
    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetBufferCount;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, int> GetBufferByIndex;
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> ConvertToContiguousBuffer;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> AddBuffer;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, int> RemoveBufferByIndex;
    public readonly delegate* unmanaged[Stdcall]<nint, int> RemoveAllBuffers;
    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetTotalLength;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> CopyToBuffer;
}
