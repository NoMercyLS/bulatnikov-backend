using System;

namespace remove_duplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!CheckArgs(args))
            {
                Environment.Exit(1);
            }

            string line;
            line = GetLine(args);

            if (line.Length == 0)
            {
                Console.WriteLine();
            }
            else
            {
                RemoveDuplicates(line);
            }
        }
        private static void RemoveDuplicates(string someLine)
        {
            string noDuplicates = "";
            for (int i = 0; i < someLine.Length; i++)
            {
                if (!noDuplicates.Contains(someLine[i]))
                {
                    noDuplicates += someLine[i];
                }
            }
            Console.WriteLine(noDuplicates);
        }

        private static bool CheckArgs(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage remove_duplicates.exe <input string>");
                return false;
            }
            return true;
        }

        private static string GetLine(string[] args)
        {
            return args[0];
        }
    }
}
