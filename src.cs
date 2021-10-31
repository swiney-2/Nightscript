using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;

namespace Moon
{
    /// <summary>
    /// Http stuff
    /// </summary>
    public class Http
    {
        /// <summary>
        /// Returns the raw text of a Uri (string Url)
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static string Loadstring(Uri Url) {
            using (WebClient wbc = new WebClient()) { 
              return wbc.DownloadString(Url);
            }
        }
        /// <summary>
        /// Sends an HTTP request ("Method") to Uri "URL"
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Method"></param>
        public static void Request(Uri Url, string Method)
        {
            using (HttpClient HttpClient = new HttpClient())
            {
                try
                {
                    switch (Method)
                    {
                        case "GET":
                            HttpClient.GetAsync(Url);
                            break;
                        case "DELETE":
                            HttpClient.DeleteAsync(Url);
                            break;
                        default:
                            throw new Exception("Invalid HttpRequest method.\nPlease use GET or DELETE");
                            break;
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show($"Caught Exception: \n{Ex.Message}\n\nPlease Retry", "Moon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    /// <summary>
    /// Process stuff
    /// </summary>
    public class Proc {
        /// <summary>
        /// Ends the process "proc"
        /// </summary>
        /// <param name="proc"></param>
        public static void KillProccess(string proc) {
            foreach (var woobie in Process.GetProcessesByName(proc)) {
                woobie.Kill();
            }
        }
        public static void Start(string path)
            => Process.Start(path);
        /// <summary>
        /// Returns the boolean true if the process "procname" exists
        /// </summary>
        /// <param name="procname"></param>
        /// <returns></returns>
        public static bool Exists(string procname) {
            if (Process.GetProcessesByName(procname).Length > 0)
            {
                return true;
            }
            else return false;
        }
    }
    /// <summary>
    /// A file system with features ye
    /// </summary>
    public class FileSystem
    {
        /// <summary>
        /// Returns the text of the file located at "Path"
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static string ReadFile(string Path)
        {
            string Text = null;

            if (!string.IsNullOrEmpty(Path) || !string.IsNullOrWhiteSpace(Path) )
            {
                if (!File.Exists(Path)) { throw new Exception($"Invalid Path Located At {Path}"); }
                else { Text = File.ReadAllText(Path); }
            }
            else { throw new Exception("File Path cannot be empty\n\nMoon.ReadFile"); }

            return Text;
        }

        /// <summary>
        /// If a file exists at "DirectoryPath" it returns true
        /// If no file exists, if returns false
        /// </summary>
        /// <param name="DirectoryPath"></param>
        /// <returns></returns>
        public static bool FolderExists(string DirectoryPath)
        {
            if (!string.IsNullOrEmpty(DirectoryPath) || !string.IsNullOrWhiteSpace(DirectoryPath))
            {
                if (!Directory.Exists(DirectoryPath)) { return false; }
                else { return true; }
            }
            else { throw new Exception("Folder Exists directory cannot be empty\n\nMoon.FolderExists"); }
        }

        /// <summary>
        /// Deletes a directory located at "Path"
        /// </summary>
        /// <param name="Path"></param>
        public static void DeleteDirectory(string Path)
        {
            if (!string.IsNullOrEmpty(Path) || !string.IsNullOrWhiteSpace(Path))
            {
                if (Directory.Exists(Path)) { Directory.Delete(Path); } else { throw new Exception($"Invalid path located at {Path}"); }
            }
            else { throw new Exception("Delete Directory path cannot be empty\n\nMoon.DeleteDirectory"); }
        }
        /// <summary>
        /// Adds text ("Data") to the file located at "Path"
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Data"></param>
        public static void AppendText(string Path, string Data)
        {
            if (!string.IsNullOrEmpty(Path) || !string.IsNullOrEmpty(Data))
            {
                using (var StreamWriter = File.AppendText(Path))
                { StreamWriter.Write(Data); StreamWriter.Close(); }
            }
            else { throw new Exception($"Invalid Path Located At {Path}"); }
        }

        /// <summary>
        /// Creates a Directory (not file) located at "Path"
        /// </summary>
        /// <param name="Path"></param>
        public static void MakeDirectory(string Path)
        {
            if (!string.IsNullOrEmpty(Path) || !string.IsNullOrWhiteSpace(Path)) { Directory.CreateDirectory(Path); }
            else { throw new Exception($"Invalid Path Located At {Path}"); }
        }

        /// <summary>
        /// Writes "data" to the file located at "path"
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Data"></param>
        public static void WriteFile(string Path, string Data)
        {
            if (!string.IsNullOrEmpty(Path) || !string.IsNullOrWhiteSpace(Path)) {
                if (!File.Exists(Path)) { throw new Exception($"Invalid Path Located At {Path}"); }
                else { File.WriteAllText(Path, Data); }
            }
            else throw new Exception($"Invalid Path Located At {Path}");
        }
        /// <summary>
        /// Creates a file at path
        /// </summary>
        /// <param name="path"></param>
        public static void MakeFile(string path)
        {
            if (!string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
            {
                File.Create(path);
            }
            else { throw new Exception("Path cannot be null/empty/whitespace"); }
        }

        /// <summary>
        /// Deletes file located at FilePath
        /// </summary>
        /// <param name="FilePath"></param>
        public static void DeleteFile(string FilePath)
        {
            if (string.IsNullOrEmpty(FilePath) || string.IsNullOrWhiteSpace(FilePath))
            {
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }
                else { throw new Exception($"Invalid Path Located At {FilePath}"); }
            }
            else { throw new Exception("Path cannot be null/empty/whitespace"); /* kill me */ }
        }

        /// <summary>
        /// If the file exists, it returns true, otherwise returns false
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static bool FileExists(string FilePath)
        {
            if (string.IsNullOrWhiteSpace(FilePath) || string.IsNullOrEmpty(FilePath))
            {
                bool Result = false;

                if (File.Exists(FilePath)) { Result = true; }
                else { Result = false; }

                return Result;
            }
            else { throw new Exception("FilePath cannot be empty."); }
        }
    }
    /// <summary>
    /// 
    /// This is the output class
    /// It can be used in the Windows terminal debugger and debug output to do multiple things
    /// 
    /// </summary>
    public class Output
    {
        /// <summary>
       ///  Clears Console
      /// </summary>
        public static void Clear()
            => Console.Clear();
        /// <summary>
        /// 
        /// Prints the text to line
        /// 
        /// </summary>
        /// <param name="Text"></param>
        public static void PrintToLine(string Text)
            => Console.WriteLine(Text);
        /// <summary>
        /// Reads the line of the console, can be returned
        /// <example>
        /// string helloworld = Output.ReadLine();
        /// </example>
        /// </summary>
        public static void ReadLine()
            => Console.ReadLine();
        /// <summary>
        /// Writes to the debug in visual studio
        /// </summary>
        /// <param name="Text"></param>
        public static void DebugWrite(string Text)
            => Debug.WriteLine($"[MOON] {Text}");
        /// <summary>
        /// Prints without going to the next line
        /// </summary>
        /// <param name="Text"></param>
        public static void Print(string Text)
            => Console.Write(Text);
        /// <summary>
        /// Sets foreground to "color"
        /// </summary>
        /// <param name="color"></param>
        public static void SetForeground(ConsoleColor color)
            => Console.ForegroundColor = color;
    }
    /// <summary>
    /// The crypt class, used for encoding, hashing, and encrypting
    /// Basically just security?
    /// </summary>
    public static class Crypt
    {
        /// <summary>
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
        public static string Sha256Hash(string RawData)
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

        public class Base64
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
            public static string Encode(string Data)
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
            public static string Decode(string Data)
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
    /// <summary>
    /// Time, just stuff with time
    /// </summary>
    public class Time
    {
        /// <summary>
        /// Awaits an integer in millseconds
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Amount"></param>
        public static void Delay<T>(T Amount)
            => Thread.Sleep(Convert.ToInt32(Amount));
    }
}