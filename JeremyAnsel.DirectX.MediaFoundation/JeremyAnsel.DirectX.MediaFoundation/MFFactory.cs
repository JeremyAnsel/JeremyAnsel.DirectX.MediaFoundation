using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.MediaFoundation;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public sealed unsafe class MFFactory : IDisposable
{
    /// <summary>
    /// Initializes the platform object.
    /// Must be called before using Media Foundation.
    /// A matching MFShutdown call must be made when the application is done using
    /// Media Foundation.
    /// The "Version" parameter should be set to MF_API_VERSION.
    /// Application should not call MFStartup / MFShutdown from workqueue threads.
    /// </summary>
    public MFFactory()
    {
        Marshal.ThrowExceptionForHR(NativeMethods.MFStartup(0x20070, 0));
    }

    /// <summary>
    /// Shuts down the platform object.
    /// Releases all resources including threads.
    /// Application should call MFShutdown the same number of times as MFStartup.
    /// Application should not call MFStartup / MFShutdown from workqueue threads.
    /// </summary>
    public void Dispose()
    {
        Marshal.ThrowExceptionForHR(NativeMethods.MFShutdown());
    }

    /// <summary>
    /// Creates a MFMediaBuffer in memory.
    /// </summary>
    /// <param name="cbMaxLength"></param>
    /// <returns></returns>
    public MFMediaBuffer CreateMemoryBuffer(uint cbMaxLength)
    {
        nint ptr;
        Marshal.ThrowExceptionForHR(NativeMethods.MFCreateMemoryBuffer(cbMaxLength, &ptr));
        return new MFMediaBuffer(ptr);
    }

    /// <summary>
    /// Creates a MFMediaBuffer wrapper at the given offset and length
    /// within an existing MFMediaBuffer
    /// </summary>
    /// <param name="pBuffer"></param>
    /// <param name="cbOffset"></param>
    /// <param name="dwLength"></param>
    /// <returns></returns>
    public MFMediaBuffer CreateMediaBufferWrapper(nint pBuffer, uint cbOffset, uint dwLength)
    {
        nint ptr;
        Marshal.ThrowExceptionForHR(NativeMethods.MFCreateMediaBufferWrapper(pBuffer, cbOffset, dwLength, &ptr));
        return new MFMediaBuffer(ptr);
    }

    /// <summary>
    /// Creates a MFMediaBuffer for a D3D11Texture2D or a D3D12Resource.
    /// </summary>
    /// <param name="riid"></param>
    /// <param name="punkSurface"></param>
    /// <param name="uSubresourceIndex"></param>
    /// <param name="fBottomUpWhenLinear"></param>
    /// <returns></returns>
    public MFMediaBuffer CreateDXGISurfaceBuffer(Guid riid, nint punkSurface, uint uSubresourceIndex, bool fBottomUpWhenLinear)
    {
        nint ptr;
        Marshal.ThrowExceptionForHR(NativeMethods.MFCreateDXGISurfaceBuffer(&riid, punkSurface, uSubresourceIndex, fBottomUpWhenLinear ? 1 : 0, &ptr));
        return new MFMediaBuffer(ptr);
    }

    /// <summary>
    /// Creates a MFAttributes.
    /// </summary>
    /// <param name="cInitialSize"></param>
    /// <returns></returns>
    public MFAttributes CreateAttributes(uint cInitialSize)
    {
        nint ptr;
        Marshal.ThrowExceptionForHR(NativeMethods.MFCreateAttributes(&ptr, cInitialSize));
        return new MFAttributes(ptr);
    }

    /// <summary>
    /// Creates a MFAttributes.
    /// </summary>
    /// <returns></returns>
    public MFAttributes CreateAttributes()
    {
        return CreateAttributes(0);
    }

    /// <summary>
    /// Creates a MFSample.
    /// </summary>
    /// <returns></returns>
    public MFSample CreateSample()
    {
        nint ptr;
        Marshal.ThrowExceptionForHR(NativeMethods.MFCreateSample(&ptr));
        return new MFSample(ptr);
    }

    public MFMediaType CreateMediaType()
    {
        nint ptr;
        Marshal.ThrowExceptionForHR(NativeMethods.MFCreateMediaType(&ptr));
        return new MFMediaType(ptr);
    }

    /// <summary>
    /// Creates the Sink Writer by specifying the output URL to generate.
    /// A suitable media archive sink is instantiated using the file extension
    /// of the URL.  The application can directly indicate which archive media
    /// sink to instantiate by setting the MF_TRANSCODE_CONTAINERTYPE attribute
    /// to one of the supported values.
    /// 
    ///     - pwszOutputURL specifies the URL of the content to generate.
    ///       If a bytestream is passed in and the container type attribute is set,
    ///       then the URL can be NULL, otherwise it is a required parameter.
    ///     - pByteStream can optionally specify a bytestream that has already been
    ///       opened for write access to the specified URL.  If this is NULL
    ////       then the Sink Writer will create its own bytestream.  Passing in a
    ///       bytestream can be useful for things like creating the bytestream
    ///       with admin privileges and then dropping down to an account with
    ///       lower privileges while encoding and writing to the bytestream.
    ///     - pAttributes specifies container or media sink encoding parameters.
    ///     - ppSinkWriter receives an instance of the MF Sink Writer
    /// </summary>
    /// <param name="pwszOutputURL"></param>
    /// <param name="pAttributes"></param>
    /// <returns></returns>
    public MFSinkWriter CreateSinkWriterFromURL(string pwszOutputURL, MFAttributes pAttributes)
    {
        char* url = stackalloc char[pwszOutputURL.Length + 1];
        for (int i = 0; i < pwszOutputURL.Length; i++)
        {
            url[i] = pwszOutputURL[i];
        }
        url[pwszOutputURL.Length] = (char)0;
        nint ptr;
        Marshal.ThrowExceptionForHR(NativeMethods.MFCreateSinkWriterFromURL(url, 0, pAttributes.Handle, &ptr));
        return new MFSinkWriter(ptr);
    }

    /// <summary>
    ///      This function is used to instantiate an MF Source Reader object for
    ///      the specified URL.
    /// </summary>
    /// <param name="pwszURL">
    ///      URL that specifies the location of the media content to open.
    /// </param>
    /// <param name="pAttributes">
    ///      Optional parameter specifying additional Source Reader configuration.
    ///      See: section below on MF Source Reader Attributes
    /// </param>
    /// <param name="ppSourceReader">
    ///     Specifies a pointer to a variable where the source reader object
    ///     will be stored.
    /// </param>
    /// <remarks>
    ///     This function is synchronous and performs I/O that can
    ///     block the calling thread.
    /// </remarks>
    public MFSourceReader CreateSourceReaderFromURL(string pwszURL, MFAttributes pAttributes)
    {
        char* url = stackalloc char[pwszURL.Length + 1];
        for (int i = 0; i < pwszURL.Length; i++)
        {
            url[i] = pwszURL[i];
        }
        url[pwszURL.Length] = (char)0;
        nint ptr;
        Marshal.ThrowExceptionForHR(NativeMethods.MFCreateSourceReaderFromURL(url, pAttributes.Handle, &ptr));
        return new MFSourceReader(ptr);
    }

    public MFDXGIDeviceManager CreateDXGIDeviceManager(out uint resetToken)
    {
        nint ptr;
        uint token;
        Marshal.ThrowExceptionForHR(NativeMethods.MFCreateDXGIDeviceManager(&token, &ptr));
        resetToken = token;
        return new MFDXGIDeviceManager(ptr);
    }
}
