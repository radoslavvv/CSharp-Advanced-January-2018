using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.TriFunction
{
    class Program
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var name in names)
            {
                long sum = GetCharSum(name);
                Func<long, long, bool> equalOrLarger = IsEqualOrLarger;

                if (equalOrLarger(n, sum))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }

        private static long GetCharSum(string name)
        {
            long sum = 0;
            foreach (char letter in name)
            {
                sum += letter;
            }
            return sum;
        }

        private static bool IsEqualOrLarger(long n, long nameSum)
        {
            return nameSum >= n;
        }
    }
}