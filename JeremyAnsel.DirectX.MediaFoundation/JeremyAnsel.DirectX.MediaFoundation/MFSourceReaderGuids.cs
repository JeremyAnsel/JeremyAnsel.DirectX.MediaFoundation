namespace JeremyAnsel.DirectX.MediaFoundation;

public static class MFSourceReaderGuids
{
    /// <summary>
    /// MF_SOURCE_READER_D3D_MANAGER
    /// Data type: IUnknown
    /// This attribute enables video sample allocation using D3D9 surfaces,
    /// and enables hardware acceleration within the Source Reader.
    /// This should be set to the IUnknown interface of an
    /// object that implements the IDirect3DDeviceManager9 interface.
    /// </summary>
    public static readonly Guid MF_SOURCE_READER_D3D_MANAGER = new(0xec822da2, 0xe1e9, 0x4b29, 0xa0, 0xd8, 0x56, 0x3c, 0x71, 0x9f, 0x52, 0x69);

    /// <summary>
    /// MF_SOURCE_READER_DISABLE_DXVA
    /// Data type: UINT32
    /// DXVA is enabled by default if the Source Reader is configured with
    /// a D3D manager.  This attribute can be set to TRUE in order to
    /// disable DXVA, while still allocating video samples using the D3D manager.
    /// </summary>
    public static readonly Guid MF_SOURCE_READER_DISABLE_DXVA = new(0xaa456cfd, 0x3943, 0x4a1e, 0xa7, 0x7d, 0x18, 0x38, 0xc0, 0xea, 0x2e, 0x35);

    /// <summary>
    /// MF_SOURCE_READER_ENABLE_VIDEO_PROCESSING
    /// Data type: UINT32
    /// This attribute enables limited video processing on
    /// video samples within the source reader.
    /// </summary>
    public static readonly Guid MF_SOURCE_READER_ENABLE_VIDEO_PROCESSING = new(0xfb394f3d, 0xccf1, 0x42ee, 0xbb, 0xb3, 0xf9, 0xb8, 0x45, 0xd5, 0x68, 0x1d);

    /// <summary>
    /// MF_SOURCE_READER_ENABLE_ADVANCED_VIDEO_PROCESSING
    /// Data type: UINT32
    /// This attribute enables advanced video processing on video samples within the source reader.
    /// Specifically it enables optimized (and HW-accelerated) scaling, colorspace conversion,
    /// frame rate conversion and deinterlacing.
    /// </summary>
    public static readonly Guid MF_SOURCE_READER_ENABLE_ADVANCED_VIDEO_PROCESSING = new(0xf81da2c, 0xb537, 0x4672, 0xa8, 0xb2, 0xa6, 0x81, 0xb1, 0x73, 0x7, 0xa3);

    /// <summary>
    /// MF_SOURCE_READER_DISABLE_CAMERA_PLUGINS	
    /// Data type: UINT32 (treat as Boolean)
    /// This attribute can be used to disable post-processing camera plug-ins from being
    /// automatically created by Source Reader.
    /// </summary>
    public static readonly Guid MF_SOURCE_READER_DISABLE_CAMERA_PLUGINS = new(0x9d3365dd, 0x58f, 0x4cfb, 0x9f, 0x97, 0xb3, 0x14, 0xcc, 0x99, 0xc8, 0xad);

    /// <summary>
    /// MF_SOURCE_READER_ENABLE_TRANSCODE_ONLY_TRANSFORMS
    /// Data type: UINT32
    /// By default, the Source Reader will not use MFTs that
    /// are registered for transcode use only. This attribute can
    /// be set to TRUE to enable use of these transcode only MFTs.
    /// </summary>
    public static readonly Guid MF_SOURCE_READER_ENABLE_TRANSCODE_ONLY_TRANSFORMS = new(0xdfd4f008, 0xb5fd, 0x4e78, 0xae, 0x44, 0x62, 0xa1, 0xe6, 0x7b, 0xbe, 0x27);

    /// <summary>
    /// MF_SOURCE_READER_D3D11_BIND_FLAGS
    /// Data type: UINT32
    /// By default, the source reader derives the D3D11 bind flags from attributes found on
    /// the media source provided during creation, and the capabilies of the provided D3D manager.  
    /// This attribute allows the caller to modify the information extracted by the media source,
    /// adding extra flags.  See the D3D11_BIND_FLAG enumeration for details.
    /// </summary>
    public static readonly Guid MF_SOURCE_READER_D3D11_BIND_FLAGS = new(0x33f3197b, 0xf73a, 0x4e14, 0x8d, 0x85, 0xe, 0x4c, 0x43, 0x68, 0x78, 0x8d);

    /// <summary>
    /// MF_SOURCE_READER_PASSTHROUGH_MODE
    /// Data type: UINT32
    /// By default, the source reader tries to copy all system memory backed video sampels into DX textures for faster processing.  
    /// When this attribute is set to TRUE (1), the source reader will avoid doing that, keeping the video samples in system memory,
    /// even if a D3D device manager is present.
    /// </summary>
    public static readonly Guid MF_SOURCE_READER_PASSTHROUGH_MODE = new(0x43ff126, 0xfe2c, 0x4708, 0xa0, 0x9b, 0xda, 0x2a, 0xb4, 0x35, 0xce, 0xd9);
}
