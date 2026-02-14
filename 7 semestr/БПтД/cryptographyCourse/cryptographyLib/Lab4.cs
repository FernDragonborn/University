using System;
using System.Collections.Generic;

namespace cryptographyLib;

public class LinearCongruentialGenerator(int seed)
{
    public IEnumerable<object>? Next()
    {
        throw new NotImplementedException();
    }
}

public class XorCipher
{
    public byte[] Transform(byte[] originalData, int seed)
    {
        throw new NotImplementedException();
    }
}