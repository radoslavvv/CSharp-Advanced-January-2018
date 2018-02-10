using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Exam_Prep
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"\[[^\[\s*]+<(\d+)REGEH(\d+)>[^\]\s*]+\]");

            MatchCollection matches = regex.Matches(input);
            StringBuilder a = new StringBuilder();

            int indexSum = 0;
            foreach (Match match in matches)
            {
                int firstIndex = int.Parse(match.Groups[1].Value);

                int firstIndexReal = firstIndex + indexSum;
                a.Append(input[firstIndexReal % input.Length]);
                indexSum += firstIndex;

                int secondIndex = int.Parse(match.Groups[2].Value);

                int secondIndexReal = secondIndex + indexSum;
                a.Append(input[secondIndexReal % input.Length]);
                indexSum += secondIndex;
            }
            Console.WriteLine(a);
        }
    }
}