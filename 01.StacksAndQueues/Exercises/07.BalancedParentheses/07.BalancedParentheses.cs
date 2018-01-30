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

        if (input.Length % 2 != 0)
        {
            Console.WriteLine("NO");
        }
        else
        {
            bool areBalanced = true;

            Stack<char> openingPar = new Stack<char>();
            foreach (char character in input)
            {
                if (character == '(' || character == '[' || character == '{')
                {
                    openingPar.Push(character);
                }
                else if (character == ')' || character == ']' || character == '}')
                {
                    if (openingPar.Count == 0)
                    {
                        areBalanced = false;
                        Console.WriteLine("NO");
                        break;
                    }
                    char lastOpenPar = openingPar.Peek();

                    if (lastOpenPar == '(' && character == ')' ||
                        lastOpenPar == '[' && character == ']' ||
                        lastOpenPar == '{' && character == '}')
                    {
                        openingPar.Pop();
                    }
                    else
                    {
                        areBalanced = false;
                        Console.WriteLine("NO");
                        break;
                    }
                }
            }
            if (areBalanced)
            {
                Console.WriteLine("YES");
            }
        }
    }
}


