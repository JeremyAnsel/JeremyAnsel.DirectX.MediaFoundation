using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.MediaFoundation;

/// <summary>
///     The IMF2DBuffer interface is supported by a media buffer whose multimedia data represents a 2D media type e.g. video.
///     For these media types it is important to know the "pitch" of the buffer which indicates the number of bytes required to go from
///     scanline to scanline.  The IMF2DBuffer interface is obtained from a buffer by calling QueryInterface().
///     For each 2D media type a contiguous standard representation is defined which is designed to be compatible with the standard
///     layout of a DirectX surface when represented by system memory.  In this representation the surface pitch is always positive and
///     equal to the number of bytes taken up by a single row of pixels padded out to a 4-byte boundary.
///
///     Applications may still access 2D buffers using IMFBuffer::Lock().  In that case the data in the buffer will always be in the
///     standard contiguous format for the format of data represented by the buffer.  An internal copy may be required on IMFBuffer::Lock()
///     and IMFBuffer::Unlock() to achieve this.  The copy will not occur if the buffer is already in the correct format.  When a copy occurs an
///     event will be generated to aid debugging performance issues resulting from the copy.  Components that process 2D data should aim to
///     use the IMF2DBuffer interface to access sample data.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class MF2DBuffer : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid MF2DBufferGuid = new(IMF2DBuffer.Guid);

    private readonly nint _comPtr;
    private readonly IMF2DBuffer* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="MF2DBuffer"/> class.
    /// </summary>
    public MF2DBuffer(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IMF2DBuffer**)comPtr;
    }

    /// <summary>
    ///     The Lock2D method ensures the buffer memory is accessible in the correct format and returns a pointer to
    ///     the start of the first line and the pitch of the buffer.  Each call to Lock2D must be matched by a corresponding call to Unlock2D.
    ///     The memory pointer and pitch value are only valid while there is at least one outstanding Lock2D call with an unmactched Unlock2D call.
    /// </summary>
    /// <param name="ppbScanline0">
    ///     Pointer to a byte ponter where the pointer to the first byte of the top row of the buffer will be stored
    /// </param>
    /// <param name="plPitch">
    ///     Pointer to a count of bytes where the pitch of the buffer will be stored.  This value can be added to a pointer to the
    ///     start of a given row of the buffer to get the pointer to the start of the next row of the buffer.
    /// </param>
    public void Lock2D(out nint ppbScanline0, out uint plPitch)
    {
        nint pbScanline0;
        uint lPitch;
        Marshal.ThrowExceptionForHR(_comImpl->Lock2D(_comPtr, &pbScanline0, &lPitch));
        ppbScanline0 = pbScanline0;
        plPitch = lPitch;
    }

    /// <summary>
    ///     The Unlock2D method unlocks the buffer.  Each call to Lock2D must be matched by a call to Unlock2D.
    ///     When there are no more outstanding Unlocks all existing pointers to the buffer and pitch values should be considered invalid.
    /// </summary>
    public void Unlock2D()
    {
        Marshal.ThrowExceptionForHR(_comImpl->Unlock2D(_comPtr));
    }

    /// <summary>
    ///     The GetScanline0AndPitch returns a pointer to the start of the first line and the pitch of the buffer.
    ///     The memory pointer and pitch value are only valid while there is at least one outstanding Lock call with an unmactched Unlock call.
    /// </summary>
    /// <param name="pbScanline0">
    ///     Pointer to a byte ponter where the pointer to the first byte of the top row of the buffer will be stored
    /// </param>
    /// <param name="plPitch">
    ///     Pointer to a count of bytes where the pitch of the buffer will be stored.  This value can be added to a pointer to the
    ///     start of a given row of the buffer to get the pointer to the start of the next row of the buffer.
    /// </param>
    public void GetScanline0AndPitch(out nint pbScanline0, out uint plPitch)
    {
        nint bScanline0;
        uint lPitch;
        Marshal.ThrowExceptionForHR(_comImpl->GetScanline0AndPitch(_comPtr, &bScanline0, &lPitch));
        pbScanline0 = bScanline0;
        plPitch = lPitch;
    }

    /// <summary>
    ///     The IsContignousFormat method returns a BOOL value which is TRUE if the buffer is in contiguous format and FALSE if it is not in contiguous format.
    /// </summary>
    /// <param name="pfIsContiguous">
    ///     Pointer to where the BOOL value saying whether the buffer is in contiguous format will be stored.
    /// </param>
    public bool IsContiguousFormat()
    {
        uint value;
        Marshal.ThrowExceptionForHR(_comImpl->IsContiguousFormat(_comPtr, &value));
        return value != 0;
    }

    /// <summary>
    ///     The GetContiguousLength method returns the number of bytes required store the buffer contents in contiguous format.
    /// </summary>
    /// <param name="pcbLength">
    ///     Pointer to where the count of bytes needed to store the buffer contents in contiguous will be stored.
    /// </param>
    public uint GetContiguousLength()
    {
        uint value;
        Marshal.ThrowExceptionForHR(_comImpl->GetContiguousLength(_comPtr, &value));
        return value;
    }

    /// <summary>
    ///     The ContiguousCopyTo method copies the contents of the buffer into the caller's buffer in contiguous format.
    /// </summary>
    /// <param name="pbDestBuffer">
    ///     Pointer to where to store the contiguous data to.
    /// </param>
    /// <param name="cbDestBuffer">
    ///     Number of bytes to copy.  This must match the value returned by GetContiguousLength.  If it doesn't this method returns E_INVALIDARG.
    /// </param>
    public void ContiguousCopyTo(nint pbDestBuffer, uint cbDestBuffer)
    {
        Marshal.ThrowExceptionForHR(_comImpl->ContiguousCopyTo(_comPtr, pbDestBuffer, cbDestBuffer));
    }

    /// <summary>
    ///     The ContiguousCopyFrom method copies the contents of the caller's buffer which is in contiguous format into
    ///     the buffer - correcting for the buffer's pitch as necessary.
    /// </summary>
    /// <param name="pbSrcBuffer">
    ///     Pointer to where to copy the contiguous from.
    /// </param>
    /// <param name="cbSrcBuffer">
    ///     Number of bytes to copy.  This must match the value returned by GetContiguousLength.  If it doesn't this method returns E_INVALIDARG.
    /// </param>
    public void ContiguousCopyFrom(nint pbSrcBuffer, uint cbSrcBuffer)
    {
        Marshal.ThrowExceptionForHR(_comImpl->ContiguousCopyFrom(_comPtr, pbSrcBuffer, cbSrcBuffer));
    }
}
