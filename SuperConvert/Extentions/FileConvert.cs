using System;
using System.IO;

namespace SuperConvert.Extentions
{
    public static class FileConvert
    {
        public static string ToBase64String(string fullPath) => Convert.ToBase64String(File.ReadAllBytes(fullPath));
        public static void ToFile(string base64String, string fileName, string filePath = "")
        {
            File.WriteAllBytes(fileName, Convert.FromBase64String(base64String));
        }
    }
}
