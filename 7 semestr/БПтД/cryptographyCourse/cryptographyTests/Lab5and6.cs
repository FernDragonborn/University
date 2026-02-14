using System.Numerics;
using cryptographyLib;

namespace cryptographyTests;

public class RsaAndSignatureTests
{
    // Використовуємо числа Мерсенна. 
    // M127 і M521 — це гарантовано прості числа.
    
    private readonly BigInteger _primeP = BigInteger.Pow(2, 127) - 1;
    
    private readonly BigInteger _primeQ = BigInteger.Pow(2, 521) - 1;

    [Fact]
    public void RSA_KeyGeneration_Validity()
    {
        var keys = RsaEngine.GenerateKeys(_primeP, _primeQ);

        // Перевірка математичної властивості: (e * d) = 1 mod phi
        var phi = (_primeP - 1) * (_primeQ - 1);
        var check = (keys.E * keys.D) % phi;

        Assert.Equal(BigInteger.One, check);
    }

    [Fact]
    public void RSA_Encryption_RoundTrip()
    {
        var keys = RsaEngine.GenerateKeys(_primeP, _primeQ);
            
        var message = BigInteger.Parse("123456789012345678901234567890");

        var encrypted = RsaEngine.Process(message, keys.E, keys.N);
        var decrypted = RsaEngine.Process(encrypted, keys.D, keys.N);

        Assert.Equal(message, decrypted);
    }

    [Fact]
    public void DigitalSignature_SignAndVerify_Success_WithRealSHA256()
    {
        var keys = RsaEngine.GenerateKeys(_primeP, _primeQ);
            
        const string document = "Це реальний контракт із SHA-256 підписом";
            
        // 1. Підписуємо (Хеш SHA256 влазить у 648-бітний ключ без проблем)
        var signature = DigitalSignatureService.SignData(document, keys.D, keys.N);
        
        // 2. Перевіряємо
        var isValid = DigitalSignatureService.VerifySignature(document, signature, keys.E, keys.N);

        Assert.True(isValid);
    }

    [Fact]
    public void DigitalSignature_DetectsTampering()
    {
        var keys = RsaEngine.GenerateKeys(_primeP, _primeQ);
            
        const string document = "Pay $100";
        var signature = DigitalSignatureService.SignData(document, keys.D, keys.N);

        const string tamperedDocument = "Pay $9000";

        var isValid = DigitalSignatureService.VerifySignature(tamperedDocument, signature, keys.E, keys.N);

        Assert.False(isValid);
    }
}