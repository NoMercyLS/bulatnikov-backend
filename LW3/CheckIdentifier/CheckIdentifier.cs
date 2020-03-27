using System;

namespace CheckIdentifier
{
    public class CheckIdentifier
    {
        public const string InvalidNumberOfArgumentsMessage = "Invalid number of arguments\n";
        public const string NotADigitNotALetterMessage = "Identifier can contains only letters and digits\n";
        public const string DigitAtTheBeginningMessage = "Identifier can't start with a digit\n";
        public const string EmptyStringMessage = "An empty string is not an identifier\n";
        public const string NoMessage = "no\n";
        public const string YesMessage = "yes\n";
        public const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public static string GetIdentifier(string[] args)
        {
            if (args.Length < 1 || args.Length > 1)
            {
                return null;
            }

            return args[0];
        }

        public static string CheckingStringForCompilanceSR3(string identifier)
        {
            if (identifier.Length == 0)
            {
                Console.WriteLine("An empty string is not an identifier\nSR3:\n<identifier> ::= <letter>\n|<identifier><letter>\n|<identifier><digit>");
                return EmptyStringMessage;
            }
            
            if (Char.IsDigit(identifier[0]))
            {
                Console.WriteLine("Unexpected symbol: '" + identifier[0] + "'\nIdentifier can't start with a digit\nSR3:\n<identifier> ::= <letter>\n|<identifier><letter>\n|<identifier><digit>");
                return DigitAtTheBeginningMessage;
            }

            for (int i = 1; i < identifier.Length; i++)
            {
                if (!CheckIdentifier.Letters.Contains(identifier[i]) && !Char.IsDigit(identifier[i]))
                {
                    Console.WriteLine("Unexpected symbol: '" + identifier[i] +"'\nIdentifier can contains only letters and digits\nSR3:\n<identifier> ::= <letter>\n|<identifier><letter>\n|<identifier><digit>");
                    return NotADigitNotALetterMessage;
                }
            }

            return YesMessage;
        }

        public static void Main(string[] args)
        {
            string identifier = GetIdentifier(args);
            if (identifier == null)
            {
                throw new Exception(InvalidNumberOfArgumentsMessage);
            }

            string message = CheckingStringForCompilanceSR3(identifier);
            if (message == YesMessage)
            {
                Console.WriteLine(YesMessage);
            }
            else
            {
                Console.WriteLine(NoMessage);
            }
        }
    }
}
