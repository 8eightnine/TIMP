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


        public CompareForm()
        {
            InitializeComponent();
        }

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

        private async Task InsertionSort()
        {
            timerIns.Start();
            swIns = new Stopwatch();
            swIns.Start();
            for (int i = 1; i < dataArray.Length; i++)
            {
                iterCount++;
                labelInsIter.Text = "Итерация: " + iterCount.ToString();
                int key = dataArray[i];
                int j = i - 1;
                while (j >= 0 && dataArray[j] > key)
                {
                    dataArray[j + 1] = dataArray[j];
                    j--;
                    panelInsertion.Invalidate();
                    await Task.Delay(50);
                }
                dataArray[j + 1] = key;
                panelInsertion.Invalidate();
                await Task.Delay(50);
            }
            timerIns.Stop();
            swIns.Stop();
        }

        private async Task BubbleSort()
        {
            timerBub.Start();
            swBub = new Stopwatch();
            swBub.Start();
            for (int i = 0; i < dataArray.Length - 1; i++)
            {
                iterCount++;
                labelBubIter.Text = "Итерация: " + iterCount.ToString();
                for (int j = 0; j < dataArray.Length - i - 1; j++)
                {
                    if (dataArray[j] > dataArray[j + 1])
                    {
                        int temp = dataArray[j];
                        dataArray[j] = dataArray[j + 1];
                        dataArray[j + 1] = temp;
                        panelBubble.Invalidate();
                        await Task.Delay(50);
                    }
                }
            }
            timerBub.Stop();
            swBub.Stop();
        }

        private async Task SelectionSort()
        {
            timerSel.Start();
            swSel = new Stopwatch();
            swSel.Start();
            for (int i = 0; i < dataArray.Length - 1; i++)
            {
                iterCount++;
                labelSelIter.Text = "Итерация: " + iterCount.ToString();
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
                panelSelection.Invalidate();
                await Task.Delay(50);
            }
            timerSel.Stop();
            swSel.Stop();
        }

        private async Task MergeSort(int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                await MergeSort(left, middle);
                await MergeSort(middle + 1, right);

                iterCount++; // Увеличиваем счетчик итераций только для реальных операций сортировки
                labelMerIter.Text = "Итерация: " + iterCount.ToString();

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
                panelMerge.Invalidate();
                await Task.Delay(50);
            }

            while (i < leftArraySize)
            {
                dataArray[k++] = leftArray[i++];
                panelMerge.Invalidate();
                await Task.Delay(50);
            }

            while (j < rightArraySize)
            {
                dataArray[k++] = rightArray[j++];
                panelMerge.Invalidate();
                await Task.Delay(50);
            }
        }


        private void panelInsertion_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < dataArray.Length; i++)
            {
                g.FillRectangle(Brushes.Blue, i * barWidth, panelInsertion.Height - dataArray[i], barWidth - 1, dataArray[i]);
            }
        }

        private void panelBubble_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < dataArray.Length; i++)
            {
                g.FillRectangle(Brushes.Blue, i * barWidth, panelBubble.Height - dataArray[i], barWidth - 1, dataArray[i]);
            }
        }

        private void panelSelection_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < dataArray.Length; i++)
            {
                g.FillRectangle(Brushes.Blue, i * barWidth, panelSelection.Height - dataArray[i], barWidth - 1, dataArray[i]);
            }
        }

        private void panelMerge_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < dataArray.Length; i++)
            {
                g.FillRectangle(Brushes.Blue, i * barWidth, panelMerge.Height - dataArray[i], barWidth - 1, dataArray[i]);
            }
        }

        private async void buttonShowSorts_Click(object sender, EventArgs e)
        {
            timerMer.Start();
            swMer = new Stopwatch();
            swMer.Start();

            GenerateRandomArray();
            iterCount = 0;

            InsertionSort();
            BubbleSort();
            SelectionSort();
            await MergeSort(0, dataArray.Length - 1);

            timerMer.Stop();
            swMer.Stop();
        }

        private void CompareForm_Load(object sender, EventArgs e)
        {
            GenerateRandomArray();
        }

        private void CompareForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void timerIns_Tick(object sender, EventArgs e)
        {
            labelInsTimer.Text = "Время: " + swIns.Elapsed.Seconds.ToString() + " с";
        }

        private void timerBub_Tick(object sender, EventArgs e)
        {
            labelBubTimer.Text = "Время: " + swBub.Elapsed.Seconds.ToString() + " с";
        }

        private void timerSel_Tick(object sender, EventArgs e)
        {
            labelSelTimer.Text = "Время: " + swSel.Elapsed.Seconds.ToString() + " с";
        }

        private void timerMer_Tick(object sender, EventArgs e)
        {
            labelMergeTimer.Text = "Время: " + swMer.Elapsed.Seconds.ToString() + " с";
        }
    }
}
