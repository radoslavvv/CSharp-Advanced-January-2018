using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    class Filter
    {
        public string Type { get; set; }
        public string Param { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().
                Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<Filter> filters = new List<Filter>();

            string input = Console.ReadLine();
            while (input != "Print")
            {
                string[] inputParams = input.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = inputParams[0];
                string filterType = inputParams[1];
                string filterParam = inputParams[2];

                if (command == "Add filter")
                {
                    filters.Add(new Filter()
                    {
                        Type = filterType,
                        Param = filterParam
                    });
                }
                else if (command == "Remove filter")
                {
                    filters.RemoveAll(f => f.Type == filterType && f.Param == filterParam);
                }

                input = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                if (filter.Type == "Length")
                {
                    int length = int.Parse(filter.Param);

                    people.RemoveAll(p => p.Length == length);
                }
                else if (filter.Type == "Starts with")
                {
                    string start = filter.Param;
                    people.RemoveAll(p => p.StartsWith(start));
                }
                else if (filter.Type == "Ends with")
                {
                    string end = filter.Param;
                    people.RemoveAll(p => p.EndsWith(end));
                }
                else if (filter.Type == "Contains")
                {
                    string part = filter.Param;
                    people.RemoveAll(p => p.Contains(part));
                }
            }

            Console.WriteLine($"{string.Join(" ",people)}");
        }
    }
}