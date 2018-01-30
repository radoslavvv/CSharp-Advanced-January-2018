using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    public static Dictionary<long, long> fibSequence = new Dictionary<long, long>();

    static void Main()
    {
        long fibPosition = long.Parse(Console.ReadLine());
        Console.WriteLine(Fibonacci(fibPosition));
    }

    public static long Fibonacci(long position)
    {
        if (fibSequence.ContainsKey(position))
        {
            return fibSequence[position];
        }
        else if (position == 2 || position == 1)
        {
            if (!fibSequence.ContainsKey(position))
            {
                fibSequence[position] = 1;
            }
            return 1;
        }
        else
        {
            long result = Fibonacci(position - 1) + Fibonacci(position - 2);

            if (!fibSequence.ContainsKey(result))
            {
                fibSequence[position] = result;
            }
            return Fibonacci(position - 1) + Fibonacci(position - 2);
        }
    }
}


