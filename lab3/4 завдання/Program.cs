using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lab3_Task4
{
    class DataItem
    {
        public int Id { get; set; }
        public double Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating list of 10,000,000 items...\n");

            List<DataItem> list = new List<DataItem>();
            for (int i = 0; i < 10_000_000; i++)
            {
                list.Add(new DataItem { Id = i, Value = i });
            }

            Console.WriteLine("Processing items using Lambda Expression...");

            Stopwatch sw = Stopwatch.StartNew();

            // Використання Parallel.ForEach із лямбда-виразом замість іменованого методу
            Parallel.ForEach(list, item =>
            {
                // Складна операція всередині лямбди
                item.Value = Math.Exp(item.Value % 10) / Math.Pow(item.Value % 10, Math.PI);
            });

            sw.Stop();

            Console.WriteLine($"\nProcessing finished in {sw.ElapsedMilliseconds} ms.");
            Console.WriteLine("Main() is done. Press any key.");
            Console.ReadKey();
        }
    }
}