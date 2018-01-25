using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        string expression = Console.ReadLine();

        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                stack.Push(i);
            }
            else if (expression[i] == ')')
            {
                int startIndex = stack.Pop();
                string currentExpression = expression.Substring(startIndex, i + 1 - startIndex);

                Console.WriteLine(currentExpression);
            }
        }
    }
}

