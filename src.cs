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
    public class Http
    {
        public static string Loadstring(Uri Url) {
            using (WebClient wbc = new WebClient()) { 
              return wbc.DownloadString(Url);
            }
        }
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
                            MessageBox.Show("Invalid Method, Please Use GET Or DELETE Methods", "Moon", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    public class Proc {
        public static void KillProccess(string proc) {
            foreach (var woobie in Process.GetProcessesByName(proc)) {
                woobie.Kill();
            }
        }
        public static void Start(string path)
            => Process.Start(path);
        public static bool Exists(string procname) {
            if (Process.GetProcessesByName(procname).Length > 0)
            {
                return true;
            }
            else return false;
        }
    }
    public class FileSystem
    {
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

        public static bool FolderExists(string DirectoryPath)
        {
            if (!string.IsNullOrEmpty(DirectoryPath) || !string.IsNullOrWhiteSpace(DirectoryPath))
            {
                if (!Directory.Exists(DirectoryPath)) { return false; }
                else { return true; }
            }
            else { throw new Exception("Folder Exists directory cannot be empty\n\nMoon.FolderExists"); }
        }

        public static void DeleteDirectory(string Path)
        {
            if (!string.IsNullOrEmpty(Path) || !string.IsNullOrWhiteSpace(Path))
            {
                if (Directory.Exists(Path)) { Directory.Delete(Path); } else { throw new Exception($"Invalid path located at {Path}"); }
            }
            else { throw new Exception("Delete Directory path cannot be empty\n\nMoon.DeleteDirectory"); }
        }

        public static void AppendText(string Path, string Data)
        {
            if (!string.IsNullOrEmpty(Path) || !string.IsNullOrEmpty(Data))
            {
                using (var StreamWriter = File.AppendText(Path))
                { StreamWriter.Write(Data); StreamWriter.Close(); }
            }
            else { throw new Exception($"Invalid Path Located At {Path}"); }
        }

        public static void MakeDirectory(string Path)
        {
            if (!string.IsNullOrEmpty(Path) || !string.IsNullOrWhiteSpace(Path)) { Directory.CreateDirectory(Path); }
            else { throw new Exception($"Invalid Path Located At {Path}"); }
        }

        public static void WriteFile(string Path, string Data)
        {
            if (!string.IsNullOrEmpty(Path) || !string.IsNullOrWhiteSpace(Path)) {
                if (!File.Exists(Path)) { throw new Exception($"Invalid Path Located At {Path}"); }
                else { File.WriteAllText(Path, Data); }
            }
            else throw new Exception($"Invalid Path Located At {Path}");
        }
        public static void MakeFile(string path)
        {
            if (!string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
            {
                File.Create(path);
            }
            else { throw new Exception("Path cannot be null/empty/whitespace"); }
        }
        public static bool DeleteFile(string FilePath)
        {
            bool Result = false;
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
                Result = true;
            }
            else { throw new Exception($"Invalid Path Located At {FilePath}"); }
            return Result;
        }

        public static bool FileExists(string FilePath)
        {
            bool Result = false;

            if (File.Exists(FilePath)) { Result = true; }
            else { Result = false; }

            return Result;
        }
    }

    public class Output
    {
        public static void Clear()
            => Console.Clear();

        public static void PrintToLine(string Text)
            => Console.WriteLine(Text);

        public static void ReadLine()
            => Console.ReadLine();

        public static void DebugWrite(string Text)
            => Debug.WriteLine($"[MOON] {Text}");

        public static void Print(string Text)
            => Console.Write(Text);
        public static void SetForeground(ConsoleColor color)
            => Console.ForegroundColor = color;
    }
    
    public static class Crypt
    {
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

    public class Time
    {
        public static void Delay<T>(T Amount)
            => Thread.Sleep(Convert.ToInt32(Amount));
    }
}
