using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Jedi
{
    public string Type { get; set; }
    public int Level { get; set; }
    public string Full { get; set; }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Jedi> masters = new List<Jedi>();
        List<Jedi> knights = new List<Jedi>();
        List<Jedi> padawans = new List<Jedi>();

        List<Jedi> special = new List<Jedi>();

        bool yodaHasAppeared = false;
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var jedi in input)
            {
                string jediType = jedi[0].ToString();
                int jediLevel = int.Parse(jedi[1].ToString());

                var currentJedi = new Jedi()
                {
                    Type = jediType,
                    Level = jediLevel,
                    Full = jedi
                };

                if (jediType == "m")
                {
                    masters.Add(currentJedi);
                }
                else if (jediType == "k")
                {
                    knights.Add(currentJedi);
                }
                else if (jediType == "p")
                {
                    padawans.Add(currentJedi);
                }
                else if (jediType == "s" || jediType == "t")
                {
                    special.Add(currentJedi);
                }
                else if (jediType == "y")
                {
                    yodaHasAppeared = true;
                }
            }

        }

        if (!yodaHasAppeared)
        {
            foreach (var jedi in special)
            {
                Console.Write($"{jedi.Full} ");
            }
        }
        else
        {
            padawans.InsertRange(0, special);
        }

        foreach (var master in masters)
        {
            Console.Write($"{master.Full} ");
        }
        foreach (var knight in knights)
        {
            Console.Write($"{knight.Full} ");
        }
        foreach (var padawan in padawans)
        {
            Console.Write($"{padawan.Full} ");

        }
        Console.WriteLine();

    }
}