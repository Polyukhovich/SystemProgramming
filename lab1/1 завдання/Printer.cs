using System;
using System.Threading;

namespace Lab1_Task1
{
    // Статичний клас із завданнями для наших потоків
    public static class Printer
    {
        // Завдання 1: вивести числа від 1 до 40
        public static void PrintNumbers()
        {
            for (int i = 1; i <= 40; i++)
            {
                // Виводимо ім'я потоку та число
                Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
                // Пауза 200 мілісекунд
                Thread.Sleep(200);
            }
            // Повідомлення про завершення
            Console.WriteLine($"\n{Thread.CurrentThread.Name} finished execution.");
        }

        // Завдання 2: вивести літери англійської абетки
        public static void PrintLetters()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {c}");
                // Пауза 300 мілісекунд
                Thread.Sleep(300);
            }
            Console.WriteLine($"\n{Thread.CurrentThread.Name} finished execution.");
        }
    }
}