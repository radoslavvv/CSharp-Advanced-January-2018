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
        Regex regex = new Regex(@"(\{)[^\[\]\{\}]*?(?<numbers>\d{3,})[^\[\]\{\}]*?(\})|(\[)[^\[\]\{\}]*?(?<numbers>\d{3,})[^\[\]\{\}]*?(\])");

        int linesCount = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        for (int index = 0; index < linesCount; index++)
        {
            sb.Append(Console.ReadLine());
        }

        MatchCollection matches = regex.Matches(sb.ToString());
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < matches.Count; i++)
        {
            string numbers = matches[i].Groups["numbers"].Value;

            if (numbers.Length % 3 == 0)
            {
                for (int j = 0; j < numbers.Length; j += 3)
                {
                    int code = int.Parse(numbers.Substring(j, 3)) - matches[i].Length;
                    result.Append((char)code);
                }
            }
        }
        Console.WriteLine(result);
    }
}

