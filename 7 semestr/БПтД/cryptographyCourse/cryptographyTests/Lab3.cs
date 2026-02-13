using cryptographyLib;

namespace cryptographyTests;

public class FrequencyAnalysisTests
{
    [Fact]
    public void Analyze_ShouldCountFrequenciesCorrectly()
    {
        // Arrange
        var analyzer = new FrequencyCracker();
        const string text = "AAABBC";

        // Act
        var freqs = analyzer.Analyze(text);

        // Assert
        Assert.Equal(3, freqs['A']);
        Assert.Equal(2, freqs['B']);
        Assert.Equal(1, freqs['C']);
    }

    [Fact]
    public void Crack_ShouldFindShift_BasedOnMostFrequentChar()
    {
        // Arrange
        // Припустимо, ми знаємо, що в мові найчастіша літера 'O'
        // Зашифруємо текст так, щоб 'O' стала 'T' (зсув 5)
        string textWithManyOs = "OOOOO OOOOO"; 
        int secretShift = 5;
        string encrypted = CaesarCipher.Encrypt(textWithManyOs, secretShift);

        var cracker = new FrequencyCracker();

        // Act
        // Метод Crack має знайти найчастіший символ у шифротексті ('T')
        // і відняти від нього еталонний символ ('O'). 'T' - 'O' = 5.
        int foundShift = cracker.Crack(encrypted, targetChar: 'O');

        // Assert
        Assert.Equal(secretShift, foundShift);
    }
}