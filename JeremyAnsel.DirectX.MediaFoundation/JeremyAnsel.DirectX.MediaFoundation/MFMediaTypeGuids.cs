namespace JeremyAnsel.DirectX.MediaFoundation;

public static class MFMediaTypeGuids
{
    /// <summary>
    /// MF_MT_MAJOR_TYPE                {GUID}
    /// </summary>
    public static readonly Guid MF_MT_MAJOR_TYPE = new(0x48eba18e, 0xf8c9, 0x4687, 0xbf, 0x11, 0x0a, 0x74, 0xc9, 0xf9, 0x6a, 0x8f);

    /// <summary>
    /// MF_MT_SUBTYPE                   {GUID}
    /// </summary>
    public static readonly Guid MF_MT_SUBTYPE = new(0xf7e34c9a, 0x42e8, 0x4714, 0xb7, 0x4b, 0xcb, 0x29, 0xd7, 0x2c, 0x35, 0xe5);

    /// <summary>
    /// MF_MT_ALL_SAMPLES_INDEPENDENT   {UINT32 (BOOL)}
    /// </summary>
    public static readonly Guid MF_MT_ALL_SAMPLES_INDEPENDENT = new(0xc9173739, 0x5e56, 0x461c, 0xb7, 0x13, 0x46, 0xfb, 0x99, 0x5c, 0xb9, 0x5f);

    /// <summary>
    /// MF_MT_FIXED_SIZE_SAMPLES        {UINT32 (BOOL)}
    /// </summary>
    public static readonly Guid MF_MT_FIXED_SIZE_SAMPLES = new(0xb8ebefaf, 0xb718, 0x4e04, 0xb0, 0xa9, 0x11, 0x67, 0x75, 0xe3, 0x32, 0x1b);

    /// <summary>
    /// MF_MT_COMPRESSED                {UINT32 (BOOL)}
    /// </summary>
    public static readonly Guid MF_MT_COMPRESSED = new(0x3afd0cee, 0x18f2, 0x4ba5, 0xa1, 0x10, 0x8b, 0xea, 0x50, 0x2e, 0x1f, 0x92);

    /// <summary>
    /// MF_MT_SAMPLE_SIZE               {UINT32}
    /// </summary>
    /// <remarks>
    /// MF_MT_SAMPLE_SIZE is only valid if MF_MT_FIXED_SIZED_SAMPLES is TRUE
    /// </remarks>
    public static readonly Guid MF_MT_SAMPLE_SIZE = new(0xdad3ab78, 0x1990, 0x408b, 0xbc, 0xe2, 0xeb, 0xa6, 0x73, 0xda, 0xcc, 0x10);

    /// <summary>
    /// MF_MT_AUDIO_NUM_CHANNELS            {UINT32}
    /// </summary>
    public static readonly Guid MF_MT_AUDIO_NUM_CHANNELS = new(0x37e48bf5, 0x645e, 0x4c5b, 0x89, 0xde, 0xad, 0xa9, 0xe2, 0x9b, 0x69, 0x6a);

    /// <summary>
    /// MF_MT_AUDIO_SAMPLES_PER_SECOND      {UINT32}
    /// </summary>
    public static readonly Guid MF_MT_AUDIO_SAMPLES_PER_SECOND = new(0x5faeeae7, 0x0290, 0x4c31, 0x9e, 0x8a, 0xc5, 0x34, 0xf6, 0x8d, 0x9d, 0xba);

    /// <summary>
    /// MF_MT_AUDIO_FLOAT_SAMPLES_PER_SECOND {double}
    /// </summary>
    public static readonly Guid MF_MT_AUDIO_FLOAT_SAMPLES_PER_SECOND = new(0xfb3b724a, 0xcfb5, 0x4319, 0xae, 0xfe, 0x6e, 0x42, 0xb2, 0x40, 0x61, 0x32);

    /// <summary>
    /// MF_MT_AUDIO_AVG_BYTES_PER_SECOND    {UINT32}
    /// </summary>
    public static readonly Guid MF_MT_AUDIO_AVG_BYTES_PER_SECOND = new(0x1aab75c8, 0xcfef, 0x451c, 0xab, 0x95, 0xac, 0x03, 0x4b, 0x8e, 0x17, 0x31);

    /// <summary>
    /// MF_MT_AUDIO_BLOCK_ALIGNMENT         {UINT32}
    /// </summary>
    public static readonly Guid MF_MT_AUDIO_BLOCK_ALIGNMENT = new(0x322de230, 0x9eeb, 0x43bd, 0xab, 0x7a, 0xff, 0x41, 0x22, 0x51, 0x54, 0x1d);

