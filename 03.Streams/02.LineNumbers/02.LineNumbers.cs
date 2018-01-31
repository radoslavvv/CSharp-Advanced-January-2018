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
        using (var streamReader = new StreamReader(@"../../Resources/text.txt"))
        {
            int lineIndex = 1;
            using (var streamWriter = new StreamWriter(@"../../Resources/output.txt"))
            {
                string currentLine = streamReader.ReadLine();
                while (currentLine != null)
                {
                    streamWriter.WriteLine($"Line {lineIndex}: {currentLine}");

                    lineIndex++;
                    currentLine = streamReader.ReadLine();
                }
            }
        }
    }
}
