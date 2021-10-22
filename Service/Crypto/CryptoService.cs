using MeroBolee.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    /// <summary>
    /// Crypto service interface
    /// </summary>
    public interface ICryptoService
    {
        /// <summary>
        /// Decrypt encrypted content and return specific type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        T Decrypt<T>(string cipherText);
        
        
        /// <summary>
        /// Encrypt content and return encrypted content as string
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        string Encrypt(string plainText);
    }


    /// <summary>
    /// Service to encrypt and decrypt
    /// </summary>
    public class CryptoService : ICryptoService
    {
        private readonly string _encryptionKey;
        private readonly byte[] _encryptionByte;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="cryptoConfig"></param>
        public CryptoService(IOptions<CryptoKeys> cryptoConfig)
        {
            CryptoKeys config = cryptoConfig.Value;

            _encryptionKey = config.EncryptionKey;
            _encryptionByte = Convert.FromBase64String(config.EncryptionByteHash);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="encryptionKey">Key for encryption</param>
        /// <param name="saltHash">Hash salt</param>
        public CryptoService(string  encryptionKey, string saltHash)
        {
            _encryptionKey = encryptionKey;
            _encryptionByte = Convert.FromBase64String(saltHash);
        }


        /// <summary>
        /// Encrypt data using <see cref="RijndaelManaged"/>
        /// </summary>
        /// <param name="plainText">A data to encrypt</param>
        /// <returns></returns>
        public string Encrypt(string plainText)
        {

            RijndaelManaged objrij = new();
            //set the mode for operation of the algorithm
            objrij.Mode = CipherMode.CBC;
            //set the padding mode used in the algorithm.
            objrij.Padding = PaddingMode.PKCS7;
            //set the size, in bits, for the secret key.
            objrij.KeySize = 0x80;
            //set the block size in bits for the cryptographic operation.
            objrij.BlockSize = 0x80;
            //set the symmetric key that is used for encryption & decryption.
            byte[] passBytes = Encoding.UTF8.GetBytes(_encryptionKey);
            //set the initialization vector (IV) for the symmetric algorithm
            byte[] EncryptionkeyBytes = _encryptionByte;
            int len = passBytes.Length;
            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionkeyBytes, len);
            objrij.Key = EncryptionkeyBytes;
            objrij.IV = EncryptionkeyBytes;
            //Creates symmetric AES object with the current key and initialization vector IV.
            ICryptoTransform objtransform = objrij.CreateEncryptor();
            byte[] textDataByte = Encoding.UTF8.GetBytes(plainText);
            //Final transform the test string.
            return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        }


        /// <summary>
        /// Decryp a data encrypted using<see cref="RijndaelManaged"/>
        /// </summary>
        /// <typeparam name="T">Type of a return data</typeparam>
        /// <param name="cipherText">A encrypted data that needs to be decrypted</param>
        /// <returns></returns>
        public T Decrypt<T>(string cipherText)
        {
            RijndaelManaged objrij = new();
            objrij.Mode = CipherMode.CBC;
            objrij.Padding = PaddingMode.PKCS7;
            objrij.KeySize = 0x80;
            objrij.BlockSize = 0x80;
            byte[] encryptedTextByte = Convert.FromBase64String(cipherText);
            byte[] passBytes = Encoding.UTF8.GetBytes(_encryptionKey);
            byte[] EncryptionkeyBytes = new byte[0x10];
            int len = passBytes.Length;
            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionkeyBytes, len);
            objrij.Key = EncryptionkeyBytes;
            objrij.IV = EncryptionkeyBytes;
            byte[] TextByte = objrij.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);
            string val =  Encoding.UTF8.GetString(TextByte);  //it will return readable string
            return (T)Convert.ChangeType(val, typeof(T));
        }
    }
}
