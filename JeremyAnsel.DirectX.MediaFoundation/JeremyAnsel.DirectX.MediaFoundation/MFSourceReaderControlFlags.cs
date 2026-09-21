namespace JeremyAnsel.DirectX.MediaFoundation;

/// <summary>
///     The enumeration type defines the various flags that can be passed
///     to the Source Reader's ReadSample method.
/// </summary>
[Flags]
public enum MFSourceReaderControlFlags
{
    None = 0,

    /// <summary>
    ///     Specifies that ReadSample should only drain samples from
    ///     the stream, and not request more samples from the media source.
    ///     This can be used to ensure all samples are returned for the 
    ///     stream before flushing, changing position, or changing the
    ///     output media type for the stream.
    /// </summary>
    Drain = 0x00000001,
}
