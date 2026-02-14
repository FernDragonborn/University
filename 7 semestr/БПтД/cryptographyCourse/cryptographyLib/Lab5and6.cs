using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace cryptographyLib;

public record Keys(BigInteger E, BigInteger D, BigInteger N);

public static class RsaEngine
{
    public static Keys GenerateKeys(BigInteger p, BigInteger q)
    {
        var n = p * q;
        var phi = (p - 1) * (q - 1);

        BigInteger e = 65537; 
        if (e >= phi || BigInteger.GreatestCommonDivisor(e, phi) != 1)
        {
            e = 3;
            while (BigInteger.GreatestCommonDivisor(e, phi) > 1)
            {
                e += 2;
            }
        }

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

        if (m == 1) 
            return 0;

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

public static class DigitalSignatureService
{
    public static BigInteger SignData(string document, BigInteger privateKeyD, BigInteger modulusN)
    {
        var hash = GetSha256Hash(document); 
        
        if (hash >= modulusN)
            throw new Exception($"Key is too small for SHA-256! N bits: {modulusN.GetBitLength()}, Hash bits: 256");

        return RsaEngine.Process(hash, privateKeyD, modulusN);
    }

    public static bool VerifySignature(string document, BigInteger signature, BigInteger publicKeyE, BigInteger modulusN)
    {
        var calculatedHash = GetSha256Hash(document);
        var decryptedHash = RsaEngine.Process(signature, publicKeyE, modulusN);

        return calculatedHash == decryptedHash;
    }

    /// <summary>
    /// Повноцінна хеш-функція SHA-256
    /// </summary>
    private static BigInteger GetSha256Hash(string input)
    {
        var bytes = Encoding.UTF8.GetBytes(input);
        var hash = SHA256.HashData(bytes);

        // BigInteger очікує Little Endian і може бути від'ємним, якщо старший біт 1.
        // Додаємо 0-байт у кінець, щоб число гарантовано було додатним.
        var positiveHash = new byte[hash.Length + 1];
        Buffer.BlockCopy(hash, 0, positiveHash, 0, hash.Length);

        return new BigInteger(positiveHash);
    }
}