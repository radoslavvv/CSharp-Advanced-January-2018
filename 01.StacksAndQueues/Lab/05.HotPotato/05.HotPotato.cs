using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        Queue<string> children = new Queue<string>(Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

        int n = int.Parse(Console.ReadLine());

        int count = 1;
        while (children.Count > 1)
        {
            if (count == n)
            {
                string removedChild = children.Dequeue();
                Console.WriteLine($"Removed {removedChild}");
                count = 1;

                continue;
            }

            children.Enqueue(children.Dequeue());

            count++;
        }
        Console.WriteLine($"Last is {children.Dequeue()}");
    }
}
