/*
Использование базовых алгоритмов при разработке методов
1. Разработать метод, который для заданного натурального числа N возвращает значение true – если
число простое, false – если число составное. С помощью данного метода:
a) вывести на экран все простые числа на отрезке [a, b];
b) найти количество всех простых чисел на отрезке [a, b];
c) найти сумму всех составных чисел на отрезке [a, b]
d) для заданного числа А вывести на экран ближайшее предшествующее по отношению к нему
простое число.
*/

using System;
using System.Diagnostics.Eventing.Reader;

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
                bool flag = false;
                int i = digit;
                while (i > 1)
                {
                    if (IsPrime(i))
                    {
                        flag = true;
                        break;
                    }
                    i--;
                }
                
                if (flag == true) { return i; }

                else { return 0; }
            }

            static void Main()
            {
                int totalComposite = 0;
                ushort count = 0;
                Console.Write("a = ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("b = ");
                int b = int.Parse(Console.ReadLine());
                Console.Write("A = ");
                int nearestA = int.Parse(Console.ReadLine());

                Console.Write("\nВсе простые числа на отрезке: ");
                for (int i = a; i <= b; i++)
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
                }
                Console.WriteLine("\nКоличество всех простых чисел на отрезке [a,b]: {0}", count);
                Console.WriteLine("Ближайшее предшествующее простое число к числу А: {0}", NearDigit(nearestA));
                Console.WriteLine("Сумма всех составых чисел на отрезке[a, b] {0}", totalComposite + "\n");
            }
        }
    }
}
