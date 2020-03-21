using System;

namespace print_args
{
    class Program
    {
        static void Main(string[] args)
        {
            if (CheckArgs(args) == 1)
            {
                Environment.Exit(1);
            }
            Console.WriteLine("Number of arguments: " + args.Length);
            PrintArgs(args);
        }

        private static int CheckArgs(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No parameters were specified!");
                return 1;
            }
            return 0;
        }

        private static void PrintArgs(string[] args)
        {
            Console.Write("Arguments: ");
            for (long i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
        }
    }
}
