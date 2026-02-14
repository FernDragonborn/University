using System.Text;
using cryptographyLib;
using Xunit;

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
        {
            Assert.Equal(generator1.Next(), generator2.Next());
        }
    }

    [Fact]
    public void Xor_RoundTrip_ShouldRestoreData()
    {
        // Arrange
        var cipher = new XorCipher();
        var originalData = Encoding.UTF8.GetBytes("Secret Data");
        var seed = 999;

        // Act
        // Шифруємо
        var encrypted = cipher.Transform(originalData, seed);
            
        // Дешифруємо (XOR оборотний, викликаємо той самий метод)
        var decrypted = cipher.Transform(encrypted, seed);

        // Assert
        Assert.NotEqual(originalData, encrypted); // Дані мали змінитися
        Assert.Equal(originalData, decrypted);    // Дані мали відновитися
    }
}