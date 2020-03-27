using System;
using System.IO;
using System.Text;

namespace RemoveExtraBlanks
{
    public class RemoveExtraBlanks
    {
        public const string FileNotFoundMessage = "File not found";
        public const string IncorrectCommandLineArgumentsMessage = "Incorrect number of command line arguments";
        public const string CannotReadFileMessage = "Can't read from file";
        public const string CannotWriteFileMessage = "Can't write to file";

        static void Main(string[] args)
        {
            string[] paths = ParseArguments(args);

            CheckFileExistance(paths[0]);
            CheckFileExistance(paths[1]);

            Encoding utf8WithoutBOM = new UTF8Encoding(false);
            string fileText = ReadText(paths[0], utf8WithoutBOM);

            fileText = GetStringWithoutExtremeBlanks(fileText);
            fileText = GetStringWithoutExtraSpaces(fileText);
            fileText = GetStringWithoutExtraTabs(fileText);
            int i = 0;
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
            if (!File.Exists(path))
            {
                Console.WriteLine("The file '" + path + "' was not found");
                throw new FileNotFoundException(FileNotFoundMessage);
            }
        }
        public static string GetStringWithoutExtremeBlanks(string text)
        {
            char[] spaces = { '\t', ' ' };
            return text.Trim(spaces);
        }
        public static string GetStringWithoutExtraSpaces(string text)
        {
            return String.Join(" ", text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
        }
        public static string GetStringWithoutExtraTabs(string text)
        {
            return String.Join("\t", text.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries));
        }
        private static string ReadText(string path, Encoding correctEncoding)
        {
            FileStream inputFile = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader inputFileText = new StreamReader(inputFile, correctEncoding);
            string text = inputFileText.ReadToEnd();
            inputFileText.Dispose();
            inputFileText.Close();
            inputFile.Close();
            return text;
        }
        private static void WriteText(string path, Encoding correctEncoding, string fileText)
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
