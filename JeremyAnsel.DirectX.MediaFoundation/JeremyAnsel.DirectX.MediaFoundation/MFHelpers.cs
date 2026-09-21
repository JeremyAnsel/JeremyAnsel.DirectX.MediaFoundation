using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.MediaFoundation;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public static unsafe class MFHelpers
{
    public static uint CalculateImageSize(Guid guidSubtype, uint unWidth, uint unHeight)
    {
        uint cbImageSize;
        Marshal.ThrowExceptionForHR(NativeMethods.MFCalculateImageSize(&guidSubtype, unWidth, unHeight, &cbImageSize));
        return cbImageSize;
    }

    public static ulong FrameRateToAverageTimePerFrame(uint unNumerator, uint unDenominator)
    {
        ulong unAverageTimePerFrame;
        Marshal.ThrowExceptionForHR(NativeMethods.MFFrameRateToAverageTimePerFrame(unNumerator, unDenominator, &unAverageTimePerFrame));
        return unAverageTimePerFrame;
    }

    public static void AverageTimePerFrameToFrameRate(ulong unAverageTimePerFrame, out uint punNumerator, out uint punDenominator)
    {
        uint unNumerator;
        uint unDenominator;
        Marshal.ThrowExceptionForHR(NativeMethods.MFAverageTimePerFrameToFrameRate(unAverageTimePerFrame, &unNumerator, &unDenominator));
        punNumerator = unNumerator;
        punDenominator = unDenominator;
    }

    public static uint HI32(ulong unPacked)
    {
        return (uint)(unPacked >> 32);
    }

    public static uint LO32(ulong unPacked)
    {
        return (uint)unPacked;
    }

    public static ulong Pack2UINT32AsUINT64(uint unHigh, uint unLow)
    {
        return ((ulong)unHigh << 32) | unLow;
    }

    public static void Unpack2UINT32AsUINT64(ulong unPacked, out uint punHigh, out uint punLow)
    {
        punHigh = HI32(unPacked);
        punLow = LO32(unPacked);
    }

    public static ulong PackSize(uint unWidth, uint unHeight)
    {
        return Pack2UINT32AsUINT64(unWidth, unHeight);
    }

    public static void UnpackSize(ulong unPacked, out uint punWidth, out uint punHeight)
    {
        Unpack2UINT32AsUINT64(unPacked, out punWidth, out punHeight);
    }

    public static ulong PackRatio(int nNumerator, uint unDenominator)
    {
        return Pack2UINT32AsUINT64((uint)nNumerator, unDenominator);
    }

    public static void UnpackRatio(ulong unPacked, out int pnNumerator, out uint punDenominator)
    {
        Unpack2UINT32AsUINT64(unPacked, out uint nNumerator, out punDenominator);
        pnNumerator = (int)nNumerator;
    }
}
