using IM.Application.Interfaces.Services;
using IM.Domain.Options;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace IM.Infrastructure.Services
{
    public class PasswordHash : IPasswordHash
    {
        private readonly PasswordOptions _options;

        public PasswordHash(IOptions<PasswordOptions> options)
        {
            _options = options.Value;
        }

        /// <summary>
        /// Creates a hash from the informed string.
        /// </summary>
        /// <param name="password">The string to be hashed</param>
        /// <returns>The hashed string with an prefixed identifier + number of iterations + hashed string</returns>
        public string Hash(string password)
        {
            var salt = GenerateSalt(_options.SaltSize);
            var hash = GenerateHash(password, salt, _options.Iterations, _options.HashSize);

            // Combine salt and hash
            var hashBytes = new byte[_options.SaltSize + _options.HashSize];
            Array.Copy(salt, 0, hashBytes, 0, _options.SaltSize);
            Array.Copy(hash, 0, hashBytes, _options.SaltSize, _options.HashSize);

            // Convert to base64
            var base64Hash = Convert.ToBase64String(hashBytes);

            // Format hash with extra information
            return string.Format("$HASH$V1${0}${1}", _options.Iterations, base64Hash);
        }

        /// <summary>
        /// Validates the prefixed identifier from hash
        /// </summary>
        /// <param name="hashString">The hash</param>
        /// <returns>Is the hash prefix identifier valid?</returns>
        public bool IsHashSupported(string hashString)
        {
            return hashString.Contains("$HASH$V1$");
        }

        /// <summary>
        /// Verifies a password against a hash.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hashedPassword"></param>
        /// <returns>
        /// Is the informed string a match for the informed hashed string?
        /// </returns>
        public bool Verify(string password, string hashedPassword)
        {
            // Check hash
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }

            // Extract iteration and Base64 string
            var splittedHashString = hashedPassword.Replace("$HASH$V1$", "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            // Get hash bytes
            var hashBytes = Convert.FromBase64String(base64Hash);

            // Get salt
            var salt = new byte[_options.SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, _options.SaltSize);

            // Create hash with given salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(_options.HashSize);

            // Get result
            for (var i = 0; i < _options.HashSize; i++)
            {
                if (hashBytes[i + _options.SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Generates the salt bytes
        /// </summary>
        /// <param name="saltSize">Salt byte size - Defined in appsettings</param>
        /// <returns>Salt bytes with defined size</returns>
        private byte[] GenerateSalt(int saltSize)
        {
            using (var generator = RandomNumberGenerator.Create())
            {
                var salt = new byte[saltSize];
                generator.GetBytes(salt);
                return salt;
            }
        }

        /// <summary>
        /// Generates the hash string
        /// </summary>
        /// <param name="password">string to be hashed</param>
        /// <param name="salt">salt byte - From GenerateSalt Method</param>
        /// <param name="iterations">Number of iterations - Defined in appsettings</param>
        /// <param name="hashSize">Defined hash size - appsettings</param>
        /// <returns>Hashed string</returns>
        private byte[] GenerateHash(string password, byte[] salt, int iterations, int hashSize)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return pbkdf2.GetBytes(hashSize);
            }
        }
    }
}
