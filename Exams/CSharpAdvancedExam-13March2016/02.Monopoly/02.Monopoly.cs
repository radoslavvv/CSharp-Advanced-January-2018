using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        int[] sizes = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int money = 50;
        int hotelsCount = 0;
        string direction = "right";

        int totalTurnsCount = 0;
       
        for (int i = 0; i < sizes[0]; i++)
        {
            string currentTurn = Console.ReadLine();
            if (direction == "right")
            {
                direction = MoveRight(ref money, ref hotelsCount, ref totalTurnsCount, i, currentTurn);
            }
            else if (direction == "left")
            {
                direction = MoveLeft(ref money, ref hotelsCount, ref totalTurnsCount, i, currentTurn);
            }
        }
        Console.WriteLine($"Turns {totalTurnsCount}");
        Console.WriteLine($"Money {money}");
    }

    private static string MoveLeft(ref int money, ref int hotelsCount, ref int totalTurnsCount, int i, string currentTurn)
    {
        string direction;
        for (int index = currentTurn.Length - 1; index >= 0; index--)
        {
            if (currentTurn[index] == 'H')
            {
                hotelsCount++;
                Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotelsCount}.");
                money = 0;
            }
            else if (currentTurn[index] == 'J')
            {
                Console.WriteLine($"Gone to jail at turn {totalTurnsCount}.");
                totalTurnsCount += 2;
                money += (hotelsCount * 10) * 2;
            }
            else if (currentTurn[index] == 'S')
            {
                int spendMoney = (i + 1) * (index + 1);

                Console.WriteLine($"Spent {Math.Min(spendMoney, money)} money at the shop.");

                money = Math.Max(0, money - spendMoney);
            }
            money += hotelsCount * 10;
            totalTurnsCount++;
        }
        direction = "right";
        return direction;
    }

    private static string MoveRight(ref int money, ref int hotelsCount, ref int totalTurnsCount, int i, string currentTurn)
    {
        string direction;
        for (int index = 0; index < currentTurn.Length; index++)
        {
            bool isInJail = false;
            if (currentTurn[index] == 'H')
            {
                hotelsCount++;
                Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotelsCount}.");
                money = 0;
            }
            else if (currentTurn[index] == 'J')
            {
                Console.WriteLine($"Gone to jail at turn {totalTurnsCount}.");
                totalTurnsCount += 2;
                money += (hotelsCount * 10) * 2;
                isInJail = true;
            }
            else if (currentTurn[index] == 'S')
            {
                int spendMoney = (i + 1) * (index + 1);

                Console.WriteLine($"Spent {Math.Min(spendMoney, money)} money at the shop.");

                money = Math.Max(0, money - spendMoney);
            }
            money += hotelsCount * 10;
            totalTurnsCount++;
        }

        direction = "left";
        return direction;
    }
}

