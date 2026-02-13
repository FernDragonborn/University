using System.Runtime.InteropServices;
using cryptographyLib;

namespace cryptographyTests;

public class WindowsCryptoApiTests
{
    [Fact]
    [Trait("Category", "Integration")]
    public void WinAPI_EncryptDecrypt_RoundTrip()
    {
        // Пропускаємо тест, якщо це не Windows
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return; 
        }

        var crypto = new WinCryptoWrapper();
        string original = "Sensitive Data for Windows";

        try
        {
            // Цей метод всередині викликає CryptAcquireContext, CryptGenKey і т.д.
            byte[] encrypted = crypto.EncryptString(original);
                
            // Переконуємось, що дані змінились
            Assert.NotEqual(System.Text.Encoding.UTF8.GetBytes(original), encrypted);

            string decrypted = crypto.DecryptString(encrypted);

            Assert.Equal(original, decrypted);
        }
        catch (Exception ex)
        {
            // Якщо API викине помилку (наприклад, немає прав), тест впаде з поясненням
            Assert.Fail($"Windows CryptoAPI failed: {ex.Message}");
        }
    }
}