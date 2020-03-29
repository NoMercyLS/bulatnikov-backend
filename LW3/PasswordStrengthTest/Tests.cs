using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrength;

namespace PasswordStrengthTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ParseArguments_IncorrectArgumentsNumber_ShouldThrowException()
        {
            string[] args = { "hello", "world" };
            try
            {
                PasswordStrengthCounter.ParseArguments(args);
            }
            catch (System.Exception e)
            {
                StringAssert.Equals(e.Message, PasswordStrengthCounter.IncorrectNumberCommandLineArgumentsMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void ParseArguments_CorrectArgumentsNumber_ShouldGoNext()
        {
            string[] args = { "HELLOWORLD" };
            string expected = "HELLOWORLD";
            string actual = PasswordStrengthCounter.ParseArguments(args);
            Assert.AreEqual(expected, actual, "Returned data is wrong");
        }
        [TestMethod]
        public void IsPasswordValid_NullPassword_ShouldThrowArgumentNullException()
        {
            string password = null;
            try
            {
                PasswordStrengthCounter.IsPasswordValid(password);
            }
            catch (System.ArgumentNullException e)
            {
                StringAssert.Equals(e.Message, PasswordStrengthCounter.NullFunctionArgumentMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void IsPasswordValid_InvalidPassword_ShouldThrowException()
        {
            string password = "HelloÁðàò, KAK ARE YOU?";
            try
            {
                PasswordStrengthCounter.IsPasswordValid(password);
            }
            catch (System.Exception e)
            {
                StringAssert.Equals(e.Message, PasswordStrengthCounter.InvalidPasswordFormatMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void IsPasswordValid_ValidPassword_ShouldGoNext()
        {
            string password = "QWERTY123qwerty";
            try
            {
                Assert.AreEqual(true, PasswordStrengthCounter.IsPasswordValid(password), "Returned data is wrong");
            }
            catch (System.Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void DigitsCount_ZeroDigitInput_ShouldGoNext()
        {
            string password = "qwerqweljrhqwkteqbwetr";
            int expected = 0;
            int actual = PasswordStrengthCounter.DigitsCount(password);
            Assert.AreEqual(expected, actual, "Returned data is wrong");
        }
        [TestMethod]
        public void DigitsCount_TenDigitInput_ShouldGoNext()
        {
            string password = "1234567890";
            int expected = 10;
            int actual = PasswordStrengthCounter.DigitsCount(password);
            Assert.AreEqual(expected, actual, "Returned data is wrong");
        }
        [TestMethod]
        public void LettersCount_ZeroLetterInput_ShouldGoNext()
        {
            string password = "1234567890";
            int expected = 0;
            int actual = PasswordStrengthCounter.LettersCount(password);
            Assert.AreEqual(expected, actual, "Invalid data returned from function");
        }
        [TestMethod]
        public void LettersCount_SixLetterInput_ShouldGoNext()
        {
            string password = "AAAAAA";
            int expected = 6;
            int actual = PasswordStrengthCounter.LettersCount(password);
            Assert.AreEqual(expected, actual, "Invalid data returned from function");
        }
        [TestMethod]
        public void UpperCaseCount_ZeroUpperCaseInput_ShouldGoNext()
        {
            string password = "aaaaaa";
            int expected = 0;
            int actual = PasswordStrengthCounter.UpperCaseCount(password);
            Assert.AreEqual(expected, actual, "Invalid data returned from function");
        }
        [TestMethod]
        public void UpperCaseCount_SixLetterInput_ShouldGoNext()
        {
            string password = "AAAAAA";
            int expected = 6;
            int actual = PasswordStrengthCounter.UpperCaseCount(password);
            Assert.AreEqual(expected, actual, "Invalid data returned from function");
        }
        [TestMethod]
        public void LowerCaseCount_ZeroUpperCaseInput_ShouldGoNext()
        {
            string password = "AAAAAA";
            int expected = 0;
            int actual = PasswordStrengthCounter.LowerCaseCount(password);
            Assert.AreEqual(expected, actual, "Invalid data returned from function");
        }
        [TestMethod]
        public void LowerCaseCount_SixLetterInput_ShouldGoNext()
        {
            string password = "aaaaaa";
            int expected = 6;
            int actual = PasswordStrengthCounter.LowerCaseCount(password);
            Assert.AreEqual(expected, actual, "Invalid data returned from function");
        }
        [TestMethod]
        public void IsOnlyLetters_TrueInput_ShouldGoNext()
        {
            string password = "aaaaaa";
            bool expected = true;
            bool actual = PasswordStrengthCounter.IsOnlyLetters(password);
            Assert.AreEqual(expected, actual, "Invalid data returned from function");
        }
        [TestMethod]
        public void IsOnlyLetters_FalseInput_ShouldGoNext()
        {
            string password = "aaaa222aa";
            bool expected = false;
            bool actual = PasswordStrengthCounter.IsOnlyLetters(password);
            Assert.AreEqual(expected, actual, "Invalid data returned from function");
        }
        [TestMethod]
        public void IsOnlyDigits_TrueInput_ShouldGoNext()
        {
            string password = "111111";
            bool expected = true;
            bool actual = PasswordStrengthCounter.IsOnlyDigits(password);
            Assert.AreEqual(expected, actual, "Invalid data returned from function");
        }
        [TestMethod]
        public void IsOnlyDigits_FalseInput_ShouldGoNext()
        {
            string password = "a222aa";
            bool expected = false;
            bool actual = PasswordStrengthCounter.IsOnlyDigits(password);
            Assert.AreEqual(expected, actual, "Invalid data returned from function");
        }
        [TestMethod]
        public void RepetitionsCount_ZeroRepetitionsInput_ShouldGoNext()
        {
            string password = "123456";
            int expected = 0;
            int actual = PasswordStrengthCounter.RepetitionsCount(password);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RepetitionsCount_FourRepetitionsInput_ShouldGoNext()
        {
            string password = "12345612";
            int expected = 4;
            int actual = PasswordStrengthCounter.RepetitionsCount(password);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculatePasswordStrength_ShouldGoNext()
        {
            string password = "qwertyy123QWERTY";
            int expected = 100;
            int actual = PasswordStrengthCounter.CalculatePasswordStrength(password);
            Assert.AreEqual(expected, actual, "Returned data from function is wrong");
        }
    }
}
