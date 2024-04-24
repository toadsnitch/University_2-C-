/*
 Вывести только те слова сообщения, в которых содержится заданная подстрока.
 */

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку: ");
        string line_1 = Console.ReadLine().ToLower();
        Console.WriteLine("Введите подстроку: ");
        string line_2  = Console.ReadLine().ToLower();
        char[] div = { ' ', ',', '.', ';', ':', '!', '?', '-', '\n' };
        string[] words = line_1.Split(div);
        Console.WriteLine();
        
        foreach (string word in words)
        {
            if (word.Contains(line_2))
            {
                Console.Write("{0}\t", word);
            }
        }
    }
}
