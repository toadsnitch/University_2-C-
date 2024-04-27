/*
18
1.Создать абстрактный класс Figure с методами вычисления площади и периметра, а также
методом, выводящим информацию о фигуре на экран. 
2. Создать производные классы: Rectangle (прямоугольник), Circle (круг), Triangle 
(треугольник) со своими методами вычисления площади и периметра. 
3. Создать массив n фигур и вывести полную информацию о фигурах на экран.

19
В абстрактном классе Figure реализовать метод CompareTo так, чтобы
можно было отсортировать объекты по их площадям.


Хранение в лист и чтобы выводилось через Tostring 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    static void Main(string[] args)
    {
        List<Figure> figures = new List<Figure>();

        using (StreamReader reader = new StreamReader("figures.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                string figureType = parts[0].Trim();

                switch (figureType)
                {
                    case "Rectangle":
                        double width = double.Parse(parts[1]);
                        double height = double.Parse(parts[2]);
                        figures.Add(new Rectangle(width, height));
                        break;
                    case "Circle":
                        double radius = double.Parse(parts[1]);
                        figures.Add(new Circle(radius));
                        break;
                    case "Triangle":
                        double a = double.Parse(parts[1]);
                        double b = double.Parse(parts[2]);
                        double c = double.Parse(parts[3]);
                        figures.Add(new Triangle(a, b, c));
                        break;
                    default:
                        Console.WriteLine("Unknown figure type: {0}", figureType);
                        break;
                }
            }
        }

        // Бинарная сериализация 
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream("figures.bin", FileMode.Create))
        {
            formatter.Serialize(stream, figures);
        }

        // Десериализация и сортировка 
        List<Figure> sortedFigures;
        using (FileStream stream = new FileStream("figures.bin", FileMode.Open))
        {
            sortedFigures = (List<Figure>)formatter.Deserialize(stream);
        }

        sortedFigures.Sort(); // Сортирует фигуры в зависимости от их площади 


        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            foreach (Figure figure in sortedFigures)
            {
                writer.WriteLine(figure.ToString());
            }
        }
    }
}
