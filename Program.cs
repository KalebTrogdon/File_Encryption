using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        string inputFile = "input.txt";
        string encryptedFile = "encrypted.txt";
        string decryptedFile = "decrypted.txt";

        // Generate random key and IV
        byte[] key = GenerateRandomKey();
        byte[] iv = GenerateRandomIV();

        // Encrypt the file
        FileEncryptor encryptor = new FileEncryptor(key, iv);
        encryptor.EncryptFile(inputFile, encryptedFile);
        Console.WriteLine("File encrypted successfully!");

        // Decrypt the file
        FileDecryptor decryptor = new FileDecryptor(key, iv);
        decryptor.DecryptFile(encryptedFile, decryptedFile);
        Console.WriteLine("File decrypted successfully!");
    }

    static byte[] GenerateRandomKey()
    {
        byte[] key = new byte[16]; // 16 bytes for AES 128
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(key);
        }
        return key;
    }

    static byte[] GenerateRandomIV()
    {
        byte[] iv = new byte[16]; // 16 bytes for AES 128
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(iv);
        }
        return iv;
    }
}
