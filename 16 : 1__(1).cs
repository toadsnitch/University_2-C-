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

                    //методы расширения
                    var lowNums = numbers.Where(x => x >= 0).OrderBy(x => x).Select(x => x); //используем лямбда выражение
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

// 0 1 8 9 -200 -35 -30 -2 5 7659 43 76 23 95
