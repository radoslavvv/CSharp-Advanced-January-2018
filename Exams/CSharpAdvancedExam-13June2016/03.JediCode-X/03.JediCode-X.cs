using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        string text = GetText();

        string namePattern = Console.ReadLine();
        string messagePattern = Console.ReadLine();

        //get all names from the text
        List<string> names = ExtractMatches(text, namePattern, false);

        //get all messages from the text
        List<string> messages = ExtractMatches(text, messagePattern, true);

        int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

        //print the results
        PrintResult(names, messages, indexes);
    }

    private static void PrintResult(List<string> names, List<string> messages, int[] indexes)
    {
        //go through all names
        for (int nameIndex = 0; nameIndex < names.Count; nameIndex++)
        {
            //if the name index is in range of the indexes and the actual index of the jedi is in the messages rage
            if ( (nameIndex < indexes.Length) && (indexes[nameIndex] > 0 && indexes[nameIndex] <= messages.Count))
            {
                Console.WriteLine($"{names[nameIndex]} - {messages[indexes[nameIndex] - 1]}");
            }
            else
            {
                break;
            }
        }
    }

    private static List<string> ExtractMatches(string text, string pattern, bool canHaveDigits)
    {
        List<string> matches = new List<string>();

        //get the index of the pattern
        int indexOfPattern = text.IndexOf(pattern);

        //while the index is valid
        while (indexOfPattern >= 0)
        {
            //the start index of the match starts with the end of the pattern
            int startIndexOfMatch = indexOfPattern + pattern.Length;

            //if the start index is in the end of the text catching just the pattern
            if (startIndexOfMatch >= text.Length - pattern.Length)
            {
                break;
            }

            //if the start of the match is letter OR it can have digits and the start of the match is digit
            if (char.IsLetter(text[startIndexOfMatch + pattern.Length]) ||
                canHaveDigits && char.IsDigit(text[startIndexOfMatch + pattern.Length]))
            {
                //the index of the pattern is 
                indexOfPattern = text.IndexOf(pattern, indexOfPattern + 1);
                continue;
            }

            // the match is substring starting with startIndexOfMatch and long the pattern length
            string match = text.Substring(startIndexOfMatch, pattern.Length);

            //if the match is valid add it to the list
            if (IsValid(match, canHaveDigits))
            {
                matches.Add(match);
            }

            //index of the pattern goes to the next char
            indexOfPattern = text.IndexOf(pattern, indexOfPattern + 1);
        }

        return matches;
    }

    private static bool IsValid(string match, bool canHaveDigits)
    {
        //go through each character in the match
        foreach (char character in match)
        {
            //if the character is not letter
            if (!char.IsLetter(character))
            {
                //if it can have digits and its a digit continue
                if (canHaveDigits && char.IsDigit(character))
                {
                    continue;
                }
                //else the match is not valid and break
                return false;
            }
        }
        //the match is valid
        return true;
    }

    private static string GetText()
    {
        int linesCount = int.Parse(Console.ReadLine());

        StringBuilder input = new StringBuilder();

        while (linesCount > 0)
        {
            input.Append(Console.ReadLine());
            linesCount--;
        }

        return input.ToString(); ;
    }
}

