using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SMET
{
    public class Encrypter
    {
        public string Encrypt3Des(string source, string key)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB;
            byteBuff = Encoding.UTF8.GetBytes(source);

            string encoded =
                Convert.ToBase64String(desCryptoProvider.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            return encoded;
        }
        public string Decrypt3Des(string encodedText, string key)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB;
            byteBuff = Convert.FromBase64String(encodedText);

            string plaintext = Encoding.UTF8.GetString(desCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            return plaintext;
        }
        public string DecryptDes(string inputString, string encKey)
        {
            MemoryStream memStream = null;
            try
            {
                byte[] key = { };
                byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
                var encryptKey = encKey;
                key = Encoding.UTF8.GetBytes(encryptKey);
                byte[] byteInput = new byte[inputString.Length];
                byteInput = Convert.FromBase64String(inputString);
                var provider = new DESCryptoServiceProvider();
                memStream = new MemoryStream();
                var transform = provider.CreateDecryptor(key, IV);
                var cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                cryptoStream.Write(byteInput, 0, byteInput.Length);
                cryptoStream.FlushFinalBlock();
            }
            catch (Exception ex)
            {
                throw;
            }
            var encoding1 = Encoding.UTF8;
            return encoding1.GetString(memStream.ToArray());
        }
        public static string DecryptAes(string encryptedText, string password)
        {
            if (encryptedText == null)
            {
                return null;
            }
            if (password == null)
            {
                password = string.Empty;
            }
            var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            var bytesDecrypted = Encrypter.DecryptAes(bytesToBeDecrypted, passwordBytes);
            return Encoding.UTF8.GetString(bytesDecrypted);
        }
        private static byte[] DecryptAes(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;
                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
        }
        public string DecryptDesCsharpString()
        {
            var decCode = "class Encrypter { public string DecryptDes(string inputString, string encKey) { MemoryStream memStream = null; try { byte[] key = { }; byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 }; var encryptKey = encKey; key = Encoding.UTF8.GetBytes(encryptKey); byte[] byteInput = new byte[inputString.Length]; byteInput = Convert.FromBase64String(inputString); var provider = new DESCryptoServiceProvider(); memStream = new MemoryStream(); var transform = provider.CreateDecryptor(key, IV); var cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write); cryptoStream.Write(byteInput, 0, byteInput.Length); cryptoStream.FlushFinalBlock(); } catch (Exception ex) { throw; } var encoding1 = Encoding.UTF8; return encoding1.GetString(memStream.ToArray()); } }";
            return decCode;
        }
        public string DecryptAesCsharpString()
        {
            var decCode = "public static class Encrypter { public static string DecryptAes(string encryptedText, string password) { if (encryptedText == null) { return null; } if (password == null) { password = String.Empty; } var bytesToBeDecrypted = Convert.FromBase64String(encryptedText); var passwordBytes = Encoding.UTF8.GetBytes(password); passwordBytes = SHA256.Create().ComputeHash(passwordBytes); var bytesDecrypted = Encrypter.Decrypt(bytesToBeDecrypted, passwordBytes); return Encoding.UTF8.GetString(bytesDecrypted); } private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes) { byte[] decryptedBytes = null; var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }; using (MemoryStream ms = new MemoryStream()) { using (RijndaelManaged AES = new RijndaelManaged()) { var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000); AES.KeySize = 256; AES.BlockSize = 128; AES.Key = key.GetBytes(AES.KeySize / 8); AES.IV = key.GetBytes(AES.BlockSize / 8); AES.Mode = CipherMode.CBC; using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write)) { cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length); cs.Close(); } decryptedBytes = ms.ToArray(); } } return decryptedBytes; } }";
            return decCode;
        }
    }
}
