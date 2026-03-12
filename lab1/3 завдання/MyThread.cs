using System.Threading;

namespace Lab1_Task3
{
    // Клас-обгортка для зручного керування потоком
    public class MyThread
    {
        // Лічильник ітерацій конкретного потоку
        public int Count { get; private set; }
        public Thread Thrd { get; private set; }

        // Спільний прапорець для всіх потоків. Якщо хтось дорахував — змінює на true.
        private static bool stop = false;

        // Конструктор, що приймає ім'я та рівень пріоритету
        public MyThread(string name, ThreadPriority priority)
        {
            Count = 0;
            Thrd = new Thread(Run)
            {
                Name = name,
                Priority = priority
            };
        }

        private void Run()
        {
            // Рахуємо, поки спільний прапорець false і лічильник < 100 мільйонів
            do
            {
                Count++;
            } while (!stop && Count < 100000000);

            // Перший потік, що вийде з циклу, встановить stop = true і зупинить інших
            stop = true;
        }
    }
}