#region using

using System;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace Mbp.Core.Managers
{
    public static class HashManager
    {
        #region Methods

        public static string CreateSaltKey(int size)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var buff = new byte[size];
                rng.GetBytes(buff);
                return Convert.ToBase64String(buff);
            }
        }

        #endregion

        #region Nested Classes

        public static class MD5
        {
            #region Methods

            public static string Hash(string text)
            {
                using (var crypto = System.Security.Cryptography.MD5.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                using (var crypto = System.Security.Cryptography.MD5.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{text}{salt}"));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            #endregion
        }

        public static class SHA1
        {
            #region Methods

            public static string Hash(string text)
            {
                using (var crypto = System.Security.Cryptography.SHA1.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                using (var crypto = System.Security.Cryptography.SHA1.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{text}{salt}"));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            #endregion
        }

        public static class SHA256
        {
            #region Methods

            public static string Hash(string text)
            {
                using (var crypto = System.Security.Cryptography.SHA256.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                using (var crypto = System.Security.Cryptography.SHA256.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{text}{salt}"));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            #endregion
        }

        public static class SHA384
        {
            #region Methods

            public static string Hash(string text)
            {
                using (var crypto = System.Security.Cryptography.SHA384.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                using (var crypto = System.Security.Cryptography.SHA384.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{text}{salt}"));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            #endregion
        }

        public static class SHA512
        {
            #region Methods

            public static string Hash(string text)
            {
                using (var crypto = System.Security.Cryptography.SHA512.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                using (var crypto = System.Security.Cryptography.SHA512.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{text}{salt}"));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            #endregion
        }

        public static class HMACMD5
        {
            #region Methods

            public static string Hash(string text)
            {
                using (var crypto = HMAC.Create("HMACMD5"))
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                using (var crypto = HMAC.Create("HMACMD5"))
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{text}{salt}"));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            #endregion
        }

        public static class HMACSHA1
        {
            #region Methods

            public static string Hash(string text)
            {
                using (var crypto = HMAC.Create("HMACSHA1"))
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                using (var crypto = HMAC.Create("HMACSHA1"))
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{text}{salt}"));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            #endregion
        }

        public static class HMACSHA256
        {
            #region Methods

            public static string Hash(string text)
            {
                using (var crypto = HMAC.Create("HMACSHA256"))
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                using (var crypto = HMAC.Create("HMACSHA256"))
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{text}{salt}"));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            #endregion
        }

        public static class HMACSHA384
        {
            #region Methods

            public static string Hash(string text)
            {
                using (var crypto = HMAC.Create("HMACSHA384"))
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                using (var crypto = HMAC.Create("HMACSHA384"))
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{text}{salt}"));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            #endregion
        }

        public static class HMACSHA512
        {
            #region Methods

            public static string Hash(string text)
            {
                using (var crypto = HMAC.Create("HMACSHA512"))
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                using (var crypto = HMAC.Create("HMACSHA512"))
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{text}{salt}"));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            #endregion
        }

        public static class MACTripleDES
        {
            #region Methods

            public static string Hash(string text)
            {
                using (var crypto = HMAC.Create("MACTripleDES"))
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                using (var crypto = HMAC.Create("MACTripleDES"))
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{text}{salt}"));
                    return BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }
            }

            #endregion
        }

        #endregion
    }
}
