//является ли заданное число четным?

using System;

namespace Total
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");
            int a = int.Parse(Console.ReadLine());
            string b = (a % 2 == 0) ? "Yes" : "No";
            Console.WriteLine(b);

        }
    }
}
