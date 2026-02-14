using System.Text;

namespace cryptographyLib;

public class LinearCongruentialGenerator(long seed)
{
    // Константи (взяті з реалізації glibc або Microsoft Visual C++)
    private const long A = 1103515245;
    private const long C = 12345;
    // Модуль 2^31 (int.MaxValue + 1)
    private const long M = 2147483648; 

    private long _current = seed;

    public byte NextByte()
    {
        // 1. Обчислюємо наступне число за формулою
        _current = (A * _current + C) % M;

        // 2. Повертаємо результат як байт (0-255).
        // Беремо остачу від ділення на 256 або старші біти для кращої "випадковості"
        return (byte)(_current % 256);
    }
}
public static class XorCipher
{
    /// <summary>
    /// Шифрує (і дешифрує) дані потоковим методом.
    /// </summary>
    /// <param name="text">Вхідний текст</param>
    /// <param name="seed">Ключ (зерно) для генератора</param>
    /// <returns>Масив байтів (результат)</returns>
    public static byte[] Process(string text, long seed)
    {
        var data = Encoding.UTF8.GetBytes(text);
        var result = new byte[data.Length];

        var lcg = new LinearCongruentialGenerator(seed);

        for (var i = 0; i < data.Length; i++)
        {
            var keyByte = lcg.NextByte();
            result[i] = (byte)(data[i] ^ keyByte);
        }

        return result;
    }

    /// <summary>
    /// Перевантаження для дешифрування байтів назад у рядок
    /// </summary>
    public static string Decrypt(byte[] encryptedData, long seed)
    {
        var result = new byte[encryptedData.Length];
            
        var lcg = new LinearCongruentialGenerator(seed);

        for (var i = 0; i < encryptedData.Length; i++)
        {
            var keyByte = lcg.NextByte();
            result[i] = (byte)(encryptedData[i] ^ keyByte);
        }

        return Encoding.UTF8.GetString(result);
    }
}