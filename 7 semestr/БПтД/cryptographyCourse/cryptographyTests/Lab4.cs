using cryptographyLib;

namespace cryptographyTests;

public class XorCipherTests
{
    [Fact]
    public void PRNG_ShouldBeDeterministic_WithSameSeed()
    {
        // Генератор має видавати однакову послідовність для одного seed
        var generator1 = new LinearCongruentialGenerator(12345);
        var generator2 = new LinearCongruentialGenerator(12345);

        for (var i = 0; i < 100; i++) 
            Assert.Equal(generator1.NextByte(), generator2.NextByte());
    }

    [Fact]
    public void XorCipher_ShouldEncryptAndDecrypt_WithSameSeed()
    {
        // Arrange
        const string secretMessage = "Secret Data 123";
        const long key = 987654321;

        // Act
        var encrypted = XorCipher.Process(secretMessage, key);

        var decrypted = XorCipher.Decrypt(encrypted, key);

        // Assert
        Assert.NotEqual(secretMessage, Convert.ToBase64String(encrypted)); 
        Assert.Equal(secretMessage, decrypted);
    }
}