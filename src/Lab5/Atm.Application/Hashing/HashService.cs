using System.Security.Cryptography;
using System.Text;

namespace Atm.Hashing;

public static class HashService
{
    public static string HashPasswordWithSalt(string passwordWithSalt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(passwordWithSalt);

        byte[] hashedBytes = SHA256.HashData(passwordBytes);

        return Convert.ToBase64String(hashedBytes);
    }

    public static bool VerifyPassword(string enteredPassword, string storedHashedPassword, string storedSalt)
    {
        string passwordWithSalt = enteredPassword + storedSalt;

        string hashedEnteredPassword = HashPasswordWithSalt(passwordWithSalt);

        return hashedEnteredPassword == storedHashedPassword;
    }
}