using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Number
{
    public string Name { get; set; }
    public string Value { get; set; }
}
class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        List<Number> list =new List<Number>();

        string[] numbers = new string[]
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i].Length == 1)
            {
                list.Add(new Number()
                {
                    Name = numbers[long.Parse(input[i])],
                    Value = input[i]
                });
            }
            else
            {
                StringBuilder name = new StringBuilder();
                foreach (char digit in input[i])
                {
                    name.Append($"{numbers[int.Parse(digit.ToString())]}-");
                }

                list.Add(new Number()
                {
                    Name = name.ToString().Substring(0, name.Length - 1),
                    Value = input[i]
                });
            }
        }

        StringBuilder result = new StringBuilder();
        foreach (var number in list.OrderBy(n => n.Name).ThenBy(n => n.Name.Length))
        {
            result.Append($"{number.Value}, ");
        }
        Console.WriteLine(result.ToString().Substring(0, result.Length - 2));
    }
}

