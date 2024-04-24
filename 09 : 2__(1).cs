/*
Дан файл f, компонентами которого являются целые числа. Переписать все четные числа в файл g, нечетные - в файл h. 
 */

using System;
using System.IO;

class Program
{
    static void Main()
    {
        using(StreamReader filein = new StreamReader("text1.txt"))
        {
            using (StreamWriter fileOut1 = new StreamWriter("textOut1.txt"))
            {
                using (StreamWriter fileOut2 = new StreamWriter("textOut2.txt"))
                {
                    string line;
                    while ((line = filein.ReadLine()) != null){
                        string[] numbers = line.Split(separator: ' ');
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            int num = int.Parse(numbers[i]);
                            if (num % 2 == 0)
                            {
                                fileOut1.Write("{0} ", num);
                            }
                            else
                            {
                                fileOut2.Write("{0} ", num);
                            }
                        }
                    }
                }
            }
        }
    }
}

//C:\Users\ashirovei\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug
