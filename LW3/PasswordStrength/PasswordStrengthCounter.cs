using System;
using System.Text;

namespace PasswordStrength
{
    public class PasswordStrengthCounter
    {
        public const string NullFunctionArgumentMessage = "Null argument was passed to function";
        public const string InvalidPasswordFormatMessage = "Invalid password format";
        public const string IncorrectNumberCommandLineArgumentsMessage = "Incorrect number of command line arguments";
        public const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        static void Main(string[] args)
        {
            string password = ParseArguments(args);
            if (IsPasswordValid(password))
            {
                
                Console.WriteLine(CalculatePasswordStrength(password));
            }
        }
        public static string ParseArguments(string[] args)
        {
            string pass;
            if (args.Length < 1 || args.Length > 1)
            {
                Console.WriteLine("Incorrect number of arguments were given to the program\nUsage: PasswordStrength.exe <password>");
                throw new Exception(IncorrectNumberCommandLineArgumentsMessage);
            }
            pass = args[0];
            return pass;
        }
        public static bool IsPasswordValid(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password", NullFunctionArgumentMessage);
            }
            foreach (char letter in password)
            {
                if (!Alphabet.Contains(letter))
                {
                    throw new Exception(InvalidPasswordFormatMessage);
                }
            }
            return true;
        }
        public static int DigitsCount(string password)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsDigit(password[i]))
                {
                    counter++;
                }
            }
            return counter;
        }
        public static int LettersCount(string password)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsLetter(password[i]))
                {
                    counter++;
                }
            }
            return counter;
        }
        public static int UpperCaseCount(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsLetter(password[i]) && Char.IsUpper(password[i]))
                {
                    count++;
                }
            }
            return count;
        }
        public static int LowerCaseCount(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsLetter(password[i]) && !Char.IsUpper(password[i]))
                {
                    count++;
                }
            }
            return count;
        }
        public static bool IsOnlyLetters(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsDigit(password[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsOnlyDigits(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsLetter(password[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public static int RepetitionsCount(string password)
        {
            int count = 0;
            int subCount;
            string repetitions = "";
            for (int i = 0; i < password.Length; i++)
            {
                subCount = 0;
                if (!repetitions.Contains(password[i]))
                {
                    repetitions += password[i];
                    for (int j = i; j < password.Length; j++)
                    {
                        if (password[j] == password[i])
                        {
                            subCount++;
                        }
                    }
                    if (subCount > 1)
                    {
                        count += subCount;
                    }
                }
            }
            return count;
        }
        public static int CalculatePasswordStrength(string password)
        {
            int strength = 0;
            strength += LettersCount(password) * 4;
            strength += DigitsCount(password) * 4;
            strength += (password.Length - UpperCaseCount(password)) * 2;
            strength += (password.Length - LowerCaseCount(password)) * 2;
            if (IsOnlyLetters(password))
            {
                strength -= password.Length;
            }
            if (IsOnlyDigits(password))
            {
                strength -= password.Length;
            }
            strength -= RepetitionsCount(password);
            return strength;
        }
    }
}