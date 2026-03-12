using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab1_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting thread race...\n");

            // Створюємо 6 потоків із різними пріоритетами згідно з 4-м варіантом
            List<MyThread> threads = new List<MyThread>
            {
                new MyThread("Thread 1 (Normal)", ThreadPriority.Normal),
                new MyThread("Thread 2 (BelowNormal)", ThreadPriority.BelowNormal),
                new MyThread("Thread 3 (AboveNormal)", ThreadPriority.AboveNormal),
                new MyThread("Thread 4 (Highest)", ThreadPriority.Highest),
                new MyThread("Thread 5 (Lowest)", ThreadPriority.Lowest),
                new MyThread("Thread 6 (Normal)", ThreadPriority.Normal)
            };

            // Запуск та очікування всіх потоків
            foreach (var t in threads) t.Thrd.Start();
            foreach (var t in threads) t.Thrd.Join();

            // Підраховуємо загальну суму ітерацій для визначення 100%
            long totalCount = 0;
            foreach (var t in threads) totalCount += t.Count;

            Console.WriteLine("--- RESULTS ---");

            // Виводимо статистику (ім'я, ітерації та відсоток процесорного часу)
            foreach (var t in threads)
            {
                double percentage = (double)t.Count / totalCount * 100;
                Console.WriteLine($"{t.Thrd.Name,-25} | Iterations: {t.Count,-10} | CPU Time: {percentage:F2}%");
            }

            Console.WriteLine("\nMain thread finished execution.");
            Console.ReadLine();
        }
    }
}