using System.Threading;

namespace Lab1_Task4
{
    public class ThreadWorker
    {
        public int Id { get; }
        public ThreadPriority Priority { get; }
        public long Count { get; private set; }
        public bool IsFinished { get; private set; }

        // Нова властивість, щоб знати, чи цей потік виграв гонку
        public bool IsWinner { get; private set; }
        public Thread Thrd { get; }

        private readonly long _target;

        // Спільний прапорець для всіх потоків (volatile гарантує миттєве оновлення для всіх ядер ЦП)
        public static volatile bool StopRace = false;

        public ThreadWorker(int id, ThreadPriority priority, long target)
        {
            Id = id;
            Priority = priority;
            _target = target;
            Count = 0;
            IsFinished = false;
            IsWinner = false;

            Thrd = new Thread(Run) { Priority = priority };
        }

        private void Run()
        {
            // Потік працює, поки не досягне мети АБО поки хтось інший не виграє гонку
            while (Count < _target && !StopRace)
            {
                Count++;
            }

            // Якщо цей потік вийшов з циклу, бо САМ досяг мети першим
            if (Count >= _target && !StopRace)
            {
                StopRace = true; // Зупиняємо всіх інших
                IsWinner = true; // Оголошуємо себе переможцем
            }

            IsFinished = true; // Ставимо статус завершення
        }
    }
}