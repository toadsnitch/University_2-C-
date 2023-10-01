using System;
using System.Threading;

namespace ConsoleApp2
{
    internal class Program
    {

        private static int F_Rec(int x1, int x2, int n)
        {
            if (n == 2)
            {
                return x2;
            }
            else
            {
                int temp = Math.Abs(x1) - 6 * x2;
                x1 = x2;
                x2 = temp;
                return F_Rec(x1, x2, n - 1);
            }
        }

        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int x1 = -10, x2 = 2;
            if (n <= 0)
            {
                Console.WriteLine("n должно быть БОЛЬШЕ 0\n");
                while (true)
                {
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(8, 3);
                    Console.Write("(-_-)");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(8, 3);
                    Console.Write("(O_O)");
                }
            }
            else
            {
                if (n == 1) { Console.WriteLine(x1); }
                else { Console.WriteLine(F_Rec(x1, x2, n)); }
            }
        }
    }
}
