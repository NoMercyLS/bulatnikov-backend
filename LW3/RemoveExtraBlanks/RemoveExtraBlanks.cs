using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace RemoveExtraBlanks
{
    public static class RemoveExtraBlanks
    {
        public const string FileNotFoundMessage = "File not found";
        public const string IncorrectCommandLineArgumentsMessage = "Incorrect number of command line arguments";
        public const string CannotReadFileMessage = "Can't read from file";
        public const string CannotWriteFileMessage = "Can't write to file";
        public const string NullArgumentMessage = "The passed argument is null";
        static void Main(string[] args)
        {
            string[] paths = ParseArguments(args);

            CheckFileExistance(paths[0]);
            CheckFileExistance(paths[1]);

            Encoding utf8WithoutBOM = new UTF8Encoding(false);
            string fileText = ReadText(paths[0], utf8WithoutBOM);

            fileText = GetStringWithoutExtremeBlanks(fileText);
            fileText = GetStringWithoutExtraBlanks(fileText);
            WriteText(paths[1], utf8WithoutBOM, fileText);
        }
        public static string[] ParseArguments(string[] args)
        {
            string[] paths = new string[2];
            if (args.Length < 2 || args.Length > 2)
            {
                Console.WriteLine("Incorrect number of arguments were given to the program\nUsage: RemoveExtraBlanks.exe <input file path> <output file path>");
                throw new Exception(IncorrectCommandLineArgumentsMessage);
            }
            paths[0] = args[0];
            paths[1] = args[1];
            return paths;
        }
        public static void CheckFileExistance(string path)
        {
            if (path == null)
            {
                throw new Exception(message: NullArgumentMessage);
            }
            if (!File.Exists(path))
            {
                Console.WriteLine("The file '" + path + "' was not found");
                throw new FileNotFoundException(FileNotFoundMessage);
            }
        }
        public static string GetStringWithoutExtremeBlanks(string text)
        {
            char[] spaces = { '\t', ' ' };
            if (text != null)
            {
                return text.Trim(spaces);
            }
            throw new Exception(message: NullArgumentMessage);
        }
        public static string GetStringWithoutExtraBlanks(string text)
        {
            if (text != null)
            {
                return Regex.Replace(text, @"[\s, \t]+", " ");
            }
            throw new Exception(message: NullArgumentMessage);
        }
        public static string ReadText(string path, Encoding correctEncoding)
        {
            FileStream inputFile = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader inputFileText = new StreamReader(inputFile, correctEncoding);
            string text = inputFileText.ReadToEnd();
            inputFileText.Dispose();
            inputFileText.Close();
            inputFile.Close();
            return text;
        }
        public static void WriteText(string path, Encoding correctEncoding, string fileText)
        {
            FileStream outputFile = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter outputFileText = new StreamWriter(outputFile, correctEncoding);
            outputFileText.Write(fileText);
            outputFileText.Flush();
            outputFileText.Close();
            outputFile.Close();
        }
    }
}
