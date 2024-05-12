/*
В файле input.txt хранится последовательность целых чисел. По входной 
последовательности построить дерево бинарного поиска и:
1. найти глубину заданного узла;
 */

using System;
using System.IO;

namespace BinTree2_2
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
                Console.WriteLine("Enter the node value:\t");
                int nodeValue = int.Parse(Console.ReadLine());
                int depth = x.Preorder(nodeValue);
                if (depth != -1)
                {
                    Console.WriteLine("Depth of node {0}:  {1}", nodeValue, depth);
                }
                else
                {
                    Console.WriteLine("Node not found");
                }
            }
        }
    }
}
