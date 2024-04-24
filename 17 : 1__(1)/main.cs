using System;
using System.IO;

namespace PointOfView
{
    class Program
    {
        static void Main()
        {
            using (StreamWriter sw = File.AppendText("output.txt"))
            {
                // Демонстрация работы класса Point
                sw.WriteLine("Cоздание точки с нулевыми координатами:");
                Point point1 = new Point(); // создание точки с нулевыми координатами
                point1.ShowMe(sw);
                sw.WriteLine("Расстояние от оси:\n" + point1.Distance());


                Point point2 = new Point(3, 4); // создание точки с заданными координатами
                sw.WriteLine("Создание новой точки:");
                point2.ShowMe(sw);
                sw.WriteLine("Расстояние от оси:\n" + point2.Distance());

                point2.Move(2, 3); // перемещение точки
                sw.WriteLine("перемещение точки на вектор: ");
                ++point2;
                point2.ShowMe(sw);

                Point point3 = new Point();

                point3.X = 9;
                point3.Z = 10; // установка нового значения координаты x, z
                sw.WriteLine("Создаём новую точку (в пространстве)");
                point3.ShowMe(sw);

                point3.ScalarMultiplier = 2; // умножение координат на скаляр
                sw.WriteLine("Умножение координат на 2 (скаляр):");
                point3.ShowMe(sw);

                sw.WriteLine("Indexer - x: " + point3[0]);
                sw.WriteLine("Indexer - y: " + point3[1]);

                ++point3; // увеличение координат на 1
                sw.WriteLine("Результат после инкремента:");
                point3.ShowMe(sw);

                --point3; // уменьшение координат на 1
                sw.WriteLine("Результат после декремента:");
                point3.ShowMe(sw);

                sw.WriteLine("поля point1 совпадают? " + (point1 ? true : false));
                sw.WriteLine("поля point2 совпадают? " + (point2 ? true : false));

                point3 = 5 + point3; // добавление скаляра
                sw.WriteLine("Прибавляем к точке скаляр 5:");
                point3.ShowMe(sw);
                point3 = point3 - 6;
                sw.WriteLine("Отнимаем от точки скаляр 6:");
                point3.ShowMe(sw);
            }
        }
    }
}
