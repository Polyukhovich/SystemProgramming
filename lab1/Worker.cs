using System;
using System.Threading;

namespace Lab1_Task2
{
    public static class Worker
    {
        // Метод для пріоритетних (звичайних) потоків
        public static void NormalThreadTask()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is executing (step {i})");
                Thread.Sleep(500); // Пауза півсекунди
            }
            Console.WriteLine($"--- {Thread.CurrentThread.Name} FINISHED ---");
        }

        // Метод для фонового потоку (нескінченний цикл)
        public static void BackgroundThreadTask()
        {
            int count = 1;
            while (true)
            {
                Console.WriteLine($"[BG] Background thread is working... ({count++})");
                Thread.Sleep(300);
            }
        }
    }
}