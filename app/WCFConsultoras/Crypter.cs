﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WCFConsultoras
{
    public class Crypter
    {
        public static string DecryptRJ256(string prm_key, string prm_iv, string prm_text_to_decrypt)
        {
            try
            {
                var sEncryptedString = prm_text_to_decrypt;

                var myRijndael = new RijndaelManaged()
                {
                    Padding = PaddingMode.Zeros,
                    Mode = CipherMode.CBC,
                    KeySize = 256,
                    BlockSize = 256
                };

                var key = Encoding.ASCII.GetBytes(prm_key);
                var IV = Encoding.ASCII.GetBytes(prm_iv);

                var decryptor = myRijndael.CreateDecryptor(key, IV);

                var sEncrypted = Convert.FromBase64String(sEncryptedString);

                var fromEncrypt = new byte[sEncrypted.Length];

                var msDecrypt = new MemoryStream(sEncrypted);
                var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);



                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                return (Encoding.ASCII.GetString(fromEncrypt));
            }
            catch (Exception ex)
            {
                return null;
            }
          
        }

        public static string EncryptRJ256(string prm_key, string prm_iv, string prm_text_to_encrypt)
        {

            try
            {
                var sToEncrypt = prm_text_to_encrypt;

                var myRijndael = new RijndaelManaged()
                {
                    Padding = PaddingMode.Zeros,
                    Mode = CipherMode.CBC,
                    KeySize = 256,
                    BlockSize = 256
                };

                var key = Encoding.ASCII.GetBytes(prm_key);
                var IV = Encoding.ASCII.GetBytes(prm_iv);

                var encryptor = myRijndael.CreateEncryptor(key, IV);

                var msEncrypt = new MemoryStream();
                var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

                var toEncrypt = Encoding.ASCII.GetBytes(sToEncrypt);

                csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
                csEncrypt.FlushFinalBlock();

                var encrypted = msEncrypt.ToArray();

                return (Convert.ToBase64String(encrypted));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
