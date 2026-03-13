using System;
using System.Threading.Tasks;

namespace Lab2_Task3
{
    class Program
    {
        static int CalculateSum(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number N: ");
            int n = int.Parse(Console.ReadLine());

            // Створення першої задачі, що повертає результат
            Task<int> sumTask = new Task<int>(() => CalculateSum(n));

            // Створення продовження за допомогою лямбда-виразу
            Task continuationTask = sumTask.ContinueWith((t) =>
            {
                Console.WriteLine($"Continuation task: The sum of numbers from 1 to {n} is {t.Result}");
            });

            // Запускаємо першу задачу
            sumTask.Start();

            // Чекаємо завершення задачі-продовження
            continuationTask.Wait();

            Console.ReadLine();
        }
    }
}