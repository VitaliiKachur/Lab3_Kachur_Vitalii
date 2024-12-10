using System;
using System.IO;
using System.Security.Cryptography;

namespace Lab3_Kachur_Vitalii
{
    public class FileEncryptor
    {
        private readonly byte[] _key;
        public delegate void ProgressUpdate(int progress);

        public FileEncryptor(string key)
        {
            if (key.Length < 16)
                throw new ArgumentException("Ключ має бути не менше 16 символів.");
            _key = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 16));
        }

        public void Encrypt(string inputFile, string outputFile, ProgressUpdate progressCallback = null)
        {
            using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
            using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;

                aes.GenerateIV();
                byte[] iv = aes.IV;

                fsOutput.Write(iv, 0, iv.Length);

                using (CryptoStream cs = new CryptoStream(fsOutput, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] buffer = new byte[1024];
                    long totalBytesRead = 0;
                    int bytesRead;

                    while ((bytesRead = fsInput.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        cs.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;

                        progressCallback?.Invoke((int)((totalBytesRead / (double)fsInput.Length) * 100));
                    }
                }
            }
        }

        public void Decrypt(string inputFile, string outputFile, ProgressUpdate progressCallback = null)
        {
            using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
            using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;

                byte[] iv = new byte[16];
                fsInput.Read(iv, 0, iv.Length);
                aes.IV = iv;

                using (CryptoStream cs = new CryptoStream(fsInput, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] buffer = new byte[1024];
                    long totalBytesRead = 0;
                    int bytesRead;

                    while ((bytesRead = cs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fsOutput.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;

                        progressCallback?.Invoke((int)((totalBytesRead / (double)fsInput.Length) * 100));
                    }
                }
            }
        }
    }
}
