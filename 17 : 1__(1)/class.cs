using System;
using System.IO;

namespace PointOfView
{
    class Point
    {
        // Поля класса
        private int x, y;
        private int? z;

        public Point()
        {
            x = 0;
            y = 0;
            z = null;
        }

        public Point(int x, int y) // конструктор с заданными координатами
        {
            this.x = x;
            this.y = y;
            this.z = null;
        }

        public Point(int x, int y, int? z) : this(x, y) // конструктор с заданными координатами
        {
            this.z = z;
        }



        // Методы
        public void ShowMe(StreamWriter sw)
        {
            try
            {
                if (z == null)
                {
                    sw.WriteLine($"Координаты: ({x}, {y})");
                }
                else
                {
                    sw.WriteLine($"Координаты: ({x}, {y}, {z})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }
        }

        public double Distance()
        {
            if (z != null)
            {
                int z1 = (int)z;
                return Math.Sqrt(x * x + y * y + z1 * z1);
            }
            else
            {
                return Math.Sqrt(x * x + y * y);
            }
        }

        public void Move(int a, int b)
        {
            x += a;
            y += b;
        }

        public void Move(int a, int b, int? c)
        {
            x += a;
            y += b;
            z += c;
        }

        // Свойства
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int? Z
        {
            get { return z; }
            set { z = value; }
        }

        public int ScalarMultiplier
        {
            set
            {
                x *= value;
                y *= value;
                z *= value;
            }
        }

        // Индексатор
        public int this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else if (index == -1) return (int)z;
                else throw new IndexOutOfRangeException("Неверный запрос");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else if (index == -1) z = value;
                else throw new IndexOutOfRangeException("Неверный запрос");
            }
        }

        // Перегрузка операций
        public static Point operator ++(Point p)
        {
            Point pNew = new Point(p.x, p.y, p.z);
            pNew.x++;
            pNew.y++;
            if (pNew.z != null) pNew.z++;
            return pNew;
        }

        public static Point operator --(Point p)
        {
            Point pNew = new Point(p.x, p.y, p.z);
            pNew.x--;
            pNew.y--;
            if (pNew.z != null)
            {
                pNew.z--;
            }
            return pNew;
        }

        public static bool operator true(Point p)
        {
            return p.x == p.y;
        }

        public static bool operator false(Point p)
        {
            return p.x != p.y;
        }

        public static Point operator +(Point p, int scalar)
        {
            return new Point(p.x + scalar, p.y + scalar, p.z + scalar);
        }

        public static Point operator -(Point p, int scalar)
        {
            return new Point(p.x - scalar, p.y - scalar, p.z - scalar);
        }

        public static Point operator +(int scalar, Point p)
        {
            return new Point(p.x + scalar, p.y + scalar, p.z + scalar);
        }

        public static Point operator -(int scalar, Point p)
        {
            return new Point(p.x - scalar, p.y - scalar, p.z - scalar);
        }

    }
}
