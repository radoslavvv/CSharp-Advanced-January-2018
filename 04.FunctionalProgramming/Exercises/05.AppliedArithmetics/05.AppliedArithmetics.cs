using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();
            while (input != "end")
            {
                if (input == "add")
                {
                    Func<int, int> addOne = n => n + 1;
                    numbers = numbers.Select(addOne).ToArray();
                }
                else if (input == "subtract")
                {
                    Func<int, int> removeOne = n => n - 1;
                    numbers = numbers.Select(removeOne).ToArray();
                }
                else if (input == "multiply")
                {
                    Func<int, int> multiplyByTwo = n => n * 2;
                    numbers = numbers.Select(multiplyByTwo).ToArray();
                }
                else if (input == "print")
                {
                    Console.WriteLine($"{string.Join(" ", numbers)}");
                }
               
                input = Console.ReadLine();
            }
        }
    }
}