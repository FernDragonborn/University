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
        if (string.IsNullOrEmpty(text)) return text;

        StringBuilder result = new StringBuilder();
            
        // Працюємо з верхнім регістром для простоти
        string input = text.ToUpper();

        foreach (char c in input)
        {
            // Якщо символ є в нашому алфавіті (A-Z)
            int index = Alphabet.IndexOf(c);
                
            if (index >= 0)
            {
                // Формула: (Index + Shift) % Length
                // Додаткова магія "+ Alphabet.Length" потрібна, щоб коректно обробляти від'ємний зсув
                int newIndex = (index + shift) % Alphabet.Length;
                    
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
        return Process(text, key, isEncrypting: true);
    }

    public static string Decrypt(string text, string key)
    {
        return Process(text, key, isEncrypting: false);
    }

    private static string Process(string text, string key, bool isEncrypting)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key)) 
            return text;

        StringBuilder result = new StringBuilder();
            
        string input = text.ToUpper();
        string normalizedKey = key.ToUpper();
            
        int keyIndex = 0;

        foreach (char c in input)
        {
            int inputIndex = Alphabet.IndexOf(c);

            if (inputIndex >= 0)
            {
                // Знаходимо зсув для поточної букви ключа
                char keyChar = normalizedKey[keyIndex % normalizedKey.Length];
                int keyShift = Alphabet.IndexOf(keyChar);

                // Якщо дешифруємо, то віднімаємо зсув
                if (!isEncrypting)
                {
                    keyShift = -keyShift;
                }

                // Застосовуємо зсув (аналогічно до Цезаря)
                int newIndex = (inputIndex + keyShift) % Alphabet.Length;
                    
                if (newIndex < 0) 
                    newIndex += Alphabet.Length;

                result.Append(Alphabet[newIndex]);

                // Переходимо до наступної букви ключа
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