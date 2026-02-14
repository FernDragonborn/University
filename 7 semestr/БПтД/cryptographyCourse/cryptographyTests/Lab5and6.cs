using System.Numerics;
using cryptographyLib;
using Xunit;

namespace cryptographyTests;

public class RsaAndSignatureTests
{
    // --- LAB 6: RSA IMPLEMENTATION ---

    [Fact]
    public void Math_ModularExponentiation_Works()
    {
        // Перевірка математичного ядра: (base^exp) % mod
        // 2^10 = 1024. 1024 % 1000 = 24.
        BigInteger baseVal = 2;
        BigInteger exp = 10;
        BigInteger mod = 1000;

        var result = RSAEngine.ModPow(baseVal, exp, mod);

        Assert.Equal(new BigInteger(24), result);
    }

    [Fact]
    public void RSA_KeyGeneration_Validity()
    {
        // Перевіряємо, чи правильно згенеровані ключі задовольняють умову:
        // (E * D) % Phi == 1
        var rsa = new RSAEngine();
            
        // Викликаємо генерацію (можна передати малі прості числа для швидкості тесту)
        var keys = rsa.GenerateKeys(p: 61, q: 53); 

        BigInteger phi = (61 - 1) * (53 - 1);
        var check = (keys.E * keys.D) % phi;

        Assert.Equal(BigInteger.One, check);
    }

    [Fact]
    public void RSA_Encryption_RoundTrip()
    {
        var rsa = new RSAEngine();
        var keys = rsa.GenerateKeys(61, 53); // Генеруємо реальні ключі
            
        BigInteger message = 12345;

        // Шифруємо публічним (E, N)
        var encrypted = rsa.Encrypt(message, keys.E, keys.N);
            
        // Розшифровуємо приватним (D, N)
        var decrypted = rsa.Decrypt(encrypted, keys.D, keys.N);

        Assert.Equal(message, decrypted);
    }

    // --- LAB 5: DIGITAL SIGNATURE ---

    [Fact]
    public void DigitalSignature_SignAndVerify_Success()
    {
        // Arrange
        var signer = new DigitalSignatureService();
        var rsa = new RSAEngine();
        var keys = rsa.GenerateKeys(p: 61, q: 53); // Використовуємо ключі з Lab 6
            
        const string document = "Contract Agreement text";
            
        // Act
        // 1. Створюємо підпис (Хеш -> Шифруємо приватним ключем D)
        var signature = signer.SignData(document, keys.D, keys.N);

        // 2. Перевіряємо підпис (Розшифровуємо публічним E -> Звіряємо хеш)
        var isValid = signer.VerifySignature(document, signature, keys.E, keys.N);

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void DigitalSignature_DetectsTampering()
    {
        var signer = new DigitalSignatureService();
        var rsa = new RSAEngine();
        var keys = rsa.GenerateKeys(61, 53);
            
        const string document = "Pay $100";
        var signature = signer.SignData(document, keys.D, keys.N);

        // Хакер змінює документ
        const string tamperedDocument = "Pay $9000";

        // Перевірка має провалитися
        var isValid = signer.VerifySignature(tamperedDocument, signature, keys.E, keys.N);

        Assert.False(isValid);
    }
}