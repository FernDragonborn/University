using System;
using System.Numerics;

namespace cryptographyLib;

public record Keys(int E, int D, int N);

public class RSAEngine
{
    public Keys GenerateKeys(int p, int q)
    {
        throw new NotImplementedException();
    }

    public BigInteger Encrypt(BigInteger message, object o, object o1)
    {
        throw new NotImplementedException();
    }

    public static BigInteger ModPow(BigInteger baseVal, BigInteger exp, BigInteger mod)
    {
        throw new NotImplementedException();
    }

    public BigInteger Decrypt(BigInteger encrypted, object o, object o1)
    {
        throw new NotImplementedException();
    }
}

public class DigitalSignatureService
{
    public object SignData(string document, object o, object o1)
    {
        throw new NotImplementedException();
    }

    public bool VerifySignature(string tamperedDocument, object signature, object o, object o1)
    {
        throw new NotImplementedException();
    }
}