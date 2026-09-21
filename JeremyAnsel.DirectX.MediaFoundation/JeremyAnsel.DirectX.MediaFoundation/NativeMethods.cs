using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.MediaFoundation;

/// <summary>
/// Native methods.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal unsafe static partial class NativeMethods
{
    /// <summary>
    /// Initializes the platform object.
    /// Must be called before using Media Foundation.
    /// A matching MFShutdown call must be made when the application is done using
    /// Media Foundation.
    /// The "Version" parameter should be set to MF_API_VERSION.
    /// Application should not call MFStartup / MFShutdown from workqueue threads
    /// </summary>
    /// <param name="version">0x20070</param>
    /// <param name="dwFlags">0</param>
    /// <returns></returns>
#if NET8_0_OR_GREATER
    [LibraryImport("Mfplat.dll", EntryPoint = "MFStartup")]
    public static partial int MFStartup(
#else
    [DllImport("Mfplat.dll", EntryPoint = "MFStartup")]
    public static extern int MFStartup(
#endif
        uint version,
        uint dwFlags
        );

    /// <summary>
    /// Shuts down the platform object.
    /// Releases all resources including threads.
    /// Application should call MFShutdown the same number of times as MFStartup.
    /// Application should not call MFStartup / MFShutdown from workqueue threads.
    /// </summary>
    /// <returns></returns>
#if NET8_0_OR_GREATER
    [LibraryImport("Mfplat.dll", EntryPoint = "MFShutdown")]
    public static partial int MFShutdown(
#else
    [DllImport("Mfplat.dll", EntryPoint = "MFShutdown")]
    public static extern int MFShutdown(
#endif
        );

    /// <summary>
    /// Creates an IMFMediaBuffer in memory.
    /// </summary>
    /// <param name="cbMaxLength"></param>
    /// <param name="ppBuffer"></param>
    /// <returns></returns>
#if NET8_0_OR_GREATER
    [LibraryImport("Mfplat.dll", EntryPoint = "MFCreateMemoryBuffer")]
    public static partial int MFCreateMemoryBuffer(
#else
    [DllImport("Mfplat.dll", EntryPoint = "MFCreateMemoryBuffer")]
    public static extern int MFCreateMemoryBuffer(
#endif
        uint cbMaxLength,
        nint* ppBuffer
        );

    /// <summary>
    /// Creates an IMFMediaBuffer wrapper at the given offset and length
    /// within an existing IMFMediaBuffer
    /// </summary>
    /// <param name="pBuffer"></param>
    /// <param name="cbOffset"></param>
    /// <param name="dwLength"></param>
    /// <param name="ppBuffer"></param>
    /// <returns></returns>
#if NET8_0_OR_GREATER
    [LibraryImport("Mfplat.dll", EntryPoint = "MFCreateMediaBufferWrapper")]
    public static partial int MFCreateMediaBufferWrapper(
#else
    [DllImport("Mfplat.dll", EntryPoint = "MFCreateMediaBufferWrapper")]
    public static extern int MFCreateMediaBufferWrapper(
#endif
        nint pBuffer,
        uint cbOffset,
        uint dwLength,
        nint* ppBuffer
        );

    /// <summary>
    /// D3D11Texture2D
    /// </summary>
    /// <param name="riid"></param>
    /// <param name="punkSurface"></param>
    /// <param name="uSubresourceIndex"></param>
    /// <param name="fBottomUpWhenLinear"></param>
    /// <param name="ppBuffer"></param>
    /// <returns></returns>
#if NET8_0_OR_GREATER
    [LibraryImport("Mfplat.dll", EntryPoint = "MFCreateDXGISurfaceBuffer")]
    public static partial int MFCreateDXGISurfaceBuffer(
#else
    [DllImport("Mfplat.dll", EntryPoint = "MFCreateDXGISurfaceBuffer")]
    public static extern int MFCreateDXGISurfaceBuffer(
#endif
        Guid* riid,
        nint punkSurface,
        uint uSubresourceIndex,
        int fBottomUpWhenLinear,
        nint* ppBuffer
        );

#if NET8_0_OR_GREATER
    [LibraryImport("Mfplat.dll", EntryPoint = "MFCreateAttributes")]
    public static partial int MFCreateAttributes(
#else
    [DllImport("Mfplat.dll", EntryPoint = "MFCreateAttributes")]
    public static extern int MFCreateAttributes(
#endif
        nint* ppMFAttributes,
        uint cInitialSize
        );

#if NET8_0_OR_GREATER
    [LibraryImport("Mfplat.dll", EntryPoint = "MFCreateSample")]
    public static partial int MFCreateSample(
#else
    [DllImport("Mfplat.dll", EntryPoint = "MFCreateSample")]
    public static extern int MFCreateSample(
#endif
        nint* ppIMFSample
        );

#if NET8_0_OR_GREATER
    [LibraryImport("Mfplat.dll", EntryPoint = "MFCreateMediaType")]
    public static partial int MFCreateMediaType(
#else
    [DllImport("Mfplat.dll", EntryPoint = "MFCreateMediaType")]
    public static extern int MFCreateMediaType(
#endif
        nint* ppMFType
        );

#if NET8_0_OR_GREATER
    [LibraryImport("Mfreadwrite.dll", EntryPoint = "MFCreateSinkWriterFromURL")]
    public static partial int MFCreateSinkWriterFromURL(
#else
    [DllImport("Mfreadwrite.dll", EntryPoint = "MFCreateSinkWriterFromURL")]
    public static extern int MFCreateSinkWriterFromURL(
#endif
        char* pwszOutputURL,
        nint pByteStream,
        nint pAttributes,
        nint* ppSinkWriter
        );

#if NET8_0_OR_GREATER
    [LibraryImport("Mfreadwrite.dll", EntryPoint = "MFCreateSourceReaderFromURL")]
    public static partial int MFCreateSourceReaderFromURL(
#else
    [DllImport("Mfreadwrite.dll", EntryPoint = "MFCreateSourceReaderFromURL")]
    public static extern int MFCreateSourceReaderFromURL(
#endif
        char* pwszURL,
        nint pAttributes,
        nint* ppSourceReader
        );

#if NET8_0_OR_GREATER
    [LibraryImport("Mfplat.dll", EntryPoint = "MFCalculateImageSize")]
    public static partial int MFCalculateImageSize(
#else
    [DllImport("Mfplat.dll", EntryPoint = "MFCalculateImageSize")]
    public static extern int MFCalculateImageSize(
#endif
        Guid* guidSubtype,
        uint unWidth,
        uint unHeight,
        uint* pcbImageSize
        );

#if NET8_0_OR_GREATER
    [LibraryImport("Mfplat.dll", EntryPoint = "MFFrameRateToAverageTimePerFrame")]
    public static partial int MFFrameRateToAverageTimePerFrame(
#else
    [DllImport("Mfplat.dll", EntryPoint = "MFFrameRateToAverageTimePerFrame")]
    public static extern int MFFrameRateToAverageTimePerFrame(
#endif
        uint unNumerator,
        uint unDenominator,
        ulong* punAverageTimePerFrame
        );

#if NET8_0_OR_GREATER
    [LibraryImport("Mfplat.dll", EntryPoint = "MFAverageTimePerFrameToFrameRate")]
    public static partial int MFAverageTimePerFrameToFrameRate(
#else
    [DllImport("Mfplat.dll", EntryPoint = "MFAverageTimePerFrameToFrameRate")]
    public static extern int MFAverageTimePerFrameToFrameRate(
#endif
        ulong unAverageTimePerFrame,
        uint* punNumerator,
        uint* punDenominator
        );

#if NET8_0_OR_GREATER
    [LibraryImport("Mfplat.dll", EntryPoint = "MFCreateDXGIDeviceManager")]
    public static partial int MFCreateDXGIDeviceManager(
#else
    [DllImport("Mfplat.dll", EntryPoint = "MFCreateDXGIDeviceManager")]
    public static extern int MFCreateDXGIDeviceManager(
#endif
        uint* resetToken,
        nint* ppDeviceManager
        );
}
