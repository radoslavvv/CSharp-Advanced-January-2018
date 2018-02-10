using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int divider = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverse = Reverse;
            numbers = reverse(numbers);

            Func<int, bool> isDivisable = n => n % divider != 0;

            numbers = numbers.Where(isDivisable)
                .ToArray();

            Console.WriteLine($"{string.Join(" ", numbers)}");
        }

        private static int[] Reverse(int[] numbers)
        {
            int[] reversedNumbers = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                reversedNumbers[i] = numbers[numbers.Length - 1 - i];
            }

            return reversedNumbers;
        }
    }
}