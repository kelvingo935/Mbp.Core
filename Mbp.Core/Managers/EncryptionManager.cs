#region using

using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using Mbp.Core.Security.Cryptography;

#endregion

namespace Mbp.Core.Managers
{
    public static class EncryptionManager
    {
        #region Methods

        private static void CheckKeys(string input,
            ref byte[] publicKey,
            ref byte[] privateKey)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (publicKey == null)
            {
                if (Engine.Current?.EncryptionKey?.PublicKey != null)
                {
                    publicKey = Engine.Current.EncryptionKey.PublicKey;
                }
                else
                {
                    throw new ArgumentNullException(nameof(publicKey));
                }
            }

            if (privateKey == null)
            {
                if (Engine.Current?.EncryptionKey?.PrivateKey != null)
                {
                    privateKey = Engine.Current.EncryptionKey.PrivateKey;
                }
                else
                {
                    throw new ArgumentNullException(nameof(privateKey));
                }
            }
        }

        #endregion

        #region Nested Classes

        public static class Aes
        {
            #region Methods

            public static EncryptionKey GenerateEncryptionKey()
            {
                var ret = new EncryptionKey();

                using (var crypto = System.Security.Cryptography.Aes.Create())
                {
                    crypto.GenerateKey();
                    ret.PublicKey = crypto.Key;
                    crypto.GenerateIV();
                    ret.PrivateKey = crypto.IV;
                }

                return ret;
            }

            public static string Decrypt(string cipherText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                CheckKeys(cipherText, ref publicKey, ref privateKey);

                var byteArr = Convert.FromBase64String(cipherText);
                string ret;
                using (var crypto = System.Security.Cryptography.Aes.Create())
                {
                    crypto.Key = publicKey;
                    crypto.IV = privateKey;

                    var decryptor = crypto.CreateDecryptor(crypto.Key, crypto.IV);

                    using (var msDecrypt = new MemoryStream(byteArr))
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        ret = srDecrypt.ReadToEnd();
                    }
                }

                return ret;
            }

            public static string Decrypt(string cipherText,
                EncryptionKey key)
            {
                return Decrypt(cipherText, key.PublicKey, key.PrivateKey);
            }

            public static T Decrypt<T>(string cipherText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                try
                {
                    return (T)Convert.ChangeType(Decrypt(cipherText, publicKey, privateKey), typeof(T));
                }
                catch (Exception)
                {
                    return default;
                }
            }

            public static T Decrypt<T>(string cipherText,
                EncryptionKey key)
            {
                return Decrypt<T>(cipherText, key.PublicKey, key.PrivateKey);
            }

            public static string Encrypt(string clearText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                CheckKeys(clearText, ref publicKey, ref privateKey);

                byte[] ret;
                using (var crypto = System.Security.Cryptography.Aes.Create())
                {
                    crypto.Key = publicKey;
                    crypto.IV = privateKey;

                    var encryptor = crypto.CreateEncryptor(crypto.Key, crypto.IV);

                    using (var msEncrypt = new MemoryStream())
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(clearText);

                        ret = msEncrypt.ToArray();
                    }
                }

