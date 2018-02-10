using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> teams = new Dictionary<string, List<string>>();
        Dictionary<string, long> wins = new Dictionary<string, long>();

        string input = Console.ReadLine();
        while (input != "stop")
        {
            string[] inputParams = input
                .Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

            string firstTeam = inputParams[0];
            string secondTeam = inputParams[1];

            long[] firstTeamSoil = inputParams[2]
                .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            long[] secondTeamSoil = inputParams[3]
                .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            if (!teams.ContainsKey(firstTeam))
            {
                teams.Add(firstTeam, new List<string>());
                wins.Add(firstTeam, 0);
            }
            teams[firstTeam].Add(secondTeam);

            if (!teams.ContainsKey(secondTeam))
            {
                teams.Add(secondTeam, new List<string>());
                wins.Add(secondTeam, 0);
            }
            teams[secondTeam].Add(firstTeam);


            if (firstTeamSoil[0] + secondTeamSoil[1] > firstTeamSoil[1] + secondTeamSoil[0])
            {
                wins[firstTeam]++;
            }
            else if (firstTeamSoil[0] + secondTeamSoil[1] < firstTeamSoil[1] + secondTeamSoil[0])
            {
                wins[secondTeam]++;
            }
            else if (firstTeamSoil[0] + secondTeamSoil[1] == firstTeamSoil[1] + secondTeamSoil[0])
            {
                if (firstTeamSoil[1] > secondTeamSoil[1])
                {
                    wins[secondTeam]++;
                }
                else
                {
                    wins[firstTeam]++;
                }
            }

            input = Console.ReadLine();
        }

        PrintResult(teams, wins);
    }

    private static void PrintResult(Dictionary<string, List<string>> teams, Dictionary<string, long> wins)
    {
        foreach (var team in wins.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
        {
            Console.WriteLine($"{team.Key}");
            Console.WriteLine($"- Wins: {team.Value}");
            Console.WriteLine($"- Opponents: {string.Join(", ", teams[team.Key].OrderBy(t => t))}");
        }
    }
}

