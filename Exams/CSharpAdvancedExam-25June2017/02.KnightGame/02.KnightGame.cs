using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[][] board = new char[n][];
        for (int i = 0; i < n; i++)
        {
            board[i] = Console.ReadLine().ToCharArray();
        }

        int maxKnightsInDanger = int.MinValue;
        int currentKnightsInDanger = 0;
        int[] mostDangerousKnight = new int[2];

        int count = 0;
        while (true)
        {
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == 'K')
                    {
                        if (IsInMatrix(row + 1, col + 2, board))
                        {
                            if (board[row + 1][col + 2] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }

                        if (IsInMatrix(row + 1, col - 2, board))
                        {
                            if (board[row + 1][col - 2] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }

                        if (IsInMatrix(row - 1, col + 2, board))
                        {
                            if (board[row - 1][col + 2] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }

                        if (IsInMatrix(row - 1, col - 2, board))
                        {
                            if (board[row - 1][col - 2] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }

                        if (IsInMatrix(row + 2, col + 1, board))
                        {
                            if (board[row + 2][col + 1] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }

                        if (IsInMatrix(row + 2, col - 1, board))
                        {
                            if (board[row + 2][col - 1] == 'K')
                            {
                                currentKnightsInDanger++;
                            }

                        }
                        if (IsInMatrix(row - 2, col + 1, board))
                        {
                            if (board[row - 2][col + 1] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }
                        if (IsInMatrix(row - 2, col - 1, board))
                        {
                            if (board[row - 2][col - 1] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }
                    }

                    if (currentKnightsInDanger > maxKnightsInDanger)
                    {
                        maxKnightsInDanger = currentKnightsInDanger;
                        mostDangerousKnight[0] = row;
                        mostDangerousKnight[1] = col;
                    }
                    currentKnightsInDanger = 0;
                }
            }
            if (maxKnightsInDanger != 0)
            {
                board[mostDangerousKnight[0]][mostDangerousKnight[1]] = '0';
                count++;
                maxKnightsInDanger = 0;
            }
            else
            {
                Console.WriteLine(count);
                return;
            }
        }
    }

    private static bool IsInMatrix(int row, int col, char[][] matrix)
    {
        if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[0].Length)
        {
            return true;
        }
        return false;
    }
}

