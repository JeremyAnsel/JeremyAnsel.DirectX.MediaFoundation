namespace JeremyAnsel.DirectX.MediaFoundation;

public static class MFSinkWriterGuids
{
    /// <summary>
    /// MF_SINK_WRITER_DISABLE_THROTTLING
    /// Data type: UINT32
    /// This attribute can be set when instantiating the Sink Writer
    /// in order to prevent the Sink Writer from throttling calls to
    /// IMFSinkWriter::WriteSample.
    /// </summary>
    public static readonly Guid MF_SINK_WRITER_DISABLE_THROTTLING = new(0x08b845d8, 0x2b74, 0x4afe, 0x9d, 0x53, 0xbe, 0x16, 0xd2, 0xd5, 0xae, 0x4f);

    /// <summary>
    /// MF_SINK_WRITER_D3D_MANAGER
    /// Data type: IUnknown
    /// This attribute enables video sample allocation using D3D9 surfaces,
    /// and enables hardware acceleration within the Sink Writer.
    /// This should be set to the IUnknown interface of an
    /// object that implements the IDirect3DDeviceManager9 interface.
    /// </summary>
    public static readonly Guid MF_SINK_WRITER_D3D_MANAGER = new(0xec822da2, 0xe1e9, 0x4b29, 0xa0, 0xd8, 0x56, 0x3c, 0x71, 0x9f, 0x52, 0x69);

    /// <summary>
    /// MF_MEDIASINK_AUTOFINALIZE_SUPPORTED
    /// Data type: UINT32
    /// Sink sets this to TRUE if it supports auto finalization feature.
    /// FALSE otherwise.
    /// </summary>
    public static readonly Guid MF_MEDIASINK_AUTOFINALIZE_SUPPORTED = new(0x48c131be, 0x135a, 0x41cb, 0x82, 0x90, 0x3, 0x65, 0x25, 0x9, 0xc9, 0x99);

    /// <summary>
    /// MF_MEDIASINK_ENABLE_AUTOFINALIZE
    /// Data type: UINT32
    /// Client of media sink sets this to TRUE if it wants the sink to auto finalize the file.
    /// FALSE otherwise.
    /// </summary>
    public static readonly Guid MF_MEDIASINK_ENABLE_AUTOFINALIZE = new(0x34014265, 0xcb7e, 0x4cde, 0xac, 0x7c, 0xef, 0xfd, 0x3b, 0x3c, 0x25, 0x30);

    /// <summary>
    /// MF_READWRITE_ENABLE_AUTOFINALIZE
    /// Data type: UINT32
    /// Client of Sink Writer sets this to TRUE if they want the underlying sink to auto finalize the file.
    /// FALSE otherwise.
    /// </summary>
    public static readonly Guid MF_READWRITE_ENABLE_AUTOFINALIZE = new(0xdd7ca129, 0x8cd1, 0x4dc5, 0x9d, 0xde, 0xce, 0x16, 0x86, 0x75, 0xde, 0x61);
}
