using System;
using System.Linq;

namespace _03.GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();

            int[][] groups = new int[3][];
            for (int index = 0; index < groups.Length; index++)
            {
                groups[index] = numbers.Where(n => Math.Abs(n) % 3 == index).ToArray();
            }

            foreach (var row in groups)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}