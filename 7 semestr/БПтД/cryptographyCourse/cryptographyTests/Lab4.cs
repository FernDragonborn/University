using cryptographyLib;

namespace cryptographyTests;

public class XorCipherTests
{
    [Fact]
    public void LCG_ShouldBeDeterministic_WithSameSeed()
    {
        // 1. Arrange
        long seed = 12345;
        // Варіант 2 - Лінійний
        var generator1 = new LinearCongruentialGenerator(seed);
        var generator2 = new LinearCongruentialGenerator(seed);

        // 2. Act & Assert
        // Перевіряємо, що послідовність байтів ідентична
        for (var i = 0; i < 100; i++)
            Assert.Equal(generator1.NextByte(), generator2.NextByte());
    }

    [Fact]
    public void LCG_ShouldChange_WithDifferentSeed()
    {
        // 1. Arrange
        var generator1 = new LinearCongruentialGenerator(seed: 12345);
        var generator2 = new LinearCongruentialGenerator(seed: 67890);

        // 2. Act & Assert
        var areDifferent = false;

        for (var i = 0; i < 10; i++)
            if (generator1.NextByte() != generator2.NextByte())
            {
                areDifferent = true;
                break;
            }

        Assert.True(areDifferent, "Different seeds should produce different sequences");
    }

    [Fact]
    public void XorCipher_ShouldEncryptAndDecrypt_Correctly()
    {
        // 1. Arrange
        const string originalText = "Variant 2 is Linear LCG";
        const long key = 555777;

        // 2. Act
        var encryptedBytes = XorCipher.Process(originalText, key);
        var decryptedText = XorCipher.Decrypt(encryptedBytes, key);

        // 3. Assert
        Assert.NotNull(encryptedBytes);
        Assert.NotEqual(originalText, Convert.ToBase64String(encryptedBytes)); // Текст зашифровано
        Assert.Equal(originalText, decryptedText); // Текст успішно розшифровано
    }
}