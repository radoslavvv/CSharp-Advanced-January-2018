using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        long counter = 1;
        while (input != "<stop/>")
        {
            Regex inverse = new Regex("<\\s*inverse.+content\\s*=\\s*\"(.+)\".+>");
            Regex reverse = new Regex("<\\s*reverse.+content\\s*=\\s*\"(.+)\".+>");
            Regex repeat = new Regex("<\\s*repeat.+value\\s*=\\s*\"(\\d+)\".+content\\s*=\\s*\"(.+)\".+>");

            Match inverseMatch = inverse.Match(input);
            Match reverseMatch = reverse.Match(input);
            Match repeatMatch = repeat.Match(input);

            if (inverseMatch.Success)
            {
                string content = inverseMatch.Groups[1].Value;

                StringBuilder sb = new StringBuilder();
                foreach (char letter in content)
                {
                    if (letter >= 65 && letter <= 90)
                    {
                        sb.Append(letter.ToString().ToLower());
                    }
                    else if (letter >= 97 && letter <= 122)
                    {
                        sb.Append(letter.ToString().ToUpper());
                    }
                    else
                    {
                        sb.Append(letter);
                    }
                }
                Console.WriteLine($"{counter}. {sb}");

                counter++;
            }
            else if (reverseMatch.Success)
            {
                string content = reverseMatch.Groups[1].Value;
                Console.WriteLine($"{counter}. {string.Join("", content.ToCharArray().Reverse())}");

                counter++;
            }
            else if (repeatMatch.Success)
            {
                long count = long.Parse(repeatMatch.Groups[1].Value);
                string content = repeatMatch.Groups[2].Value;

                for (long i = 0; i < count; i++)
                {
                    Console.WriteLine($"{counter}. {content}");
                    counter++;
                }
            }

            input = Console.ReadLine();
        }
    }
}

