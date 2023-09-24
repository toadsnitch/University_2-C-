using System;

namespace Total
{
    internal class Program1
    {
        class Program
        {

            public static bool IsPrime(int number)
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

            static void Main() 
            {
                bool flag = false;
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
                        if (flag == false && i < A)
                        {
                            nearestA = i;
                            flag = true;
                        }
                    }
                    else
                    {
                        if (i >= 1)
                        {
                            totalComposite += i;
                        }
                    }
                }
                Console.WriteLine("\nКоличество всех простых чисел на отрезке [a,b]: {0} \n" +
                    "Сумма всех составых чисел на отрезке [a,b]: {1} \n" +
                    "Ближайшее предшествующее простое число к числу А: {2} \n", count, totalComposite, nearestA);
                   
            }
        }
    }
}
