using System;
using System.Threading;

namespace Lab1_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread started...\n");

            // Створюємо звичайні (пріоритетні) потоки
            Thread normalThread1 = new Thread(Worker.NormalThreadTask) { Name = "Normal Thread 1" };
            Thread normalThread2 = new Thread(Worker.NormalThreadTask) { Name = "Normal Thread 2" };

            // Створюємо фоновий потік (обов'язково вказуємо IsBackground = true)
            Thread bgThread = new Thread(Worker.BackgroundThreadTask) { Name = "Background Thread", IsBackground = true };

            // Спочатку запускаємо фоновий потік, потім звичайні
            bgThread.Start();
            normalThread1.Start();
            normalThread2.Start();

            // Головний потік чекає ТІЛЬКИ на завершення звичайних потоків
            normalThread1.Join();
            normalThread2.Join();

            // Коли звичайні потоки закінчують роботу, програма доходить сюди.
            // Після цього фоновий потік буде примусово завершений ОС.
            Console.WriteLine("\nMain thread finished execution.");
        }
    }
}