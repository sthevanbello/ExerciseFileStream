using System;
using System.IO;

namespace ReadCSV
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"D:\Temp\myfolder\products.csv";
            string outputPath = @"D:\Temp\myfolder\out\summary.csv";
            FileInfo file = new FileInfo(outputPath);

            try
            {
                using (StreamReader streamReader = File.OpenText(path))
                {


                    using (StreamWriter streamWriter = File.AppendText(outputPath))
                    {
                        string result = "";

                        while (!streamReader.EndOfStream)
                        {
                            string line = streamReader.ReadLine();

                            string[] price = line.Split(",");
                            double aux = 0;
                            double multi = 1;

                            for (int i = 0; i < price.Length - 1; i++)
                            {
                                if (aux != null)
                                {
                                    aux = double.Parse(price[i + 1]);
                                    multi = multi * aux;
                                }

                                result = $"{multi}";

                            }

                            if (file.Length == 0)
                            {
                                streamWriter.WriteLine($"{price[0]}, {result}");

                            }

                            else
                            {
                                throw new IOException("File already exists");
                            }
                        }
                        Console.WriteLine("Done!!!");

                    }
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
