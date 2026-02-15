using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;
using cryptographyLib;
using Spectre.Console;

// Для RSA (BigInteger)
// Твоя бібліотека

namespace cryptographyCLI;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public static class Program
{
    // Глобальний стан для RSA
    private static Keys? _rsaKeys;

    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[bold yellow]Main Menu[/]").RuleStyle("grey"));

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select Laboratory Work:")
                    .PageSize(pageSize: 10)
                    .AddChoices(
                        "Lab 1: Caesar Cipher (Simple Substitution)",
                        "Lab 2: Vigenere Cipher (Polyalphabetic)",
                        "Lab 3: Frequency Analysis (Cracking Caesar)",
                        "Lab 4: Stream Cipher (XOR + LCG)",
                        "Lab 5: RSA Encryption (Asymmetric)",
                        "Lab 6: Digital Signatures",
                        "HW: Windows CryptoAPI (RC4)",
                        "[red]Exit[/]"
                    ));

            if (choice == "[red]Exit[/]") break;

            switch (choice)
            {
                case "Lab 1: Caesar Cipher (Simple Substitution)": MenuLab1(); break;
                case "Lab 2: Vigenere Cipher (Polyalphabetic)": MenuLab2(); break;
                case "Lab 3: Frequency Analysis (Cracking Caesar)": MenuLab3(); break;
                case "Lab 4: Stream Cipher (XOR + LCG)": MenuLab4(); break;
                case "Lab 5: RSA Encryption (Asymmetric)": MenuLab5(); break;
                case "Lab 6: Digital Signatures": MenuLab6(); break;
                case "HW: Windows CryptoAPI (RC4)": MenuHW(); break;
            }
        }
    }

    // ==========================================
    // LAB 1: CAESAR CIPHER
    // ==========================================
    private static void MenuLab1()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[green]Lab 1: Caesar Cipher[/]"));

            var action = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select Action:")
                .AddChoices("Encrypt", "Decrypt", "[grey]Back[/]"));

            if (action == "[grey]Back[/]") return;

            var text = GetContentInput("Enter text");
            if (string.IsNullOrEmpty(text)) continue;

            var shiftStr = AskInputOrBack("Enter shift (integer)");
            if (shiftStr == null) continue;

            if (!int.TryParse(shiftStr, out var shift))
            {
                PrintErr("Invalid shift! Must be a number.");
                continue;
            }

            string result;

            if (action == "Encrypt")
                result = CaesarCipher.Encrypt(text, shift);
            else
                result = CaesarCipher.Decrypt(text, shift);

            SaveOrPrintResult(result);
        }
    }

    // ==========================================
    // LAB 2: VIGENERE CIPHER
    // ==========================================
    private static void MenuLab2()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[green]Lab 2: Vigenere Cipher[/]"));

            var action = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select Action:")
                .AddChoices("Encrypt", "Decrypt", "[grey]Back[/]"));

            if (action == "[grey]Back[/]") return;

            var text = GetContentInput("Enter text");
            if (string.IsNullOrEmpty(text)) continue;

            var key = AskInputOrBack("Enter key (word)");
            if (string.IsNullOrEmpty(key)) continue;

            string result;

            if (action == "Encrypt")
                result = VigenereCipher.Encrypt(text, key);
            else
                result = VigenereCipher.Decrypt(text, key);

            SaveOrPrintResult(result);
        }
    }

    // ==========================================
    // LAB 3: FREQUENCY ANALYSIS
    // ==========================================
    private static void MenuLab3()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[yellow]Lab 3: Frequency Analysis[/]"));

            var action = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .AddChoices("Crack Ciphertext", "[grey]Back[/]"));

            if (action == "[grey]Back[/]") return;

            var text = GetContentInput("Enter encrypted text");
            if (string.IsNullOrEmpty(text)) continue;

            var guessedShift = FrequencyCracker.Crack(text);
            var decrypted = CaesarCipher.Decrypt(text, guessedShift);

            AnsiConsole.MarkupLine($"[green]Analyzed! Best guess shift: {guessedShift}[/]");
            SaveOrPrintResult(decrypted);
        }
    }

    // ==========================================
    // LAB 4: STREAM CIPHER (XOR)
    // ==========================================
    private static void MenuLab4()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[blue]Lab 4: Stream Cipher (XOR)[/]"));

            var mode = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select Mode:")
                .AddChoices("Encrypt Data", "Decrypt Data", "[grey]Back[/]"));

            if (mode == "[grey]Back[/]") return;

            var seedStr = AskInputOrBack("Enter Key (Seed - integer number)");
            if (seedStr == null) continue;

            if (!long.TryParse(seedStr, out var seed))
            {
                PrintErr("Invalid key! Must be a number.");
                continue;
            }

            if (mode == "Encrypt Data")
                HandleLab4Encrypt(seed);
            else
                HandleLab4Decrypt(seed);

            Pause();
        }
    }

    private static void HandleLab4Encrypt(long seed)
    {
        var source = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Select Input Source:")
            .AddChoices("Enter Plain Text (Raw String)", "Load Text from File", "[grey]Back[/]"));

        if (source == "[grey]Back[/]") return;

        string? textToEncrypt = null;

        if (source == "Enter Plain Text (Raw String)")
            textToEncrypt = AskInputOrBack("Enter text to encrypt");
        else if (source == "Load Text from File")
            textToEncrypt = TryLoadTextFromFile();

        if (string.IsNullOrEmpty(textToEncrypt)) return;

        var resultBytes = XorCipher.Process(textToEncrypt, seed);
        SaveOrPrintBytes(resultBytes);
    }

    private static void HandleLab4Decrypt(long seed)
    {
        var source = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Select Encrypted Input Source:")
            .AddChoices("Read from Binary File", "Enter Base64 String", "Enter Plain Text (Raw String)",
                "[grey]Back[/]"));

        if (source == "[grey]Back[/]") return;

        byte[]? inputBytes = null;

        if (source == "Read from Binary File")
            inputBytes = TryLoadBytesFromFile();
        else if (source == "Enter Base64 String")
        {
            var b64 = AskInputOrBack("Paste Base64 string");

            if (!string.IsNullOrEmpty(b64))
            {
                try
                {
                    inputBytes = Convert.FromBase64String(b64);
                }
                catch
                {
                    PrintErr("Invalid Base64 format!");
                }
            }
        }
        else if (source == "Enter Plain Text (Raw String)")
        {
            var rawText = AskInputOrBack("Enter plain text to decrypt");

            if (!string.IsNullOrEmpty(rawText))
                inputBytes = Encoding.UTF8.GetBytes(rawText);
        }

        if (inputBytes == null) return;

        var resultString = XorCipher.Decrypt(inputBytes, seed);
        SaveOrPrintResult(resultString);
    }

    // ==========================================
    // LAB 5: RSA
    // ==========================================
    private static void MenuLab5()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[purple]Lab 5: RSA Encryption[/]"));

            // Виправлено доступ до полів: _rsaKeys.N, _rsaKeys.E
            AnsiConsole.MarkupLine(_rsaKeys == null
                ? "[yellow]Keys: Not Generated[/]"
                : $"[green]Keys: Active (N={_rsaKeys.N})[/]");

            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .AddChoices("Generate Keys", "Encrypt", "Decrypt", "[grey]Back[/]"));

            if (choice == "[grey]Back[/]") return;

            if (choice == "Generate Keys")
            {
                AnsiConsole.MarkupLine("Generating 2048-bit keys... This may take a few seconds.");

                _rsaKeys = RsaEngine.GenerateKeys();

                AnsiConsole.MarkupLine("[green]Keys generated![/]");
                // Виводити ключі повністю не варто, вони будуть на пів екрана
                AnsiConsole.MarkupLine($"Modulus length: {_rsaKeys.N.GetBitLength()} bits");
                Pause();
            }
            else if (choice == "Encrypt")
            {
                if (_rsaKeys == null)
                {
                    PrintErr("Generate keys first!");
                    continue;
                }

                var text = GetContentInput("Enter text to encrypt");
                if (string.IsNullOrEmpty(text)) continue;

                // Перетворюємо текст на число (спрощено, весь текст як одне велике число)
                var bytes = Encoding.UTF8.GetBytes(text);
                var bigIntData = new BigInteger(bytes, isUnsigned: true, isBigEndian: true);

                if (bigIntData >= _rsaKeys.N)
                {
                    PrintErr("Data too large for this key size! Try shorter text.");
                    continue;
                }

                // Виправлено: передаємо E та N
                var encrypted = RsaEngine.Process(bigIntData, _rsaKeys.E, _rsaKeys.N);
                SaveOrPrintResult(encrypted.ToString());
            }
            else if (choice == "Decrypt")
            {
                if (_rsaKeys == null)
                {
                    PrintErr("Generate keys first!");
                    continue;
                }

                var inputStr = AskInputOrBack("Enter numeric value (BigInteger) to decrypt");
                if (inputStr == null) continue;

                if (BigInteger.TryParse(inputStr, out var encryptedVal))
                {
                    // Виправлено: передаємо D та N
                    var decryptedBigInt = RsaEngine.Process(encryptedVal, _rsaKeys.D, _rsaKeys.N);

                    var decryptedBytes = decryptedBigInt.ToByteArray(isUnsigned: true, isBigEndian: true);
                    var decryptedText = Encoding.UTF8.GetString(decryptedBytes);

                    SaveOrPrintResult(decryptedText);
                }
                else
                    PrintErr("Invalid number format");
            }
        }
    }

    // ==========================================
    // LAB 6: DIGITAL SIGNATURES
    // ==========================================
    private static void MenuLab6()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[orange1]Lab 6: Digital Signatures[/]"));

            if (_rsaKeys == null)
            {
                AnsiConsole.MarkupLine("[yellow]RSA Keys are missing. Using default test keys...[/]");
                _rsaKeys = RsaEngine.GenerateKeys();
            }

            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .AddChoices("Sign Data", "Verify Signature", "[grey]Back[/]"));

            if (choice == "[grey]Back[/]") return;

            if (choice == "Sign Data")
            {
                var text = GetContentInput("Enter text to sign");
                if (string.IsNullOrEmpty(text)) continue;

                try
                {
                    // Виправлено: передаємо D (Private Exponent) та N
                    var signature = DigitalSignatureService.SignData(text, _rsaKeys.D, _rsaKeys.N);
                    AnsiConsole.MarkupLine("[green]Signed successfully![/]");
                    SaveOrPrintResult(signature.ToString());
                }
                catch (Exception ex)
                {
                    PrintErr($"Signing failed: {ex.Message}");
                }
            }
            else if (choice == "Verify Signature")
            {
                var text = GetContentInput("Enter original text");
                if (string.IsNullOrEmpty(text)) continue;

                var sigStr = AskInputOrBack("Enter signature (number)");
                if (sigStr == null) continue;

                if (BigInteger.TryParse(sigStr, out var signature))
                {
                    // Виправлено: передаємо E (Public Exponent) та N
                    var isValid = DigitalSignatureService.VerifySignature(text, signature, _rsaKeys.E, _rsaKeys.N);

                    if (isValid)
                        AnsiConsole.MarkupLine("[green bold]VERIFICATION SUCCESSFUL: Signature is valid.[/]");
                    else
                        AnsiConsole.MarkupLine("[red bold]VERIFICATION FAILED: Signature is invalid![/]");

                    Pause();
                }
                else
                    PrintErr("Invalid signature format");
            }
        }
    }

    // ==========================================
    // HW: WINDOWS CRYPTO API (RC4)
    // ==========================================
    private static void MenuHW()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[red]HW: Windows CryptoAPI (RC4)[/]"));

            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .AddChoices("Encrypt (RC4)", "Decrypt (RC4)", "[grey]Back[/]"));

            if (choice == "[grey]Back[/]") return;

            try
            {
                using var crypto = new WinCryptoWrapper();

                if (choice == "Encrypt (RC4)")
                {
                    var text = GetContentInput("Enter text to encrypt");
                    if (string.IsNullOrEmpty(text)) continue;

                    var encryptedBytes = crypto.EncryptString(text);
                    SaveOrPrintBytes(encryptedBytes);
                }
                else
                {
                    var source = AnsiConsole.Prompt(new SelectionPrompt<string>()
                        .Title("Select Encrypted Source:")
                        .AddChoices("Enter Base64 String", "Read from Binary File", "[grey]Back[/]"));

                    if (source == "[grey]Back[/]") continue;

                    byte[]? inputBytes = null;

                    if (source == "Enter Base64 String")
                    {
                        var b64 = AskInputOrBack("Paste Base64");
                        if (b64 != null) inputBytes = Convert.FromBase64String(b64);
                    }
                    else
                        inputBytes = TryLoadBytesFromFile();

                    if (inputBytes != null)
                    {
                        var decryptedText = crypto.DecryptString(inputBytes);
                        SaveOrPrintResult(decryptedText);
                    }
                }
            }
            catch (Exception ex)
            {
                PrintErr($"CryptoAPI Error: {ex.Message}");
            }
        }
    }

    // ==========================================
    // HELPER METHODS
    // ==========================================

    private static string? GetContentInput(string promptText)
    {
        var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title($"{promptText} via:")
            .AddChoices("Manual Input", "Load from File", "[grey]Back[/]"));

        if (choice == "[grey]Back[/]") return null;

        if (choice == "Manual Input")
            return AskInputOrBack(promptText);

        return TryLoadTextFromFile();
    }

    private static string? TryLoadTextFromFile()
    {
        var rawPath = Ask("Enter file path:");

        if (string.IsNullOrWhiteSpace(rawPath))
        {
            PrintErr("File path is empty.");
            return null;
        }

        var path = rawPath.Trim(trimChar: '"');

        if (!File.Exists(path))
        {
            PrintErr($"File not found: {path}");
            return null;
        }

        return File.ReadAllText(path, Encoding.UTF8);
    }

    private static byte[]? TryLoadBytesFromFile()
    {
        var rawPath = Ask("Enter file path:");

        if (string.IsNullOrWhiteSpace(rawPath))
        {
            PrintErr("File path is empty.");
            return null;
        }

        var path = rawPath.Trim(trimChar: '"');

        if (!File.Exists(path))
        {
            PrintErr($"File not found: {path}");
            return null;
        }

        return File.ReadAllBytes(path);
    }

    private static void SaveOrPrintResult(string content)
    {
        var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Select Output Format:")
            .AddChoices("Print to Console", "Save to File"));

        if (choice == "Print to Console")
        {
            var panel = new Panel(new Text(content));
            panel.Header = new PanelHeader("Result");
            panel.BorderColor(Color.Green);
            AnsiConsole.Write(panel);
            Pause();
        }
        else
        {
            var path = Ask("Enter path to save (.txt):");

            if (!string.IsNullOrWhiteSpace(path))
            {
                File.WriteAllText(path, content);
                AnsiConsole.MarkupLine($"[green]Saved to {path}[/]");
                Pause();
            }
        }
    }

    private static void SaveOrPrintBytes(byte[] data)
    {
        var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Select Output Format:")
            .AddChoices("Print as Base64", "Save Binary to File"));

        if (choice == "Print as Base64")
        {
            var base64 = Convert.ToBase64String(data);
            var panel = new Panel(new Text(base64));
            panel.Header = new PanelHeader("Encrypted Data (Base64)");
            panel.BorderColor(Color.Yellow);
            AnsiConsole.Write(panel);
            Pause();
        }
        else
        {
            var path = Ask("Enter path to save (.bin):");

            if (!string.IsNullOrWhiteSpace(path))
            {
                File.WriteAllBytes(path, data);
                AnsiConsole.MarkupLine($"[green]Saved {data.Length} bytes to {path}[/]");
                Pause();
            }
        }
    }

    private static string? AskInputOrBack(string prompt)
    {
        Console.ResetColor();
        Console.Write($"{prompt} (type 'b' to back): ");
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input) || input.Trim().ToLower() == "b")
            return null;

        return input;
    }

    private static string? Ask(string prompt)
    {
        Console.Write($"{prompt} ");
        return Console.ReadLine();
    }

    private static void PrintErr(string msg)
    {
        AnsiConsole.MarkupLine($"[red]{msg}[/]");
        Pause();
    }

    private static void Pause()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.Markup("[grey]Press any key...[/]");
        Console.ReadKey(intercept: true);
    }
}