using System.Security.Cryptography;
using System.Text;

namespace EclipseWorks.Helper
{
    public class PasswordHasher
    {
        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = password + salt;
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private static string ApplyPepper(string hashedPassword)
        {
            var pepper = Environment.GetEnvironmentVariable(SecurityConstants.EclipseWorksPasswordHashPepper);

            using (var sha256 = SHA256.Create())
            {
                var pepperedPassword = hashedPassword + pepper;
                byte[] pepperedPasswordBytes = Encoding.UTF8.GetBytes(pepperedPassword);
                byte[] hashBytes = sha256.ComputeHash(pepperedPasswordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }
    }
}
