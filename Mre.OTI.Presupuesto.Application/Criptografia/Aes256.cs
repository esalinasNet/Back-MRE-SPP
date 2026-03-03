using System;
using System.IO;
using System.Security.Cryptography;

namespace Mre.tecnologia.util.lib.Criptografia
{
    public class Aes256
    {
        public static byte[] EncriptarStringABytes(string textoPlano, byte[] key, out byte[] iv)
        {
            // Check arguments.
            if (textoPlano == null || textoPlano.Length <= 0)
                throw new ArgumentNullException("Ingrese el parámetro: texto");
            if (key == null || key.Length != 32)
                throw new ArgumentNullException("Ingrese el parámetro: clave");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aes = Aes.Create())
            {
                aes.BlockSize = 128;
                aes.KeySize = 256;
                aes.Key = key;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;

                iv = aes.IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(textoPlano);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public static string EncriptarStringABase64String(string textoPlano, byte[] key, out byte[] iv)
        {
            // Check arguments.
            if (textoPlano == null || textoPlano.Length <= 0)
                throw new ArgumentNullException("Ingrese el parámetro: texto");
            if (key == null || key.Length != 32)
                throw new ArgumentNullException("Ingrese el parámetro: clave");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aes = Aes.Create())
            {
                aes.BlockSize = 128;
                aes.KeySize = 256;
                aes.Key = key;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;

                iv = aes.IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(textoPlano);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return Convert.ToBase64String(encrypted);
        }

        public static string DesencriptarBytesAString(byte[] textoCifrado, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (textoCifrado == null || textoCifrado.Length <= 0)
                throw new ArgumentNullException("Ingrese el parámetro: textoCifrado");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Ingrese el parámetro: key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("Ingrese el parámetro: vector de inicialización");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aes = Aes.Create())
            {
                aes.BlockSize = 128;
                aes.KeySize = 256;
                aes.Key = key;
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(textoCifrado))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        public static string DesencriptarBase64StringAString(string textoCifrado, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (textoCifrado == null || textoCifrado.Length <= 0)
                throw new ArgumentNullException("Ingrese el parámetro: textoCifrado");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Ingrese el parámetro: key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("Ingrese el parámetro: vector de inicialización");

            byte[] arrayCifrado = Convert.FromBase64String(textoCifrado);

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aes = Aes.Create())
            {
                aes.BlockSize = 128;
                aes.KeySize = 256;
                aes.Key = key;
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(arrayCifrado))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        public static string GenerarKey(bool useHex = false)
        {
            int keyByteSize = 32;
            byte[] randomArray = new byte[keyByteSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomArray);
            }
            if (useHex)
                return BitConverter.ToString(randomArray).Replace("-", "");
            else
                return Convert.ToBase64String(randomArray);
        }
    }
}
