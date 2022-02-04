using System;
using System.IO;

namespace ITechArtHW
{
    public class FileReader
    {
        public static string ReadFileProjectRoot(string fileName)
        {
            var workingDirectory = Directory.GetCurrentDirectory();
            var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var filePath = Path.Combine(projectDirectory, fileName);

            try
            {
                var jsonFile = File.ReadAllText(filePath);
                return jsonFile;
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(
                    $"File: {fileName}, by path: {filePath} not found. Error message: {e.Message}");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Read error. Path is null. {ex.Message}");
            }
        }
    }
}