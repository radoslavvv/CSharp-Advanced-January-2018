using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
           int[] numbers = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Func<int[], int> minNumberFunc = GetMinNumber;
            int minNumber = minNumberFunc(numbers);

            Console.WriteLine(minNumber);
        }

        private static int GetMinNumber(int[] numbers)
        {
            int minNumber = int.MaxValue;

            foreach (int number in numbers)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            return minNumber;
        }
    }
}