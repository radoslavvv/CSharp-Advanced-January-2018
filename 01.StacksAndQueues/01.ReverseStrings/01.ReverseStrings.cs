using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Stack<char> stack = new Stack<char>();

        foreach (char letter in input)
        {
            stack.Push(letter);
        }

        while(stack.Count > 0)
        {
            Console.Write(stack.Pop());
        }
        Console.WriteLine();
    }
}

