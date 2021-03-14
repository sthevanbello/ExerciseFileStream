using ReadCSV.Entities;
using System;
using System.IO;

namespace ReadCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path with the name of the file .cvs: ");
            string sourceFilePath = Console.ReadLine();

            string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
            string targetFolder = sourceFolderPath + @"\out";
            string outputPath = targetFolder + @"\summary.csv";

            FileInfo file = new FileInfo(outputPath);

            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);

                using (StreamWriter streamWriter = File.AppendText(outputPath))
                {
                    string result = "";

                    foreach (var line in lines)
                    {

                        string[] fields = line.Split(",");

                        string name = fields[0];
                        double price = double.Parse(fields[1]);
                        int quantity = int.Parse(fields[2]);

                        Product product = new Product(name, price, quantity);

                        if (file.Length == 0)
                        {
                            streamWriter.WriteLine($"{product}");
                        }
                        else
                        {
                            throw new IOException("File already exists");
                        }
                    }
                    Console.WriteLine("Done!!!");
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadKey();
        }
    }
}
