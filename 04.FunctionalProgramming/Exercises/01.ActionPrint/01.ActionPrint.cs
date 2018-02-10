using System;
using System.Linq;

namespace _04.FunctionalProgramming_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string> printNames = Console.WriteLine;
            foreach (var name in names)
            {
                printNames(name);
            }
        }
    }
}