using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.MediaFoundation;

/// <summary>
///     The MF Source Reader provides a simple programming model that allows
///     applications to easily access multimedia content from files or 
///     devices.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class MFSourceReader : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid MFSourceReaderGuid = new(IMFSourceReader.Guid);

    private readonly nint _comPtr;
    private readonly IMFSourceReader* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="MFSourceReader"/> class.
    /// </summary>
    public MFSourceReader(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IMFSourceReader**)comPtr;
    }

    public const uint InvalidStreamIndex = 0xFFFFFFFF;
    public const uint AllStreams = 0xFFFFFFFE;
    public const uint AnyStream = 0xFFFFFFFE;
    public const uint FirstAudioStream = 0xFFFFFFFD;
    public const uint FirstVideoStream = 0xFFFFFFFC;

    /// <summary>
    ///     Returns whether or not the specified stream is selected.
    ///     If the specified stream does not exist, the error
    ///     MF_E_INVALIDSTREAMNUMBER is returned.
    /// </summary>
    /// <param name="dwStreamIndex">
    ///     Specifies the stream index to query for selection state.
    /// </param>
    /// <param name="pfSelected">
    ///     Specifies a pointer to a variable where the selection state
    ///     will be stored.
    /// </param>
    public bool GetStreamSelection(uint dwStreamIndex)
    {
        uint value;
        Marshal.ThrowExceptionForHR(_comImpl->GetStreamSelection(_comPtr, dwStreamIndex, &value));
        return value != 0;
    }

    /// <summary>
    ///     Sets the selection state for the specified stream.
    ///     MF_SOURCE_READER_ALL_STREAMS can be specified in order
    ///     to set the stream selection for all available streams.
    /// </summary>
    /// <param name="dwStreamIndex">
    ///     Specifies the stream index.
    /// </param>
    /// <param name="fSelected">
    ///     Specifies whether or not the stream should be selected.
    /// </param>
    public void SetStreamSelection(uint dwStreamIndex, bool fSelected)
    {
        Marshal.ThrowExceptionForHR(_comImpl->SetStreamSelection(_comPtr, dwStreamIndex, fSelected ? 1U : 0U));
    }

    /// <summary>
    ///     Returns the native media type for the specified stream.
    /// </summary>
    /// <param name="dwStreamIndex">
    ///     Specifies the stream index.
    /// </param>
    /// <param name="dwMediaTypeIndex">
    ///     Specifies the media type index.  As some sources support
    ///     multiple native media types, the index is used to indicate
    ///     the position in the list of supported media types.
    /// </param>
    /// <param name="ppMediaType">
    ///     Receives a copy of the specified native media type.
    /// </param>
    public MFMediaType? GetNativeMediaType(uint dwStreamIndex, uint dwMediaTypeIndex)
    {
        nint ptr;
        int hr = _comImpl->GetNativeMediaType(_comPtr, dwStreamIndex, dwMediaTypeIndex, &ptr);
        if (hr < 0)
        {
            return null;
        }
        return new MFMediaType(ptr);
    }

    /// <summary>
    ///     Returns the media type of the samples currently being
    ///     output for the specified stream.
    /// </summary>
    /// <param name="dwStreamIndex">
    ///     Specifies the stream index.
    /// </param>
    /// <param name="ppMediaType">
    ///     Receives a copy of the current media type.
    /// </param>
    public MFMediaType GetCurrentMediaType(uint dwStreamIndex)
    {
        nint ptr;
        Marshal.ThrowExceptionForHR(_comImpl->GetCurrentMediaType(_comPtr, dwStreamIndex, &ptr));
        return new MFMediaType(ptr);
    }

    /// <summary>
    ///     Sets the output media type for samples returned for the specified
    ///     stream.
    /// </summary>
    /// <param name="dwStreamIndex">
    ///     Specifies the stream index.
    /// </param>
    /// <param name="pdwReserved">
    ///     Reserved for future use.
    /// </param>
    /// <param name="pMediaType">
    ///     Specifies the desired media type for the stream.
    /// </param>
    /// <remarks>
    ///     If an appropriate MFT cannot be found to transform the native
    ///     media type into the desired media type, then an error is
    ///     returned, and the current media type remains unchanged.
    /// </remarks>
    public void SetCurrentMediaType(uint dwStreamIndex, MFMediaType pMediaType)
    {
        Marshal.ThrowExceptionForHR(_comImpl->SetCurrentMediaType(_comPtr, dwStreamIndex, null, pMediaType.Handle));
    }

    /// <summary>
    ///     Requests the next available sample.  The caller can either
    ///     request a sample from a specific stream, or from any of
    ///     the selected streams.
    /// </summary>
    /// <param name="dwStreamIndex">
    ///     Specifies the stream for which the sample request is being made.
    ///     MF_SOURCE_READER_ANY_STREAM can be specified in order to request
    ///     the next sample from any available stream.
    /// </param>
    /// <param name="dwControlFlags">
    ///     Specifies flags that control the behavior of ReadSample.
    ///     See: section above on MF Source Reader Control Flags.
    /// </param>
    /// <param name="pdwActualStreamIndex">
    ///     Receives the actual stream index of the media sample.
    /// </param>
    /// <param name="pdwStreamFlags">
    ///     Receives the accumulated flags for the stream.
    ///     See: section above on MF Source Reader Flags
    /// </param>
    /// <param name="pllTimestamp">
    ///     Receives the presentation time of the sample.
    ///     If MF_SOURCE_READERF_STREAM_TICK is set in the stream flags,
    ///     then this receives the timestamp for the stream tick.
    /// </param>
    /// <param name="ppSample">
    ///     Receives the next sample for the stream.
    /// </param>
    /// <remarks>
    ///     When operating in synchronous mode, the out parameters
    ///     are all required parameters.
    ///
    ///     When operating in asynchronous mode, the out parameters
    ///     must all be set to NULL.
    ///
    ///     Streams must be selected in order to request samples
    ///     from them.
    ///
    ///     It is possible for ReadSample to return S_OK in synchronous
    ///     mode while not returning a sample.  The caller should always
    ///     check for NULL before dereferencing the sample.  This can
    ///     happen if EOS is reached, in which case
    ///     MF_SOURCE_READERF_ENDOFSTREAM will be set for the stream.
    ///     Another reason is if there is a gap in the stream, in which
    ///     case MF_SOURCE_READERF_STREAMTICK will be set.  For stream
    ///     ticks, the sample will be NULL, but the timestamp parameter
    ///     will be set to indicate the position in the stream where the
    ///     gap occurred.
    ///
    /// </remarks>
    public MFSample? ReadSample(uint dwStreamIndex, MFSourceReaderControlFlags dwControlFlags, out uint pdwActualStreamIndex, out MFSourceReaderFlags pdwStreamFlags, out ulong pllTimestamp)
    {
        nint ptr;
        uint dwActualStreamIndex;
        uint dwStreamFlags;
        ulong llTimestamp;
        Marshal.ThrowExceptionForHR(_comImpl->ReadSample(_comPtr, dwStreamIndex, (uint)dwControlFlags, &dwActualStreamIndex, &dwStreamFlags, &llTimestamp, &ptr));
        pdwActualStreamIndex = dwActualStreamIndex;
        pdwStreamFlags = (MFSourceReaderFlags)dwStreamFlags;
        pllTimestamp = llTimestamp;
        return ptr == 0 ? null : new MFSample(ptr);
    }

    /// <summary>
    ///     Releases any queued up samples, and cancels any outstanding sample
    ///     requests.
    /// </summary>
    /// <param name="dwStreamIndex">
    ///     Allows the application to specify which stream to flush.
    ///     MF_SOURCE_READER_ALL_STREAMS can be specified in order to 
    ///     flush all available streams.
    /// </param>
    /// <remarks>
    ///     In async mode, the OnFlush callback is called when the
    ///     flush operation completes.  Before receiving the OnFlush
    ///     callback, the application should not request any more
    ///     samples from the source reader.  Doing so will result in
    ///     the MF_E_NOTACCEPTING error being returned.
    /// </remarks>
    public void Flush(uint dwStreamIndex)
    {
        Marshal.ThrowExceptionForHR(_comImpl->Flush(_comPtr, dwStreamIndex));
    }
}
