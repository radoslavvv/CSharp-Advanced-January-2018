using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numbersCount = input.Length;
            int numbersSum = input.Sum();

            Console.WriteLine(numbersCount);
            Console.WriteLine(numbersSum);
        }
    }
}