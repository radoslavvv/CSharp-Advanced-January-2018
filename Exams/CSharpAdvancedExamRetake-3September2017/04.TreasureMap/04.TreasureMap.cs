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

        Regex regex = new Regex(@"#[^#!]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\d)(?<streetNumber>\d{3})-(?<streetPass>\d{6}|\d{4})(?!\d)[^#!]*?!|![^#!]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\d)(?<streetNumber>\d{3})-(?<streetPass>\d{6}|\d{4})(?!\d)[^#!]*?#");

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);

            Match middleMatch = matches[matches.Count / 2];

            string streetName = middleMatch.Groups[1].Value;
            string streetNumber = middleMatch.Groups[2].Value;
            string streetPassword = middleMatch.Groups[3].Value;

            Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {streetPassword}.");
        }
    }
}

