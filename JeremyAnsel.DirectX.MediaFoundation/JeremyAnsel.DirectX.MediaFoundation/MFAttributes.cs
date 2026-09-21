using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.MediaFoundation.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.MediaFoundation;

/// <summary>
///     The IMFAttributes interface is a general-purpose interface for storing
///     key/value pairs, where the key is a GUID and the value is one of a
///     small number of common data types, including UINT32, UINT64, double,
///     GUID, Unicode string, and BLOB (counted array of UINT8).  In addition
///     to the methods inherited from IUnknown, the IMFAttributes interface
///     exposes the following methods.
/// </summary>
/// <remarks>
///     <para>
///         The LockStore and UnlockStore calls may not be nested, and may not
///         be called from different threads.
///     </para>
/// </remarks>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class MFAttributes : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid MFAttributesGuid = new(IMFAttributes.Guid);

    private readonly nint _comPtr;
    private readonly IMFAttributes* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="MFAttributes"/> class.
    /// </summary>
    public MFAttributes(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IMFAttributes**)comPtr;
    }

    /// <summary>
    ///     GetItemType returns the type of a value from the attributes store
    ///     that corresponds to the given key (a GUID).
    /// </summary>
    /// <param name="guidKey">
    ///     Key corresponding to value to search for
    /// </param>
    /// <param name="pType">
    ///     Pointer to an MF_ATTRIBUTE_TYPE value.  It is filled in with a copy
    ///     of the type of the stored value, if the value is found.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             The key exists, and the value of pType signifies the type of
    ///             the item value.
    ///     </para>
    ///     <para>
    ///         MF_E_ATTRIBUTENOTFOUND.
    ///             No value corresponding to this key is stored in this object.
    ///     </para>
    /// </returns>
    public int GetItemType(Guid guidKey)
    {
        int value;
        Marshal.ThrowExceptionForHR(_comImpl->GetItemType(_comPtr, &guidKey, &value));
        return value;
    }

    /// <summary>
    ///     GetUINT32 retrieves a value of type UINT32 corresponding to the
    ///     given key.
    /// </summary>
    /// <param name="guidKey">
    ///     GUID specifying the value to retrieve.
    /// </param>
    /// <param name="punValue">
    ///     Value of the property, in a UINT32.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Value was found and retrieved successfully.
    ///     </para>
    ///     <para>
    ///         MF_E_INVALIDTYPE
    ///             Value was found, but is not of type UINT32.
    ///     </para>
    ///     <para>
    ///         MF_E_ATTRIBUTENOTFOUND.
    ///             No value corresponding to this key is stored in this object.
    ///     </para>
    /// </returns>
    public uint GetUINT32(Guid guidKey)
    {
        uint value;
        Marshal.ThrowExceptionForHR(_comImpl->GetUINT32(_comPtr, &guidKey, &value));
        return value;
    }

    /// <summary>
    ///     GetUINT64 retrieves a value of type UINT64 corresponding to the
    ///     given key.
    /// </summary>
    /// <param name="guidKey">
    ///     GUID specifying the value to retrieve.
    /// </param>
    /// <param name="punValue">
    ///     Value of the property, in a UINT64.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Value was found and retrieved successfully.
    ///     </para>
    ///     <para>
    ///         MF_E_INVALIDTYPE
    ///             Value was found, but is not of type UINT64.
    ///     </para>
    ///     <para>
    ///         MF_E_ATTRIBUTENOTFOUND.
    ///             No value corresponding to this key is stored in this object.
    ///     </para>
    /// </returns>
    public ulong GetUINT64(Guid guidKey)
    {
        ulong value;
        Marshal.ThrowExceptionForHR(_comImpl->GetUINT64(_comPtr, &guidKey, &value));
        return value;
    }

    /// <summary>
    ///     GetDouble retrieves a value of type double corresponding to the
    ///     given key.
    /// </summary>
    /// <param name="guidKey">
    ///     GUID specifying the value to retrieve.
    /// </param>
    /// <param name="pfValue">
    ///     Value of the property, in a double.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Value was found and retrieved successfully.
    ///     </para>
    ///     <para>
    ///         MF_E_INVALIDTYPE
    ///             Value was found, but is not of type double.
    ///     </para>
    ///     <para>
    ///         MF_E_ATTRIBUTENOTFOUND.
    ///             No value corresponding to this key is stored in this object.
    ///     </para>
    /// </returns>
    public double GetDouble(Guid guidKey)
    {
        double value;
        Marshal.ThrowExceptionForHR(_comImpl->GetDouble(_comPtr, &guidKey, &value));
        return value;
    }

    /// <summary>
    ///     GetGUID retrieve a value of type GUID corresponding to the given
    ///     key.
    /// </summary>
    /// <param name="guidKey">
    ///     GUID specifying the value to retrieve.
    /// </param>
    /// <param name="pguidValue">
    ///     Value of the property, in a GUID.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Value was found and retrieved successfully.
    ///     </para>
    ///     <para>
    ///         MF_E_INVALIDTYPE
    ///             Value was found, but is not of type GUID.
    ///     </para>
    ///     <para>
    ///         MF_E_ATTRIBUTENOTFOUND.
    ///             No value corresponding to this key is stored in this object.
    ///     </para>
    /// </returns>
    public Guid GetGUID(Guid guidKey)
    {
        Guid value;
        Marshal.ThrowExceptionForHR(_comImpl->GetGUID(_comPtr, &guidKey, &value));
        return value;
    }

    /// <summary>
    ///     GetStringLength retrieve the length of a string value corresponding
    ///     to the given key.
    /// </summary>
    /// <param name="guidKey">
    ///     GUID specifying the value to check.
    /// </param>
    /// <param name="pcchLength">
    ///     Upon success, holds the length of the string, in characters, not
    ///     including the NULL terminator.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Value was found and retrieved successfully.
    ///     </para>
    ///     <para>
    ///         E_OUTOFMEMORY
    ///             Value was found, but string length is too large to fit in a
    ///             UINT32 value.
    ///     </para>
    ///     <para>
    ///         MF_E_INVALIDTYPE
    ///             Value was found, but is not of type LPWSTR.
    ///     </para>
    ///     <para>
    ///         MF_E_ATTRIBUTENOTFOUND.
    ///             No value corresponding to this key is stored in this object.
    ///     </para>
    /// </returns>
    public uint GetStringLength(Guid guidKey)
    {
        uint value;
        Marshal.ThrowExceptionForHR(_comImpl->GetStringLength(_comPtr, &guidKey, &value));
        return value;
    }

    /// <summary>
    ///     GetString retrieves a string value corresponding to the given key.
    /// </summary>
    /// <param name="guidKey">
    ///     GUID specifying the value to retrieve.
    /// </param>
    /// <param name="pwszValue">
    ///     Upon success, holds the retrieved LPWSTR value.
    /// </param>
    /// <param name="cchBufSize">
    ///     Specifies the size, in characters, of the buffer passed in the
    ///     pwszValue parameter.  Note that this is the size of the entire
    ///     buffer, not string length, so no further space for NULL
    ///     termination will be assumed.
    /// </param>
    /// <param name="pcchLength">
    ///     Upon success, contains the length, in characters, of the string in the
    ///     pwszValue parameter, excluding NULL termination.  pcchLength may be
    ///     NULL if the length of the return string is not needed.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Value was found and retrieved successfully.
    ///     </para>
    ///     <para>
    ///         E_OUTOFMEMORY
    ///             Value was found, but string length is too large to fit in a
    ///             UINT32 value.
    ///     </para>
    ///     <para>
    ///         HRESULT_FROM_WIN32( ERROR_INSUFFICIENT_BUFFER )
    ///             cchBufSize was not sufficiently large to hold the string
    ///             value with NULL terminator.  In this case, *pcchLength will be
    ///             set to the length of the string value in chars.  The caller
    ///             will need to allocate a buffer of size at least
    ///             *ppchLength + 1 chars and call the method again.
    ///     </para>
    ///     <para>
    ///         MF_E_INVALIDTYPE
    ///             Value was found, but is not of type LPWSTR.
    ///     </para>
    ///     <para>
    ///         MF_E_ATTRIBUTENOTFOUND.
    ///             No value corresponding to this key is stored in this object.
    ///     </para>
    /// </returns>
    public string GetString(Guid guidKey)
    {
        uint length = GetStringLength(guidKey);
        char* str = stackalloc char[(int)length + 1];
        Marshal.ThrowExceptionForHR(_comImpl->GetString(_comPtr, &guidKey, str, length, null));
        str[(int)length] = (char)0;
        return new string(str);
    }

    /// <summary>
    ///     GetUnknown retrieves an interface pointer to the requested
    //      interface, in an LPVOID, from the value corresponding to the given
    ///     key.
    /// </summary>
    /// <param name="guidKey">
    ///     GUID specifying the value to retrieve.
    /// </param>
    /// <param name="riid">
    ///
    /// <param name="ppv">
    ///     Value of the property, in an LPVOID.  Returned value needs to be cast
    ///     to an interface pointer of the appropriate type.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Value was found and retrieved successfully.
    ///     </para>
    ///     <para>
    ///         MF_E_INVALIDTYPE
    ///             Value was found, but is not of type IUnknown.
    ///     </para>
    ///     <para>
    ///         E_NOINTERFACE
    ///             Value was found, but does not support the interface
    ///             specified by the riid parameter.
    ///     </para>
    ///     <para>
    ///         MF_E_ATTRIBUTENOTFOUND.
    ///             No value corresponding to this key is stored in this object.
    ///     </para>
    /// </returns>
    /// <remarks>
    ///     It is the responsibility of the caller to call Release on the
    ///     returned interface pointer when done with it.
    /// </remarks>
    public nint GetUnknown(Guid guidKey, Guid riid)
    {
        nint ptr;
        Marshal.ThrowExceptionForHR(_comImpl->GetUnknown(_comPtr, &guidKey, &riid, &ptr));
        return ptr;
    }

    /// <summary>
    ///     DeleteItem removes the value associated with the specified key from
    ///     the attribute set.
    /// </summary>
    /// <param name="guidKey">
    ///     GUID specifying the key.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Value was successfully removed.
    ///     </para>
    /// </returns>
    public void DeleteItem(Guid guidKey)
    {
        Marshal.ThrowExceptionForHR(_comImpl->DeleteItem(_comPtr, &guidKey));
    }

    /// <summary>
    ///     DeleteAllItems removes all values from the attribute set.
    /// </summary>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             All values were successfully removed from the set.
    ///     </para>
    /// </returns>
    public void DeleteAllItems()
    {
        Marshal.ThrowExceptionForHR(_comImpl->DeleteAllItems(_comPtr));
    }

    /// <summary>
    ///     SetUINT32 associates the given UINT32 value with the specified key.
    /// </summary>
    /// <param name="guidKey">
    ///     GUID specifying the key.
    /// </param>
    /// <param name="unValue">
    ///     Value of the property.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Value was successfully set.
    ///     </para>
    ///     <para>
    ///         E_OUTOFMEMORY
    ///             Insufficient memory was available to create a new item in
    ///             the store.
    ///     </para>
    /// </returns>
    public void SetUINT32(Guid guidKey, uint unValue)
    {
        Marshal.ThrowExceptionForHR(_comImpl->SetUINT32(_comPtr, &guidKey, unValue));
    }

    /// <summary>
    ///     SetUINT64 associates the given UINT64 value with the specified key.
    /// </summary>
    /// <param name="guidKey">
    ///     GUID specifying the key.
    /// </param>
    /// <param name="unValue">
    ///     Value of the property.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Value was successfully set.
    ///     </para>
    ///     <para>
    ///         E_OUTOFMEMORY
    ///             Insufficient memory was available to create a new item in
    ///             the store.
    ///     </para>
    /// </returns>
    public void SetUINT64(Guid guidKey, ulong unValue)
    {
        Marshal.ThrowExceptionForHR(_comImpl->SetUINT64(_comPtr, &guidKey, unValue));
    }

    /// <summary>
    ///     SetDouble associates the given double value with the specified key.
    /// </summary>
    /// <param name="guidKey">
    ///     GUID specifying the key.
    /// </param>
    /// <param name="fValue">
    ///     Value of the property.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Value was successfully set.
    ///     </para>
    ///     <para>
    ///         E_OUTOFMEMORY
    ///             Insufficient memory was available to create a new item in
    ///             the store.
    ///     </para>
    /// </returns>
    public void SetDouble(Guid guidKey, double fValue)
    {
        Marshal.ThrowExceptionForHR(_comImpl->SetDouble(_comPtr, &guidKey, fValue));
    }

    /// <summary>
    ///     SetGUID associates the given GUID value with the specified key.
    /// </summary>
    /// <param name="guidKey">
    ///     GUID specifying the key.
    /// </param>
    /// <param name="guidValue">
    ///     Value of the property.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Value was successfully set.
    ///     </para>
    ///     <para>
    ///         E_OUTOFMEMORY
    ///             Insufficient memory was available to create a new item in
    ///             the store.
    ///     </para>
    /// </returns>
    public void SetGUID(Guid guidKey, Guid guidValue)
    {
        Marshal.ThrowExceptionForHR(_comImpl->SetGUID(_comPtr, &guidKey, &guidValue));
    }

    /// <summary>
    ///     SetString associates the given LPWSTR value with the specified key.
    /// </summary>
    /// <param name="guidKey">
    ///     GUID specifying the key.
    /// </param>
    /// <param name="wszValue">
    ///     Value of the property.  WszValue is presumed to be NULL-terminated.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Value was successfully set.
    ///     </para>
    ///     <para>
    ///         E_OUTOFMEMORY
    ///             Insufficient memory was available to create a new item in
    ///             the store.
    ///     </para>
    /// </returns>
    /// <remarks>
    ///      Callee will allocate a new buffer and copy the given string, rather
    ///      than storing a reference to the string passed in.  Thus, caller is
    ///      responsible for freeing any memory which may have been allocated
    ///      for wszValue.
    /// </remarks>
    public void SetString(Guid guidKey, string wszValue)
    {
        char* str = stackalloc char[wszValue.Length + 1];
        for (int i = 0; i < wszValue.Length; i++)
        {
            str[i] = wszValue[i];
        }
        str[wszValue.Length] = (char)0;
        Marshal.ThrowExceptionForHR(_comImpl->SetString(_comPtr, &guidKey, str));
    }

    /// <summary>
    ///     SetUnknown associates the given IUnknown interface pointer value
    ///     with the specified key.
    /// </summary>
    /// <param name="guidKey">
    ///     GUID specifying the key.
    /// </param>
    /// <param name="pUnknown">
    ///     Value of the property.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Value was successfully set.
    ///     </para>
    ///     <para>
    ///         E_OUTOFMEMORY
    ///             Insufficient memory was available to create a new item in
    ///             the store.
    ///     </para>
    /// </returns>
    public void SetUnknown(Guid guidKey, nint pUnknown)
    {
        Marshal.ThrowExceptionForHR(_comImpl->SetUnknown(_comPtr, &guidKey, pUnknown));
    }

    /// <summary>
    ///     LockStore excludes other threads from accessing the set, until such
    ///     time as UnlockStore is called.
    /// </summary>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Store was successfully locked.
    ///     </para>
    /// </returns>
    public void LockStore()
    {
        Marshal.ThrowExceptionForHR(_comImpl->LockStore(_comPtr));
    }

    /// <summary>
    ///     UnlockStore allows other threads access to the set, if they were
    ///     previously denied access via LockStore.
    /// </summary>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             Store was successfully unlocked.
    ///     </para>
    /// </returns>
    public void UnlockStore()
    {
        Marshal.ThrowExceptionForHR(_comImpl->UnlockStore(_comPtr));
    }

    /// <summary>
    ///     GetCount retrieves the number of items currently in the set.
    /// </summary>
    /// <param name="pcItems">
    ///     Upon success, will contain the count of items in the set.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             The call was successful, and *pcItems contains the number of
    ///             values in the set.
    ///     </para>
    /// </returns>
    public uint GetCount()
    {
        uint value;
        Marshal.ThrowExceptionForHR(_comImpl->GetCount(_comPtr, &value));
        return value;
    }

    /// <summary>
    ///     CopyAllItems clones all items from the store to the specified store.
    /// </summary>
    /// <param name="pDest">
    ///     pointer to an IMFAttributes interface which will recieve all items
    ///     from this set.
    /// </param>
    /// <returns>
    ///     <para>
    ///         S_OK.
    ///             The call was successful.
    ///     </para>
    ///     <para>
    ///         E_FAIL.
    ///             Copying one or more items from the store to the destination
    ///             was unsuccessful.
    ///     </para>
    /// </returns>
    /// <remarks>
    ///     <para>
    ///         Note that the pDest store must be unlocked in order to retrieve
    ///         or set items by key.
    ///     </para>
    ///     <para>
    ///         CopyAllItems is a destructive operation on the destination store.
    ///         In the event of a failure to copy all items, the state of the
    ///         pDest store is UNDEFINED.  Furthermore, any existing items in
    ///         the pDest store will be removed prior to copying items from the
    ///         source store.
    ///     </para>
    /// </remarks>
    public void CopyAllItems(MFAttributes pDest)
    {
        Marshal.ThrowExceptionForHR(_comImpl->CopyAllItems(_comPtr, pDest.Handle));
    }

    public uint GetAttributeUINT32(Guid guidKey, uint unDefault)
    {
        uint value;
        if (_comImpl->GetUINT32(_comPtr, &guidKey, &value) < 0)
        {
            value = unDefault;
        }
        return value;
    }

    public ulong GetAttributeUINT64(Guid guidKey, ulong unDefault)
    {
        ulong value;
        if (_comImpl->GetUINT64(_comPtr, &guidKey, &value) < 0)
        {
            value = unDefault;
        }
        return value;
    }

    public double GetAttributeDouble(Guid guidKey, double fDefault)
    {
        double value;
        if (_comImpl->GetDouble(_comPtr, &guidKey, &value) < 0)
        {
            value = fDefault;
        }
        return value;
    }

    public void GetAttribute2UINT32asUINT64(Guid guidKey, out uint punHigh32, out uint punLow32)
    {
        ulong unPacked = GetUINT64(guidKey);
        MFHelpers.Unpack2UINT32AsUINT64(unPacked, out punHigh32, out punLow32);
    }

    public void SetAttribute2UINT32asUINT64(Guid guidKey, uint unHigh32, uint unLow32)
    {
        SetUINT64(guidKey, MFHelpers.Pack2UINT32AsUINT64(unHigh32, unLow32));
    }

    public void GetAttributeRatio(Guid guidKey, out uint punNumerator, out uint punDenominator)
    {
        GetAttribute2UINT32asUINT64(guidKey, out punNumerator, out punDenominator);
    }

    public void GetAttributeSize(Guid guidKey, out uint punWidth, out uint punHeight)
    {
        GetAttribute2UINT32asUINT64(guidKey, out punWidth, out punHeight);
    }

    public void SetAttributeRatio(Guid guidKey, uint unNumerator, uint unDenominator)
    {
        SetAttribute2UINT32asUINT64(guidKey, unNumerator, unDenominator);
    }

    public void SetAttributeSize(Guid guidKey, uint unWidth, uint unHeight)
    {
        SetAttribute2UINT32asUINT64(guidKey, unWidth, unHeight);
    }
}
