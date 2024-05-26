using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rgz
{
    public partial class MainForm : Form
    {
        private int[] dataArray;
        private int arraySize;
        private const int barWidth = 10;
        private int iterCount = 0;
        Stopwatch sw;

        public MainForm()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            comboBoxSortType.Items.AddRange(new string[]
            {
                "Вставкой",
                "Пузырьком",
                "Выбором",
                "Слиянием"
            });
            comboBoxSortType.SelectedIndex = 0;

            comboBoxSortType.SelectedIndexChanged += ComboBoxSortType_SelectedIndexChanged;

            buttonSort.Click += ButtonSort_Click;

            // Создаем массив данных, но не заполняем его
            //dataArray = new int[Int32.Parse(textBoxArrElCnt.Text)];

            // Подписываемся на событие загрузки формы
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Генерируем массив данных после загрузки формы
            GenerateRandomArray();
        }

        private void ComboBoxSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GenerateRandomArray();
        }

        private void GenerateRandomArray()
        {
            arraySize = Int32.Parse(textBoxArrElCnt.Text);
            dataArray = new int[arraySize];

            if (panelVisualize == null)
            {
                return; // панель еще не инициализирована
            }

            Random rand = new Random();
            for (int i = 0; i < arraySize; i++)
            {
                dataArray[i] = rand.Next(5, panelVisualize.Height);
            }
            panelVisualize.Invalidate();
        }

        private async void ButtonSort_Click(object sender, EventArgs e)
        {
            iterCount = 0;
            labelIterCnt.Text = iterCount.ToString();
            timer1.Equals(0);
            timer1.Start();
            buttonSort.Enabled = false;
            buttonRegenArr.Enabled = false;
            sw = new Stopwatch();
            sw.Start();
            switch (comboBoxSortType.SelectedItem.ToString())
            {
                case "Вставкой":
                    await InsertionSort();
                    break;
                case "Пузырьком":
                    await BubbleSort();
                    break;
                case "Выбором":
                    await SelectionSort();
                    break;
                case "Слиянием":
                    await MergeSort(0, dataArray.Length - 1);
                    break;
            }
            buttonSort.Enabled = true;
            buttonRegenArr.Enabled = true;
            timer1.Stop();
            sw.Stop();
        }

        private async Task InsertionSort()
        {
            for (int i = 1; i < dataArray.Length; i++)
            {
                iterCount++;
                labelIterCnt.Text = iterCount.ToString();
                int key = dataArray[i];
                int j = i - 1;
                while (j >= 0 && dataArray[j] > key)
                {
                    dataArray[j + 1] = dataArray[j];
                    j--;
                    panelVisualize.Invalidate();
                    await Task.Delay(50);
                }
                dataArray[j + 1] = key;
                panelVisualize.Invalidate();
                await Task.Delay(50);
            }
        }

        private async Task BubbleSort()
        {
            for (int i = 0; i < dataArray.Length - 1; i++)
            {
                iterCount++;
                labelIterCnt.Text = iterCount.ToString();
                for (int j = 0; j < dataArray.Length - i - 1; j++)
                {
                    if (dataArray[j] > dataArray[j + 1])
                    {
                        int temp = dataArray[j];
                        dataArray[j] = dataArray[j + 1];
                        dataArray[j + 1] = temp;
                        panelVisualize.Invalidate();
                        await Task.Delay(50);
                    }
                }
            }
        }

        private async Task SelectionSort()
        {
            for (int i = 0; i < dataArray.Length - 1; i++)
            {
                iterCount++;
                labelIterCnt.Text = iterCount.ToString();
                int minIndex = i;
                for (int j = i + 1; j < dataArray.Length; j++)
                {
                    if (dataArray[j] < dataArray[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = dataArray[minIndex];
                dataArray[minIndex] = dataArray[i];
                dataArray[i] = temp;
                panelVisualize.Invalidate();
                await Task.Delay(50);
            }
        }

        private async Task MergeSort(int left, int right)
        {
            iterCount++;
            labelIterCnt.Text = iterCount.ToString();
            if (left < right)
            {
                int middle = (left + right) / 2;
                await MergeSort(left, middle);
                await MergeSort(middle + 1, right);
                await Merge(left, middle, right);
            }
        }

        private async Task Merge(int left, int middle, int right)
        {
            int leftArraySize = middle - left + 1;
            int rightArraySize = right - middle;

            int[] leftArray = new int[leftArraySize];
            int[] rightArray = new int[rightArraySize];

            Array.Copy(dataArray, left, leftArray, 0, leftArraySize);
            Array.Copy(dataArray, middle + 1, rightArray, 0, rightArraySize);

            int i = 0, j = 0, k = left;

            while (i < leftArraySize && j < rightArraySize)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    dataArray[k++] = leftArray[i++];
                }
                else
                {
                    dataArray[k++] = rightArray[j++];
                }
                panelVisualize.Invalidate();
                await Task.Delay(50);
            }

            while (i < leftArraySize)
            {
                dataArray[k++] = leftArray[i++];
                panelVisualize.Invalidate();
                await Task.Delay(50);
            }

            while (j < rightArraySize)
            {
                dataArray[k++] = rightArray[j++];
                panelVisualize.Invalidate();
                await Task.Delay(50);
            }
        }

        private void panelVisualize_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < dataArray.Length; i++)
            {
                g.FillRectangle(Brushes.Blue, i * barWidth, panelVisualize.Height - dataArray[i], barWidth - 1, dataArray[i]);
            }
        }

        private void buttonRegenArr_Click(object sender, EventArgs e)
        {
            GenerateRandomArray();
        }

        private void comboBoxSortType_SelectedValueChanged(object sender, EventArgs e)
        {
            GenerateRandomArray();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTimer.Text = sw.Elapsed.Seconds.ToString() + " с";
        }

        private void buttonCompareSorts_Click(object sender, EventArgs e)
        {
            CompareForm compareForm = new CompareForm();
            compareForm.Show();
            this.Hide();
        }
    }
}