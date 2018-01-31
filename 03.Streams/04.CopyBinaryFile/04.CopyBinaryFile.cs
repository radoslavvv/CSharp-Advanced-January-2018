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
        byte[] buffer = new byte[4096];

        using (var sourceFile = new FileStream(@"../../Resources/file.txt", FileMode.Open))
        {
            using (var destination =
                new FileStream(@"../../Resources/file-Copy.txt", FileMode.Create))
            {
                while (true)
                {
                    int readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }

                    destination.Write(buffer, 0, readBytes);
                }
            }
        }
    }
}

