using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveExtraBlanks;
namespace RemoveExtraBlanksTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ParseArgument_WithGreaterNumberOfArguments_ShouldThrowException()
        {
            string[] arguments = { "asdfasdf", "asdasdasd", "asdasdasd" };
            try
            {
                RemoveExtraBlanks.RemoveExtraBlanks.ParseArguments(arguments);
            }
            catch (System.Exception e)
            {
                StringAssert.Equals(e.Message, RemoveExtraBlanks.RemoveExtraBlanks.IncorrectCommandLineArgumentsMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void ParseArgument_WithFewerNumberOfArguments_ShouldThrowException()
        {
            string[] arguments = { };
            try
            {
                RemoveExtraBlanks.RemoveExtraBlanks.ParseArguments(arguments);
            }
            catch (System.Exception e)
            {
                StringAssert.Equals(e.Message, RemoveExtraBlanks.RemoveExtraBlanks.IncorrectCommandLineArgumentsMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void ParseArgument_WithCorrectNumberOfArguments_ReturnsArguments()
        {
            string[] arguments = {"asd", "dsa"};
            string[] expected = {"asd", "dsa"};
            string[] actual = RemoveExtraBlanks.RemoveExtraBlanks.ParseArguments(arguments);
            Assert.AreEqual(expected[0], actual[0], "Arguments returns incorrectly");
            Assert.AreEqual(expected[1], actual[1], "Arguments returns incorrectly");
        }
        [TestMethod]
        public void CheckFileExistance_WithNonExistentFile_ShouldThrowException()
        {
            string filePath = "test.txt";
            try
            {
                RemoveExtraBlanks.RemoveExtraBlanks.CheckFileExistance(filePath);
            }
            catch (System.Exception e)
            {
                StringAssert.Equals(e.Message, RemoveExtraBlanks.RemoveExtraBlanks.FileNotFoundMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void CheckFileExistance_WithExistentFile_ShouldGoNext()
        {
            string filePath = "testInput.txt";
            bool isPassed = false;
            RemoveExtraBlanks.RemoveExtraBlanks.CheckFileExistance(filePath);
            isPassed = true;
            Assert.IsTrue(isPassed, "File checked incorrectly.");
        }
        [TestMethod]
        public void GetStringWithoutExtremeBlanks_ShouldGoNext()
        {
            string text = "\t\t GOGOGO \t \t";
            string actual = RemoveExtraBlanks.RemoveExtraBlanks.GetStringWithoutExtremeBlanks(text);
            string expected = "GOGOGO";
            Assert.AreEqual(expected, actual, "Blanks removed incorrectly");
        }
        [TestMethod]
        public void GetStringWithoutExtraSpaces_ShouldGoNext()
        {
            string line = "hello  world!      how    are                    u?";
            string expected = "hello world! how are u?";
            string actual = RemoveExtraBlanks.RemoveExtraBlanks.GetStringWithoutExtraSpaces(line);
            Assert.AreEqual(expected, actual, "Spaces removed incorrectly");
        }
        [TestMethod]
        public void GetStringWithoutExtraTabs_ShouldGoNext()
        {
            string line = "hello\t\tworld!\t\t\t\t\t\thow\t\t\t\t\t\t\t\tare\t\t\t\t\t\t\t\t\tu?";
            string expected = "hello\tworld!\thow\tare\tu?";
            string actual = RemoveExtraBlanks.RemoveExtraBlanks.GetStringWithoutExtraTabs(line);
            Assert.AreEqual(expected, actual, "Tabs removed incorrectly");
        }
    }
}
