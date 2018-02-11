using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int sizes = int.Parse(Console.ReadLine());
        char[][] matrix = new char[sizes][];
        int[] sam = new int[2];
        int[] n = new int[2];

        CreateMatrix(sizes, matrix, sam, n);

        string input = Console.ReadLine();

        bool nikoladzeIsDead = false;
        bool samIsDead = false;
        for (int i = 0; i < input.Length; i++)
        {
            if (sam[0] == n[0])
            {
                nikoladzeIsDead = true;
                break;
            }

            samIsDead = CheckForSam(matrix, sam, samIsDead);
            if (samIsDead)
            {
                break;
            }

            samIsDead = MoveGuards(matrix, sam[0], sam[1], samIsDead);
            samIsDead = CheckForSam(matrix, sam, samIsDead);
            if (samIsDead)
            {
                break;
            }

            sam = MoveSam(matrix, sam, input, i);
            samIsDead = CheckForSam(matrix, sam, samIsDead);
            if (samIsDead)
            {
                break;
            }
            if (sam[0] == n[0])
            {
                nikoladzeIsDead = true;
                break;
            }
        }

        if (samIsDead)
        {
            Console.WriteLine($"Sam died at {sam[0]}, {sam[1]}");
            matrix[sam[0]][sam[1]] = 'X';
        }
        else if (nikoladzeIsDead)
        {
            Console.WriteLine($"Nikoladze killed!");
            matrix[n[0]][n[1]] = 'X';
        }
        PrintMatrix(matrix);
    }

    private static void CreateMatrix(int sizes, char[][] matrix, int[] sam, int[] n)
    {
        for (int row = 0; row < sizes; row++)
        {
            matrix[row] = Console.ReadLine().ToCharArray();
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == 'S')
                {
                    sam[0] = row;
                    sam[1] = col;
                }
                else if (matrix[row][col] == 'N')
                {
                    n[0] = row;
                    n[1] = col;
                }
            }
        }
    }

    private static bool CheckForSam(char[][] matrix, int[] sam, bool samIsDead)
    {
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == 'b')
                {
                    if (row == sam[0] && sam[1] >= col)
                    {
                        samIsDead = true;

                        break;
                    }
                }
                else if (matrix[row][col] == 'd')
                {
                    if (row == sam[0] && sam[1] <= col)
                    {
                        samIsDead = true;

                        break;
                    }
                }
            }
        }

        return samIsDead;
    }

    private static int[] MoveSam(char[][] matrix, int[] sam, string input, int i)
    {
        if (input[i] == 'U')
        {
            matrix[sam[0]][sam[1]] = '.';
            matrix[sam[0] - 1][sam[1]] = 'S';

            sam[0]--;
        }
        else if (input[i] == 'L')
        {
            matrix[sam[0]][sam[1]] = '.';
            matrix[sam[0]][sam[1] - 1] = 'S';

            sam[1]--;
        }
        else if (input[i] == 'R')
        {
            matrix[sam[0]][sam[1]] = '.';
            matrix[sam[0]][sam[1] + 1] = 'S';

            sam[1]++;
        }
        else if (input[i] == 'D')
        {
            matrix[sam[0]][sam[1]] = '.';
            matrix[sam[0] + 1][sam[1]] = 'S';

            sam[0]++;
        }

        return sam;
    }

    private static bool MoveGuards(char[][] matrix, int samRow, int samCol, bool samIsDead)
    {
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == 'b')
                {
                    if (col == matrix[0].Length - 1)
                    {
                        matrix[row][col] = 'd';
                    }
                    else
                    {
                        matrix[row][col] = '.';
                        matrix[row][col + 1] = 'b';
                    }

                    if (row == samRow)
                    {
                        if (samCol > col)
                        {
                            samIsDead = true;
                        }
                    }

                    break;
                }
                else if (matrix[row][col] == 'd')
                {

                    if (col == 0)
                    {
                        matrix[row][col] = 'b';
                    }
                    else
                    {
                        matrix[row][col] = '.';
                        matrix[row][col - 1] = 'd';
                    }
                    if (row == samRow)
                    {
                        if (samCol < col)
                        {
                            samIsDead = true;
                        }
                    }
                    break;
                }
            }
        }
        return samIsDead;
    }

    private static void PrintMatrix(char[][] matrix)
    {
        foreach (char[] row in matrix)
        {
            Console.WriteLine($"{string.Join("", row)}");
        }
    }
}

