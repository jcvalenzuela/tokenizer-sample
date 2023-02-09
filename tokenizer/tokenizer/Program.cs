using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
//Julius Ceazar D. Valenzuela
//Tokenizer Program for PL
namespace tokenizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string localPath = new Uri(path).LocalPath;
            string p_adv = localPath + "\\6k_adverbs.txt";
            string p_adj = localPath + "\\28k_adjectives.txt";
            string p_verb = localPath + "\\31k_verbs.txt";
            string p_noun = localPath + "\\91k_nouns.txt";

            Console.WriteLine("Enter a sentence: ");
            string[] words = Console.ReadLine().Split(',', '.', '!', '\'',' ');

            Program token = new Program();

            foreach (string word in words)
            {
                //condition for identifying if the word is "ADVERB"
                if (!token.getTypeOfSpeech(word, p_adv, "adverb").Equals(""))
                {
                    Console.WriteLine(word +" is an adverb ");
                }
                //condition for identifying if the word is "ADJECTIVE"
                else if (!token.getTypeOfSpeech(word, p_adj, "adjective").Equals(""))
                {
                    Console.WriteLine(word +" is an adjective");
                }
                //condition for identifying if the word is "VERB"
                else if (!token.getTypeOfSpeech(word, p_verb, "verb").Equals(""))
                {
                    Console.WriteLine(word +" is a verb");
                }
                //condition for identifying if the word is "NOUN"
                else if (!token.getTypeOfSpeech(word, p_noun, "noun").Equals(""))
                {
                    Console.WriteLine(word +" is a noun");
                }
                //condition for identifying if the word is "unidentified or it is a separator"
                else
                {
                    Console.WriteLine(word +" is unidentified");
                }

            }
            Console.ReadLine();
        }

        private string getTypeOfSpeech(string word, string path, string typeOfspeech)
        {
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line = "";

                while (line != null)
                {
                    line = sr.ReadLine();
                    if (word == line)
                    {
                        return typeOfspeech;
                    }
                }
            }

            return "";
        }
    }
}
