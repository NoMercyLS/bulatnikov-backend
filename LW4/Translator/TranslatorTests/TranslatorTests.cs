using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translator;

namespace TranslatorTests
{
    [TestClass]
    public class TranslatorTests
    {
        Translator.Translator dictionary = new Translator.Translator("../../../../Translator/Dictionary.txt");
        [TestMethod]
        public void UnknownEnWord_ShouldReturnNull()
        {
            string word = "Chicken";
            string result = dictionary.GetTranslation(word);
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void UnknownRuWord_ShouldReturnNull()
        {
            string word = "Курица";
            string result = dictionary.GetTranslation(word);
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void RuWord_ShouldReturnTranslation()
        {
            string word = "кит";
            string result = dictionary.GetTranslation(word);
            Assert.AreEqual("whale", result);
        }
        [TestMethod]
        public void EnWord_ShouldReturnTranslation()
        {
            string word = "whale";
            string result = dictionary.GetTranslation(word);
            Assert.AreEqual("кит", result);
        }      
        [TestMethod]
        public void EmptyWord_ShouldReturnNull()
        {
            string word = "";
            string result = dictionary.GetTranslation(word);
            Assert.AreEqual(null, result);
        }
    }
}
