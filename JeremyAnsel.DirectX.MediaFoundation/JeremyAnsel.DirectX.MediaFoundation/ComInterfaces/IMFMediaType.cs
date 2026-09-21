using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;

[Guid(Guid)]
internal unsafe readonly struct IMFMediaType
{
    public const string Guid = "44ae0fa8-ea31-4109-8d2e-4cae4997c555";

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

    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, int> GetMajorType;
    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> IsCompressedFormat;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint*, int> IsEqual;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, void*, int> GetRepresentation;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, void*, int> FreeRepresentation;
}
