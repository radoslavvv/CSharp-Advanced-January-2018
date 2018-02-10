using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.CubicMessages
{
    class Program
    {
        static void Main(string[] args)
        {

            string message = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            while (message != "Over!")
            {
                Regex regex = new Regex($@"^(\d+)([A-Za-z]{{{n}}})([^A-Za-z]*)$");
                Match match = regex.Match(message);

                if (match.Success)
                {
                    StringBuilder sb = new StringBuilder();

                    string text = match.Groups[2].Value;
                    string digits = match.Groups[1].Value + match.Groups[3].Value;

                    for (int index = 0; index < digits.Length; index++)
                    {
                        if(int.TryParse(digits[index].ToString(), out int realNumber))
                        {
                            if (realNumber < text.Length)
                            {
                                sb.Append(text[realNumber]);
                            }
                            else
                            {
                                sb.Append(" ");
                            }
                        }
                    }

                    Console.WriteLine($"{text} == {sb}");
                }
                message = Console.ReadLine();
                if (message == "Over!")
                {
                    break;
                }
                n = int.Parse(Console.ReadLine());
            }
        }
    }
}