    /// <summary>
    /// MF_MT_AUDIO_BITS_PER_SAMPLE         {UINT32}
    /// </summary>
    public static readonly Guid MF_MT_AUDIO_BITS_PER_SAMPLE = new(0xf2deb57f, 0x40fa, 0x4764, 0xaa, 0x33, 0xed, 0x4f, 0x2d, 0x1f, 0xf6, 0x69);

    /// <summary>
    /// MF_MT_AUDIO_VALID_BITS_PER_SAMPLE   {UINT32}
    /// </summary>
    public static readonly Guid MF_MT_AUDIO_VALID_BITS_PER_SAMPLE = new(0xd9bf8d6a, 0x9530, 0x4b7c, 0x9d, 0xdf, 0xff, 0x6f, 0xd5, 0x8b, 0xbd, 0x06);

    /// <summary>
    /// MF_MT_AUDIO_SAMPLES_PER_BLOCK       {UINT32}
    /// </summary>
    public static readonly Guid MF_MT_AUDIO_SAMPLES_PER_BLOCK = new(0xaab15aac, 0xe13a, 0x4995, 0x92, 0x22, 0x50, 0x1e, 0xa1, 0x5c, 0x68, 0x77);

    /// <summary>
    /// MF_MT_AUDIO_CHANNEL_MASK            {UINT32}
    /// </summary>
    public static readonly Guid MF_MT_AUDIO_CHANNEL_MASK = new(0x55fb5765, 0x644a, 0x4caf, 0x84, 0x79, 0x93, 0x89, 0x83, 0xbb, 0x15, 0x88);

    /// <summary>
    /// MF_MT_FRAME_SIZE                {UINT64 (HI32(Width),LO32(Height))}
    /// </summary>
    public static readonly Guid MF_MT_FRAME_SIZE = new(0x1652c33d, 0xd6b2, 0x4012, 0xb8, 0x34, 0x72, 0x03, 0x08, 0x49, 0xa3, 0x7d);

    /// <summary>
    /// MF_MT_FRAME_RATE                {UINT64 (HI32(Numerator),LO32(Denominator))}
    /// </summary>
    public static readonly Guid MF_MT_FRAME_RATE = new(0xc459a2e8, 0x3d2c, 0x4e44, 0xb1, 0x32, 0xfe, 0xe5, 0x15, 0x6c, 0x7b, 0xb0);

    /// <summary>
    /// MF_MT_PIXEL_ASPECT_RATIO        {UINT64 (HI32(Numerator),LO32(Denominator))}
    /// </summary>
    public static readonly Guid MF_MT_PIXEL_ASPECT_RATIO = new(0xc6376a1e, 0x8d0a, 0x4027, 0xbe, 0x45, 0x6d, 0x9a, 0x0a, 0xd3, 0x9b, 0xb6);

    /// <summary>
    /// MF_MT_INTERLACE_MODE            {UINT32 (oneof MFVideoInterlaceMode)}
    /// </summary>
    public static readonly Guid MF_MT_INTERLACE_MODE = new(0xe2724bb8, 0xe676, 0x4806, 0xb4, 0xb2, 0xa8, 0xd6, 0xef, 0xb4, 0x4c, 0xcd);

    /// <summary>
    /// MF_MT_AVG_BITRATE               {UINT32}
    /// </summary>
    public static readonly Guid MF_MT_AVG_BITRATE = new(0x20332624, 0xfb0d, 0x4d9e, 0xbd, 0x0d, 0xcb, 0xf6, 0x78, 0x6c, 0x10, 0x2e);

    /// <summary>
    /// MF_MT_AVG_BIT_ERROR_RATE        {UINT32}
    /// </summary>
    public static readonly Guid MF_MT_AVG_BIT_ERROR_RATE = new(0x799cabd6, 0x3508, 0x4db4, 0xa3, 0xc7, 0x56, 0x9c, 0xd5, 0x33, 0xde, 0xb1);

    /// <summary>
    /// MF_MT_MAX_KEYFRAME_SPACING      {UINT32}
    /// </summary>
    public static readonly Guid MF_MT_MAX_KEYFRAME_SPACING = new(0xc16eb52b, 0x73a1, 0x476f, 0x8d, 0x62, 0x83, 0x9d, 0x6a, 0x02, 0x06, 0x52);

    /// <summary>
    /// MF_MT_OUTPUT_BUFFER_NUM {UINT32}
    /// </summary>
    public static readonly Guid MF_MT_OUTPUT_BUFFER_NUM = new(0xa505d3ac, 0xf930, 0x436e, 0x8e, 0xde, 0x93, 0xa5, 0x09, 0xce, 0x23, 0xb2);
}
