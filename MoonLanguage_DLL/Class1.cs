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
                        case "BALLS":
                            MessageBox.Show("lmao balls\n\n\n\n\n\n\n\n\n\n\n\n\n\\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n balls");
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
    }
    public class FileSystem
    {
        public static string ReadFile(string Path)
        {
            string Text = null;

            if (!string.IsNullOrEmpty(Path))
            {
                if (!File.Exists(Path))
                    MessageBox.Show($"Invalid Path Located At {Path}", "Moon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Text = File.ReadAllText(Path);
                }
            }
            else { Text = string.Empty; }

            return Text;
        }

        public static bool FolderExists(string DirectoryPath)
        {
            if (!Directory.Exists(DirectoryPath)) { return false; }
            else { return true; }
        }

        public static void DeleteDirectory(string Path)
        {
            if (!string.IsNullOrEmpty(Path))
            {
                if (Directory.Exists(Path)) { Directory.Delete(Path); }
            }
            else
            {
                MessageBox.Show("Invalid Directory Path", "Moon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void AppendText(string Path, string Data)
        {
            if (!string.IsNullOrEmpty(Path) || !string.IsNullOrEmpty(Data))
            {
                using (var StreamWriter = File.AppendText(Path))
                {
                    StreamWriter.Write(Data);
                    StreamWriter.Close();
                }
            }
            else
            {
                MessageBox.Show($"Invalid Path Located At {Path}", "Moon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void MakeDirectory(string Path)
        {
            if (!string.IsNullOrEmpty(Path)) { Directory.CreateDirectory(Path); }
            else { MessageBox.Show($"Invalid Path Located At {Path}", "Moon", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public static void WriteFile(string Path, string Data)
        {
            if (!string.IsNullOrEmpty(Path))
            {
                if (!File.Exists(Path)) { MessageBox.Show($"Invalid Path Located At {Path}", "Moon", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else { File.WriteAllText(Path, Data); }
            }
            else
            {
                MessageBox.Show($"Invalid Path Located At {Path}", "Moon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void MakeFile(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                File.Create(path);
            }
            MessageBox.Show("Path cannot be null or empty!");
        }
        public static bool DeleteFile(string FilePath)
        {
            bool Result = false;
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
                Result = true;
            }
            else
            {
                MessageBox.Show($"Invalid Path Located At {FilePath}", "Moon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public static void Debug(string Text)
            => Console.WriteLine($"[Debug] {Text}");

        public static void Print(string Text)
            => Console.Write(Text);
    }
    
    public static class Crypt
    {
        public static string Sha256Hash(string RawData)
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

        public class Base64
        {
            public static string Encode(string Data)
            {
                string Result = null;
                if (!string.IsNullOrEmpty(Data))
                {
                    var EncodeData = Encoding.UTF8.GetBytes(Data);
                    Result = Convert.ToBase64String(EncodeData);
                }
                return Result;
            }

            public static string Decode(string Data)
            {
                string Result = null;
                if (!string.IsNullOrEmpty(Data))
                {
                    byte[] Decoded = Convert.FromBase64String(Data);
                    Result = Encoding.UTF8.GetString(Decoded);
                }
                return Result;
            }
        }

    }

    public class Time
    {
        public static void Delay<T>(T Amount)
            => Thread.Sleep(Convert.ToInt32(Amount));
    }
}