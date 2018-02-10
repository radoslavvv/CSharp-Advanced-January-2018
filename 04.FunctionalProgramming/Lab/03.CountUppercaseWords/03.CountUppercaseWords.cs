using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] upperCaseWords = Console.ReadLine()
                .Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w[0] == w.ToUpper()[0])
                .ToArray();

            foreach (var word in upperCaseWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}