using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.MediaFoundation;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class MFDXGIDeviceManager : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid MFDXGIDeviceManagerGuid = new(IMFDXGIDeviceManager.Guid);

    private readonly nint _comPtr;
    private readonly IMFDXGIDeviceManager* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="MFDXGIDeviceManager"/> class.
    /// </summary>
    public MFDXGIDeviceManager(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IMFDXGIDeviceManager**)comPtr;
    }

    public void CloseDeviceHandle(nint hDevice)
    {
        Marshal.ThrowExceptionForHR(_comImpl->CloseDeviceHandle(_comPtr, hDevice));
    }

    public nint LockDevice(nint hDevice, Guid riid, bool fBlock)
    {
        nint ptr;
        Marshal.ThrowExceptionForHR(_comImpl->LockDevice(_comPtr, hDevice, &riid, &ptr, fBlock ? 1U : 0U));
        return ptr;
    }

    public nint OpenDeviceHandle()
    {
        nint ptr;
        Marshal.ThrowExceptionForHR(_comImpl->OpenDeviceHandle(_comPtr, &ptr));
        return ptr;
    }

    public void ResetDevice(nint pUnkDevice, uint resetToken)
    {
        Marshal.ThrowExceptionForHR(_comImpl->ResetDevice(_comPtr, pUnkDevice, resetToken));
    }

    public void TestDevice(nint hDevice)
    {
        Marshal.ThrowExceptionForHR(_comImpl->TestDevice(_comPtr, hDevice));
    }

    public void UnlockDevice(nint hDevice, bool fSaveState)
    {
        Marshal.ThrowExceptionForHR(_comImpl->UnlockDevice(_comPtr, hDevice, fSaveState ? 1U : 0U));
    }
}
