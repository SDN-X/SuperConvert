using System;
using System.IO;

namespace SuperConvert.Extensions
{
    public static class FileConverter
    {
        public static string ToBase64String(string fullPath) => Convert.ToBase64String(File.ReadAllBytes(fullPath));
        public static void ToFile(string base64String, string fileName, string filePath = "")
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name cannot be null or empty.", nameof(fileName));

            var outputPath = string.IsNullOrWhiteSpace(filePath)
                ? fileName
                : Path.Combine(filePath, fileName);

            var directory = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(directory))
                Directory.CreateDirectory(directory);

            File.WriteAllBytes(outputPath, Convert.FromBase64String(base64String));
        }
    }
}
