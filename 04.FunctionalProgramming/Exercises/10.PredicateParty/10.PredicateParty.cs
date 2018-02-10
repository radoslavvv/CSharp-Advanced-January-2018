using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleInvited = Console.ReadLine().
                Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();
            while (input != "Party!")
            {
                string[] inputParams = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                string action = inputParams[0];
                string criteria = inputParams[1];
                int length = 0;
                string part = "";

                if (criteria == "Length")
                {
                    length = int.Parse(inputParams[2]);
                }
                else
                {
                    part = inputParams[2];
                }

                if (action == "Double")
                {
                    for (var index = 0; index < peopleInvited.Count; index++)
                    {
                        var person = peopleInvited[index];

                        if (criteria == "StartsWith" && person.StartsWith(part))
                        {
                            peopleInvited.Insert(index,person);
                        }
                        else if (criteria == "EndsWith" && person.EndsWith(part))
                        {
                            peopleInvited.Insert(index ,person);
                        }
                        else if (criteria == "Length" && person.Length == length ) 
                        {
                            peopleInvited.Insert(index, person);
                        }
                        index++;
                    }
                }
                else if (action == "Remove")
                {
                    if (criteria == "StartsWith")
                    {
                        peopleInvited.RemoveAll(p => p.StartsWith(part));
                    }
                    else if (criteria == "EndsWith")
                    {
                        peopleInvited.RemoveAll(p => p.EndsWith(part));
                    }
                    else if (criteria == "Length")
                    {
                        peopleInvited.RemoveAll(p => p.Length == length);
                    }
                }


                input = Console.ReadLine();
            }

            if (peopleInvited.Any())
            {
                Console.WriteLine($"{string.Join(", ", peopleInvited)} are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
        }
    }
}
