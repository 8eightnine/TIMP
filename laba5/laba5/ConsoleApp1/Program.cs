using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main2(string[] args)
        {

            Console.WriteLine("Введите арифметическое выражение:");
            string expression = Console.ReadLine();
            var result = POLIZ.ConvertToRPN(expression);
            Console.WriteLine("Результат в обратной польской записи: " + result);
        }
    }
}
