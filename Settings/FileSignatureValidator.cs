using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee
{

    /// <summary>
    /// Validate file signature from file extension
    /// </summary>
    public static class FileSignatureValidator
    {
        private static readonly Dictionary<string, List<byte[]>> _fileSignature;
        static FileSignatureValidator()
        {
            _fileSignature = new Dictionary<string, List<byte[]>>{
                { ".jpg", new List<byte[]>
                    {
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE0},
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE1},
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE8},
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 }, //.jpeg extension signature
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }  //.jpeg extension signature
                    }
                },
                { ".jpeg", new List<byte[]>
                    {
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },//.jpg extension signature
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE1}, //.jpg extension signature
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE8}, //.jpg extension signature                        
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }
                    }
                },
                { ".png", new List<byte[]>
                    {
                        //.png extension signature
                        new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A },
                        //.jpg extension signature
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE0},
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE1},
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE8},
                        //.jpeg extension signature
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }
                    }
                },
                { ".pdf", new List<byte[]>
                    {
                        new byte[] { 0x25, 0x50, 0x44, 0x46}
                    }
                },
                { ".doc", new List<byte[]>
                    {
                        new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1},
                        new byte[] { 0xD0, 0x44, 0x4F, 0x43},
                        new byte[] { 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1,0X00},
                        new byte[] { 0xD0, 0xA5, 0x2D, 0x00},
                        new byte[] { 0xEC, 0xA5, 0xC1, 0x00},
                    }
                },
                { ".docx", new List<byte[]>
                    {
                        new byte[] { 0x50, 0x4B, 0x03, 0x04},
                        new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00},
                    }
                },
            };
        }

        /// <summary>
        /// Validate file is actually a given extension file from its signature
        /// </summary>
        /// <param name="file"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static bool ValidateSignature(this IFormFile file, string extension)
        {
            using (var stream = file.OpenReadStream())
            {
                using (var reader = new BinaryReader(stream))
                {
                    var signatures = _fileSignature[extension.ToLowerInvariant()];
                    var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

                    return signatures.Any(signature => headerBytes.Take(signature.Length).SequenceEqual(signature));
                }

            }
        }
    }
}
