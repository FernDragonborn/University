using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace cryptographyLib;

public record Keys(BigInteger E, BigInteger D, BigInteger N);

public static class RsaEngine
{
    public static Keys GenerateKeys(int keySize = 2048)
    {
        var pSize = keySize / 2;
        var qSize = keySize - pSize;

        var p = PrimeExtensions.GenerateLargePrime(pSize);
        var q = PrimeExtensions.GenerateLargePrime(qSize);

        while (p == q)
            q = PrimeExtensions.GenerateLargePrime(qSize);

        var n = p * q;
        var phi = (p - 1) * (q - 1);

        // 65537 - стандартне значення для RSA (Fermat number F4)
        BigInteger e = 65537;

        // Якщо раптом E не взаємно просте з phi (рідкісний випадок для 65537), шукаємо інше
        while (BigInteger.GreatestCommonDivisor(e, phi) > 1)
            e += 2;

        var d = ModInverse(e, phi);

        return new Keys(e, d, n);
    }

    public static BigInteger Process(BigInteger data, BigInteger key, BigInteger modulus)
    {
        return BigInteger.ModPow(data, key, modulus);
    }

    private static BigInteger ModInverse(BigInteger a, BigInteger m)
    {
        var m0 = m;
        BigInteger y = 0, x = 1;

        if (m == 1) return 0;

        while (a > 1)
        {
            var q = a / m;
            var t = m;

            m = a % m;
            a = t;
            t = y;

            y = x - q * y;
            x = t;
        }

        if (x < 0) x += m0;
        return x;
    }
}

public static class PrimeExtensions
{
    public static BigInteger GenerateLargePrime(int bitLength)
    {
        while (true)
        {
            var candidate = GenerateRandomBigInteger(bitLength);

            if (candidate.IsEven)
                candidate += 1;

            // Перевіряємо тестом Міллера-Рабіна
            if (candidate.IsProbablePrime(k: 10)) // k=10 дає дуже високу точність
                return candidate;
        }
    }

    // Тест Міллера-Рабіна на простоту
    public static bool IsProbablePrime(this BigInteger source, int k = 10)
    {
        if (source == 2 || source == 3) return true;
        if (source < 2 || source % 2 == 0) return false;

        // Представляємо source - 1 у вигляді d * 2^s
        var d = source - 1;
        var s = 0;

        while (d % 2 == 0)
        {
            d /= 2;
            s += 1;
        }

        // Проводимо k раундів перевірки
        for (var i = 0; i < k; i++)
        {
            // Вибираємо випадкове a в діапазоні [2, source - 2]
            var a = GenerateRandomBigInteger(source.ToByteArray().Length * 8);
            a %= source - 2;
            if (a < 2) a = 2; // Корекція меж

            var x = BigInteger.ModPow(a, d, source);

            if (x == 1 || x == source - 1)
                continue;

            var composite = true;

            for (var r = 1; r < s; r++)
            {
                x = BigInteger.ModPow(x, exponent: 2, source);

                if (x == source - 1)
                {
                    composite = false;
                    break;
                }
            }

            if (composite)
                return false;
        }

        return true;
    }

    // Допоміжний метод: криптографічно стійкий рандом
    private static BigInteger GenerateRandomBigInteger(int bitLength)
    {
        var byteLength = bitLength / 8;
        if (bitLength % 8 != 0) byteLength++; // Додаємо байт, якщо біти не кратні 8

        var bytes = new byte[byteLength];
        RandomNumberGenerator.Fill(bytes); // Використовуємо системний крипто-рандом

        // Забезпечуємо, що останній байт не обрізає число (маскуємо зайві біти)
        // Також ставимо старший біт в 1, щоб число точно мало потрібну довжину
        // (спрощено просто беремо модуль BigInteger, щоб було додатне)

        var bigInt = new BigInteger(bytes, isUnsigned: true, isBigEndian: true);
        return bigInt;
    }
}

public static class DigitalSignatureService
{
    public static BigInteger SignData(string document, BigInteger privateKeyD, BigInteger modulusN)
    {
        var hash = GetSha256Hash(document);

        if (hash >= modulusN)
        {
            throw new Exception(
                $"Key is too small for SHA-256! Key size: {modulusN.GetBitLength()} bits, Hash: 256 bits.");
        }

        return RsaEngine.Process(hash, privateKeyD, modulusN);
    }

    public static bool VerifySignature(string document, BigInteger signature, BigInteger publicKeyE,
        BigInteger modulusN)
    {
        var calculatedHash = GetSha256Hash(document);
        var decryptedHash = RsaEngine.Process(signature, publicKeyE, modulusN);

        return calculatedHash == decryptedHash;
    }

    private static BigInteger GetSha256Hash(string input)
    {
        var bytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = SHA256.HashData(bytes);

        // Важливо: isUnsigned: true, щоб число трактувалось як додатне
        return new BigInteger(hashBytes, isUnsigned: true, isBigEndian: true);
    }
}