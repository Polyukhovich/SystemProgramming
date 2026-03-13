using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2_Task2
{
    class Program
    {
        static void CountToFive()
        {
            for (int i = 1; i <= 5; i++)
            {
                // Виводимо поточний ідентифікатор задачі
                Console.WriteLine($"[CurrentId: {Task.CurrentId}] executing step: {i}");
                Thread.Sleep(150);
            }
        }

        static void Main(string[] args)
        {
            // Створюємо три задачі
            Task t1 = new Task(CountToFive);
            Task t2 = new Task(CountToFive);
            Task t3 = new Task(CountToFive);

            // Запускаємо їх
            t1.Start();
            t2.Start();
            t3.Start();

            // Виводимо ідентифікатори об'єктів задач
            Console.WriteLine($"Task 1 Id: {t1.Id}");
            Console.WriteLine($"Task 2 Id: {t2.Id}");
            Console.WriteLine($"Task 3 Id: {t3.Id}\n");

            // Чекаємо завершення всіх задач
            Task.WaitAll(t1, t2, t3);
            Console.ReadLine();
        }
    }
}