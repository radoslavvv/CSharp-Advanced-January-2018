using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CubicAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();
            while (input != "Count em all")
            {
                //WTF WHY?
                string[] inputParams = input.Trim().Split(new string[] { " -> "}, StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                string regionName = inputParams[0].Trim();
                string meteorType = inputParams[1].Trim();
                long count = long.Parse(inputParams[2].Trim());

                if (!regions.ContainsKey(regionName))
                {
                    regions.Add(regionName, new Dictionary<string, long>()
                    {
                        {"Red", 0},
                        {"Black", 0},
                        {"Green", 0}
                    });
                }

                if (regions[regionName].ContainsKey(meteorType))
                {
                    regions[regionName][meteorType] += count;

                    if (meteorType == "Green" && regions[regionName]["Green"] >= 1000000)
                    {
                        try
                        {
                            long redsCount = regions[regionName]["Green"] / 1000000;
                            regions[regionName]["Green"] = regions[regionName]["Green"] % 1000000;
                            regions[regionName]["Red"] += redsCount;

                            if (regions[regionName]["Red"] >= 1000000)
                            {
                                redsCount = regions[regionName]["Red"] / 1000000;
                                regions[regionName]["Red"] = regions[regionName]["Red"] % 1000000;
                                regions[regionName]["Black"] += redsCount;
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    else if (meteorType == "Red" && regions[regionName]["Red"] >= 1000000)
                    {
                        try
                        {
                            long blacksCount = regions[regionName]["Red"] / 1000000;
                            regions[regionName]["Red"] = regions[regionName]["Red"] % 1000000;
                            regions[regionName]["Black"] += blacksCount;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var region in regions.OrderByDescending(r => r.Value.First(m => m.Key == "Black").Value).
                ThenBy(r => r.Key.Length).ThenBy(r => r.Key))
            {
                Console.WriteLine(region.Key);
                foreach (var meteor in region.Value.OrderByDescending(m => m.Value).ThenBy(m => m.Key))
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }
    }
}