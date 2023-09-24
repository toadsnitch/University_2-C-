//Найти количество всех делителей

using System;

namespace Total
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 2;
            Console.Write("a= ");
            int a = int.Parse(Console.ReadLine());
            
            for(int i = 2; i <= a / 2 + 1; i++) {
                if (a % i == 0) count++;
            }

            Console.WriteLine(count * 2);



        }
    }
}
