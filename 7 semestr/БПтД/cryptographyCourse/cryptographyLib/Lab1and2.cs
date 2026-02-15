using System.Text;

namespace cryptographyLib;

public static class CaesarCipher
{
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string Encrypt(string text, int shift)
    {
        return Process(text, shift);
    }

    public static string Decrypt(string text, int shift)
    {
        // Дешифрування - це шифрування з від'ємним зсувом
        return Process(text, -shift);
    }

    private static string Process(string text, int shift)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        var result = new StringBuilder();
        var input = text.ToUpper();

        foreach (var c in input)
        {
            var index = Alphabet.IndexOf(c);

            if (index >= 0)
            {
                // Формула: (Index + Shift) % Length
                var newIndex = (index + shift) % Alphabet.Length;

                if (newIndex < 0)
                    newIndex += Alphabet.Length;

                result.Append(Alphabet[newIndex]);
            }
            else
            {
                // Якщо це пробіл, цифра або знак пунктуації - залишаємо як є
                result.Append(c);
            }
        }

        return result.ToString();
    }
}

public static class VigenereCipher
{
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string Encrypt(string text, string key)
    {
        return Process(text, key, isDecrypting: false);
    }

    public static string Decrypt(string text, string key)
    {
        return Process(text, key, isDecrypting: true);
    }

    private static string Process(string text, string key, bool isDecrypting)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
            return text;

        var result = new StringBuilder();
        var normalizedInput = text.ToUpper();
        var normalizedKey = key.ToUpper();
        var keyIndex = 0;

        foreach (var c in normalizedInput)
        {
            var inputIndex = Alphabet.IndexOf(c);

            if (inputIndex >= 0)
            {
                // Знаходимо зсув для поточної букви ключа
                var keyChar = normalizedKey[keyIndex % normalizedKey.Length];
                var keyShift = Alphabet.IndexOf(keyChar);

                // Якщо дешифруємо, то віднімаємо зсув
                if (isDecrypting)
                    keyShift = -keyShift;

                // Застосовуємо зсув (аналогічно до Цезаря)
                var newIndex = (inputIndex + keyShift) % Alphabet.Length;

                if (newIndex < 0)
                    newIndex += Alphabet.Length;

                result.Append(Alphabet[newIndex]);
                keyIndex++;
            }
            else
            {
                // Не чіпаємо спецсимволи
                result.Append(c);
            }
        }

        return result.ToString();
    }
}