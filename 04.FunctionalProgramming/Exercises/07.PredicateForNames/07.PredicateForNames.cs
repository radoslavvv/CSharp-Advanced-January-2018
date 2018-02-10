using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] inputNames = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).
                ToArray();

            Func<string, bool> hasSmallerLenght = name => name.Length <= n;
            Func<string[], string[]> filterNamesByLenght = names => names.Where(hasSmallerLenght).ToArray();

            inputNames = filterNamesByLenght(inputNames);

            foreach (var name in inputNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}