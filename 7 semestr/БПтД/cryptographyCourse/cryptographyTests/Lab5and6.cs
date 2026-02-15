using System.Numerics;
using cryptographyLib;

namespace cryptographyTests;

public class RsaAndSignatureTests
{
    [Fact]
    public void RSA_Encryption_RoundTrip()
    {
        var keys = RsaEngine.GenerateKeys();

        var message = BigInteger.Parse("123456789012345678901234567890");

        var encrypted = RsaEngine.Process(message, keys.E, keys.N);
        var decrypted = RsaEngine.Process(encrypted, keys.D, keys.N);

        Assert.Equal(message, decrypted);
    }

    [Fact]
    public void DigitalSignature_SignAndVerify_Success_WithRealSHA256()
    {
        var keys = RsaEngine.GenerateKeys();

        const string document = "Це реальний контракт із SHA-256 підписом";

        var signature = DigitalSignatureService.SignData(document, keys.D, keys.N);

        var isValid = DigitalSignatureService.VerifySignature(document, signature, keys.E, keys.N);

        Assert.True(isValid);
    }

    [Fact]
    public void DigitalSignature_DetectsTampering()
    {
        var keys = RsaEngine.GenerateKeys();

        const string document = "Pay $100";
        var signature = DigitalSignatureService.SignData(document, keys.D, keys.N);

        const string tamperedDocument = "Pay $9000";

        var isValid = DigitalSignatureService.VerifySignature(tamperedDocument, signature, keys.E, keys.N);

        Assert.False(isValid);
    }
}