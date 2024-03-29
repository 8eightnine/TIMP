﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace laba1
{
    class VirtualMemo
    {
        string Name;
        int BlockSize;
        int[] Arr; // Массив значений
        int[] ArrPast;
        bool[] BMap; // Битовая карта
        bool[] BMapPast;
        int Index; // Индекс на странице
        int NumPagePast = -1;
        int NumPage = -1; // Номер страницы
        int Pages;
        private int BufferSize;
        private int[][] ArrBuffers;
        private bool[][] BMapBuffers;
        private int[] NumPageBuffers;
        private int bufferIndex = 0; // Индекс текущего буфера в кольцевом буфере

        // Конструктор
        public VirtualMemo(int BlockSize, int BufferSize, string Name = "Def.dat")
        {
            this.BlockSize = BlockSize;
            this.Name = Name;
            this.BufferSize = BufferSize;
            ArrBuffers = new int[BufferSize][];
            BMapBuffers = new bool[BufferSize][];
            NumPageBuffers = new int[BufferSize];
            BMap = new bool[BlockSize];
            BMapPast = new bool[BlockSize];
            Arr = new int[BlockSize];
            ArrPast = new int[BlockSize];
        }

        // Создание файла
        public void CreateFile()
        {
            int el;
            while (true)
            {
                Console.WriteLine("Введите количество элементов");
                string b = Console.ReadLine();
                bool success = int.TryParse(b, out el);
                if (success)
                {
                    if (el >= 1) break;
                    else Console.WriteLine("Неверный ввод"); continue;
                }
                else
                {
                    Console.WriteLine("Неверный ввод"); continue;
                }
            }
            using (FileStream fs = new FileStream(Name, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8))
                {
                    int pages = el / BlockSize;
                    int lastp = el - pages * BlockSize;

                    for (int i = 0; i < pages; i++)
                    {
                        bw.Seek((sizeof(bool) * BMap.Length + sizeof(int) * Arr.Length) * (i), 0);

                        Random rnd = new Random();

                        for (int j = 0; j < BlockSize; j++)
                        {
                            int b = rnd.Next(0, 2);
                            if (b == 0)
                            {
                                BMap[j] = false;
                                bw.Write(false);
                            }
                            else
                            {
                                BMap[j] = true;
                                bw.Write(true);
                            }

                        }
                        for (int j = 0; j < BlockSize; j++)
                        {
                            if (BMap[j] == true)
                                bw.Write(rnd.Next(1, 255));
                            else bw.Write(0);
                        }
                    }
                    if (lastp != 0)
                    {
                        pages = pages + 1;
                        Random rnd = new Random();
                        for (int j = 0; j < BlockSize; j++)
                        {
                            if (j < lastp)
                            {
                                int b = rnd.Next(0, 2);
                                if (b == 0)
                                {
                                    BMap[j] = false;
                                    bw.Write(false);
                                }
                                else
                                {
                                    BMap[j] = true;
                                    bw.Write(true);
                                }
                            }
                            else bw.Write(false);

                        }
                        for (int j = 0; j < BlockSize; j++)
                        {
                            if (BMap[j] == true)
                                bw.Write(rnd.Next(1, 255));
                            else bw.Write(0);
                        }
                    }
                    Pages = pages;
                    Console.WriteLine("кол-во стр в файле: " + Pages);
                }
            }
        }

        // Ввод индекса
        private int Index_()
        {
            int index;
            while (true)
            {
                Console.WriteLine("Введите индекс");
                string b = Console.ReadLine();
                bool success = int.TryParse(b, out index);
                if (success)
                {
                    if (index >= 0) return index;
                    else Console.WriteLine("Неверный ввод"); continue;
                }
                else
                {
                    Console.WriteLine("Неверный ввод"); continue;
                }
            }
        }

        // Чтение файла
        //private const int BufferSize = bufferSize; // Фиксированный размер буфера

        //private int[][] ArrBuffers = new int[BufferSize][]; // Массив буферов массивов Arr
        //private bool[][] BMapBuffers = new bool[BufferSize][]; // Массив буферов массивов BMap
        //private int[] NumPageBuffers = new int[BufferSize]; // Массив номеров страниц в буфере
        //private int bufferIndex = 0; // Индекс текущего буфера в кольцевом буфере

        public void InitializeBuffers()
        {
            for (int i = 0; i < BufferSize; i++)
            {
                ArrBuffers[i] = new int[BlockSize];
                BMapBuffers[i] = new bool[BlockSize];
                NumPageBuffers[i] = -1; // Или другое подходящее значение по умолчанию
            }
        }

        public void ReadIn()
        {
            int tempPage = NumPage;
            int index = Index_(); // Предположим, что Index_() возвращает правильный индекс

            int pageNum = (index / BlockSize) + 1;
            Index = index % BlockSize;

            if (pageNum > Pages)
                NumPage = 1;
            else
                NumPage = pageNum;

            int bufferIndex = GetBufferIndex(NumPage);
            if (bufferIndex != -1)
            {
                // Скопировать данные из буфера
                Array.Copy(ArrBuffers[bufferIndex], Arr, ArrBuffers[bufferIndex].Length);
                Array.Copy(BMapBuffers[bufferIndex], BMap, BMapBuffers[bufferIndex].Length);
                Console.WriteLine($"Страница №{NumPage} загружена из буфера.");
            }
            else
            {
                using (BinaryReader reader = new BinaryReader(File.Open(Name, FileMode.Open)))
                {
                    // Переход к началу нужной страницы в файле
                    reader.BaseStream.Seek((NumPage - 1) * BlockSize, SeekOrigin.Begin);
                    Console.WriteLine("Страница: " + NumPage);
                    Console.Write("Страницы в буфере: ");
                    foreach (var page in NumPageBuffers)
                    {
                        if (page != 0)
                        {
                            Console.Write(page + " ");
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Кол-во буфера: " + NumPageBuffers.Length);

                    // Чтение данных страницы
                    for (int i = 0; i < BlockSize; i++)
                        BMap[i] = reader.ReadBoolean();

                    for (int i = 0; i < BlockSize; i++)
                    {
                        if (BMap[i])
                            Arr[i] = reader.ReadInt32();
                        else
                            reader.ReadInt32(); // Пропустить данные, если флаг равен false
                    }
                }

                // Сохранить страницу в буфер, только если она не была прочитана из буфера
                SaveInBuffer();
            }

            NumPagePast = tempPage;
        }

        private int GetBufferIndex(int pageNum)
        {
            for (int i = 0; i < BufferSize; i++)
            {
                if (NumPageBuffers[i] == pageNum)
                    return i;
            }
            return -1;
        }

        private void SaveInBuffer()
        {
            // Сохранить текущую страницу в буфер
            ArrBuffers[bufferIndex] = (int[])Arr.Clone();
            BMapBuffers[bufferIndex] = (bool[])BMap.Clone();
            NumPageBuffers[bufferIndex] = NumPage;

            // Обновить индекс буфера
            bufferIndex = (bufferIndex + 1) % BufferSize;
        }

        // Чтение по индексу
        public void ReadIndex()
        {
            ReadIn();

            if (BMap[Index] == true)
            {
                Console.WriteLine("Элемент:" + Arr[Index]);
            }
            else
            {
                Console.WriteLine("Ячейка пуста");
            }
        }

        // Запись значения
        public void EnValue()
        {
            int el;
            while (true)
            {
                Console.WriteLine("Введите значение");
                string b = Console.ReadLine();
                bool success = int.TryParse(b, out el);
                if (success == false)
                {
                    Console.WriteLine("Неверный ввод"); continue;
                }
                else
                {
                    break;
                }
            }
            Arr[Index] = el;
            BMap[Index] = true;

            WriteFile();
        }

        // Удаление значения
        public void Delete()
        {
            Arr[Index] = 0;
            BMap[Index] = false;
            WriteFile();
        }

        // Замена значения
        public void EnDel()
        {
            ReadIn();
            if (BMap[Index] == true)
            {
                Console.WriteLine("Удалить старое значение?: \n 1 - да \n 2 - нет ");
                int a;
                a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        {
                            Delete();
                            EnValue();
                            break;
                        }
                    case 2: Console.WriteLine("Значение не изменено"); break;
                    default: Console.WriteLine("Ошибка ввода"); break;
                }
            }
            else
            {
                Console.WriteLine("Ячейка пустая");
                EnValue();
            }
        }

        // Запись файла
        private void WriteFile()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(Name, FileMode.OpenOrCreate)))
            {
                writer.Seek((sizeof(bool) * BMap.Length + sizeof(int) * Arr.Length) * (NumPage - 1), 0);

                for (int i = 0; i < BlockSize; i++)
                {
                    writer.Write(BMap[i]);
                }

                for (int i = 0; i < BlockSize; i++)
                {
                    writer.Write(Arr[i]);
                }
            }
        }
    }
}