using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        int targetInfoIndex = int.Parse(Console.ReadLine());

        Dictionary<string, long> infoIndexes = new Dictionary<string, long>();

        Dictionary<string, Dictionary<string, string>> people = new Dictionary<string, Dictionary<string, string>>();

        string input = Console.ReadLine();
        while (input != "end transmissions")
        {
            string[] inputParams = input.Split(new char[] { '=', ':', ';' });

            string name = inputParams[0];
            if (!people.ContainsKey(name))
            {
                people.Add(name, new Dictionary<string, string>());
            }
            for (int i = 1; i < inputParams.Length; i += 2)
            {
                people[name][inputParams[i]] = inputParams[i + 1];
            }

            input = Console.ReadLine();
        }

        foreach (var person in people)
        {
            long sum = 0;
            foreach (var pairs in person.Value)
            {
                sum += pairs.Key.Length + pairs.Value.Length;
            }
            infoIndexes[person.Key] = sum;
        }
        string[] lastLine = Console.ReadLine().Split(' ').ToArray();

        string searchedName = lastLine[1];
        Console.WriteLine($"Info on {searchedName}:");
        foreach (var pair in people[searchedName].OrderBy(a => a.Key))
        {
            Console.WriteLine($"---{pair.Key}: {pair.Value}");
        }

        Console.WriteLine($"Info index: {infoIndexes[searchedName]}");
        if (infoIndexes[searchedName] >= targetInfoIndex)
        {
            Console.WriteLine($"Proceed");
        }
        else
        {
            Console.WriteLine($"Need {targetInfoIndex - infoIndexes[searchedName]} more info.");
        }
    }
}

