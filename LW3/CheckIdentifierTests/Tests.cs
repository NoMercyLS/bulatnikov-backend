using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIdentifier;

namespace CheckIdentifierTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GetIdentifier_WithGreaterArgsNumber_ShouldThrowException()
        {
            string[] arguments = new string[] { "", ")))" };
            try
            {
                CheckIdentifier.CheckIdentifier.GetIdentifier(arguments);
            }
            catch (System.Exception e)
            {
                StringAssert.Equals(e.Message, CheckIdentifier.CheckIdentifier.InvalidNumberOfArgumentsMessage);
                return;
            }
        }

        public void GetIdentifier_WithoutArgs_ShouldThrowException()
        {
            string[] arguments = new string[] { };
            try
            {
                CheckIdentifier.CheckIdentifier.GetIdentifier(arguments);
            }
            catch (System.Exception e)
            {
                StringAssert.Equals(e.Message, CheckIdentifier.CheckIdentifier.InvalidNumberOfArgumentsMessage);
                return;
            }
        }

        public void CheckingStringForCompilanceSR3_EmptyString_ShouldReturnEmptyStringMessage()
        {
            string identifier = "";
            StringAssert.Equals(CheckIdentifier.CheckIdentifier.CheckingStringForCompilanceSR3(identifier), CheckIdentifier.CheckIdentifier.EmptyStringMessage);
        }

        public void CheckingStringForCompilanceSR3_StringStartsWithDigit_ShouldReturnDigitAtTheBeginningMessage()
        {
            string identifier = "32rrr";
            StringAssert.Equals(CheckIdentifier.CheckIdentifier.CheckingStringForCompilanceSR3(identifier), CheckIdentifier.CheckIdentifier.DigitAtTheBeginningMessage);
        }

        public void CheckingStringForCompilanceSR3_StringContainsNotADigitNotALetterSymbol_ShouldReturnNotADigitNotALetterMessage()
        {
            string identifier = "32rr_r";
            StringAssert.Equals(CheckIdentifier.CheckIdentifier.CheckingStringForCompilanceSR3(identifier), CheckIdentifier.CheckIdentifier.NotADigitNotALetterMessage);
        }
    }
}
