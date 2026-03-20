using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lab3_Task1
{
    class Program
    {
        // Константи для розміру масивів
        const int SizeSmall = 10_000_000;
        const int SizeLarge = 50_000_000;

        static void Main(string[] args)
        {
            Console.WriteLine("--- BENCHMARK: SEQUENTIAL VS PARALLEL ---");
            Console.WriteLine("Wait while calculating...\n");

            Console.WriteLine($"{"Type",-8} | {"Size",-10} | {"Formula",-20} | {"Seq Time (ms)",-15} | {"Par Time (ms)",-15} | {"Winner",-10}");
            Console.WriteLine(new string('-', 90));

            // Тести для масивів різного розміру та типу
            RunTestsInt(SizeSmall);
            RunTestsInt(SizeLarge);
            RunTestsDouble(SizeSmall);
            RunTestsDouble(SizeLarge);

            Console.WriteLine("\nBenchmark finished. Press any key to exit.");
            Console.ReadKey();
        }

        static void RunTestsDouble(int size)
        {
            double[] data = new double[size];
            for (int i = 0; i < size; i++) data[i] = (i % 10) + 1; // Заповнення малими числами, щоб уникнути Infinity

            // Формула 1: x = x / 10
            RunBenchmark("double", size, "x = x / 10",
                () => { for (int i = 0; i < size; i++) data[i] = data[i] / 10.0; },
                () => { Parallel.For(0, size, i => data[i] = data[i] / 10.0); });

            // Формула 2: x = x / pi
            RunBenchmark("double", size, "x = x / PI",
                () => { for (int i = 0; i < size; i++) data[i] = data[i] / Math.PI; },
                () => { Parallel.For(0, size, i => data[i] = data[i] / Math.PI); });

            // Формула 3: x = e^x / x^pi
            RunBenchmark("double", size, "x = e^x / x^PI",
                () => { for (int i = 0; i < size; i++) data[i] = Math.Exp(data[i]) / Math.Pow(data[i], Math.PI); },
                () => { Parallel.For(0, size, i => data[i] = Math.Exp(data[i]) / Math.Pow(data[i], Math.PI)); });

            // Формула 4: x = e^(pi * x) / x^pi
            RunBenchmark("double", size, "x = e^(PI*x) / x^PI",
                () => { for (int i = 0; i < size; i++) data[i] = Math.Exp(Math.PI * data[i]) / Math.Pow(data[i], Math.PI); },
                () => { Parallel.For(0, size, i => data[i] = Math.Exp(Math.PI * data[i]) / Math.Pow(data[i], Math.PI)); });
        }

        static void RunTestsInt(int size)
        {
            int[] data = new int[size];
            for (int i = 0; i < size; i++) data[i] = (i % 10) + 1;

            // Для int використовуємо тільки першу формулу (ділення цілих чисел), 
            // оскільки інші формули вимагають роботи з плаваючою крапкою (double)
            RunBenchmark("int", size, "x = x / 10",
                () => { for (int i = 0; i < size; i++) data[i] = data[i] / 10; },
                () => { Parallel.For(0, size, i => data[i] = data[i] / 10); });
        }

        static void RunBenchmark(string type, int size, string formula, Action seqAction, Action parAction)
        {
            Stopwatch sw = new Stopwatch();

            // Вимірювання послідовного часу
            sw.Start();
            seqAction();
            sw.Stop();
            long seqTime = sw.ElapsedMilliseconds;

            sw.Reset();

            // Вимірювання паралельного часу
            sw.Start();
            parAction();
            sw.Stop();
            long parTime = sw.ElapsedMilliseconds;

            string winner = parTime < seqTime ? "Parallel" : "Sequential";

            Console.WriteLine($"{type,-8} | {size,-10} | {formula,-20} | {seqTime,-15} | {parTime,-15} | {winner,-10}");
        }
    }
}