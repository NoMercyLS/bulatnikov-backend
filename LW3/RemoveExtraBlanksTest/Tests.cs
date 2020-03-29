using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveExtraBlanks;
using System.Text;

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
        public void CheckFileExistance_WithNullArgument_ShouldThrowException()
        {
            string filePath = null;
            try
            {
                RemoveExtraBlanks.RemoveExtraBlanks.CheckFileExistance(filePath);
            }
            catch (System.Exception e)
            {
                StringAssert.Equals(e.Message, RemoveExtraBlanks.RemoveExtraBlanks.NullArgumentMessage);
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
        public void GetStringWithoutExtremeBlanks_WithNullArgument_ShouldThrowException()
        {
            string text = null;
            string actual;
            try
            {
                actual = RemoveExtraBlanks.RemoveExtraBlanks.GetStringWithoutExtremeBlanks(text);
            }
            catch (System.Exception e)
            {
                StringAssert.Equals(e.Message, RemoveExtraBlanks.RemoveExtraBlanks.NullArgumentMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void GetStringWithoutExtremeBlanks_ShouldGoNext()
        {
            string text = "\t\t GOGOGO \t \t";
            string actual = RemoveExtraBlanks.RemoveExtraBlanks.GetStringWithoutExtremeBlanks(text);
            string expected = "GOGOGO";
            Assert.AreEqual(expected, actual, "Extreme blanks removed incorrectly");
        }
        [TestMethod]
        public void GetStringWithoutExtraBlanks_WithNullArgument_ShouldThrowException()
        {
            string text = null;
            string actual;
            try
            {
                actual = RemoveExtraBlanks.RemoveExtraBlanks.GetStringWithoutExtraBlanks(text);
            }
            catch (System.Exception e)
            {
                StringAssert.Equals(e.Message, RemoveExtraBlanks.RemoveExtraBlanks.NullArgumentMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void GetStringWithoutExtraBlanks_ShouldGoNext()
        {
            string text = "Hello\t\t\t\t       world   \t\t\t! How    are     u            \t\t\t\t guys\t\t\t\t\t?";
            string expected = "Hello world ! How are u guys ?";
            string actual = RemoveExtraBlanks.RemoveExtraBlanks.GetStringWithoutExtraBlanks(text);

            Assert.AreEqual(expected, actual, "Blanks removed incorrectly");
        }
        [TestMethod]
        public void ReadText_ShouldGoNext()
        {
            string expected = "Hello world! I'm here!";
            string actual = RemoveExtraBlanks.RemoveExtraBlanks.ReadText("testInput.txt", new UTF8Encoding(false));
            Assert.AreEqual(expected, actual, "Text was read incorrectly");
        }
        [TestMethod]
        public void WriteText_ShouldGoNext()
        {
            string expected = "Hello world! I'm here!";
            string text = "Hello world! I'm here!";
            RemoveExtraBlanks.RemoveExtraBlanks.WriteText("testOutput.txt", new UTF8Encoding(false), text);
            string actual = RemoveExtraBlanks.RemoveExtraBlanks.ReadText("testOutput.txt", new UTF8Encoding(false));
            Assert.AreEqual(expected, actual, "Text was written incorrectly");
        }
    }
}
