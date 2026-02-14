using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;
using Spectre.Console;
using cryptographyLib;

namespace cryptographyCLI;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public static class Program
{
    // Стан для RSA (щоб зберігати ключі між меню)
    private static Keys? _rsaKeys;
    private static readonly string[] MainMenu =
    [
        "Lab 1: Caesar Cipher (Simple Substitution)",
        "Lab 2: Vigenere Cipher (Polyalphabetic)",
        "Lab 3: Frequency Analysis (Cracking Caesar)",
        "Lab 4: Stream Cipher (XOR + LCG)",
        "Lab 5: RSA Encryption (Asymmetric)",
        "Lab 6: Digital Signatures",
        "HW: Windows CryptoAPI (RC4)",
        "[red]Exit[/]",
    ];
    private static readonly string[] ContentInputMenu = 
    [
        "Manual Text Input", 
        "Load from File", 
        "[grey]Back[/]",
    ];
    private static readonly string[] SaveOrPrintTextMenu = 
    [
        "Print to Console", 
        "Save to File",
    ];
    private static readonly string[] SaveOrPrintBytesMenu = 
    [
        "Print as Base64", 
        "Save Binary to File",
    ];

    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        AnsiConsole.Write(
            new FigletText("CRYPTO MASTER")
                .LeftJustified()
                .Color(Color.Cyan1));

        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[yellow]Main Menu - All Labs[/]").RuleStyle("grey"));

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select Laboratory Work:")
                    .PageSize(12)
                    .AddChoices(MainMenu));

            if (choice == "[red]Exit[/]") return;

            try
            {
                if (choice.StartsWith("Lab 1")) MenuLab1();
                else if (choice.StartsWith("Lab 2")) MenuLab2();
                else if (choice.StartsWith("Lab 3")) MenuLab3();
                else if (choice.StartsWith("Lab 4")) MenuLab4();
                else if (choice.StartsWith("Lab 5")) MenuLab5_RSA();
                else if (choice.StartsWith("Lab 6")) MenuLab6_Signatures();
                else if (choice.StartsWith("HW")) MenuHomework();
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteException(ex);
                Pause();
            }
        }
    }

    // --- HELPER: Ввід тексту або файлу ---
    private static string? GetContentInput(string promptTitle)
    {
        var inputType = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"[blue]{promptTitle}[/] - Select Input Source:")
                .AddChoices(ContentInputMenu));

        if (inputType == "[grey]Back[/]") 
            return null;

        if (inputType == "Load from File")
        {
            var path = AnsiConsole.Ask<string>("Enter [green]file path[/]:");
            if (!File.Exists(path))
            {
                AnsiConsole.MarkupLine("[red]File not found![/]");
                return null;
            }
            return File.ReadAllText(path, Encoding.UTF8);
        }
        else
        {
            return AskInputOrBack("Enter text");
        }
    }

    // --- HELPER: Збереження результату ---
    private static void SaveOrPrintResult(string content)
    {
        AnsiConsole.WriteLine();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What to do with the result?")
                .AddChoices(SaveOrPrintTextMenu));

        if (choice == "Save to File")
        {
            var path = AnsiConsole.Ask<string>("Enter path to save:");
            File.WriteAllText(path, content, Encoding.UTF8);
            AnsiConsole.MarkupLine($"[green]Saved to {path}[/]");
        }
        else
        {
            AnsiConsole.Write(new Panel(content).Header("Result").BorderColor(Color.Green));
        }
    }
    
    // Перевантаження для байтів (для Lab 4 і HW)
    private static void SaveOrPrintBytes(byte[] data)
    {
        AnsiConsole.WriteLine();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What to do with the result?")
                .AddChoices(SaveOrPrintBytesMenu));

        if (choice == "Save Binary to File")
        {
            var path = AnsiConsole.Ask<string>("Enter path to save:");
            File.WriteAllBytes(path, data);
            AnsiConsole.MarkupLine($"[green]Saved {data.Length} bytes to {path}[/]");
        }
        else
        {
            var base64 = Convert.ToBase64String(data);
            AnsiConsole.Write(new Panel(base64).Header("Result (Base64)").BorderColor(Color.Green));
        }
    }

    // --- LAB 1: CAESAR ---
    private static void MenuLab1()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[blue]Lab 1: Caesar Cipher[/]"));
            
            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .AddChoices("Encrypt", "Decrypt", "[grey]Back[/]"));
            
            if (choice == "[grey]Back[/]") return;

            var text = GetContentInput("Input Text");
            if (text == null) continue;

            var shiftStr = AskInputOrBack("Enter shift (number)");
            if (shiftStr == null) continue;
            if (!int.TryParse(shiftStr, out var shift)) 
            {
                AnsiConsole.MarkupLine("[red]Invalid number![/]"); Pause(); continue;
            }

            var result = choice == "Encrypt" 
                ? CaesarCipher.Encrypt(text, shift) 
                : CaesarCipher.Decrypt(text, shift);

            SaveOrPrintResult(result);
            Pause();
        }
    }

    // --- LAB 2: VIGENERE ---
    private static void MenuLab2()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[blue]Lab 2: Vigenere Cipher[/]"));

            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .AddChoices("Encrypt", "Decrypt", "[grey]Back[/]"));
            
            if (choice == "[grey]Back[/]") return;

            var text = GetContentInput("Input Text");
            if (text == null) continue;

            var key = AskInputOrBack("Enter Key (word)");
            if (key == null) continue;

            var result = choice == "Encrypt"
                ? VigenereCipher.Encrypt(text, key)
                : VigenereCipher.Decrypt(text, key);

            SaveOrPrintResult(result);
            Pause();
        }
    }

    // --- LAB 3: FREQUENCY ANALYSIS ---
    private static void MenuLab3()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[blue]Lab 3: Frequency Analysis[/]"));

            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .AddChoices("Analyze Text Frequency", "Crack Caesar Cipher", "[grey]Back[/]"));
            
            if (choice == "[grey]Back[/]") return;

            var text = GetContentInput("Cipher Text Source");
            if (text == null) continue;

            if (choice.StartsWith("Analyze"))
            {
                var freqs = FrequencyCracker.Analyze(text);
                
                // Малюємо графік
                var chart = new BarChart()
                    .Width(60)
                    .Label("[green]Character Frequency[/]")
                    .CenterLabel();

                foreach (var pair in freqs.OrderByDescending(x => x.Value).Take(10)) 
                    chart.AddItem(pair.Key.ToString(), pair.Value, Color.Yellow);

                AnsiConsole.Write(chart);
            }
            else
            {
                var shift = FrequencyCracker.Crack(text);
                AnsiConsole.MarkupLine($"[bold]Predicted Shift:[/] [green]{shift}[/]");
                
                var crackedText = CaesarCipher.Decrypt(text, shift);
                AnsiConsole.Write(new Panel(crackedText.Substring(0, Math.Min(100, crackedText.Length)) + "...")
                    .Header("Preview of Decrypted Text"));
                
                SaveOrPrintResult(crackedText);
            }
            Pause();
        }
    }

    // --- LAB 4: STREAM CIPHER (XOR) ---
    private static void MenuLab4()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[blue]Lab 4: Stream Cipher (XOR)[/]"));
            AnsiConsole.MarkupLine("[dim]Note: Encrypt takes text, Decrypt takes bytes/file[/]");

            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .AddChoices("Encrypt Data", "Decrypt Data", "[grey]Back[/]"));
            
            if (choice == "[grey]Back[/]") return;

            var seedStr = AskInputOrBack("Enter Seed (number)");
            if (seedStr == null) continue;
            var seed = long.Parse(seedStr);

            if (choice == "Encrypt Text")
            {
                var text = GetContentInput("Input Text");
                if (text == null) continue;

                var resultBytes = XorCipher.Process(text, seed);
                SaveOrPrintBytes(resultBytes);
            }
            else
            {
                // Для дешифрування нам потрібні байти
                byte[] inputBytes;
                var source = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .AddChoices("Read from Binary File", "Enter Base64 String"));

                if (source == "Read from Binary File")
                {
                    var path = AnsiConsole.Ask<string>("Enter file path:");
                    if (!File.Exists(path)) { AnsiConsole.MarkupLine("[red]File not found[/]"); Pause(); continue; }
                    inputBytes = File.ReadAllBytes(path);
                }
                else
                {
                    var b64 = AskInputOrBack("Base64 string");
                    if (b64 == null) continue;
                    try { inputBytes = Convert.FromBase64String(b64); }
                    catch { AnsiConsole.MarkupLine("[red]Invalid Base64[/]"); Pause(); continue; }
                }

                var resultString = XorCipher.Decrypt(inputBytes, seed);
                SaveOrPrintResult(resultString);
            }
            Pause();
        }
    }

    // --- HW: WIN API (RC4) ---
    private static void MenuHomework()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[purple]HW: Windows CryptoAPI (RC4)[/]"));

            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .AddChoices("Encrypt", "Decrypt", "[grey]Back[/]"));
            
            if (choice == "[grey]Back[/]") return;

            try 
            {
                using var crypto = new WinCryptoWrapper();
                AnsiConsole.MarkupLine("[gray]System context acquired & Key generated.[/]");

                if (choice == "Encrypt")
                {
                    var text = GetContentInput("Text to Encrypt");
                    if (text == null) continue;

                    var encryptedBytes = crypto.EncryptString(text);
                    SaveOrPrintBytes(encryptedBytes);
                }
                else
                {
                    // Для дешифрування треба подати байти. 
                    // В рамках цієї реалізації (wrapper) ключ генерується випадково в конструкторі.
                    // Тому дешифрувати можна ТІЛЬКИ те, що зашифрували в ЦІЙ ЖЕ сесії об'єкта.
                    // Але оскільки ми перестворюємо об'єкт crypto, старі дані не розшифруються.
                    // ЦЕ ОБМЕЖЕННЯ БІБЛІОТЕКИ DZ.CS (ключ не передається в конструктор).
                    
                    AnsiConsole.MarkupLine("[red]Warning: WinCryptoWrapper generates a NEW random key each time.[/]");
                    AnsiConsole.MarkupLine("To test decryption properly, we must Encrypt AND Decrypt in one go:");
                    
                    var text = AskInputOrBack("Enter text to test full cycle");
                    if(text == null) continue;

                    var enc = crypto.EncryptString(text);
                    AnsiConsole.MarkupLine($"[green]Encrypted bytes:[/] {Convert.ToBase64String(enc)}");
                    
                    var dec = crypto.DecryptString(enc);
                    AnsiConsole.MarkupLine($"[green]Decrypted text:[/] {dec}");
                }
            }
            catch(Exception ex)
            {
                AnsiConsole.WriteException(ex);
            }
            Pause();
        }
    }

    // --- LAB 5: RSA ---
    private static void MenuLab5_RSA()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[blue]Lab 5: RSA Encryption[/]"));
            
            if (_rsaKeys != null)
                AnsiConsole.MarkupLine($"[dim]Current Keys: N has {_rsaKeys.N.GetBitLength()} bits[/]");
            else
                AnsiConsole.MarkupLine("[dim]Keys: Not generated yet[/]");

            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .AddChoices("Generate Keys", "Encrypt Message", "Decrypt Message", "[grey]Back[/]"));

            if (choice == "[grey]Back[/]") return;

            if (choice == "Generate Keys")
            {
                GenerateKeysInteractive();
            }
            else if (choice.StartsWith("Encrypt"))
            {
                if (!EnsureKeysExist()) continue;
                // RSA шифрує числа. Якщо хочеш текст, його треба перевести в BigInteger.
                // Для простоти лаби - вводимо число або текст, який конвертуємо в байти -> число.
                
                var input = AskInputOrBack("Enter numeric message (or text)");
                if (input == null) continue;

                BigInteger msg;
                if (!BigInteger.TryParse(input, out msg))
                {
                    // Пробуємо як текст -> число
                    var bytes = Encoding.UTF8.GetBytes(input);
                    msg = new BigInteger(bytes, isUnsigned: true, isBigEndian: true);
                    AnsiConsole.MarkupLine($"[gray]Converted text to number: {msg}[/]");
                }

                if (msg >= _rsaKeys!.N) { AnsiConsole.MarkupLine("[red]Message too big![/]"); Pause(); continue; }

                var enc = RsaEngine.Process(msg, _rsaKeys.E, _rsaKeys.N);
                AnsiConsole.MarkupLine($"[green]Encrypted Number:[/] {enc}");
                
                // Можна зберегти число у файл як текст
                SaveOrPrintResult(enc.ToString());
                Pause();
            }
            else if (choice.StartsWith("Decrypt"))
            {
                if (!EnsureKeysExist()) continue;
                
                // Читаємо число з файлу або консолі
                var encStr = GetContentInput("Encrypted Number Source");
                if (encStr == null) continue;
                
                if(!BigInteger.TryParse(encStr, out var encMsg)) 
                { AnsiConsole.MarkupLine("[red]Invalid number[/]"); Pause(); continue; }
                
                var dec = RsaEngine.Process(encMsg, _rsaKeys!.D, _rsaKeys.N);
                AnsiConsole.MarkupLine($"[green]Decrypted Number:[/] {dec}");

                // Спробуємо конвертувати назад у текст (якщо це був текст)
                try {
                    var bytes = dec.ToByteArray(isUnsigned: true, isBigEndian: true);
                    var txt = Encoding.UTF8.GetString(bytes);
                    AnsiConsole.MarkupLine($"[dim]Text representation: {txt}[/]");
                }
                catch
                {
                    // ignored
                }

                Pause();
            }
        }
    }

    private static void GenerateKeysInteractive()
    {
        var method = AnsiConsole.Prompt(new SelectionPrompt<string>()
             .Title("Method:")
             .AddChoices("Auto (Mersenne Primes)", "Manual Input"));

        BigInteger p, q;
        if (method.StartsWith("Auto"))
        {
            p = BigInteger.Pow(2, 127) - 1;
            q = BigInteger.Pow(2, 521) - 1;
        }
        else
        {
            p = BigInteger.Parse(AnsiConsole.Ask<string>("P:"));
            q = BigInteger.Parse(AnsiConsole.Ask<string>("Q:"));
        }
        
        AnsiConsole.Status().Start("Generating...", ctx => 
        {
            _rsaKeys = RsaEngine.GenerateKeys(p, q);
        });
        AnsiConsole.MarkupLine("[green]Keys Generated![/]");
        Pause();
    }

    // --- LAB 6: SIGNATURES ---
    private static void MenuLab6_Signatures()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[blue]Lab 6: Digital Signatures[/]"));

            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .AddChoices("Sign Document", "Verify Signature", "[grey]Back[/]"));

            if (choice == "[grey]Back[/]") return;

            if (choice.StartsWith("Sign"))
            {
                if (!EnsureKeysExist()) continue;
                
                // Тут "Document" може бути текстом або вмістом файлу
                var doc = GetContentInput("Document to Sign");
                if (doc == null) continue;

                var sig = DigitalSignatureService.SignData(doc, _rsaKeys!.D, _rsaKeys.N);
                AnsiConsole.MarkupLine($"[green]Signature generated![/]");
                SaveOrPrintResult(sig.ToString());
                Pause();
            }
            else
            {
                if (!EnsureKeysExist()) continue;

                var doc = GetContentInput("Original Document");
                if (doc == null) continue;

                var sigStr = AskInputOrBack("Enter Signature (number)");
                if (sigStr == null) continue;

                var isValid = DigitalSignatureService.VerifySignature(doc, BigInteger.Parse(sigStr), _rsaKeys!.E, _rsaKeys.N);
                
                if (isValid) AnsiConsole.Write(new Panel("VALID").BorderColor(Color.Green));
                else AnsiConsole.Write(new Panel("INVALID").BorderColor(Color.Red));
                Pause();
            }
        }
    }

    // --- UTILS ---
    private static string? AskInputOrBack(string prompt)
    {
        AnsiConsole.Markup($"[bold]{prompt}[/] ([grey]type 'b' to back[/]): ");
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "b") return null;
        return input;
    }

    private static bool EnsureKeysExist()
    {
        if (_rsaKeys == null)
        {
            AnsiConsole.MarkupLine("[red]Keys not generated! Go to Lab 5 first.[/]");
            Pause();
            return false;
        }
        return true;
    }

    private static void Pause()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.Markup("[grey]Press any key...[/]");
        Console.ReadKey(true);
    }
}