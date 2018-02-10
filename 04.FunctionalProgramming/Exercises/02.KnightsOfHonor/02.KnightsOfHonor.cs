using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            Action<string> addSir = name => Console.WriteLine($"Sir {name}");

            foreach (var name in names)
            {
                addSir(name);
            }
        }
    }
}