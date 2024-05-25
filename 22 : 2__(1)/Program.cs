/*
В входном файле указывается количество вершин графа/орграфа и матрица смежности:  
Для заданного графа: 
1. найти все вершины графа, достижимые из данной;  
*/

using System;
using System.IO;
using System.Collections.Generic;

class Graph
{
    private int[,] adjacencyMatrix;
    private int numVertices;

    public Graph(int[,] adjacencyMatrix)
    {
        this.adjacencyMatrix = adjacencyMatrix;
        this.numVertices = adjacencyMatrix.GetLength(0);
    }

    public List<int> ReachableVertices(int startVertex) // возвращает список вершин, достижимых из заданной
    {
        List<int> visited = new List<int>();
        ReachableDFS(startVertex, visited);
        return visited;
    }


    //Пояснение. ДФС проходит путь до конца, и только  потом возвращается. БФС сначала проходит соседей, а потом идет на след уровень

    //Если рассматривать вершину 0, то он добавляет сначала 1, потом 3. Потом возвращается к единице, но там тоже все просмотрено,
    //поэтому возвращается к вершине ноль. у вершины 0 есть еще одна вершина которая подходит, это 2. После двойки рекурсия завершается
    //Короче она когда до конца доходит идет назад к просмотренным вершинам и смотри их еще раз на наличие других вершин 
    private void ReachableDFS(int vertex, List<int> visited) //реккурсивный поиск в глубину
    {
        for (int i = 0; i < numVertices; i++)
        {
            if (adjacencyMatrix[vertex, i] == 1 && !visited.Contains(i)) //Contains возв TRue или FALse
            {
                visited.Add(i);
                ReachableDFS(i, visited);
            }
        }
    }

    public void Show()
    {
        for (int i = 0; i < numVertices; i++)
        {
            for (int j = 0; j < numVertices; j++)
            {
                Console.Write("{0,4}", adjacencyMatrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");
        int numVertices = int.Parse(lines[0]);
        int[,] adjacencyMatrix = new int[numVertices, numVertices];

        for (int i = 0; i < numVertices; i++)
        {
            string[] row = lines[i + 1].Split(' ');
            for (int j = 0; j < numVertices; j++)
            {
                adjacencyMatrix[i, j] = int.Parse(row[j]);
            }
        }

        Graph graph = new Graph(adjacencyMatrix);

                
        graph.Show();
        Console.WriteLine();

        for (int i = 0; i < numVertices; i++)
        {
            List<int> reachableVertices = graph.ReachableVertices(i);
            reachableVertices.Remove(i); // Удаляем саму стартовую вершину из списка достижимых вершин
            if (reachableVertices.Count > 0)
            {
                Console.WriteLine($"Для вершины {i} достижимы следующие вершины: {string.Join(", ", reachableVertices)}");
            }
            else
            {
                Console.WriteLine($"Для вершины {i} нет достижимых вершин");
            }
        }
    }
}
