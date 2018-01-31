using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int lineIndex = 0;
        using (var streamReader = new StreamReader(@"..\..\Resources\text.txt"))
        {
            string currentLine = streamReader.ReadLine();
            while (currentLine != null)
            {
                if (lineIndex % 2 != 0)
                {
                    Console.WriteLine(currentLine);
                }

                lineIndex++;
                currentLine = streamReader.ReadLine();
            }
        }
    }
}

