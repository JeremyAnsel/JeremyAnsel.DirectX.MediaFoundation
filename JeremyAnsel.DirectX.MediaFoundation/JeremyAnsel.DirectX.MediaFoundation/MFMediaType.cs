using JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.MediaFoundation;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class MFMediaType : MFAttributes
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid MFMediaTypeGuid = new(IMFMediaType.Guid);

    private readonly nint _comPtr;
    private readonly IMFMediaType* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="MFMediaType"/> class.
    /// </summary>
    public MFMediaType(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IMFMediaType**)comPtr;
    }

    public Guid GetMajorType()
    {
        Guid value;
        Marshal.ThrowExceptionForHR(_comImpl->GetMajorType(_comPtr, &value));
        return value;
    }

    public bool IsCompressedFormat()
    {
        uint value;
        Marshal.ThrowExceptionForHR(_comImpl->IsCompressedFormat(_comPtr, &value));
        return value != 0;
    }
}
