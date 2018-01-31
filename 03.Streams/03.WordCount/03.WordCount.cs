using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        Dictionary<string, int> words = new Dictionary<string, int>();

        using (var streamReader = new StreamReader(@"../../Resources/words.txt"))
        {
            string currentWord = streamReader.ReadLine().ToLower();
            while (currentWord != null)
            {
                words[currentWord.ToLower()] = 0;
                currentWord = streamReader.ReadLine();
            }
        }

        using (var streamReader = new StreamReader(@"../../Resources/text.txt"))
        {
            string currentLine = streamReader.ReadLine();
            while (currentLine != null)
            {
                string[] lineWords = Regex.Split(currentLine, "[^A-Za-z\']+")
                    .Select(w => w.ToLower())
                    .ToArray();

                foreach (string word in lineWords)
                {
                    if (words.ContainsKey(word))
                    {
                        words[word]++;
                    }
                }
                currentLine = streamReader.ReadLine();
            }
        }

        using (var streamWriter = new StreamWriter(@"../../Resources/result.txt"))
        {
            foreach (var word in words.OrderByDescending(w => w.Value))
            {
                streamWriter.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}

