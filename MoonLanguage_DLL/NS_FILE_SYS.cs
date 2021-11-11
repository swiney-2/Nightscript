using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightscript
{
    class NS_FILE_SYS
    {
        /// <summary>
        /// Returns the text of the file located at "Path"
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static string FILESYS_READFILE(string Path)
        {
            string Text = null;

            if (!string.IsNullOrEmpty(Path) || !string.IsNullOrWhiteSpace(Path))
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
        public static bool FILESYS_FILE_EXISTS(string DirectoryPath)
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
        public static void DIRECTORY_DEL(string Path)
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
        public static void FILESYS_APPEND_TEXT(string Path, string Data)
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
        public static void DIRECTORY_NEW(string Path)
        {
            if (!string.IsNullOrEmpty(Path) || !string.IsNullOrWhiteSpace(Path)) { Directory.CreateDirectory(Path); }
            else { throw new Exception($"Invalid Path Located At {Path}"); }
        }

        /// <summary>
        /// Writes "data" to the file located at "path"
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Data"></param>
        public static void FILE_WRITE(string Path, string Data)
        {
            if (!string.IsNullOrEmpty(Path) || !string.IsNullOrWhiteSpace(Path))
            {
                if (!File.Exists(Path)) { throw new Exception($"Invalid Path Located At {Path}"); }
                else { File.WriteAllText(Path, Data); }
            }
            else throw new Exception($"Invalid Path Located At {Path}");
        }
        /// <summary>
        /// Creates a file at path
        /// </summary>
        /// <param name="path"></param>
        public static void FILE_NEW(string path)
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
        public static void FILE_DELETE(string FilePath)
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
        public static bool RETURN_FILE_EXISTS(string FilePath)
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
}
