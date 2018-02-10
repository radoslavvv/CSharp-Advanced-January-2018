using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CryptoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int max = 0;
            for (int step = 0; step < inputNumbers.Length; step++)
            {
                for (int index = 0; index < inputNumbers.Length; index++)
                {
                    int currentIndex = index;
                    int nextIndex = (index + step) % inputNumbers.Length;
                    int current = 1;

                    while (inputNumbers[currentIndex] < inputNumbers[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % inputNumbers.Length;
                        
                        current++;
                    }
                    if (current > max)
                    {
                        max = current;
                    }
                }
            }
            Console.WriteLine(max);
        }
    }
}