                return Convert.ToBase64String(ret);
            }

            public static string Encrypt(string clearText,
                EncryptionKey key)
            {
                return Encrypt(clearText, key.PublicKey, key.PrivateKey);
            }

            public static string UrlDecrypt(string cipherText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                CheckKeys(cipherText, ref publicKey, ref privateKey);

                var byteArr = Convert.FromBase64String(WebUtility.UrlDecode(cipherText));
                string ret;
                using (var crypto = System.Security.Cryptography.Aes.Create())
                {
                    crypto.Key = publicKey;
                    crypto.IV = privateKey;

                    var decryptor = crypto.CreateDecryptor(crypto.Key, crypto.IV);

                    using (var msDecrypt = new MemoryStream(byteArr))
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        ret = srDecrypt.ReadToEnd();
                    }
                }

                return ret;
            }

            public static string UrlDecrypt(string cipherText,
                EncryptionKey key)
            {
                return UrlDecrypt(cipherText, key.PublicKey, key.PrivateKey);
            }

            public static T UrlDecrypt<T>(string cipherText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                try
                {
                    return (T)Convert.ChangeType(UrlDecrypt(cipherText, publicKey, privateKey), typeof(T));
                }
                catch (Exception)
                {
                    return default;
                }
            }

            public static T UrlDecrypt<T>(string cipherText,
                EncryptionKey key)
            {
                return UrlDecrypt<T>(cipherText, key.PublicKey, key.PrivateKey);
            }

            public static string UrlEncrypt(string clearText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                CheckKeys(clearText, ref publicKey, ref privateKey);

                byte[] ret;
                using (var crypto = System.Security.Cryptography.Aes.Create())
                {
                    crypto.Key = publicKey;
                    crypto.IV = privateKey;

                    var encryptor = crypto.CreateEncryptor(crypto.Key, crypto.IV);

                    using (var msEncrypt = new MemoryStream())
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(clearText);

                        ret = msEncrypt.ToArray();
                    }
                }

                return WebUtility.UrlEncode(Convert.ToBase64String(ret));
            }

            public static string UrlEncrypt(string clearText,
                EncryptionKey key)
            {
                return UrlEncrypt(clearText, key.PublicKey, key.PrivateKey);
            }

            #endregion
        }

        public static class TripleDES
        {
            #region Methods

            public static EncryptionKey GenerateEncryptionKey()
            {
                var ret = new EncryptionKey();

                using (var crypto = System.Security.Cryptography.TripleDES.Create())
                {
                    crypto.GenerateKey();
                    ret.PublicKey = crypto.Key;
                    crypto.GenerateIV();
                    ret.PrivateKey = crypto.IV;
                }

                return ret;
            }

            public static string Decrypt(string cipherText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                CheckKeys(cipherText, ref publicKey, ref privateKey);

                var byteArr = Convert.FromBase64String(cipherText);
                string ret;
                using (var crypto = System.Security.Cryptography.TripleDES.Create())
                {
                    crypto.Key = publicKey;
                    crypto.IV = privateKey;

                    var decryptor = crypto.CreateDecryptor(crypto.Key, crypto.IV);

                    using (var msDecrypt = new MemoryStream(byteArr))
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        ret = srDecrypt.ReadToEnd();
                    }
                }

                return ret;
            }

            public static string Decrypt(string cipherText,
                EncryptionKey key)
            {
                return Decrypt(cipherText, key.PublicKey, key.PrivateKey);
            }

            public static T Decrypt<T>(string cipherText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                try
                {
                    return (T)Convert.ChangeType(Decrypt(cipherText, publicKey, privateKey), typeof(T));
                }
                catch (Exception)
                {
                    return default;
                }
            }

            public static T Decrypt<T>(string cipherText,
                EncryptionKey key)
            {
                return Decrypt<T>(cipherText, key.PublicKey, key.PrivateKey);
            }

            public static string Encrypt(string clearText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                CheckKeys(clearText, ref publicKey, ref privateKey);

                byte[] ret;
                using (var crypto = System.Security.Cryptography.TripleDES.Create())
                {
                    crypto.Key = publicKey;
                    crypto.IV = privateKey;

                    var encryptor = crypto.CreateEncryptor(crypto.Key, crypto.IV);

                    using (var msEncrypt = new MemoryStream())
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(clearText);

                        ret = msEncrypt.ToArray();
                    }
                }

                return Convert.ToBase64String(ret);
            }

            public static string Encrypt(string clearText,
                EncryptionKey key)
            {
                return Encrypt(clearText, key.PublicKey, key.PrivateKey);
            }

            public static string UrlDecrypt(string cipherText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                CheckKeys(cipherText, ref publicKey, ref privateKey);

                var byteArr = Convert.FromBase64String(WebUtility.UrlDecode(cipherText));
                string ret;
                using (var crypto = System.Security.Cryptography.TripleDES.Create())
                {
                    crypto.Key = publicKey;
                    crypto.IV = privateKey;

                    var decryptor = crypto.CreateDecryptor(crypto.Key, crypto.IV);

                    using (var msDecrypt = new MemoryStream(byteArr))
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        ret = srDecrypt.ReadToEnd();
                    }
                }

                return ret;
            }

            public static string UrlDecrypt(string cipherText,
                EncryptionKey key)
            {
                return UrlDecrypt(cipherText, key.PublicKey, key.PrivateKey);
            }

            public static T UrlDecrypt<T>(string cipherText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                try
                {
                    return (T)Convert.ChangeType(UrlDecrypt(cipherText, publicKey, privateKey), typeof(T));
                }
                catch (Exception)
                {
                    return default;
                }
            }

            public static T UrlDecrypt<T>(string cipherText,
                EncryptionKey key)
            {
                return UrlDecrypt<T>(cipherText, key.PublicKey, key.PrivateKey);
            }

            public static string UrlEncrypt(string clearText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                CheckKeys(clearText, ref publicKey, ref privateKey);

                byte[] ret;
                using (var crypto = System.Security.Cryptography.TripleDES.Create())
                {
                    crypto.Key = publicKey;
                    crypto.IV = privateKey;

                    var encryptor = crypto.CreateEncryptor(crypto.Key, crypto.IV);

                    using (var msEncrypt = new MemoryStream())
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(clearText);

                        ret = msEncrypt.ToArray();
                    }
                }

                return WebUtility.UrlEncode(Convert.ToBase64String(ret));
            }

            public static string UrlEncrypt(string clearText,
                EncryptionKey key)
            {
                return UrlEncrypt(clearText, key.PublicKey, key.PrivateKey);
            }

            #endregion
        }

        #endregion
    }
}
