/*
Найти максимальный элемент в каждой строке и записать данные в новый массив.
*/

using System;
using System.Linq;

namespace ConsoleApp2
{
    internal class Program
    {
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
        static void MaxNumberArray_Jagged(int[][] MyArray_Jagged, out int[] MyArray_OneDimensional)
        {
            MyArray_OneDimensional = new int[MyArray_Jagged.Length];
            for (int i = 0; i < MyArray_Jagged.Length; i++)
            {
                int max = MyArray_Jagged[i].Max();
                MyArray_OneDimensional[i] = max;   
            }
        }
        static void PrintArray_OneDimensional(int[] MyArray_OneDimensional)
        {
            Console.Write("Maximum elements: ");
            foreach (int elem in MyArray_OneDimensional)
            {
                Console.Write("{0} ", elem);
            }
            Console.WriteLine();
        }
        static void Main()
        {
            int[] MyArray_OneDimensional;
            int[][] MyArray_Jagged;
            ReadArray_Jagged(out MyArray_Jagged);
            MaxNumberArray_Jagged(MyArray_Jagged , out MyArray_OneDimensional);
            PrintArray_OneDimensional(MyArray_OneDimensional);
        }
    }
}
