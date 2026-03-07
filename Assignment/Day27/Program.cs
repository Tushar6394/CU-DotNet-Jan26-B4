
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string directory = @"..\..\..\";

        if (!Directory.Exists(directory))
        {
            Console.WriteLine("directory not found");
            return;
        }

        string file1 = "data.csv";
        string path = directory + file1;

        if (!File.Exists(path))
        {
            Console.WriteLine("file not found");
            return;
        }

        string allData = "";

        // Write data to file
        using (StreamWriter sw = new StreamWriter(path, true))
        {
            string data;

            do
            {
                Console.WriteLine("Enter CSV data (type 'stop' to end):");
                data = Console.ReadLine();

                if (data == "stop")
                    break;

                sw.WriteLine(data);
                allData += data + Environment.NewLine;

            } while (true);
        }
        Console.WriteLine("\nReading data using StringReader:\n");

        using (StringReader sr = new StringReader(allData))
        {
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
