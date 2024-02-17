namespace laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер блока:");
            int blockSize = int.Parse(Console.ReadLine());
            if (blockSize <= 0)
            {
                while (blockSize <= 0)
                {
                    Console.WriteLine("Неверное значение, введите другое:");
                    blockSize = int.Parse(Console.ReadLine());
                }
            } 

            VirtualMemo virtualMemo = new VirtualMemo(blockSize);

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