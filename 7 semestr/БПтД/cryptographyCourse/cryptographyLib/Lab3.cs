namespace cryptographyLib;

public class FrequencyCracker
{
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    /// <summary>
    ///     Підраховує частоту появи кожної літери в тексті.
    /// </summary>
    public static Dictionary<char, int> Analyze(string text)
    {
        var occurences = new Dictionary<char, int>();

        if (string.IsNullOrEmpty(text))
            return occurences;

        var input = text.ToUpper();

        foreach (var c in input.Where(c => Alphabet.Contains(c)))
        {
            occurences.TryAdd(c, value: 0);
            occurences[c] += 1;
        }

        return occurences;
    }

    /// <summary>
    ///     Намагається зламати шифр Цезаря методом частотного аналізу.
    /// </summary>
    /// <param name="cipherText">Зашифрований текст</param>
    /// <param name="targetChar">Літера, яка найчастіше зустрічається у цій мові (за замовчуванням 'E' для англійської)</param>
    /// <returns>Ймовірний зсув (ключ)</returns>
    public static int Crack(string cipherText, char targetChar = 'E')
    {
        // 0. Отримуємо частотність входжень
        var occurences = Analyze(cipherText);

        if (occurences.Count == 0)
            return 0;

        // 1. Знаходимо найпопулярнішу літеру в шифротексті
        var mostFrequentInCipher = occurences
            .OrderByDescending(pair => pair.Value)
            .First()
            .Key;

        // 2. Обчислюємо зсув
        // Формула: Index(Found) - Index(Expected)
        var foundIndex = Alphabet.IndexOf(mostFrequentInCipher);
        var targetIndex = Alphabet.IndexOf(char.ToUpper(targetChar));

        var shift = foundIndex - targetIndex;

        // 3. Нормалізація зсуву
        if (shift < 0)
            shift += Alphabet.Length;

        return shift;
    }
}