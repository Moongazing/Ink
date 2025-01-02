using System.Security.Cryptography;
using System.Text;

namespace Moongazing.Ink.Kernel.Security.Hashing;

public static class HashingHelper
{
    public static void CreateHash(string input, out byte[] inputHash, out byte[] inputSalt)
    {
        using HMACSHA512 hmac = new();

        inputSalt = hmac.Key;
        inputHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));
    }
    public static bool VerifyHash(string input, byte[] inputHash, byte[] inputSalt)
    {
        using HMACSHA512 hmac = new(inputSalt);

        byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));

        return computedHash.SequenceEqual(inputHash);
    }
}
