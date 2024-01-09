/*
1. Во всех задачах данного раздела подразумевается, что исходная информация хранится в
текстовом файле input.txt, каждая строка которого содержит полную информацию о некотором
объекте; результирующая информация должна быть записана в файл output.txt.
2. Для хранения данных внутри программы организовать одномерный массив структур или любую
другую подходящую коллекцию структур. Выбор коллекции обосновать.

Задание 1. На основе данных входного файла составить список студентов группы,
включив следующие данные: ФИО, год рождения, домашний адрес, какую школу окончил.
Вывести в новый файл информацию о студентах, окончивших заданную школу,
отсортировав их по году рождения.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyProgram
{
    class Program
    {
        class People //представляет структуру данных для хранения информации о студентх
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Patronymic { get; set; }
            public int Year { get; set; }
            public string Address { get; set; }
            public int School { get; set; }
        }

        static void Main()
        {
            using (StreamReader fileIn = new StreamReader("input.txt"))
            {
                using (StreamWriter fileOut = new StreamWriter("output.txt", false))
                {
                    List<People> students = new List<People>();
                    int desiredSchool = Convert.ToInt32(fileIn.ReadLine()); //Номер школы, для которой нужно вывести студентов
                    while (!fileIn.EndOfStream)
                    {
                        string[] data = fileIn.ReadLine().Split(' '); //считываем построчно
                        //создаем новый объект People для каждого студента, заполняем его данными и добавляем в список students
                        People student = new People();
                        student.Surname = data[0];
                        student.Name = data[1];
                        student.Patronymic = data[2];
                        student.Year = int.Parse(data[3]);
                        student.Address = data[4];
                        student.School = int.Parse(data[5]);
                        students.Add(student);
                    }

                    var filteredStudents =
                        from student in students
                        //Метод расширения Where, аналогично предложению where позволят проводить фильтрацию данных некоторого источника. 
                       
                        where student.School == desiredSchool // запрос фильтрует студентов из списка students,
                                                              // оставляя только тех, кто окончил заданную школу, и затем сортирует их по году рождения.
                        
                        orderby student.Year //Метод расширения OrderBy также как и предложение orderby в интегрированном
                                             //запросе позволяет отсортировать данные, извлеченные из источника данных

                        //чтобы сортировка данных производилась по убыванию значения - OrderByDescending
                        select student;

                    foreach (var student in filteredStudents)
                    {
                        fileOut.WriteLine("{0} {1} {2} {3} {4} {5}", student.Surname, student.Name, student.Patronymic, student.Year, student.Address, student.School);
                    }
                }
            }
        }
    }
}


/*
32
Аширов Егор Игоревич 2004 Ветеринарная_8 32
Киряев Максим Степанович 2005 Комсомольская_5А 32
Соловьев Ян Ярославович 2004 Ломоносова_21 6
 */
