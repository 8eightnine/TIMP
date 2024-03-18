namespace laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            int blockSize = 0;
            int bufferSize = 0;
            bool validInput = false;
            bool validInput2 = false;

            while (!validInput)
            {
                Console.WriteLine("Введите размер блока:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out blockSize) && blockSize > 0)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Неверное значение, введите положительное целое число.");
                }
            }

            while (!validInput2)
            {
                Console.WriteLine("Введите размер буфера (от 3 до 512):");
                string input = Console.ReadLine();

                if (int.TryParse(input, out bufferSize) && bufferSize >= 3 && bufferSize <= 512)
                {
                    validInput2 = true;
                }
                else
                {
                    Console.WriteLine("Неверное значение, введите положительное целое число от 3 до 512.");
                }
            }

            VirtualMemo virtualMemo = new VirtualMemo(blockSize, bufferSize);

            while (true)
            {
                Console.WriteLine("1 - Создать файл");
                Console.WriteLine("2 - Прочитать значение по индексу");
                Console.WriteLine("3 - Изменить значение по индексу");
                Console.WriteLine("0 - Выйти");

                var IsValid = false;
                int choice = -1;

                while(IsValid != true)
                {
                    IsValid = Int32.TryParse(Console.ReadLine(), out choice);
                    if(IsValid == false) 
                    {
                        Console.WriteLine("Неверный ввод, попробуйте еще раз.");
                    }
                }

                switch (choice)
                {
                    case 0:
                        return;
                    case 1:

                        virtualMemo.CreateFile();
                        break;

                    case 2:
                        virtualMemo.ReadIndex();
                        break;

                    case 3:
                        virtualMemo.EnDel();
                        break;

                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }
    }
}