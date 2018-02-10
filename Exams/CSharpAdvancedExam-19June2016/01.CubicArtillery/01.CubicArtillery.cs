using System;
using System.Collections.Generic;
using System.Linq;

namespace Exams
{
    class Bunker
    {
        public string Name { get; set; }
        public long Capacity { get; set; }
        public Queue<long> Weapons { get; set; }

    }
    class Program
    {
        static void Main()
        {
            long maxCapacity = long.Parse(Console.ReadLine());

            List<Bunker> bunkers = new List<Bunker>();

            string input = Console.ReadLine();
            while (input != "Bunker Revision")
            {
                string[] inputParams = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var inputParam in inputParams)
                {
                    if (long.TryParse(inputParam, out long weapon))
                    {
                        long bunkersCount = bunkers.Count;
                        for (int i = 0; i < bunkersCount; i++)
                        {
                            if (bunkers.Count == 1)
                            {
                                if (weapon <= maxCapacity)
                                {
                                    Bunker bunker = bunkers[0];
                                    while (bunker.Capacity + weapon > maxCapacity)
                                    {
                                        bunker.Capacity -= bunker.Weapons.Dequeue();
                                    }
                                    bunkers[i].Capacity += weapon;
                                    bunkers[i].Weapons.Enqueue(weapon);

                                    break;
                                }
                            }
                            else
                            {
                                if (bunkers[i].Capacity + weapon <= maxCapacity)
                                {
                                    bunkers[i].Capacity += weapon;
                                    bunkers[i].Weapons.Enqueue(weapon);

                                    break;
                                }
                                else
                                {
                                    if (bunkers[i].Weapons.Count > 0)
                                    {
                                        Console.WriteLine($"{bunkers[i].Name} -> {string.Join(", ", bunkers[i].Weapons)}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{bunkers[i].Name} -> Empty");
                                    }

                                    bunkers.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                    }
                    else
                    {
                        bunkers.Add(new Bunker()
                        {
                            Capacity = 0,
                            Name = inputParam,
                            Weapons = new Queue<long>()
                        });
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
