using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            List<int> numbers = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }

            for (int j = 0; j < dividers.Length; j++)
            {
                int currentDivider = dividers[j];

                Func<int, bool> isDivisable = number => number % currentDivider == 0;

                numbers = numbers.Where(isDivisable).ToList();
            }
            Console.WriteLine($"{string.Join(" ", numbers)}");
        }
    }
}