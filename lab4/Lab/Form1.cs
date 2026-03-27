using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Lab
{
    public partial class Form1 : Form
    {
        // [ЗАВДАННЯ 4]: Об'єкт для керування скасуванням асинхронної задачі
        private CancellationTokenSource cts;

        // Змінна, яка буде контролювати швидкість роботи (затримку в мілісекундах)
        private int delayTime = 50;

        // Змінна кольору прогрес бару 
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        const int PBM_SETSTATE = 1040;
        public Form1()
        {
            InitializeComponent();

            this.Text = "Advanced Async Calculator";
            this.BackColor = Color.WhiteSmoke;

            // [ЗАВДАННЯ 1]: Радіокнопки потрібні для демонстрації того, що головний потік 
            radioButton1.Text = "Fast (10 ms)";
            radioButton2.Text = "Normal (50 ms)";
            radioButton3.Text = "Slow (200 ms)";
            radioButton2.Checked = true;

            buttonCancel.Enabled = false;
        }
        // [ЗАВДАННЯ 1]: Запуск асинхронної задачі. Метод позначено як 'async', 
        private async void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;

            buttonCancel.Enabled = true;

            SendMessage(progressBar1.Handle, PBM_SETSTATE, (IntPtr)1, IntPtr.Zero);

            labelResult.Text = "Result: calculating...";
            labelResult.ForeColor = Color.Black;
            progressBar1.Value = 0;

            // [ЗАВДАННЯ 3]: Інформування про хід виконання. 
            // Створюємо об'єкт IProgress, який оновлює відсотки у тексті та сам прогрес-бар.
            IProgress<int> onChangeProgress = new Progress<int>((i) =>
            {
                labelProgress.Text = i.ToString() + "%";
                progressBar1.Value = i;
            });

            // [ЗАВДАННЯ 4]: Ініціалізація токена скасування перед початком роботи.
            cts = new CancellationTokenSource();

            try
            {
                // [ЗАВДАННЯ 1] та [ЗАВДАННЯ 2]: 
                // Виклик довготривалої операції через 'await' (не блокує форму).
                // Отримання результату обчислень (result) після завершення задачі.
                int result = await ProcessAsync(100, onChangeProgress, cts.Token);

                // [ЗАВДАННЯ 2]: Відображення отриманого результату на елементі керування форми.
                if (!cts.IsCancellationRequested)
                {
                    labelResult.Text = "Result: " + result.ToString();
                    labelResult.ForeColor = Color.DarkGreen;
                }
            }
            finally
            {
                buttonStart.Enabled = true;
                buttonCancel.Enabled = false;
            }
        }

        // [ЗАВДАННЯ 4]: Дочасне переривання довготривалої операції
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (cts != null && !cts.IsCancellationRequested)
            {
                // Переводимо токен у стан "скасований"
                cts.Cancel();

                SendMessage(progressBar1.Handle, PBM_SETSTATE, (IntPtr)2, IntPtr.Zero);

                labelResult.Text = "Result: CANCELED ";
                labelResult.ForeColor = Color.Red;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) delayTime = 10;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) delayTime = 50;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) delayTime = 200;
        }

        // асинхрон        // Метод повертає Task<int>
        private Task<int> ProcessAsync(int count, IProgress<int> changeProgressBar, CancellationToken cancellationToken)
        {
            // [ЗАВДАННЯ 1]: Запускаємо код в окремому фоновому потоці за допомогою Task.Run
            return Task.Run(() =>
            {
                int sum = 0;

                for (int i = 1; i <= count; i++)
                {
                    // [ЗАВДАННЯ 4]: Перевірка того, чи має бути скасована операція на кожній ітерації
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return sum; // Перериваємо цикл і повертаємо те, що встигли порахувати
                    }

                    sum += i; // Імітація обчислень (Завдання 2)

                    // [ЗАВДАННЯ 3]: Передаємо поточний відсоток (i) назад на головну форму
                    changeProgressBar.Report(i);

                    // Штучна затримка, що імітує "довготривалу операцію" 
                    Thread.Sleep(delayTime);
                }

                // [ЗАВДАННЯ 2]: Повертаємо фінальний результат
                return sum;
            });
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}