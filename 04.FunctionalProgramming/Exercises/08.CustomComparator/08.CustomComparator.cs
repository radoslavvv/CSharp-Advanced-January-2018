using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, bool> isEven = n => n % 2 == 0;
            Func<int, bool> isOdd = n => n % 2 != 0;

            Func<int[], int[]> order = numbers => numbers.OrderBy(n => n).ToArray();

            int[] evenNumbers = input.Where(isEven).OrderBy(n => n).ToArray();
            int[] oddNumbers = order(input.Where(isOdd).ToArray());

            Console.WriteLine($"{string.Join(" ", evenNumbers.Concat(oddNumbers))}");
        }
    }
}