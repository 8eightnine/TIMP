using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class VirtualMemo
    {
        string Name;
        int BlockSize;
        int[] Arr; //значения
        bool[] BMap; //битовая карта
        int Index; //индекс на странице
        int NumPage; //номер странице
        int Pages;

        public VirtualMemo(int BlockSize, string Name = "Def.dat")
        {
            this.BlockSize = BlockSize;
            this.Name = Name;
            BMap = new bool[BlockSize];
            Arr = new int[BlockSize];

        }

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
                        bw.Seek((sizeof(bool) * BMap.Count() + sizeof(int) * Arr.Count()) * (i), 0);

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

        //ввод индекса
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

        public void ReadIn()
        {
            int index = Index_();
            int pageNum = 1;
            if (index % BlockSize == 0)
            {
                pageNum = index / BlockSize + 1;
                Index = 0;
            }
            else
            {
                pageNum = index / BlockSize + 1;
                Index = index - (index / BlockSize) * BlockSize;
            }
            if (pageNum > Pages)
            {
                NumPage = 1;//самая старая загруженная страница
            }
            else NumPage = pageNum;

            using (BinaryReader reader = new BinaryReader(File.Open(Name, FileMode.Open)))
            {
                // Считывание страницы в буферный массив
                reader.Read(new byte[(sizeof(bool) * BMap.Count() + sizeof(int) * Arr.Count()) * (NumPage - 1)], 0, (sizeof(bool) * BMap.Count() + sizeof(int) * Arr.Count()) * (NumPage - 1));
                Console.WriteLine("Страница:" + NumPage);
                Console.WriteLine("Индекс:" + Index);
                for (int i = 0; i < BlockSize; i++)
                    BMap[i] = reader.ReadBoolean();

                for (int i = 0; i < BlockSize; i++)
                {
                    if (BMap[i] == true)
                        Arr[i] = reader.ReadInt32();
                    else reader.ReadInt32();
                }
            }

        }
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

        public void Delete()
        {
            Arr[Index] = 0;
            BMap[Index] = false;
            WriteFile();
        }
        
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
                Console.WriteLine("ячейка пустая");
                EnValue();
            }
        }

        private void WriteFile()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(Name, FileMode.OpenOrCreate)))
            {
                writer.Seek((sizeof(bool) * BMap.Count() + sizeof(int) * Arr.Count()) * (NumPage - 1), 0);

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
