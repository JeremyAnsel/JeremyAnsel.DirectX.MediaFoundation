namespace JeremyAnsel.DirectX.MediaFoundation;

public static class MFReadWriteGuids
{
    /// <summary>
    /// MF_READWRITE_DISABLE_CONVERTERS
    /// Data type: UINT32
    /// This attribute can be used to ensure that the Source Reader
    /// or Sink Writer does not perform additional conversion on
    /// the multimedia data besides a single decode or encode operation.
    /// </summary>
    public static readonly Guid MF_READWRITE_DISABLE_CONVERTERS = new(0x98d5b065, 0x1374, 0x4847, 0x8d, 0x5d, 0x31, 0x52, 0x0f, 0xee, 0x71, 0x56);

    /// <summary>
    /// MF_READWRITE_ENABLE_HARDWARE_TRANSFORMS
    /// Data type: UINT32
    /// By default, the Source Reader and Sink Writer will not
    /// use hardware decoders or encoders.  This attribute can
    /// be set to TRUE to enable hardware transforms.
    /// </summary>
    public static readonly Guid MF_READWRITE_ENABLE_HARDWARE_TRANSFORMS = new(0xa634a91c, 0x822b, 0x41b9, 0xa4, 0x94, 0x4d, 0xe4, 0x64, 0x36, 0x12, 0xb0);

    /// <summary>
    /// MF_READWRITE_D3D_OPTIONAL
    /// Data type: UINT32
    /// This attribute is used to tell Source Reader\Sink Writer that application can accept non-DX samples.
    /// Source Reader will attempt to provide DX samples but will fallback to sysmem allocation if DX allocation fails.
    /// This attribute is only valid when D3D manager is set.
    /// </summary>
    public static readonly Guid MF_READWRITE_D3D_OPTIONAL = new(0x216479d9, 0x3071, 0x42ca, 0xbb, 0x6c, 0x4c, 0x22, 0x10, 0x2e, 0x1d, 0x18);

    /// <summary>
    ///    MF_LOW_LATENCY                  {UINT32 (BOOL)}
    /// </summary>
    public static readonly Guid MF_LOW_LATENCY = new(0x9c27891a, 0xed7a, 0x40e1, 0x88, 0xe8, 0xb2, 0x27, 0x27, 0xa0, 0x24, 0xee);
}
