using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine()
            .Split(' ')
            .Reverse()
            .ToArray();

        Stack<string> stack = new Stack<string>();

        foreach (string character in input)
        {
            stack.Push(character);
        }

        int sum = int.Parse(stack.Pop());
        while (stack.Count > 1)
        {
            string action = stack.Pop();
            int number = int.Parse(stack.Pop());
           
            if (action == "-")
            {
                sum -= number;
            }
            else if (action == "+")
            {
                sum += number;
            }
        }
        Console.WriteLine(sum);
    }
}

