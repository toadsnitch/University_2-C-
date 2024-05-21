using System;

namespace Graphh11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph("input.txt"); // Входной файл с данными графа
            g.Show();
            Console.WriteLine();

            Console.WriteLine("Введите вершину:  ");
            int vertex = int.Parse(Console.ReadLine());
            g.CountAdjacentVertices(vertex);
        }
    }
}
