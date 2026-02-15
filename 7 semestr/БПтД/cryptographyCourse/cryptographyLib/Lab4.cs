using System.Text;

namespace cryptographyLib;

// ВАРІАНТ 2: Лінійний конгруентний датчик (LCG)
// Формула: X(n+1) = (a * X(n) + c) mod m
public class LinearCongruentialGenerator(long seed)
{
    // Класичні константи (використовуються в glibc/C++ компіляторах)
    private const long A = 1103515245;
    private const long C = 12345;
    private const long M = 2147483648; // 2^31

    private long _current = seed;

    public byte NextByte()
    {
        // 1. Обчислюємо наступне число за лінійною формулою
        _current = (A * _current + C) % M;

        // 2. Повертаємо результат як байт (0-255).
        return (byte)(_current % 256);
    }
}

public static class XorCipher
{
    /// <summary>
    ///     Шифрує дані методом гамування (Варіант 2 - Лінійний).
    /// </summary>
    public static byte[] Process(string text, long seed)
    {
        var data = Encoding.UTF8.GetBytes(text);
        var result = new byte[data.Length];

        // Використовуємо Лінійний генератор
        var generator = new LinearCongruentialGenerator(seed);

        for (var i = 0; i < data.Length; i++)
        {
            var keyByte = generator.NextByte();
            // Операція XOR: C = P ^ K
            result[i] = (byte)(data[i] ^ keyByte);
        }

        return result;
    }

    /// <summary>
    ///     Дешифрує байти.
    /// </summary>
    public static string Decrypt(byte[] encryptedData, long seed)
    {
        var resultBytes = new byte[encryptedData.Length];

        // Створюємо новий генератор з тим самим seed
        var generator = new LinearCongruentialGenerator(seed);

        for (var i = 0; i < encryptedData.Length; i++)
        {
            var keyByte = generator.NextByte();
            resultBytes[i] = (byte)(encryptedData[i] ^ keyByte);
        }

        return Encoding.UTF8.GetString(resultBytes);
    }
}