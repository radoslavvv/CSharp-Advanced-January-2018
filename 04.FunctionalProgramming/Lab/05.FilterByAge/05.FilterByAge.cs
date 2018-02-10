using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,int> people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] currentPerson = Console.ReadLine().
                    Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string currentPersonName = currentPerson[0];
                int currentPersonAge = int.Parse(currentPerson[1]);

                people[currentPersonName] = currentPersonAge;
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);

            if (condition == "younger")
            {
                Func<KeyValuePair<string, int>, bool> funct = p => p.Value < age;
                people = people.Where(funct).ToDictionary(x => x.Key, y => y.Value);
            }
            else if (condition == "older")
            {
                Func<KeyValuePair<string, int>, bool> funct = p => p.Value >= age;
                people = people.Where(funct).ToDictionary(x => x.Key, y => y.Value);
            }

            foreach (var person in people)
            {
                if (format.Length == 2)
                {
                    Console.WriteLine($"{person.Key} - {person.Value}");
                }
                else if (format[0] == "name")
                {
                    Console.WriteLine($"{person.Key}");
                }
                else if (format[0] == "age")
                {
                    Console.WriteLine($"{person.Value}");
                }
            }
        }
    }
}