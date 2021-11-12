using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nightscript
{
    class NS_CRYPT
    {/// <summary>
     /// 
     /// SHA-2 is a set of cryptographic hash functions designed by the United States National Security Agency
     /// It is not encoding
     /// It is a hash
     ///  
     /// <warning>
     /// 
     /// A hash is not ‘encryption’ – it cannot be decrypted back to the original text 
     /// 
     /// </warning>
     /// 
     /// </summary>
     /// 
     /// <example>
     /// 
     ///  "Hello, World!" becomes "dffd6021bb2bd5b0af676290809ec3a53191dd81c7f70a4b28688a362182986f", yeah.. yikes
     ///  Although, hashing can be very helpful
     ///  Say your application is storing IP's and information for login purposes, someone can crack your application and get to your database
     ///  If you hash the information, they only have the hashed information and not the raw text
     ///  And they have no way of getting the raw text
     ///  
     /// </example>
     /// 
     /// <param name="RawData"></param>
     /// <returns></returns>
        public static string HASH_SHA256(string RawData)
        {
            if (!string.IsNullOrEmpty(RawData) || string.IsNullOrWhiteSpace(RawData))
            {
                using (SHA256 Sha256Hash = SHA256.Create())
                {
                    byte[] Bytes = Sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(RawData));

                    StringBuilder Builder = new StringBuilder();
                    for (int i = 0; i < Bytes.Length; i++)
                    {
                        Builder.Append(Bytes[i].ToString("x2"));
                    }
                    return Builder.ToString();
                }
            }
            else { throw new Exception("Data to hash cannot be empty"); }
        }

        public class BASE_64
        {
            /// <summary>
            /// 
            /// Encoding into Base64 leaves you with an output.. encoded.
            /// 
            /// <example>
            /// 
            /// "Hello, World!" ends up as "SGVsbG8sIFdvcmxkIQ=="
            /// </example>
            /// 
            /// 
            /// </summary>
            /// <param name="Data"></param>
            /// <returns></returns>
            public static string ENCODE_NEW(string Data)
            {
                if (!string.IsNullOrEmpty(Data) || string.IsNullOrWhiteSpace(Data))
                {
                    string Result = null;
                    if (!string.IsNullOrEmpty(Data))
                    {
                        var EncodeData = Encoding.UTF8.GetBytes(Data);
                        Result = Convert.ToBase64String(EncodeData);
                    }
                    return Result;
                }
                else { throw new Exception("Data to Encode cannot be empty"); }
            }
            /// <summary>
            /// 
            /// Decoding into Base64 turns the Base64 encoded string back into raw text
            /// 
            /// <example>
            /// "SGVsbG8sIFdvcmxkIQ==" ends up as "Hello, World!"
            /// </example>
            /// 
            /// </summary>
            /// 
            /// <param name="Data"></param>
            /// <returns></returns>
            public static string DECODE_NEW(string Data)
            {
                if (!string.IsNullOrEmpty(Data) || !string.IsNullOrWhiteSpace(Data))
                {
                    string Result = null;
                    if (!string.IsNullOrEmpty(Data))
                    {
                        byte[] Decoded = Convert.FromBase64String(Data);
                        Result = Encoding.UTF8.GetString(Decoded);
                    }
                    return Result;
                }
                else { throw new Exception("String to Decode cannot be null/empty."); }
            }
        }
    }
}
