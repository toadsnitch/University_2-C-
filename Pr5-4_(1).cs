//Разработать рекурсивный метод, не возвращающий значений:
/*
1.Разработать рекурсивный метод, который по заданному натуральному числу N (N>=1000) выведет на
экран все натуральные числа, не превышающие N, в порядке возрастания. Например, для N=8, на
экран выводится 1 2 3 4 5 6 7 8. 
*/

using System;

namespace ConsoleApp2
{
    internal class Program
    {

        static void F_Rec(int i, int n)
        {
            if (i <= n)
            {
                Console.Write(i + " ");
                F_Rec(i + 1, n);
            }
           

        }

        static void Main()
        {
            Console.Write("(N >= 1000) n = ");
            int n = int.Parse(Console.ReadLine());
            int i = 1;
            F_Rec(i, n);
            
        }
    }
}
