/*
I. Решить задачу, используя структуру SPoint для хранения координат точки:
Замечание.В задачах с нечетными номерами множество точек задано на плоскости, в задачах с
четными номерами множество точек задано в пространстве.
1–2. Найти точку, которая наиболее удалена от начала координат. 
*/

using System;
using System.IO;
using System.Collections.Generic;

struct SPoint
{
    // поля структуры 
    public int x;
    public int y;
    // конструктор структкры. конструктор предназначен для инициализации полей экземпляров структуры 
    public SPoint(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    // метод, который находит расстояние между точками 
    public double FindDistance()
    {
        return Math.Sqrt(x * x + y * y);
    }
    //результат на экран 
    public void show()
    {
        Console.WriteLine("{0} {1}", x, y);
    }
}

class Program
{
    static void Main()
    {
        double maxDistance = 0;
        List<SPoint> Max = new List<SPoint>();
        string[] liness = File.ReadAllLines("points.txt");

        foreach (string line in liness) //foreach переходит построчно
        {
            string[] coords = line.Split(' ');
            //вызываем конструктор (Создается новый объект point типа SPoint) 
            SPoint point = new SPoint(int.Parse(coords[0]), int.Parse(coords[1]));
            double distance = point.FindDistance();
            if (distance > maxDistance)
            {
                Max.Clear(); //удаляет все значения из списка 
                Max.Add(point);
                maxDistance = distance;
            }
            else if (distance == maxDistance)
            {
                Max.Add(point);
            }
        }
        foreach (SPoint max in Max)
        {
            max.show();
        }
    }
}

/*
1 3
2 5
6 9
-2 300
100 200
 */
