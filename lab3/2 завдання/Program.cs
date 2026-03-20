using System;
using System.Threading.Tasks;

namespace Lab3_Task2
{
    class Program
    {
        // Константа: шукане число
        const double TargetNumber = 500.0;
        // Константа: відхилення (окіл)
        const double Epsilon = 0.5;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting parallel search...\n");

            double[] data = new double[10_000_000];

            // Заповнення масиву
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i * 0.1;
            }

            // Штучно ховаємо цільове значення десь у масиві
            data[5_555_555] = 500.2; // Знаходиться в межах [499.5; 500.5]

            // Виклик Parallel.For з ParallelLoopState для можливості зупинки
            ParallelLoopResult result = Parallel.For(0, data.Length, (i, pls) =>
            {
                // Перевірка умови: чи входить елемент в окіл цільового числа
                if (Math.Abs(data[i] - TargetNumber) <= Epsilon)
                {
                    Console.WriteLine($"[FOUND] Value {data[i]} found at index {i}. Aborting loop!");
                    pls.Break(); // Передчасне завершення циклу
                }
            });

            if (!result.IsCompleted)
            {
                Console.WriteLine($"\nSearch aborted on iteration {result.LowestBreakIteration}.");
            }
            else
            {
                Console.WriteLine("\nSearch completed. Value not found.");
            }

            Console.WriteLine("\nMain() is done. Press any key.");
            Console.ReadKey();
        }
    }
}