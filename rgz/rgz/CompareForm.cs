using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rgz
{
    public partial class CompareForm : Form
    {
        private int[] dataArray;
        private const int barWidth = 5;
        private int arraySize = 25;
        private int iterCount = 0;
        Stopwatch swIns;
        Stopwatch swBub;
        Stopwatch swSel;
        Stopwatch swMer;

        private int[] insArray;
        private int[] bubArray;
        private int[] selArray;
        private int[] merArray;

        public CompareForm()
        {
            InitializeComponent();
        }

        // Метод для генерации случайного массива данных
        private void GenerateRandomArray()
        {
            dataArray = new int[arraySize];

            if (panelInsertion == null || panelBubble == null || panelSelection == null || panelMerge == null)
            {
                return; // панель еще не инициализирована
            }

            Random rand = new Random();
            for (int i = 0; i < arraySize; i++)
            {
                dataArray[i] = rand.Next(5, panelInsertion.Height);
            }
            panelInsertion.Invalidate();
            panelBubble.Invalidate();
            panelSelection.Invalidate();
            panelMerge.Invalidate();
        }

        // Метод для копирования массива данных
        private int[] CopyArray()
        {
            int[] copy = new int[dataArray.Length];
            Array.Copy(dataArray, copy, dataArray.Length);
            return copy;
        }

        // Метод для сортировки вставкой
        private async Task InsertionSort(int[] array, Panel panel)
        {
            timerIns.Start();
            swIns = new Stopwatch();
            swIns.Start();
            for (int i = 1; i < array.Length; i++)
            {
                iterCount++;
                labelInsIter.Text = "Итерация: " + iterCount.ToString();
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                    panel.Invalidate();
                    await Task.Delay(50);
                }
                array[j + 1] = key;
                panel.Invalidate();
                await Task.Delay(50);
            }
            timerIns.Stop();
            swIns.Stop();
        }

        // Метод для пузырьковой сортировки
        private async Task BubbleSort(int[] array, Panel panel)
        {
            timerBub.Start();
            swBub = new Stopwatch();
            swBub.Start();
            for (int i = 0; i < array.Length - 1; i++)
            {
                iterCount++;
                labelBubIter.Text = "Итерация: " + iterCount.ToString();
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        panel.Invalidate();
                        await Task.Delay(50);
                    }
                }
            }
            timerBub.Stop();
            swBub.Stop();
        }

        // Метод для сортировки выбором
        private async Task SelectionSort(int[] array, Panel panel)
        {
            timerSel.Start();
            swSel = new Stopwatch();
            swSel.Start();
            for (int i = 0; i < array.Length - 1; i++)
            {
                iterCount++;
                labelSelIter.Text = "Итерация: " + iterCount.ToString();
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
                panel.Invalidate();
                await Task.Delay(50);
            }
            timerSel.Stop();
            swSel.Stop();
        }

        // Метод для сортировки слиянием
        private async Task MergeSort(int[] array, int left, int right, Panel panel)
        {
            if (left == 0 && right == array.Length - 1)
            {
                timerMer.Start();
                swMer = new Stopwatch();
                swMer.Start();
            }

            if (left < right)
            {
                int middle = (left + right) / 2;

                await MergeSort(array, left, middle, panel);
                await MergeSort(array, middle + 1, right, panel);

                iterCount++;
                labelMerIter.Text = "Итерация: " + iterCount.ToString();

                await Merge(array, left, middle, right, panel);
            }

            if (left == 0 && right == array.Length - 1)
            {
                timerMer.Stop();
                swMer.Stop();
            }
        }

        // Метод для слияния массивов
        private async Task Merge(int[] array, int left, int middle, int right, Panel panel)
        {
            int leftArraySize = middle - left + 1;
            int rightArraySize = right - middle;

            int[] leftArray = new int[leftArraySize];
            int[] rightArray = new int[rightArraySize];

            Array.Copy(array, left, leftArray, 0, leftArraySize);
            Array.Copy(array, middle + 1, rightArray, 0, rightArraySize);

            int i = 0, j = 0, k = left;

            while (i < leftArraySize && j < rightArraySize)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k++] = leftArray[i++];
                }
                else
                {
                    array[k++] = rightArray[j++];
                }
                panel.Invalidate();
                await Task.Delay(50);
            }

            while (i < leftArraySize)
            {
                array[k++] = leftArray[i++];
                panel.Invalidate();
                await Task.Delay(50);
            }

            while (j < rightArraySize)
            {
                array[k++] = rightArray[j++];
                panel.Invalidate();
                await Task.Delay(50);
            }
        }

        // Отрисовка панели для сортировки вставкой
        private void panelInsertion_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < insArray.Length; i++)
            {
                g.FillRectangle(Brushes.Blue, i * barWidth, panelInsertion.Height - insArray[i], barWidth - 1, insArray[i]);
            }
        }

        // Отрисовка панели для пузырьковой сортировки
        private void panelBubble_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < bubArray.Length; i++)
            {
                g.FillRectangle(Brushes.Blue, i * barWidth, panelBubble.Height - bubArray[i], barWidth - 1, bubArray[i]);
            }
        }

        // Отрисовка панели для сортировки выбором
        private void panelSelection_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < selArray.Length; i++)
            {
                g.FillRectangle(Brushes.Blue, i * barWidth, panelSelection.Height - selArray[i], barWidth - 1, selArray[i]);
            }
        }

        // Отрисовка панели для сортировки слиянием
        private void panelMerge_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < merArray.Length; i++)
            {
                g.FillRectangle(Brushes.Blue, i * barWidth, panelMerge.Height - merArray[i], barWidth - 1, merArray[i]);
            }
        }

        // Обработка нажатия на кнопку для начала сортировки
        private async void buttonShowSorts_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBoxArrSize.Text, out int arrSize))
            {
                if (arrSize <= 25 && arrSize >= 5)
                {
                    arraySize = Int32.Parse(textBoxArrSize.Text);
                    GenerateRandomArray();
                    iterCount = 0;

                    insArray = CopyArray();
                    bubArray = CopyArray();
                    selArray = CopyArray();
                    merArray = CopyArray();

                    var insTask = InsertionSort(insArray, panelInsertion);
                    var bubTask = BubbleSort(bubArray, panelBubble);
                    var selTask = SelectionSort(selArray, panelSelection);
                    var merTask = MergeSort(merArray, 0, merArray.Length - 1, panelMerge);

                    await Task.WhenAll(insTask, bubTask, selTask, merTask);
                }
                else
                {
                    MessageBox.Show("Массив должен иметь размер от 5 до 25!");
                }
            }
            else
            {
                MessageBox.Show("Размером массива должно быть число!");
            }
        }

        // Метод, который выполняется при загрузке формы
        private void CompareForm_Load(object sender, EventArgs e)
        {
            GenerateRandomArray();
            insArray = CopyArray();
            bubArray = CopyArray();
            selArray = CopyArray();
            merArray = CopyArray();
        }

        // Метод, который выполняется при закрытии формы
        private void CompareForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        // Обновление времени для сортировки вставкой
        private void timerIns_Tick(object sender, EventArgs e)
        {
            labelInsTimer.Text = "Время: " + swIns.Elapsed.Seconds.ToString() + " с";
        }

        // Обновление времени для пузырьковой сортировки
        private void timerBub_Tick(object sender, EventArgs e)
        {
            labelBubTimer.Text = "Время: " + swBub.Elapsed.Seconds.ToString() + " с";
        }

        // Обновление времени для сортировки выбором
        private void timerSel_Tick(object sender, EventArgs e)
        {
            labelSelTimer.Text = "Время: " + swSel.Elapsed.Seconds.ToString() + " с";
        }

        // Обновление времени для сортировки слиянием
        private void timerMer_Tick(object sender, EventArgs e)
        {
            labelMergeTimer.Text = "Время: " + swMer.Elapsed.Seconds.ToString() + " с";
        }
    }
}
