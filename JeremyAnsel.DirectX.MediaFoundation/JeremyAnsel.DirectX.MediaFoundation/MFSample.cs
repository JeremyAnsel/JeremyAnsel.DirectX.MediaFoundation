using JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.MediaFoundation;

/// <summary>
///     The IMFSample interface represents a multimedia sample for a 
///     multimedia stream type.  An typical example is a video frame,
///     and a notable exception is audio where an IMFSample does not usually 
///     represent a single sample of audio, but rather a chunk
///     of audio samples.  Note that this allows us to reduce the overhead for 
///     representing audio in the pipeline.
///
///     A sample may consist of a multiple buffers as is the case of compressed
///     audio or video samples received from the network or being sent to an 
///     ASF media sink or ASF multiplexer.  
///
///     The IMFAttributes interface can be used to tag the sample with extra
///     information that is not represented by the IMFSample methods.
///     The MFSampleExtension_xxx GUIDs in mfapi.h define some standard 
///     attributes, but custom attributes are allowed and are preserved
///     through the Media Foundation pipeline as well as possible.
/// </summary>
/// <remarks>
///     MediaFoundation does not provide a synchronized (thread-safe) way to 
///     call the IMFSample methods.
///     To guarantee thread-safety, the caller should obtain a lock while 
///     working with sample object to prevent access by other threads.
/// </remarks>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class MFSample : MFAttributes
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid MFSampleGuid = new(IMFSample.Guid);

    private readonly nint _comPtr;
    private readonly IMFSample* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="MFSample"/> class.
    /// </summary>
    public MFSample(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IMFSample**)comPtr;
    }

    /// <summary>
    ///     The GetSampleTime method returns the presentation time associated with the sample.
    /// </summary>
    /// <param name="phnsSampleTime">
    ///     Specifies a pointer to a 64 bit variable where the presentation time will be stored.
    /// </param>
    /// <returns>
    ///     If the method succeeds, it returns S_OK.
    ///     If no the sample does not have a sample time MF_E_NO_SAMPLE_TIMESTAMP is returned.
    ///     If this method fails otherwise it returns an error code.
    /// </returns>
    /// <remarks>
    ///     The presentation time is stored in 100ns interval units.
    /// </remarks>
    public ulong GetSampleTime()
    {
        ulong value;
        Marshal.ThrowExceptionForHR(_comImpl->GetSampleTime(_comPtr, &value));
        return value;
    }

    /// <summary>
    ///     The SetSampleTime method allows the caller to set the presentation time associated with the sample.
    /// </summary>
    /// <param name="hnsSampleTime">
    ///     64 bit value specifying the presentation time.
    /// </param>
    /// <remarks>
    ///     The presentation time is stored in 100ns interval units.
    /// </remarks>
    public void SetSampleTime(ulong hnsSampleTime)
    {
        Marshal.ThrowExceptionForHR(_comImpl->SetSampleTime(_comPtr, hnsSampleTime));
    }

    /// <summary>
    ///     The GetSampleDuration method returns the duration of the sample.
    /// </summary>
    /// <param name="phnsSampleDuration">
    ///     Specifies a pointer to a 64 bit variable where duration will be stored.
    /// </param>
    /// <returns>
    ///     If the method succeeds, it returns S_OK.
    ///     If no the sample does not have a duration MF_E_NO_SAMPLE_DURATION is returned.
    ///     If this method fails otherwise it returns an error code.
    /// </returns>
    /// <remarks>
    ///     The duration is specified in 100ns interval units.
    ///     If the duration is zero, then the sample duration is unknown.  In such cases, it is possible that it can be derived from the media type e.g. video frame rate.
    ///     Application should avoid calculating duration of presentation as sum of sample durations because of possible cumulative error.
    ///     For example cumulative error for 60fps video on 24 hours interval is 0.1728 seconds.
    ///         For 60fps, there are 5184000 frames * 166667 100ns/frame = 24 hours + 0.1728 seconds
    /// </remarks>
    public ulong GetSampleDuration()
    {
        ulong value;
        Marshal.ThrowExceptionForHR(_comImpl->GetSampleDuration(_comPtr, &value));
        return value;
    }

    /// <summary>
    ///     The SetSampleDuration method allows the caller to set the duration of the sample.
    /// </summary>
    /// <param name="hnsSampleDuration">
    ///     64 bit value specifying the sample duration.
    /// </param>
    /// <remarks>
    ///     The duration is specified in 100ns interval units.  This value should be set wherever possible to aid in the processing of samples in a multimedia pipeline.
    /// </remarks>
    public void SetSampleDuration(ulong hnsSampleDuration)
    {
        Marshal.ThrowExceptionForHR(_comImpl->SetSampleDuration(_comPtr, hnsSampleDuration));
    }

    /// <summary>
    ///     The GetBufferCount method returns the count of the buffers in that are currently associated with this sample.
    /// </summary>
    /// <param name="pdwBufferCount">
    ///     Pointer to a 32 bit variable where the buffer count will be stored.
    /// </param>
    /// <remarks>
    ///     It is valid to have a sample with a buffer count of zero.  This is considered to be an empty sample.
    /// </remarks>
    public uint GetBufferCount()
    {
        uint value;
        Marshal.ThrowExceptionForHR(_comImpl->GetBufferCount(_comPtr, &value));
        return value;
    }

    /// <summary>
    ///     The GetBufferByIndex method returns a pointer to the IMFMediaBuffer object at a specified index in the sample.
    /// </summary>
    /// <param name="dwIndex">
    ///     32 bit value specifying the index of the buffer object requested.
    /// </param>
    /// <param name="ppBuffer">
    ///     Pointer to a pointer where the buffer object will be stored.
    /// </param>
    public MFMediaBuffer GetBufferByIndex(uint dwIndex)
    {
        nint ptr;
        Marshal.ThrowExceptionForHR(_comImpl->GetBufferByIndex(_comPtr, dwIndex, &ptr));
        return new MFMediaBuffer(ptr);
    }

    /// <summary>
    ///     The GetContiguousBuffer method converts sample with multiple buffers into sample with single buffer and returns a pointer to this buffer.
    /// </summary>
    /// <param name="ppBuffer">
    ///     Pointer to a pointer where the buffer object will be stored.
    /// </param>
    /// <remarks>
    ///     This method copies the content of the sample into a contiguous media buffer, and should be used with care.
    /// </remarks>
    public MFMediaBuffer ConvertToContiguousBuffer()
    {
        nint ptr;
        Marshal.ThrowExceptionForHR(_comImpl->ConvertToContiguousBuffer(_comPtr, &ptr));
        return new MFMediaBuffer(ptr);
    }

    /// <summary>
    ///     The AddBuffer method allows the caller to add a media buffer to the end of current list of buffers in the sample.
    /// </summary>
    /// <param name="pBuffer">
    ///     Pointer to a buffer object.
    /// </param>
    /// <returns>
    ///     If the method succeeds, it returns S_OK.
    ///     If sample does not support adding buffers, it returns MF_E_SAMPLE_UNSUPPORTED_OP.
    ///     If it fails, it returns an error code.
    /// </returns>
    /// <remarks>
    ///     The newly added buffer represents sample data at an offset equal to the previous total length of the sample.
    /// </remarks>
    public void AddBuffer(MFMediaBuffer pBuffer)
    {
        Marshal.ThrowExceptionForHR(_comImpl->AddBuffer(_comPtr, pBuffer.Handle));
    }

    /// <summary>
    ///     The RemoveBufferByIndex method allows the caller to remove a buffer object at a specified index within the list of available buffer objects in the sample.
    /// </summary>
    /// <param name="dwIndex">
    ///     32 bit value specifying the index.
    /// </param>
    /// <returns>
    ///     If the method succeeds, it returns S_OK.
    ///     If sample does not support removing buffers, it returns MF_E_SAMPLE_UNSUPPORTED_OP.
    ///     If it fails, it returns an error code.
    /// </returns>
    /// <remarks>
    ///     The total length of the sample is reduced by the length of the removed buffer, and the offsets of all buffer objects that
    ///     were at indices greater than dwIndex are shifted up by the length of the removed buffer.
    /// </remarks>
    public void RemoveBufferByIndex(uint dwIndex)
    {
        Marshal.ThrowExceptionForHR(_comImpl->RemoveBufferByIndex(_comPtr, dwIndex));
    }

    /// <summary>
    ///     The RemoveAllBuffers method allows the caller to remove all buffer objects associated with the sample.
    /// </summary>
    /// <returns>
    ///     If the method succeeds, it returns S_OK.
    ///     If sample does not support removing buffers, it returns MF_E_SAMPLE_UNSUPPORTED_OP.
    ///     If it fails, it returns an error code.
    /// </returns>
    /// <remarks>
    ///     After this call, the buffer count of the sample is zero i.e. it is an empty sample.
    /// </remarks>
    public void RemoveAllBuffers()
    {
        Marshal.ThrowExceptionForHR(_comImpl->RemoveAllBuffers(_comPtr));
    }

    /// <summary>
    ///     The GetTotalLength method returns the total length of all buffers objects in the sample.
    /// </summary>
    /// <param name="pcbTotalLength">
    ///     Pointer to a 32 bit variable where the total length in bytes will be stored.
    /// </param>
    /// <remarks>
    ///     The total length of the sample is tracked when buffers are added (via AddBuffer), removed (via RemoveBufferByIndex and RemoveAllBuffers).
    /// </remarks>
    public uint GetTotalLength()
    {
        uint value;
        Marshal.ThrowExceptionForHR(_comImpl->GetTotalLength(_comPtr, &value));
        return value;
    }

    /// <summary>
    ///     The CopyToBuffer method allows the caller to copy the sample data to the buffer object provided.
    /// </summary>
    /// <param name="pBuffer">
    ///     Pointer to a buffer object.
    /// </param>
    /// <returns>
    ///     If the method succeeds, it returns S_OK. If destination buffer is too small, it returns MF_E_BUFFERTOOSMALL. If it fails for other reason, it returns an error code.
    /// </returns>
    public void CopyToBuffer(MFMediaBuffer pBuffer)
    {
        Marshal.ThrowExceptionForHR(_comImpl->CopyToBuffer(_comPtr, pBuffer.Handle));
    }
}
