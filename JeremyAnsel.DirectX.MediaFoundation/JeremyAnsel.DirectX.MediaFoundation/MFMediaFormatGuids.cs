namespace JeremyAnsel.DirectX.MediaFoundation;

public static class MFMediaFormatGuids
{
    public static uint FCC(string ch4)
    {
        return ((uint)(byte)ch4[3] << 24) | ((uint)(byte)ch4[2] << 16) | ((uint)(byte)ch4[1] << 8) | (byte)ch4[0];
    }

    public static Guid DEFINE_MEDIATYPE_GUID(uint format)
    {
        return new Guid(format, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xaa, 0x00, 0x38, 0x9b, 0x71);
    }

    public static class Video
    {
        public static readonly Guid Base = DEFINE_MEDIATYPE_GUID(0);
        public static readonly Guid RGB32 = DEFINE_MEDIATYPE_GUID(22);
        public static readonly Guid ARGB32 = DEFINE_MEDIATYPE_GUID(21);
        public static readonly Guid RGB24 = DEFINE_MEDIATYPE_GUID(20);
        public static readonly Guid RGB555 = DEFINE_MEDIATYPE_GUID(24);
        public static readonly Guid RGB565 = DEFINE_MEDIATYPE_GUID(23);
        public static readonly Guid RGB8 = DEFINE_MEDIATYPE_GUID(41);
        public static readonly Guid L8 = DEFINE_MEDIATYPE_GUID(50);
        public static readonly Guid L16 = DEFINE_MEDIATYPE_GUID(81);
        public static readonly Guid D16 = DEFINE_MEDIATYPE_GUID(80);
        public static readonly Guid AI44 = DEFINE_MEDIATYPE_GUID(FCC("AI44"));
        public static readonly Guid AYUV = DEFINE_MEDIATYPE_GUID(FCC("AYUV"));
        public static readonly Guid YUY2 = DEFINE_MEDIATYPE_GUID(FCC("YUY2"));
        public static readonly Guid YVYU = DEFINE_MEDIATYPE_GUID(FCC("YVYU"));
        public static readonly Guid YVU9 = DEFINE_MEDIATYPE_GUID(FCC("YVU9"));
        public static readonly Guid UYVY = DEFINE_MEDIATYPE_GUID(FCC("UYVY"));
        public static readonly Guid NV11 = DEFINE_MEDIATYPE_GUID(FCC("NV11"));
        public static readonly Guid NV12 = DEFINE_MEDIATYPE_GUID(FCC("NV12"));
        public static readonly Guid NV21 = DEFINE_MEDIATYPE_GUID(FCC("NV21"));
        public static readonly Guid YV12 = DEFINE_MEDIATYPE_GUID(FCC("YV12"));
        public static readonly Guid I420 = DEFINE_MEDIATYPE_GUID(FCC("I420"));
        public static readonly Guid I422 = DEFINE_MEDIATYPE_GUID(FCC("I422"));
        public static readonly Guid I444 = DEFINE_MEDIATYPE_GUID(FCC("I444"));
        public static readonly Guid IYUV = DEFINE_MEDIATYPE_GUID(FCC("IYUV"));
        public static readonly Guid Y210 = DEFINE_MEDIATYPE_GUID(FCC("Y210"));
        public static readonly Guid Y216 = DEFINE_MEDIATYPE_GUID(FCC("Y216"));
        public static readonly Guid Y410 = DEFINE_MEDIATYPE_GUID(FCC("Y410"));
        public static readonly Guid Y416 = DEFINE_MEDIATYPE_GUID(FCC("Y416"));
        public static readonly Guid Y41P = DEFINE_MEDIATYPE_GUID(FCC("Y41P"));
        public static readonly Guid Y41T = DEFINE_MEDIATYPE_GUID(FCC("Y41T"));
        public static readonly Guid Y42T = DEFINE_MEDIATYPE_GUID(FCC("Y42T"));
        public static readonly Guid P210 = DEFINE_MEDIATYPE_GUID(FCC("P210"));
        public static readonly Guid P216 = DEFINE_MEDIATYPE_GUID(FCC("P216"));
        public static readonly Guid P010 = DEFINE_MEDIATYPE_GUID(FCC("P010"));
        public static readonly Guid P016 = DEFINE_MEDIATYPE_GUID(FCC("P016"));
        public static readonly Guid v210 = DEFINE_MEDIATYPE_GUID(FCC("v210"));
        public static readonly Guid v216 = DEFINE_MEDIATYPE_GUID(FCC("v216"));
        public static readonly Guid v410 = DEFINE_MEDIATYPE_GUID(FCC("v410"));
        public static readonly Guid MP43 = DEFINE_MEDIATYPE_GUID(FCC("MP43"));
        public static readonly Guid MP4S = DEFINE_MEDIATYPE_GUID(FCC("MP4S"));
        public static readonly Guid M4S2 = DEFINE_MEDIATYPE_GUID(FCC("M4S2"));
        public static readonly Guid MP4V = DEFINE_MEDIATYPE_GUID(FCC("MP4V"));
        public static readonly Guid WMV1 = DEFINE_MEDIATYPE_GUID(FCC("WMV1"));
        public static readonly Guid WMV2 = DEFINE_MEDIATYPE_GUID(FCC("WMV2"));
        public static readonly Guid WMV3 = DEFINE_MEDIATYPE_GUID(FCC("WMV3"));
        public static readonly Guid WVC1 = DEFINE_MEDIATYPE_GUID(FCC("WVC1"));
        public static readonly Guid MSS1 = DEFINE_MEDIATYPE_GUID(FCC("MSS1"));
        public static readonly Guid MSS2 = DEFINE_MEDIATYPE_GUID(FCC("MSS2"));
        public static readonly Guid MPG1 = DEFINE_MEDIATYPE_GUID(FCC("MPG1"));
        public static readonly Guid DVSL = DEFINE_MEDIATYPE_GUID(FCC("dvsl"));
        public static readonly Guid DVSD = DEFINE_MEDIATYPE_GUID(FCC("dvsd"));
        public static readonly Guid DVHD = DEFINE_MEDIATYPE_GUID(FCC("dvhd"));
        public static readonly Guid DV25 = DEFINE_MEDIATYPE_GUID(FCC("dv25"));
        public static readonly Guid DV50 = DEFINE_MEDIATYPE_GUID(FCC("dv50"));
        public static readonly Guid DVH1 = DEFINE_MEDIATYPE_GUID(FCC("dvh1"));
        public static readonly Guid DVC = DEFINE_MEDIATYPE_GUID(FCC("dvc "));
        public static readonly Guid H264 = DEFINE_MEDIATYPE_GUID(FCC("H264"));
        public static readonly Guid H265 = DEFINE_MEDIATYPE_GUID(FCC("H265"));
        public static readonly Guid MJPG = DEFINE_MEDIATYPE_GUID(FCC("MJPG"));
        public static readonly Guid _420O = DEFINE_MEDIATYPE_GUID(FCC("420O"));
        public static readonly Guid HEVC = DEFINE_MEDIATYPE_GUID(FCC("HEVC"));
        public static readonly Guid HEVC_ES = DEFINE_MEDIATYPE_GUID(FCC("HEVS"));
        public static readonly Guid VP80 = DEFINE_MEDIATYPE_GUID(FCC("VP80"));
        public static readonly Guid VP90 = DEFINE_MEDIATYPE_GUID(FCC("VP90"));
        public static readonly Guid ORAW = DEFINE_MEDIATYPE_GUID(FCC("ORAW"));
    }

    public static class Audio
    {
        public static readonly Guid Base = DEFINE_MEDIATYPE_GUID(0x00);
        public static readonly Guid PCM = DEFINE_MEDIATYPE_GUID(0x01);
        public static readonly Guid Float = DEFINE_MEDIATYPE_GUID(0x03);
        public static readonly Guid MP3 = DEFINE_MEDIATYPE_GUID(0x0055);
        public static readonly Guid AAC = DEFINE_MEDIATYPE_GUID(0x1610);
        public static readonly Guid FLAC = DEFINE_MEDIATYPE_GUID(0xF1AC);
        public static readonly Guid Opus = DEFINE_MEDIATYPE_GUID(0x704F);
    }

    public static class Image
    {
        public static readonly Guid JPEG = new(0x19e4a5aa, 0x5662, 0x4fc5, 0xa0, 0xc0, 0x17, 0x58, 0x02, 0x8e, 0x10, 0x57);
        public static readonly Guid RGB32 = new(0x00000016, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xaa, 0x00, 0x38, 0x9b, 0x71);
    }
}
