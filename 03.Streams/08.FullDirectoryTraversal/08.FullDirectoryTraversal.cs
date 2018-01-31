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
        string path = Console.ReadLine();
        List<string> allDirectories = GetAllDirectories(path);

        Dictionary<string, List<FileInfo>> files = new Dictionary<string, List<FileInfo>>();
        foreach (var directory in allDirectories)
        {
            string[] filesPaths = Directory.GetFiles(path);
            foreach (var file in filesPaths)
            {
                FileInfo fileInfo = new FileInfo(file);
                string fileExtension = fileInfo.Extension;

                if (!files.ContainsKey(fileExtension))
                {
                    files[fileExtension] = new List<FileInfo>();
                }
                files[fileExtension].Add(fileInfo);
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string fullFilePath = desktopPath + @"\report.txt";
            using (var writer = new StreamWriter(fullFilePath))
            {
                foreach (var file in files.OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key))
                {
                    writer.WriteLine(file.Key);
                    foreach (var fileInfo in file.Value.OrderByDescending(f => f.Length))
                    {
                        writer.WriteLine($"--{fileInfo.Name} - {(double)fileInfo.Length / 1024:0.00}kb");
                    }
                }
            }
        }
    }

    private static List<string> GetAllDirectories(string path)
    {
        List<string> allDirectories = new List<string>();

        string[] directoriesPaths = Directory.GetDirectories(path);
        foreach (var directory in directoriesPaths)
        {
            allDirectories.AddRange(GetAllDirectories(directory));
        }
        allDirectories.Add(path);

        return allDirectories;
    }
}

