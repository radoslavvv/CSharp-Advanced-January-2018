using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Queue<string> cars = new Queue<string>();

        int passedCarsCount = 0;

        string input = Console.ReadLine();
        while (input != "end")
        {
            if (input == "green")
            {
                for (int i = 0; i < n; i++)
                {
                    if (cars.Count > 0)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        passedCarsCount++;
                    }
                }
            }
            else
            {
                cars.Enqueue(input);
            }

            input = Console.ReadLine();
        }
        Console.WriteLine($"{passedCarsCount} cars passed the crossroads.");
    }
}

