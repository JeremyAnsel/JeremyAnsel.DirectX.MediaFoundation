using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.MediaFoundation;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class MFSinkWriter : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid MFSinkWriterGuid = new(IMFSinkWriter.Guid);

    private readonly nint _comPtr;
    private readonly IMFSinkWriter* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="MFSinkWriter"/> class.
    /// </summary>
    public MFSinkWriter(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IMFSinkWriter**)comPtr;
    }

    /// <summary>
    /// Adds a stream to the writer.
    ///     - pTargetMediaType specifies the target format of the media samples
    ///       for the stream.  This is the format of the samples as they will
    ///       be written out to the storage medium.
    ///     - pdwStreamIndex receives the stream index associated with the
    ///       new stream.
    /// </summary>
    /// <param name="pTargetMediaType"></param>
    /// <returns></returns>
    public uint AddStream(MFMediaType pTargetMediaType)
    {
        uint value;
        Marshal.ThrowExceptionForHR(_comImpl->AddStream(_comPtr, pTargetMediaType.Handle, &value));
        return value;
    }

    /// <summary>
    /// Specifies the format of the media samples that will be passed to the
    /// Sink Writer for a particular stream if different from the target
    /// format.  This method is used to identify the encoder to be used
    /// for the stream.
    ///
    ///     - dwStreamIndex specifies the index of the stream to configure.
    ///     - pInputMediaType specifies the format of the media samples that
    ///       will be passed to the Sink Writer for this stream.
    ///     - pEncodingParameters is used to specify additional attributes used
    ///       to configure the encoder.
    ///
    /// Note: This can called at any time to dynamically change the format
    ///       of the input samples for the stream.  Since a format change
    ///       is queued on the stream, and may fail during processing, calling
    ///       SetInputMediaType will immediately test the MFT to see if the new
    ///       type is supported, and only then will it queue the format change.
    /// </summary>
    /// <param name="dwStreamIndex"></param>
    /// <param name="pInputMediaType"></param>
    /// <param name="pEncodingParameters"></param>
    public void SetInputMediaType(uint dwStreamIndex, MFMediaType pInputMediaType, MFAttributes? pEncodingParameters)
    {
        Marshal.ThrowExceptionForHR(_comImpl->SetInputMediaType(
            _comPtr,
            dwStreamIndex,
            pInputMediaType.Handle,
            pEncodingParameters is null ? 0 : pEncodingParameters.Handle));
    }

    /// <summary>
    /// Called after all streams are configured, but before
    /// writing out any samples.
    /// </summary>
    public void BeginWriting()
    {
        Marshal.ThrowExceptionForHR(_comImpl->BeginWriting(_comPtr));
    }

    /// <summary>
    /// Called to pass in a new sample to the writer.
    ///
    /// Note: By default calls to WriteSample may block for a period of time
    ///       to throttle the rate at which samples are processed.  The
    ///       application can disable this throttling by configuring the writer 
    ///       with the MF_SINK_WRITER_DISABLE_THROTTLING attribute.
    /// </summary>
    /// <param name="dwStreamIndex"></param>
    /// <param name="pSample"></param>
    public void WriteSample(uint dwStreamIndex, MFSample pSample)
    {
        Marshal.ThrowExceptionForHR(_comImpl->WriteSample(_comPtr, dwStreamIndex, pSample.Handle));
    }

    /// <summary>
    /// Called to flush all samples that are queued to be encoded
    /// or have not yet been sent to the sink.
    ///
    ///     - dwStreamIndex can either specify a single stream or can be set to
    ///       MF_SINK_WRITER_ALL_STREAMS to flush all stream.
    /// </summary>
    /// <param name="dwStreamIndex"></param>
    public void Flush(uint dwStreamIndex)
    {
        Marshal.ThrowExceptionForHR(_comImpl->Flush(_comPtr, dwStreamIndex));
    }

    /// <summary>
    /// Called after all samples have been passed to the writer.
    ///
    /// Note: By default, this call will block until the content generation
    ///       has completed, which may take some time.
    ///       The app can choose to make Finalize() return immediately and
    ///       trigger a callback when the operation completes by configuring
    ///       the Sink Writer with an IMFSinkWriterCallback interface set on
    ///       the attribute store during Sink Writer creation.
    /// </summary>
    public void FinalizeWriter()
    {
        Marshal.ThrowExceptionForHR(_comImpl->Finalize(_comPtr));
    }
}
