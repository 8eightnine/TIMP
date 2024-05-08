using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Line
    {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public Line(int x1, int x2)
        {
            X1 = x1;
            X2 = x2;
        }
    }
    public class Shadow
    {
        List<Line> lines;
        public List<Line> Lines { get { return lines; } }

        public Shadow()
        {
            lines = new List<Line>();
        }

        public void AddLine(int x1, int x2)
        {
            Line newLine;

            if (x1 < x2)//проверяем,  чтобы первая координата была меньше второй
                newLine = new Line(x1, x2);
            else
                newLine = new Line(x2, x1);

            for (int i = 0; i < lines.Count; i++) //упорядочиваем отрезки по первой координате
                if (lines[i].X1 > x1)
                {
                    lines.Insert(i, newLine);   //вставляем отрезок в список 
                    return;                     //выходим из метода
                }
            lines.Add(newLine);             //добавляем отрезок в конец списка
        }

        public int GetSum()
        {
            if (lines.Count == 0) return 0; //если отрезков нет

            int index = 0; //номер текщего отрезка
            int start = 0; //начало суммы текущих подряд идущих отрезков
            int end = 0;   //конец суммы текущих подряд идущих отрезков

            int sum = 0;

            while (index <= lines.Count)//перебираем все отрезки
            {
                //если это последняя линия
                // или – разрыв между отрезками
                if (index == lines.Count || lines[end].X2 < lines[index].X1)
                {
                    sum += Math.Abs(lines[end].X2 - lines[start].X1);
                    start = index;
                    end = index;
                }
                else if (lines[end].X2 < lines[index].X2) end = index; //если окончание текущего отрезка дальше  окончания
                index++; //текущей суммы отрезков, значит у нас новое окончание суммы отрезков
            }

            return sum;
        }
    }
}
