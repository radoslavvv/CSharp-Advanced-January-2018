using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
           int[] numbers = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            string type = Console.ReadLine();

            if (type == "even")
            {
                Func<int[], int[]> getEvens = FindEvens;
                numbers = getEvens(numbers);
            }
            else if (type == "odd")
            {
                Func<int[], int[]> getOdds = FindOdds;
                numbers = getOdds(numbers);
            }
            Console.WriteLine(string.Join(" ", numbers));
           
        }

        private static int[] FindEvens (int[] numbers)
        {
            List<int> evens = new List<int>();
            for (int number = numbers[0]; number <= numbers[1]; number++)
            {
                if (number % 2 == 0)
                {
                    evens.Add(number);
                }
            }

            return evens.ToArray();
        }

        private static int[] FindOdds(int[] numbers)
        {
            List<int> odds = new List<int>();
            for (int number = numbers[0]; number <= numbers[1]; number++)
            {
                if (number % 2 != 0)
                {
                    odds.Add(number);
                }
            }

            return odds.ToArray();
        }
    }
}