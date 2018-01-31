using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    private const int bufferSize = 4096;

    static void Main()
    {
        Slice(@"..\..\Resources\sliceMe.mp4", @"..\..\SlicedFiles\", 5.0);
        List<string> files = new List<string>()
        {
            @"..\..\SlicedFiles\Part-1.mp4.gz",
            @"..\..\SlicedFiles\Part-2.mp4.gz",
            @"..\..\SlicedFiles\Part-3.mp4.gz",
            @"..\..\SlicedFiles\Part-4.mp4.gz",
            @"..\..\SlicedFiles\Part-5.mp4.gz"
        };
        Assemble(files, @"..\..\Result\");
    }

    public static void Slice(string sourceFile, string destinationDirectory, double parts)
    {
        using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
        {
            long pieceSize = (long)(reader.Length / parts);
            string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

            for (int i = 1; i <= parts; i++)
            {
                string currentPartPath = destinationDirectory + $"Part-{i}.{extension}.gz";

                long currentPieceSize = 0;
                using (GZipStream writer = new GZipStream(new FileStream(currentPartPath, FileMode.Create), CompressionLevel.Optimal))
                {
                    byte[] buffer = new byte[bufferSize];

                    while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                    {
                        writer.Write(buffer, 0, bufferSize);
                        currentPieceSize += bufferSize;

                        if (currentPieceSize >= pieceSize)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }

    public static void Assemble(List<string> files, string destinationDirectory)
    {
        string extension = files[0].Substring(files[0].LastIndexOf(".") - 3, 3);

        string assembledFile = $"{destinationDirectory}-Assembled.{extension}";
        using (FileStream writer = new FileStream(assembledFile, FileMode.Create))
        {
            foreach (var file in files)
            {
                using (GZipStream reader = new GZipStream(new FileStream(file, FileMode.Open), CompressionMode.Decompress))
                {

                    byte[] buffer = new byte[bufferSize];
                    while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                    {
                        writer.Write(buffer, 0, bufferSize);
                    }
                }
            }
        }
    }
}

