using System;
using System.IO;
using System.Security.Cryptography;

public class FileEncryptor
{
    private byte[] key;
    private byte[] iv;

    public FileEncryptor(byte[] key, byte[] iv)
    {
        this.key = key;
        this.iv = iv;
    }

    public void EncryptFile(string inputFile, string outputFile)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
            {
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
                {
                    using (CryptoStream cs = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
                    {
                        fsInput.CopyTo(cs);
                    }
                }
            }
        }
    }
}
