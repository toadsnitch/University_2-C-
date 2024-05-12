/*
В файле input.txt хранится последовательность целых чисел. По входной 
последовательности построить дерево бинарного поиска и:
1. проверить, является ли построенное дерево сбалансированным;
*/
using System;
using System.Collections.Specialized;
using System.IO;

namespace BinTree3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader fileIn = new StreamReader("input.txt"))
            {
                BinaryTree tree = new BinaryTree(); //Создаем дерево

                string line;
                char[] div = { ' ' };
                while ((line = fileIn.ReadLine()) != null)
                {
                    string[] mas = line.Split(div, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < mas.Length; i++)
                    {
                        tree.Add(int.Parse(mas[i]));
                    }
                }

                if (tree.IsBalanced())
                {
                    Console.WriteLine("The tree is balanced\n");
                    tree.Preorder();
                }
                else
                {
                    Console.WriteLine("The tree isn't balanced\nBalanced Tree:\n");
                    tree.Balancer();
                    tree.Preorder();
                }          
            }
        }
    }
}
