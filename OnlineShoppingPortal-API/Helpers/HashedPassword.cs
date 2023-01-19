using System.Security.Cryptography;

namespace OnlineShoppingPortal_API.Helpers
{
    public class HashedPassword
    {
        // custom encryption apart from RSA, SHA, Hill Escrow etc
        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        private static readonly int SaltSize = 16;
        private static readonly int HashSize = 20;
        private static readonly int Iterations = 10000;

        public static string HashedPass(string password)
        {
            byte[] salt;
            rng.GetBytes(salt = new byte[SaltSize]);
            // create key
            var key = new Rfc2898DeriveBytes(password, salt, Iterations);
            // create hash
            var hash = key.GetBytes(HashSize);
            var hashBytes = new byte[SaltSize + HashSize];
            // pass source, destionation, length
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // get hash into base64 string
            var base64Hash = Convert.ToBase64String(hashBytes);

            return base64Hash;
        }

        public static bool VerifyPass(string password, string base64Hash) 
        {
            // convert base64 string into bytes
            // reversal
            var hashBytes = Convert.FromBase64String(base64Hash);
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var key = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = key.GetBytes(HashSize);

            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i+SaltSize] != hash[i]) // matching against pw with hash bytes64
                {
                    return false;
                }
            }
            return true;
        }
    }
}
