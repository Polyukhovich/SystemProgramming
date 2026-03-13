using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2_Task4
{
    class Program
    {
        // Метод тепер приймає параметр n
        static void CalculateFactorial(int n)
        {
            long factorial = 1;
            for (int i = 1; i <= n; i++) factorial *= i;
            Console.WriteLine($"Factorial of {n} = {factorial}");
        }

        // Метод тепер приймає параметр n
        static void CalculateSum(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++) sum += i;
            Console.WriteLine($"Sum of numbers from 1 to {n} = {sum}");
        }

        // Метод приймає кількість повторень виводу повідомлення
        static void PrintMessage(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Message from method 3...");
                Thread.Sleep(300); // пауза 300 мс
            }
        }

        static void Main(string[] args)
        {
            // 1. Спочатку зчитуємо всі дані в головному потоці
            Console.Write("Enter a number for the factorial: ");
            int factNum = int.Parse(Console.ReadLine());

            Console.Write("Enter a number for the sum: ");
            int sumNum = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of messages to print: ");
            int msgCount = int.Parse(Console.ReadLine());

            Console.WriteLine("\nStarting methods via Parallel.Invoke()...\n");

            // 2. Паралельне виконання методів з використанням лямбда-виразів,
            // щоб передати введені змінні як аргументи
            Parallel.Invoke(
                () => CalculateFactorial(factNum),
                () => CalculateSum(sumNum),
                () => PrintMessage(msgCount)
            );

            Console.WriteLine("\nAll methods finished execution.");
            Console.ReadLine();
        }
    }
}