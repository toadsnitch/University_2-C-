using System;
using System.IO;

namespace Graphh11
{
    public class Graph
    {
        private class Node
        {
            private int[,] array;

            public int this[int i, int j]
            {
                get
                {
                    return array[i, j];
                }
                set
                {
                    array[i, j] = value;
                }
            }

            public int Size //получение числа вершин в графе 
            {
                get
                {
                    return array.GetLength(0);
                }
            }

            // Конструктор для инициализации матрицы смежности
            public Node(int[,] a)
            {
                array = a;
            }

            public int CountAdjacentVertices(int v) //метод для подсчета кол-ва вершин с вершиной v
            {
                int count = 0;
                // Перебор всех вершин
                for (int u = 0; u < Size; u++)
                {
                    if (array[v, u] != 0)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        private Node graph;

        public Graph(string name)
        {
            using (StreamReader file = new StreamReader(name))
            {
                int n = int.Parse(file.ReadLine());
                int[,] a = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    string line = file.ReadLine();
                    string[] mas = line.Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = int.Parse(mas[j]);
                    }
                }

                // Инициализация графа матрицей смежности
                graph = new Node(a);
            }
        }

        // Метод для отображения матрицы смежности на консоли
        public void Show()
        {
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    Console.Write("{0,4}", graph[i, j]);
                }
                Console.WriteLine();
            }
        }

        // Метод для подсчета и вывода количества смежных вершин для данной вершины v
        public void CountAdjacentVertices(int v)
        {
            int count = graph.CountAdjacentVertices(v);
            Console.WriteLine("Количество вершин, смежных с вершиной {0}: {1}", v, count);
        }
    }
}
