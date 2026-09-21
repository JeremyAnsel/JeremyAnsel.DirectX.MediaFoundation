namespace JeremyAnsel.DirectX.MediaFoundation;

public enum MFVideoInterlaceMode
{
    /// <summary>
    /// This is an invalid flag and will be deleted before release. 
    /// </summary>
    Unknown = 0,

    Progressive = 2,
    FieldInterleavedUpperFirst = 3,
    FieldInterleavedLowerFirst = 4,
    FieldSingleUpper = 5,
    FieldSingleLower = 6,
    MixedInterlaceOrProgressive = 7,
}
