using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parkingParams = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Dictionary<int, HashSet<int>> parking = new Dictionary<int, HashSet<int>>();

            string input = Console.ReadLine();
            while (input != "stop")
            {
                int[] inputParams = input
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int enterRow = inputParams[0];
                int desiredRow = inputParams[1];
                int desiredCol = inputParams[2];

                int parkingCol = 0;
                if (IsEmpty(desiredRow, desiredCol, parking))
                {
                    parkingCol = desiredCol;
                }
                else
                {
                    for (int col = 1; col < parkingParams[1] - 1; col++)
                    {
                        if((desiredCol - col) > 0 && IsEmpty(desiredRow, desiredCol - col, parking))
                        {
                            parkingCol = desiredCol - col;
                            break;
                        }else if (desiredCol + col < parkingParams[1] && IsEmpty(desiredRow, desiredCol + col, parking))
                        {
                            parkingCol = desiredCol + col;
                            break;
                        }
                    }
                }

                if (parkingCol == 0)
                {
                    Console.WriteLine($"Row {desiredRow} full");
                }
                else
                {
                    parking[desiredRow].Add(parkingCol);
                    int stepsCount = Math.Abs(enterRow - desiredRow) + 1 + parkingCol;

                    Console.WriteLine(stepsCount);
                }

                input = Console.ReadLine();
            }

        }

        private static bool IsEmpty(int desiredRow, int desiredCol, Dictionary<int, HashSet<int>> parking)
        {
            if (parking.ContainsKey(desiredRow))
            {
                if (parking[desiredRow].Contains(desiredCol))
                {
                    return false;
                }
            }
            else
            {
                parking[desiredRow] = new HashSet<int>();
            }

            return true;
        }
    }
}
