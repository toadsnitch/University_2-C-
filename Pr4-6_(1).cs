//Найти количество всех делителей

using System;

namespace Total
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 2;
            Console.Write("n= ");
            int n = int.Parse(Console.ReadLine());

            Console.Write(1 + " ");
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) //если i делитель n
                {
                    if (i * i == n) //и i нет парного делителя
                    {
                        count += 1;
                        Console.Write("{0} ", i);
                    }
                    else
                    {
                        count += 2;
                        Console.Write("{0} {1} ", i, n / i);
                    }
                }
            }
            Console.Write(n);
            Console.WriteLine("\n" + count);
        }
    }
}
