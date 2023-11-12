/*
В ступенчатом массиве элементы которого – целые числа, произвести следующие
действия:
1. Вставить новую строку после строки, в которой находится первый встреченный
минимальный элемент.

1 2 3 4 5 -2     вставляем после этой строки потому что она первая*
-2

1 2 3 4 5 -2     
0 0 0 0 0 0
-2

*/

using System;
using System.Linq;

namespace ConsoleApp2
{
    internal class Program
    {
        static int[][] Input(out int rows, out int min_index, out int min_length)
        {
            int min_val = int.MaxValue;
            min_length = 0;                                            
            Console.Write("Number of rows = ");
            rows = int.Parse(Console.ReadLine());
            min_index = rows;
            int[][] Array = new int[rows + 1][];
            for (int i = 0; i < rows; i++)
            {
                Console.Write("Enter the number of items in line {0}: ", i);
                int cols = int.Parse(Console.ReadLine());
                Array[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("a[{0}][{1}]= ", i, j);
                    Array[i][j] = int.Parse(Console.ReadLine());
                }
                if (Array[i].Min() < min_val)
                {
                    min_val = Array[i].Min();
                    min_index = i;
                    min_length = Array[i].Length;
                }
            }
            return Array;
        }

        static void Add(int[][] Array, ref int min_index, ref int min_length, ref int rows)
        {
            for (int i = rows; i > min_index; i--)
            {
                Array[i] = Array[i - 1];
            }
            Array[min_index + 1] = new int[min_length];  
        }

        static void Print(int[][] Array)
        {
            Console.WriteLine();
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = 0; j < Array[i].Length; j++)
                {
                    Console.Write("{0} ", Array[i][j]);
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {
            int rows, min_index, min_length;
            int[][] Array = Input(out rows, out min_index, out min_length);
            Add(Array, ref min_index, ref min_length, ref rows);
            Print(Array);
            
        }
    }
}
