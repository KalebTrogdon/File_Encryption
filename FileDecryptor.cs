using System;
using System.IO;
using System.Security.Cryptography;

public class FileDecryptor
{
    private byte[] key;
    private byte[] iv;

    public FileDecryptor(byte[] key, byte[] iv)
    {
        this.key = key;
        this.iv = iv;
    }

    public void DecryptFile(string inputFile, string outputFile)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
            {
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
                {
                    using (CryptoStream cs = new CryptoStream(fsInput, decryptor, CryptoStreamMode.Read))
                    {
                        cs.CopyTo(fsOutput);
                    }
                }
            }
        }
    }
}
