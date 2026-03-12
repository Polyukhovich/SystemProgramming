using System;
using System.Threading;

namespace Lab1_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread started...\n");

            // Створюємо два потоки, одразу задаємо їм імена 
            Thread thread1 = new Thread(Printer.PrintNumbers) { Name = "Number Thread" };
            Thread thread2 = new Thread(Printer.PrintLetters) { Name = "Letter Thread" };

            // Запускаємо виконання потоків
            thread1.Start();
            thread2.Start();

            // Змушуємо головний потік чекати завершення обох дочірніх
            thread1.Join();
            thread2.Join();

            Console.WriteLine("\nMain thread finished execution.");
            Console.ReadLine();
        }
    }
}