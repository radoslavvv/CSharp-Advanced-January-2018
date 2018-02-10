using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Method
{
    public string Name { get; set; }
    public Queue<string> CalledMethods { get; set; }
}
class Program
{
    static void Main()
    {
        Stack<Method> methods = new Stack<Method>();
        int numberOfLines = int.Parse(Console.ReadLine());

        Regex methodRegex = new Regex(@"static\s+.*\s+([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(");
        Regex callRegex = new Regex(@"([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(");

        //go through all lines of code
        for (int i = 0; i < numberOfLines; i++)
        {
            var currentLine = Console.ReadLine();

            //match method declaration
            var methodMatch = methodRegex.Match(currentLine);

            //match called method
            var callMatch = callRegex.Matches(currentLine);

            //if the line is method declaration
            if (methodMatch.Success)
            {
                //add it to the end of the methods queue
                methods.Push(new Method()
                {
                    Name = methodMatch.Groups[1].Value,
                    CalledMethods = new Queue<string>()
                });
            }
            //else if the line has method calls in it
            else
            {
                //go through all calls
                foreach (Match match in callMatch)
                {
                    //add them to the last declared method's called methods
                    methods.Peek().CalledMethods.Enqueue(match.Groups[1].Value);
                }
            }
        }

        //print results
        foreach (var method in methods.OrderByDescending(m => m.CalledMethods.Count).ThenBy(m => m.Name))
        {
            if (method.CalledMethods.Count > 0)
            {
                Console.WriteLine(
                    $"{method.Name} -> {method.CalledMethods.Count} -> {string.Join(", ", method.CalledMethods.OrderBy(c => c))}");
            }
            else
            {
                Console.WriteLine(
                    $"{method.Name} -> None");
            }
        }
    }
}