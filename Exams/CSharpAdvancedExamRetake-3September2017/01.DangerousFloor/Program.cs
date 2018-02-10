using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        string[][] board = new string[8][];
        for (int i = 0; i < 8; i++)
        {
            board[i] = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }
        string input = Console.ReadLine();

        while (input != "END")
        {
            bool commandIsInvalid = false;
            bool noSuchPiece = false;
            bool outOfBoard = false;

            string type = input[0].ToString();

            int startPostionRow = int.Parse(input[1].ToString());
            int startPostionCol = int.Parse(input[2].ToString());
            int endPostitionRow = int.Parse(input[4].ToString());
            int endPostitionCol = int.Parse(input[5].ToString());

            if (IsInMatrix(startPostionRow, startPostionCol, board))
            {
                if (board[startPostionRow][startPostionCol] == type)
                {
                    if (type == "K")
                    {
                        if ((Math.Abs(endPostitionRow - startPostionRow) == 0 && Math.Abs(endPostitionCol - startPostionCol) == 1) ||
                            (Math.Abs(endPostitionRow - startPostionRow) == 1 && Math.Abs(endPostitionCol - startPostionCol) == 0 ) ||
                            (Math.Abs(endPostitionRow - startPostionRow) == 1 && Math.Abs(endPostitionCol - startPostionCol) == 1))
                        {
                            outOfBoard = MovePiece(board, outOfBoard, startPostionRow, startPostionCol, endPostitionRow, endPostitionCol);
                        }
                        else
                        {
                            commandIsInvalid = true;
                        }
                    }
                    else if (type == "R")
                    {
                        if ((endPostitionRow != startPostionRow && endPostitionCol == startPostionCol) ||
                            (endPostitionCol != startPostionCol && endPostitionRow == startPostionRow))
                        {

                            outOfBoard = MovePiece(board, outOfBoard, startPostionRow, startPostionCol, endPostitionRow, endPostitionCol);
                        }
                        else
                        {
                            commandIsInvalid = true;
                        }
                    }
                    else if (type == "Q")
                    {
                        if (Math.Abs(startPostionRow - endPostitionRow) == Math.Abs(startPostionCol - endPostitionCol) || (endPostitionRow != startPostionRow && endPostitionCol == startPostionCol) ||
                            (endPostitionCol != startPostionCol && endPostitionRow == startPostionRow))
                        {
                            outOfBoard = MovePiece(board, outOfBoard, startPostionRow, startPostionCol, endPostitionRow, endPostitionCol);
                        }
                        else
                        {
                            commandIsInvalid = true;
                        }
                    }
                    else if (type == "P")
                    {
                        if (startPostionRow - endPostitionRow == 1 && startPostionCol == endPostitionCol)
                        {
                            outOfBoard = MovePiece(board, outOfBoard, startPostionRow, startPostionCol, endPostitionRow, endPostitionCol);
                        }
                        else
                        {
                            commandIsInvalid = true;
                        }
                    }
                    else if (type == "B")
                    {
                        if (Math.Abs(startPostionRow - endPostitionRow) == Math.Abs(startPostionCol - endPostitionCol))
                        {
                            outOfBoard = MovePiece(board, outOfBoard, startPostionRow, startPostionCol, endPostitionRow, endPostitionCol);
                        }
                        else
                        {
                            commandIsInvalid = true;
                        }
                    }
                }
                else
                {
                    noSuchPiece = true;
                }
            }
            else
            {
                noSuchPiece = true;
            }

            if (noSuchPiece)
            {
                Console.WriteLine($"There is no such a piece!");
            }
            else if (commandIsInvalid)
            {
                Console.WriteLine($"Invalid move!");
            }
            else if (outOfBoard)
            {
                Console.WriteLine($"Move go out of board!");
            }
            input = Console.ReadLine();
        }
    }

    private static bool MovePiece(string[][] board, bool outOfBoard, int startPostionRow, int startPostionCol, int endPostitionRow, int endPostitionCol)
    {
        if (IsInMatrix(endPostitionRow, endPostitionCol, board))
        {
            board[endPostitionRow][endPostitionCol] = board[startPostionRow][startPostionCol];
            board[startPostionRow][startPostionCol] = "x";
        }
        else
        {
            outOfBoard = true;
        }

        return outOfBoard;
    }

    private static bool IsInMatrix(int row, int col, string[][] matrix)
    {
        return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[0].Length;
    }

}

