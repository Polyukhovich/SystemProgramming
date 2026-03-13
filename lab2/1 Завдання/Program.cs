using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2_Task1
{
    class Program
    {
        static void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Number: {i}");
                Thread.Sleep(200);
            }
        }

        static void PrintLetters()
        {
            // Виводимо літери від A до J
            for (char c = 'A'; c <= 'J'; c++)
            {
                Console.WriteLine($"Letter: {c}");
                Thread.Sleep(200);
            }
        }

        static void Main(string[] args)
        {
            // Створення задач
            Task task1 = new Task(PrintNumbers);
            Task task2 = new Task(PrintLetters);

            // Запуск задач на виконання
            task1.Start();
            task2.Start();

            // Очікування завершення обох задач
            Task.WaitAll(task1, task2);

            Console.WriteLine("Both tasks finished execution.");
            Console.ReadLine();
        }
    }
}