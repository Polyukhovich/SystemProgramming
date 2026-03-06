using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab1_Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- THREAD CONFIGURATION ---");
            Console.Write("Enter the target number for counting (e.g., 100000000): ");
            long target = long.Parse(Console.ReadLine());

            Console.Write("Enter the number of threads: ");
            int numThreads = int.Parse(Console.ReadLine());

            List<ThreadWorker> workers = new List<ThreadWorker>();

            for (int i = 1; i <= numThreads; i++)
            {
                Console.WriteLine($"\nSelect priority for Thread {i}:");
                Console.WriteLine("1 - Lowest\n2 - BelowNormal\n3 - Normal\n4 - AboveNormal\n5 - Highest");
                Console.Write("Your choice (1-5): ");
                int choice = int.Parse(Console.ReadLine());

                ThreadPriority priority = choice switch
                {
                    1 => ThreadPriority.Lowest,
                    2 => ThreadPriority.BelowNormal,
                    3 => ThreadPriority.Normal,
                    4 => ThreadPriority.AboveNormal,
                    5 => ThreadPriority.Highest,
                    _ => ThreadPriority.Normal
                };

                workers.Add(new ThreadWorker(i, priority, target));
            }

            Console.Clear();
            Console.WriteLine("Starting execution...\n");

            // Скидаємо прапорець гонки перед стартом
            ThreadWorker.StopRace = false;

            int startRow = Console.CursorTop;

            foreach (var w in workers) w.Thrd.Start();

            bool allDone = false;
            while (!allDone)
            {
                allDone = true;
                Console.SetCursorPosition(0, startRow);

                foreach (var w in workers)
                {
                    // Визначаємо статус для красивого виводу
                    string status;
                    if (w.IsWinner) status = "[WINNER]  ";
                    else if (w.IsFinished) status = "[STOPPED] ";
                    else status = "[RUNNING] ";

                    double progress = (double)w.Count / target * 100;

                    Console.WriteLine($"Thread {w.Id} ({w.Priority,-11}) | Status: {status} | Counter: {w.Count,-12} | Progress: {progress,6:F2}%");

                    if (!w.IsFinished) allDone = false;
                }

                Thread.Sleep(50);
            }

            foreach (var w in workers) w.Thrd.Join();

            // Виведення фінальної таблиці з переможцем
            Console.WriteLine("\n--- RACE RESULTS & CPU TIME DISTRIBUTION ---");
            long totalCount = 0;
            foreach (var w in workers) totalCount += w.Count;

            // Сортуємо список, щоб переможець завжди відображався першим у таблиці результатів (за бажанням)
            // workers.Sort((a, b) => b.Count.CompareTo(a.Count)); 

            foreach (var w in workers)
            {
                double timePercentage = (double)w.Count / totalCount * 100;

                // Додаємо медаль для переможця
                string place = w.IsWinner ? "[1st PLACE] " : "[STOPPED]   ";

                Console.WriteLine($"{place} Thread {w.Id} ({w.Priority,-11}) received ~{timePercentage:F2}% of CPU time.");
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}