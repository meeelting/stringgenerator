using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unleash_the_giraffe
{
    class ProceduralStringGenerator
    {
        const int tagReplacementDepth = 7;

        private Random random = new Random();
        public Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
        public List<List<string>> structure = new List<List<string>>();

        public const string standardStructureSeparator = "\n";
        public string structureSeparator = standardStructureSeparator;

        public ProceduralStringGenerator() : this(standardStructureSeparator) { }
        public ProceduralStringGenerator(string structureSeparator) => this.structureSeparator = structureSeparator;

        public void AddPart(string key, params string[] items) => dictionary.Add(key, items.ToList());
        public void SetStructure(params string[] items) => structure.Add(items.ToList());

        public string Get()
        {
            structureSeparator = (structureSeparator == string.Empty || structureSeparator == null) ? standardStructureSeparator : structureSeparator;

            var story = string.Empty;
            foreach (var item in structure)
            {
                var sentence = item.RandomElement(random);                
                for (int i = 0; i < tagReplacementDepth; i++)
                    sentence = ConvertIntoStory(sentence);

                story += sentence.ToUpperFirstLetter() + structureSeparator;
            }

            story = story.ToUpperFirstLetter();

            return story;
        }

        private string ConvertIntoStory(string sentence)
        {
            foreach (var keyword in dictionary.Keys)
            {
                sentence = SentenceReplace(sentence, keyword, dictionary[keyword]);
            }

            return sentence;
        }

        private string SentenceReplace(string sentence, string keyword, List<string> words)
        {
            var sb = new StringBuilder(sentence);
            var positions = sentence.AllIndexesOf(keyword);

            while (positions.Count != 0)
            {
                var index = positions[0];
                sb.Remove(index, keyword.Length);
                sb.Insert(index, words.RandomElement(random));

                sentence = sb.ToString();
                positions = sentence.AllIndexesOf(keyword);
            }

            return sb.ToString().Replace("  ", " ");
        }
    }
}
