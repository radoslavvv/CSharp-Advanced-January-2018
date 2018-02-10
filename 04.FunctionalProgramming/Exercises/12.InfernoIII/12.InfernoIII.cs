using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.InfernoIII
{
    class Filter
    {
        public string Type { get; set; }
        public int Param { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> gems = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<Filter> filters = new List<Filter>();

            string command = Console.ReadLine();
            while (command != "Forge")
            {
                string[] commandParams = command
                    .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                string commandType = commandParams[0];
                string filterType = commandParams[1];
                int filterParam = int.Parse(commandParams[2]);

                if (commandType == "Exclude")
                {
                    Filter currentFilter = new Filter()
                    {
                        Param = filterParam,
                        Type = filterType
                    };

                    filters.Add(currentFilter);
                }
                else if (commandType == "Reverse")
                {
                    for (int index = 0; index < filters.Count; index++)
                    {
                        if (filters[index].Type == filterType && filters[index].Param == filterParam)
                        {
                            filters.RemoveAt(index);
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            gems = Forge(gems, filters);

            PrintResult(gems);
        }

        private static void PrintResult(List<int> gems)
        {
            Console.WriteLine($"{string.Join(" ", gems)}");
        }

        private static List<int> Forge(List<int> gems, List<Filter> filters)
        {
            for (int i = filters.Count - 1; i >= 0; i--)
            {
                var currFilter = filters[i];
                if (currFilter.Type == "Sum Left")
                {
                    gems = SumLeft(gems, currFilter.Param);
                }
                else if (currFilter.Type == "Sum Right")
                {
                    gems = SumRight(gems, currFilter.Param);
                }
                else if (currFilter.Type == "Sum Left Right")
                {
                    gems = SumLeftRight(gems, currFilter.Param);
                }
            }
            return gems;
        }

        private static List<int> SumLeft(List<int> gems, int value)
        {
            for (int i = 0; i < gems.Count; i++)
            {
                if (i == 0)
                {
                    if (gems[i] == value)
                    {
                        gems.RemoveAt(0);
                        i--;
                    }

                }
                else if (gems[i - 1] + gems[i] == value)
                {
                    gems.RemoveAt(i);
                    i--;
                }
            }
            return gems;
        }

        private static List<int> SumRight(List<int> gems, int value)
        {
            for (int i = 0; i < gems.Count; i++)
            {
                if (i == gems.Count - 1)
                {
                    if (gems[i] == value)
                    {
                        gems.RemoveAt(gems.Count - 1);
                        i--;
                    }
                }
                else if (gems[i] + gems[i + 1] == value)
                {
                    gems.RemoveAt(i);
                    i--;
                }
            }
            return gems;
        }

        private static List<int> SumLeftRight(List<int> gems, int value)
        {
            for (int i = 0; i < gems.Count; i++)
            {
                int leftGem = (i == 0) ? 0 : gems[i - 1];
                int rightGem = (i == gems.Count - 1) ? 0 : gems[i + 1];

                if (leftGem + gems[i] + rightGem == value)
                {
                    gems.RemoveAt(i);
                    i--;
                }
            }
            return gems;
        }
    }
}