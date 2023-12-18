using System.Security.Cryptography;

namespace Atm.Hashing;

public static class SaltGenerator
{
    public static string GenerateSalt()
    {
        const int saltSize = 16;

        byte[] saltBytes = new byte[saltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }

        string salt = Convert.ToBase64String(saltBytes);

        return salt;
    }
}
