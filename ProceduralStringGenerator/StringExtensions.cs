using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unleash_the_giraffe
{
    public static class StringExtensions
    {
        public static string ReplaceAt(this string source, int index, char replace)
        {
            var sb = new StringBuilder(source);
            sb[index] = replace;
            return sb.ToString();
        }

        public static List<int> AllIndexesOf(this string source, string value)
        {
            var indexes = new List<int>();

            if (String.IsNullOrEmpty(value))
            {
                return indexes;
            }

            for (int index = 0; ; index += value.Length)
            {
                index = source.IndexOf(value, index);
                if (index == -1)
                {
                    return indexes;
                }

                indexes.Add(index);
            }
        }

        public static string ToUpperFirstLetter(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }
                
            var letters = source.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);

            return new string(letters);
        }
    }
}
