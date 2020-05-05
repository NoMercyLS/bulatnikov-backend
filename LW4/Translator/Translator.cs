using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Translator
{
    public class Translator
    {
        public Dictionary<string, string> dictionary;
        public Translator(string filePath)
        {
            dictionary = InitDictionary(filePath);
        }

        private Dictionary<string, string> InitDictionary(string filePath)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string> { };
            using (StreamReader file = new StreamReader(filePath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] pair = line.Split(' ');
                    dictionary.Add(pair[0], pair[1]);
                }
                file.Close();
            }
            return dictionary;
        }

        public string GetTranslation(string word)
        {
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                if (pair.Key == word)
                {
                    return pair.Value;
                }
                if (pair.Value == word)
                {
                    return pair.Key;
                }
            }
            return null;
        }
    }
}
