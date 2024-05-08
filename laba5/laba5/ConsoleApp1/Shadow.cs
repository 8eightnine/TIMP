using System.Collections.Generic;

namespace ConsoleApp1
{
    public class ShadowCalc
    {
        static void Main(string[] args)
        {

            Shadow();

        }

        public static void Shadow()
        {
            OX ox = new OX();
            Console.WriteLine("Введите кол-во линий");
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < number; i++)
                {
                    Console.WriteLine("Начало отрезка :" + i);
                    int start = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Конец отрезка :" + i);
                    int end = Convert.ToInt32(Console.ReadLine());
                    if (start <= end)
                    {
                        Line line = new Line(start, end);
                        ox.lines.Add(line);
                    }
                    else
                    {
                        Line line = new Line(end, start);
                        ox.lines.Add(line);
                    }
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Введите количество линий!!!!");
                Shadow();
            }
            Value value = new Value(ox);
            Console.WriteLine("Результат: " + value.shadow_lenght());
        }


    }
    public class Value
    {
        public OX ox;
        public Value(OX ox)
        {
            this.ox = ox;
        }
        public int shadow_lenght()
        {
            int sum = 0;
            for (int i = 0; i < ox.lines.Count; i++)
            {
                for (int j = 0; j < ox.lines.Count; j++)
                {
                    if (i == j) continue;
                    if (ox.lines[i].start >= ox.lines[j].start && ox.lines[i].end <= ox.lines[j].end) //линия i входит в линию j
                    {
                        ox.lines[i].start = 0;
                        ox.lines[i].end = 0;
                    }
                    if (ox.lines[j].start >= ox.lines[i].start && ox.lines[j].end <= ox.lines[i].end) //линия j входит в линию i
                    {
                        ox.lines[j].start = 0;
                        ox.lines[j].end = 0;
                    }
                    if (ox.lines[i].start > ox.lines[j].start && ox.lines[i].start < ox.lines[j].end && ox.lines[j].end < ox.lines[i].end) //линия i начинается в линии j но заканчивается не в линии j
                    {
                        ox.lines[i].start = ox.lines[j].end;

                    }
                    if (ox.lines[i].start < ox.lines[j].start && ox.lines[i].start < ox.lines[j].end && ox.lines[i].end < ox.lines[j].end && ox.lines[i].end > ox.lines[j].end) //линия i не начинается в линии j но заканчивается в линии j
                    {
                        ox.lines[i].end = ox.lines[j].start;
                    }
                }
            }
            for (int i = 0; i < ox.lines.Count; i++) //подсчёт суммы длин
            {
                sum += ox.lines[i].end - ox.lines[i].start;
            }
            return sum;
        }

    }
    public class OX
    {
        public List<Line> lines = new List<Line>();
    }
    public class Line
    {
        public int start, end;

        public Line(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
        public bool check()
        {
            if (start > -501 && start < 501 && end > -501 && end < 501)
            {
                return true;
            }
            else return false;
        }
    }
}
