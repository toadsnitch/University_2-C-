using System;

namespace Total
{
    internal class Program1
    {
        class Program
        {

            private static bool IsPrime(int number)
            {
                if (number <= 1)
                {
                    return false;
                }
                for (int i = 2; i <= Math.Sqrt(number); i++) //Если число а не является простым, то оно имеет делитель, который меньше или равен корню из а.
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }

            private static int NearDigit(int digit)
            {
                int i = digit;
                while (i > 1)
                {
                    if (IsPrime(digit))
                    {

                    }
                }
            }
        

            static void Main()
            {
                int totalComposite = 0, nearestA = 0;
                ushort count = 0;
                Console.Write("a = ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("b = ");
                int b = int.Parse(Console.ReadLine());
                Console.Write("A = ");
                int A = int.Parse(Console.ReadLine());

                Console.Write("\nВсе простые числа на отрезке: ");
                for (int i = b; i >= a; i--)
                {
                    if (IsPrime(i))
                    {
                        Console.Write(i + " ");
                        count++;
                    }
                    else
                    {
                        if (i >= 1)
                        {
                            totalComposite += i;
                        }
                    }


                    Console.WriteLine("\nКоличество всех простых чисел на отрезке [a,b]: {0}", count);
                    Console.WriteLine("\nБлижайшее предшествующее простое число к числу А: {0}", nearestA(NearDigit);
                    Console.WriteLine("\nСумма всех составых чисел на отрезке[a, b] {0}", totalComposite);
                }


            }
        }
    }
}
