using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        StringBuilder text = new StringBuilder();
        int commandsCount = int.Parse(Console.ReadLine());

        Stack<string> previousText = new Stack<string>();

        for (int i = 0; i < commandsCount; i++)
        {
            string[] command = Console.ReadLine().Split();

            if (command[0] == "1")
            {
                previousText.Push(text.ToString());
                text.Append(command[1]);
            }
            else if (command[0] == "2")
            {
                int removeCount = int.Parse(command[1]);
                previousText.Push(text.ToString());

                text = new StringBuilder(text.ToString().Substring(0, text.Length - removeCount));
            }
            else if (command[0] == "3")
            {
                int index = int.Parse(command[1]);
                Console.WriteLine(text[index - 1]);
            }
            else if (command[0] == "4")
            {
                text = new StringBuilder(previousText.Pop());
            }
        }
    }
}
