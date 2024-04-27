/*
В файле input.txt хранится последовательность целых чисел. По входной 
последовательности построить дерево бинарного поиска и найти для него:
1. сумму нечетных значений узлов дерева;
 */

using System;
using System.IO;

namespace BinTree1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader fileIn = new StreamReader("input.txt"))
            {
                BinaryTree x = new BinaryTree(); //Создаем дерево

                string line;
                char[] div = { ' ' };
                while ((line = fileIn.ReadLine()) != null)
                {
                    string[] mas = line.Split(div, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < mas.Length; i++)
                    {
                        x.Add(int.Parse(mas[i]));
                    }
                }
                x.Preorder();
            }
        }
    }
}
