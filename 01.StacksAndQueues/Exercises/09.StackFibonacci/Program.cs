using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        long input = long.Parse(Console.ReadLine());
        Stack<long> fibSequence = new Stack<long>();

        fibSequence.Push(1);
        fibSequence.Push(1);

        while (fibSequence.Count < input)
        {
            long previousFirst = fibSequence.Pop();
            long previousSecond = fibSequence.Peek();

            long nextNumber = previousFirst + previousSecond;

            fibSequence.Push(previousFirst);
            fibSequence.Push(nextNumber);
        }
        Console.WriteLine(fibSequence.Peek());
    }
}

