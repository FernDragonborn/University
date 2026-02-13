using System.Runtime.InteropServices;
using System.Text;

namespace cryptographyLib;

[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public partial class WinCryptoWrapper : IDisposable
{
    private const uint ProvRsaFull = 1;
    private const uint CryptVerifycontext = 0xF0000000;
    private const uint AlgClassDataEncrypt = 3 << 13;
    private const uint AlgTypeStream = 4 << 9;
    private const uint AlgSidRc4 = 1;
    private const uint CalgRc4 = (AlgClassDataEncrypt | AlgTypeStream | AlgSidRc4);
    private const uint CryptExportable = 0x00000001;
    
    [LibraryImport("advapi32.dll", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool CryptAcquireContext(
        out IntPtr phProv,
        string? pszContainer,
        string? pszProvider,
        uint dwProvType,
        uint dwFlags);

    [LibraryImport("advapi32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool CryptGenKey(
        IntPtr hProv,
        uint algid,
        uint dwFlags,
        out IntPtr phKey);

    [LibraryImport("advapi32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool CryptEncrypt(
        IntPtr hKey,
        IntPtr hHash,
        [MarshalAs(UnmanagedType.Bool)] bool final,
        uint dwFlags,
        [In, Out] byte[] pbData,
        ref uint pdwDataLen,
        uint dwBufLen);

    [LibraryImport("advapi32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool CryptDecrypt(
        IntPtr hKey,
        IntPtr hHash,
        [MarshalAs(UnmanagedType.Bool)] bool final,
        uint dwFlags,
        [In, Out] byte[] pbData,
        ref uint pdwDataLen);

    // ReSharper disable UnusedMethodReturnValue.Local
    [LibraryImport("advapi32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool CryptDestroyKey(IntPtr hKey);

    [LibraryImport("advapi32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool CryptReleaseContext(IntPtr hProv, uint dwFlags);
    // ReSharper restore UnusedMethodReturnValue.Local
    
    private IntPtr _hProvider;
    private IntPtr _hKey;
    
    public WinCryptoWrapper()
    {
        if (!CryptAcquireContext(out _hProvider, null, null, ProvRsaFull, CryptVerifycontext))
        {
            throw new Exception($"Error acquiring context. Error code: {Marshal.GetLastWin32Error()}");
        }

        if (!CryptGenKey(_hProvider, CalgRc4, CryptExportable, out _hKey))
        {
            throw new Exception($"Error generating key. Error code: {Marshal.GetLastWin32Error()}");
        }
    }


    public byte[] EncryptString(string text)
    {
        var dataBytes = Encoding.UTF8.GetBytes(text);
        var dataLen = (uint)dataBytes.Length;
        
        // Створюємо надмірно великий буфер, щоб уникнути переповнення під час процесу шифрування 
        var bufferLen = dataLen * 2; 
        var buffer = new byte[bufferLen];
        Array.Copy(dataBytes, buffer, dataLen);

        if (!CryptEncrypt(_hKey, IntPtr.Zero, true, 0, buffer, ref dataLen, bufferLen))
        {
            throw new Exception($"Encryption failed. Error code: {Marshal.GetLastWin32Error()}");
        }

        // Обрізаємо буфер до реального розміру зашифрованих даних
        var result = new byte[dataLen];
        Array.Copy(buffer, result, dataLen);
        return result;
    }

    public string DecryptString(byte[] encryptedData)
    {
        var buffer = new byte[encryptedData.Length];
        Array.Copy(encryptedData, buffer, encryptedData.Length);
        var dataLen = (uint)buffer.Length;

        if (!CryptDecrypt(_hKey, IntPtr.Zero, true, 0, buffer, ref dataLen))
        {
            throw new Exception($"Decryption failed. Error code: {Marshal.GetLastWin32Error()}");
        }

        return Encoding.UTF8.GetString(buffer, 0, (int)dataLen);
    }

    public void Dispose()
    {
        if (_hKey != IntPtr.Zero)
        {
            CryptDestroyKey(_hKey);
            _hKey = IntPtr.Zero;
        }

        if (_hProvider == IntPtr.Zero) 
            return;
        CryptReleaseContext(_hProvider, 0);
        _hProvider = IntPtr.Zero;
        
        GC.SuppressFinalize(this);
    }
}