using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lab3_Task3
{
    //Вона нам потрібна виключно для того, щоб паралельні потоки могли залізти всередину і змінити оригінальні дані в нашому головному списку, а не гралися з їхніми копіями.
    class DataItem
    {
        public int Id { get; set; }
        public double Value { get; set; }
    }

    class Program
    {
        // Метод, що виконується на кожному кроці
        static void ProcessItem(DataItem item)
        {
            // Складна операція: x = x / PI
            item.Value = item.Value / Math.PI;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Generating list of 10,000,000 items...\n");

            List<DataItem> list = new List<DataItem>();
            for (int i = 0; i < 10_000_000; i++)
            {
                list.Add(new DataItem { Id = i, Value = i });
            }

            Console.WriteLine("Processing items with Parallel.ForEach...");

            Stopwatch sw = Stopwatch.StartNew();

            // Використання Parallel.ForEach з іменованим методом
            Parallel.ForEach(list, ProcessItem);

            sw.Stop();

            Console.WriteLine($"\nProcessing finished in {sw.ElapsedMilliseconds} ms.");
            Console.WriteLine($"Value of first item is now: {list[0].Value}");
            Console.WriteLine($"Value of last item is now: {list[list.Count - 1].Value}");

            Console.WriteLine("\nMain() is done. Press any key.");
            Console.ReadKey();
        }
    }
}