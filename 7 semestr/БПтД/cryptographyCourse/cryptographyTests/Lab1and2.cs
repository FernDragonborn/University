using cryptographyLib;

namespace cryptographyTests;

public class SubstitutionCiphersTests
{
    // --- LAB 1: CAESAR CIPHER ---

    [Theory]
    [InlineData("ABC", 1, "BCD")]
    [InlineData("ZOO", 1, "APP")] // Перевірка переходу через кінець алфавіту (Z -> A)
    [InlineData("HELLO", 3, "KHOOR")]
    public void Caesar_Encrypt_ShouldShiftCorrectly(string input, int shift, string expected)
    {
        // Act
        string result = CaesarCipher.Encrypt(input, shift);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("BCD", 1, "ABC")]
    [InlineData("APP", 1, "ZOO")] 
    public void Caesar_Decrypt_ShouldReverseShift(string input, int shift, string expected)
    {
        string result = CaesarCipher.Decrypt(input, shift);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Caesar_RoundTrip_ReturnsOriginalText()
    {
        const string original = "CRYPTOGRAPHY IS FUN";
        const int shift = 5;

        var encrypted = CaesarCipher.Encrypt(original, shift);
        var decrypted = CaesarCipher.Decrypt(encrypted, shift);

        Assert.Equal(original, decrypted);
    }

    // --- LAB 2: VIGENERE CIPHER ---

    [Theory]
    [InlineData("ATTACKATDAWN", "LEMON", "LXFOPVEFRNHR")]
    [InlineData("CRYPTO", "ABC", "CSAPUQ")]
    public void Vigenere_Encrypt_ShouldMatchKnownVectors(string input, string key, string expected)
    {
        var result = VigenereCipher.Encrypt(input, key);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Vigenere_KeyRepeat_ShouldWorkWithShortKey()
    {
        // Якщо ключ коротший за текст, він має повторюватися
        const string input = "AAAAA"; // 5 літер
        const string key = "BC";    // 2 літери -> ключ буде BCBCB
            
        // A+B=B, A+C=C, A+B=B, A+C=C, A+B=B
        const string expected = "BCBCB"; 

        var result = VigenereCipher.Encrypt(input, key);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    // "LEMON" -> "ATTACKATDAWN"
    [InlineData("LXFOPVEFRNHR", "LEMON", "ATTACKATDAWN")] 
    // "ABC" -> "CRYPTO" (використовуємо виправлене значення)
    [InlineData("CSAPUQ", "ABC", "CRYPTO")]       
    public void Vigenere_Decrypt_ShouldRestoreKnownText(string cipherText, string key, string expectedPlain)
    {
        // Act
        string result = VigenereCipher.Decrypt(cipherText, key);

        // Assert
        Assert.Equal(expectedPlain, result);
    }
}