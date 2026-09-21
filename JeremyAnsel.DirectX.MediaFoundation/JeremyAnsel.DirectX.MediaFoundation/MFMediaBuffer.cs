using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.MediaFoundation;

/// <summary>
///     The IMFMediaBuffer interface represent a buffer of multimedia data
///     for any possible multimedia type.
///     It provides methods for accessing the buffer pointer, the current
///     length, and the maximum length of the buffer
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class MFMediaBuffer : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid MFMediaBufferGuid = new(IMFMediaBuffer.Guid);

    private readonly nint _comPtr;
    private readonly IMFMediaBuffer* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="MFMediaBuffer"/> class.
    /// </summary>
    public MFMediaBuffer(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IMFMediaBuffer**)comPtr;
    }

    /// <summary>
    ///     The Lock method gives the caller access to the underlying
    ///     buffer pointer and current length of the media buffer.
    /// </summary>
    /// <param name="ppbBuffer">
    ///     Specifies a pointer to a variable where the buffer pointer
    ///     will be stored.
    /// </param>
    /// <param name="pcbMaxLength">
    ///     Pointer to a count of bytes where the maximum length of the
    ///     buffer will be stored.  
    ///     This is the maximum amount of data that can be written to the
    ///     buffer.
    /// </param>
    /// <param name="pcbCurrentLength">
    ///     Pointer to a count of bytes where the current length of the
    ///     buffer will be stored.  
    ///     This is amount of valid data currently in the buffer.
    ///     May be NULL
    /// </param>
    /// <remarks>
    ///     The buffer pointer is guaranteed to be valid for access up to
    ///     the maximum length of the media buffer for the duration of the lock.
    //      When the caller is finished, the Unlock method should be called.
    ///     Note that Unlock must be called the same number of times that
    //      Lock has been called in order to signal completion of the use of
    ///     the buffer pointer.
    ///     It is recommended that the caller lock the media buffer only
    //      for the time necessary to manipulate the buffer contents.
    /// </remarks>
    public void Lock(
        out nint ppbBuffer,
        out uint pcbMaxLength,
        out uint pcbCurrentLength
        )
    {
        nint pbBuffer;
        uint cbMaxLength;
        uint cbCurrentLength;
        Marshal.ThrowExceptionForHR(_comImpl->Lock(_comPtr, &pbBuffer, &cbMaxLength, &cbCurrentLength));
        ppbBuffer = pbBuffer;
        pcbMaxLength = cbMaxLength;
        pcbCurrentLength = cbCurrentLength;
    }

    /// <summary>
    ///     The Unlock method signals completion of the use of the
    ///     buffer pointer acquired via the Lock method.
    /// </summary>
    /// <remarks>
    ///     The buffer pointer acquired via Lock can no longer be used
    ///     once the caller signals completion of that
    ///     usage via the Unlock call.
    ///     Also, note that Unlock must be called the same number of
    ///     times that Lock has been called in order to signal completion
    ///     of the use of the buffer pointer.
    /// </remarks>
    public void Unlock()
    {
        Marshal.ThrowExceptionForHR(_comImpl->Unlock(_comPtr));
    }

    /// <summary>
    ///     The GetCurrentLength method returns the current length of the
    ///     media buffer.
    /// </summary>
    /// <param name="pcbCurrentLength">
    ///     Pointer to a count of bytes where the current length of the
    ///     buffer will be stored.
    /// </param>
    /// <remarks>
    ///     A returned value of zero bytes indicates a media buffer with
    ///     no valid data (an empty buffer).
    /// </remarks>
    public uint GetCurrentLength()
    {
        uint value;
        Marshal.ThrowExceptionForHR(_comImpl->GetCurrentLength(_comPtr, &value));
        return value;
    }

    /// <summary>
    ///     The SetCurrentLength method allows the caller to set the current
    ///     length of the media buffer.
    /// </summary>
    /// <param name="cbCurrentLength">
    ///     Current length of the media buffer in bytes.
    /// </param>
    /// <remarks>
    ///     This method should be used anytime a client modifies the content
    ///     of the media buffer in such a way that
    ///     the length of valid data in the media buffer changes.
    /// </remarks>
    public void SetCurrentLength(uint cbCurrentLength)
    {
        Marshal.ThrowExceptionForHR(_comImpl->SetCurrentLength(_comPtr, cbCurrentLength));
    }

    /// <summary>
    ///     The GetMaxLength method allows the caller to retrieve the maximum
    ///     length of the buffer represented by the IMFMediaBuffer object.
    /// </summary>
    /// <param name="pcbMaxLength">
    ///     Pointer to a count of bytes where the maximum length of the
    ///     buffer will be stored.
    /// </param>
    public uint GetMaxLength()
    {
        uint value;
        Marshal.ThrowExceptionForHR(_comImpl->GetMaxLength(_comPtr, &value));
        return value;
    }

    public MF2DBuffer? AsMF2DBuffer()
    {
        nint ptr = QueryInterface(MF2DBuffer.MF2DBufferGuid);
        return ptr == 0 ? null : new MF2DBuffer(ptr);
    }
}
