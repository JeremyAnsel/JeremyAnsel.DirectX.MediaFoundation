using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;

[Guid(Guid)]
internal unsafe readonly struct IMFAttributes
{
    public const string Guid = "2cd2d921-c447-44a7-a13c-4adabfc247e3";

    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, void*, int> GetItem;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, int*, int> GetItemType;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, void*, int*, int> CompareItem;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int, int*, int> Compare;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, uint*, int> GetUINT32;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, ulong*, int> GetUINT64;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, double*, int> GetDouble;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, Guid*, int> GetGUID;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, uint*, int> GetStringLength;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, char*, uint, uint*, int> GetString;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, char**, uint*, int> GetAllocatedString; // returned string must be deallocated with CoTaskMemFree
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, uint*, int> GetBlobSize;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, byte*, uint, uint*, int> GetBlob;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, byte**, uint*, int> GetAllocatedBlob; // returned blob must be deallocated with CoTaskMemFree
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, Guid*, nint*, int> GetUnknown;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, void*, int> SetItem;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, int> DeleteItem;
    public readonly delegate* unmanaged[Stdcall]<nint, int> DeleteAllItems;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, uint, int> SetUINT32;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, ulong, int> SetUINT64;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, double, int> SetDouble;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, Guid*, int> SetGUID;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, char*, int> SetString;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, byte*, uint, int> SetBlob;
    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, nint, int> SetUnknown;
    public readonly delegate* unmanaged[Stdcall]<nint, int> LockStore;
    public readonly delegate* unmanaged[Stdcall]<nint, int> UnlockStore;
    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetCount;
    public readonly delegate* unmanaged[Stdcall]<nint, uint, Guid*, void*, int> GetItemByIndex; // can be NULL. If not NULL, when done must use PropVariantClear() to free
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> CopyAllItems;
}
