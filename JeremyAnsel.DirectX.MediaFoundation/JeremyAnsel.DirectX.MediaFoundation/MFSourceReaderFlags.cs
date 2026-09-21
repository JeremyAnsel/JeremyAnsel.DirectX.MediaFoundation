namespace JeremyAnsel.DirectX.MediaFoundation;

/// <summary>
///     The enumeration type defines the various flags that can be returned
///     from the MF Source Reader when retrieving the next sample.
/// </summary>
[Flags]
public enum MFSourceReaderFlags
{
    None = 0,

    /// <summary>
    ///     Specifies that an error has occurred while processing sample
    ///     requests.  If this is set, then no other calls should be made
    ///     on the source reader besides shutting it down.
    /// </summary>
    Error = 0x00000001,

    /// <summary>
    ///     Specifies that the stream has ended.
    /// </summary>
    EndOfStream = 0x00000002,

    /// <summary>
    ///     Specifies that one or more new streams have been created.
    ///     The application can modify stream selection and configure
    ///     output media types for the new streams.
    /// </summary>
    NewStream = 0x00000004,

    /// <summary>
    ///     Specifies that the native media type for the stream has changed.
    /// </summary>
    NativeMediaTypeChanged = 0x00000010,

    /// <summary>
    ///     Specifies that the current media type for the stream has changed.
    /// </summary>
    CurrentMediaTypeChanged = 0x00000020,

    /// <summary>
    ///     Specifies that there is a gap in the stream.
    /// </summary>
    StreamTick = 0x00000100,

    /// <summary>
    ///     Indicates that all transforms inserted by the application have been
    ///     removed for a particular stream. This could be due to a dynamic format
    ///     change from a source or decoder that prevents custom transforms from
    ///     being used because they cannot handle the new media type.
    /// </summary>
    AllEffectsRemoved = 0x00000200,
}
