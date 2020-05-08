using RVT_Block_lib.Models;
using RVT_Block_lib.Responses;
using RVTLibrary.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RVTLibrary.Algoritms
{
    public class Cipher : ICipher
    {
        string pidvn = "";
        public NodeRegResponse Decrypt(string encrypt)
        {
            NodeRegMessage node1 = new NodeRegMessage();
            NodeRegResponse node = new NodeRegResponse();
            var idbdDecrypt = Convert.FromBase64String(encrypt);
            var keyBytes = Encoding.UTF8.GetBytes(pidvn);

            keyBytes = SHA256.Create().ComputeHash(keyBytes);

            var IDBDDecrypted = Cipher.Decrypt(idbdDecrypt,keyBytes);
            string decrypted=Encoding.UTF8.GetString(IDBDDecrypted);
            var result = decrypted.Split("_");
            for (int i = 0; i <= result.Length; i++)
                node1.NeighBours[i].NodeId = result[i];

            return node;

        }
        public string Encrypt(NodeRegMessage node)
        {
            string idbdtext="";
            for (int i = 0; i<= node.NeighBours.Count; i++)
                idbdtext = node.NeighBours[i].NodeId;
            var idbdEncrypt = Encoding.UTF8.GetBytes(idbdtext);
            var keyBytes = Encoding.UTF8.GetBytes(node.NeighBours.ToString());

            keyBytes = SHA256.Create().ComputeHash(keyBytes);

            var idbdEncrypted = Cipher.Encrypt(idbdEncrypt, keyBytes);

            return Convert.ToBase64String(idbdEncrypted);
        }
        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;
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

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
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
    }
}
