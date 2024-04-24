/*
Дана последовательность целых чисел.
Замечание. Задачи из данного пункта решить двумя способами, используя одномерный массив, а затем
двумерный. Размерность массива вводится с клавиатуры. (Я сюда три массива запихнул)
1. Заменить все положительные элементы противоположными им числами
*/

using System;

namespace ConsoleApp2
{
    internal class Program
    {
        //Methods for one-dimensional array
        static void ReadArray_OneDimensional(int[] MyArray_OneDimensional)
        {
            Console.WriteLine("Enter the array elements: ");
            for (int i = 0; i < MyArray_OneDimensional.Length; i++)
            {
                Console.Write("Array[{0}] = ", i);
                MyArray_OneDimensional[i] = int.Parse(Console.ReadLine()); 
            }
        }

        static void ChangeArray_OneDimensional(int[] MyArray_OneDimensional)
        {
            for (int i = 0; i < MyArray_OneDimensional.Length; i++)
            {
                if (MyArray_OneDimensional[i] > 0) { MyArray_OneDimensional[i] = MyArray_OneDimensional[i] * (-1); }
            }
        }

        static void PrintArray_OneDimensional(int[] MyArray_OneDimensional)
        {
            foreach (int elem in MyArray_OneDimensional)
            {
                Console.Write("{0} ", elem);
            }
            Console.WriteLine();
        }

        //Methods for two-dimensional array
        static void ReadArray_TwoDimensional(int[,] MyArray_TwoDimensional)
        {
            Console.WriteLine("Enter the array elements: ");
            for (int i = 0; i < MyArray_TwoDimensional.GetLength(0); i++)
            {
                for (int j = 0; j < MyArray_TwoDimensional.GetLength(1); j++)
                {
                    Console.Write("Array[{0},{1}] = ", i, j);
                    MyArray_TwoDimensional[i,j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static void CangeArray_TwoDimensional(int[,] MyArray_TwoDimensional)
        {
            for (int i = 0; i < MyArray_TwoDimensional.GetLength(0); i++)
            {
                for (int j = 0; j < MyArray_TwoDimensional.GetLength(1); j++)
                {
                    if (MyArray_TwoDimensional[i,j] > 0) { MyArray_TwoDimensional[i,j] = MyArray_TwoDimensional[i,j] * (-1); }
                }
            }
        }

        static void PrintArray_TwoDimensional(int[,] MyArray_TwoDimensional)
        {
            for (int i = 0; i < MyArray_TwoDimensional.GetLength(0); i++)
            {
                for (int j = 0; j < MyArray_TwoDimensional.GetLength(1); j++)
                {
                    Console.Write("{0} ", MyArray_TwoDimensional[i,j]);
                }
                Console.WriteLine();
            }
        }

        //Methods for jagged array
        static void ReadArray_Jagged(out int[][] MyArray_Jagged)
        {
            Console.Write("Number of rows = ");
            int rows = int.Parse(Console.ReadLine());
            MyArray_Jagged = new int[rows][];
            for (int i = 0; i < MyArray_Jagged.Length; i++)
            {
                Console.Write("Enter the number of items in line {0}: ", i);
                int n = int.Parse(Console.ReadLine());
                MyArray_Jagged[i] = new int[n];
                for (int j = 0; j < MyArray_Jagged[i].Length; j++)
                {
                    Console.Write("a[{0}][{1}]= ", i, j);
                    MyArray_Jagged[i][j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static void ChangeArray_Jagged(int[][] MyArray_Jagged)
        {
            for (int i = 0; i < MyArray_Jagged.Length; i++)
            {
                for (int j = 0; j < MyArray_Jagged[i].Length; j++)
                {
                    if (MyArray_Jagged[i][j] > 0) { MyArray_Jagged[i][j] = MyArray_Jagged[i][j] * (-1); }
                }
            }
        }

        static void PrintArray_Jagged(int[][] MyArray_Jagged)
        {
            Console.WriteLine();
            for (int i = 0; i < MyArray_Jagged.Length; i++)
            {
                for (int j = 0; j < MyArray_Jagged[i].Length; j++)
                {
                    Console.Write("{0} ", MyArray_Jagged[i][j]);
                }
                Console.WriteLine();
            }
        }


        static void Main()
        {
            Console.Write("1 - one-dimensional array\n2 - two-dimensional array\n3 - jagged array\nSelect the rank of the array: ");
            int v = int.Parse(Console.ReadLine());
            if (v == 1)
            {
                Console.Write("n = ");
                int n = int.Parse(Console.ReadLine());
                int[] MyArray_OneDimensional = new int[n];
                
                ReadArray_OneDimensional(MyArray_OneDimensional);
                ChangeArray_OneDimensional(MyArray_OneDimensional);
                PrintArray_OneDimensional(MyArray_OneDimensional);
            }
            else if (v == 2)
            {
                Console.Write("Rows = ");
                int rows = int.Parse(Console.ReadLine());
                Console.Write("Cols = ");
                int cols = int.Parse(Console.ReadLine());
                int[,] MyArray_TwoDimensional = new int[rows, cols];

                ReadArray_TwoDimensional(MyArray_TwoDimensional);
                CangeArray_TwoDimensional(MyArray_TwoDimensional);
                PrintArray_TwoDimensional(MyArray_TwoDimensional);
            }
            else
            {
                int[][] MyArray_Jagged;

                ReadArray_Jagged(out MyArray_Jagged);
                ChangeArray_Jagged(MyArray_Jagged);
                PrintArray_Jagged(MyArray_Jagged);
            }
        }
    }
}



