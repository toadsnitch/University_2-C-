/*
Для хранения последовательности можно использовать одномерный массив
или любую другую подходящую коллекцию. Выбор структуры данных обосновать. Ввод вывод
данных – файловый.
1. Вывести на экран все положительные числа, отсортировав их в порядке возрастания.
*/

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Example
{
    class Program
    {
        static void Main()
        {
            using (StreamReader fileIn = new StreamReader("input.txt"))
            {
                using (StreamWriter fileOut = new StreamWriter("output.txt", false))
                {
                    List<int> numbers = new List<int>();
                    string line;
                    char[] div = { ' ' };
                    while ((line = fileIn.ReadLine()) != null)
                    {
                        string[] mas = line.Split(div, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < mas.Length; i++)
                        {
                            numbers.Add(int.Parse(mas[i]));
                        }
                    }

                    //создание запроса
                    var lowNums =
                        from num in numbers
                        where num >= 0
                        orderby num
                        select num;
                    //выполнение запроса
                    foreach (var x in lowNums)
                    {
                        fileOut.Write("{0} ", x);

                    }

                }
            }
        }
    }
}
