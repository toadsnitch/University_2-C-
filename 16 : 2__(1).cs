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

using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        struct Student // Структура для хранения информации о студентах
        {
            public string Name;
            public string Surname;
            public string Patronymic;
            public string HomeAdress;
            public int SchoolName;
            public int Year;

            /*Конструктор - это метод, который используется для инициализации нового объекта. В данном случае, 
              конструктор принимает несколько параметров (имя, фамилия, отчество, домашний адрес, номер школы и 
              год рождения) и устанавливает значения полей структуры "Student" равными переданным параметрам.*/
            public Student(string Name, string Surname, string Patronymic, string HomeAdress, int SchoolName, int Year)
            {
                this.Name = Name;
                this.Surname = Surname;
                this.Patronymic = Patronymic;
                this.HomeAdress = HomeAdress;
                this.SchoolName = SchoolName;
                this.Year = Year;
            }
        }

        static void Main()
        {
            using (StreamReader fileIn = new StreamReader("input.txt"))
            {
                int n = int.Parse(fileIn.ReadLine());
                Student[] students = new Student[n]; // Массив students типа Student для хранения информации о студентах
                int schoolFilter = 32;

                for (int i = 0; i < n; i++)
                {
                    string[] st = fileIn.ReadLine().Split(' ');
                    students[i] = new Student(st[0], st[1], st[2], st[3], int.Parse(st[4]), int.Parse(st[5])); // инициализируем Student
                }

                //Фильтруем по номеру школы и соритруем по году рождения
                var sortStudents = students
                    .Where(s => s.SchoolName == schoolFilter) /*Метод расширения Where, аналогично предложению where 
                                                              позволят проводить фильтрацию данных некоторого источника. */
                    .OrderBy(s => s.Year); /*Метод расширения OrderBy также как и предложение orderby в интегрированном
                                           запросе позволяет отсортировать данные, извлеченные из источника данных*/
                
                //Для того, чтобы сортировка данных производилась по убыванию значения некоторого ключа можно использовать метод        OrderByDescending
                using (StreamWriter fileOut = new StreamWriter("output.txt"))
                {
                    foreach (Student c in sortStudents)
                        fileOut.WriteLine(c.Name + ' ' + c.Surname + ' ' + c.Patronymic + ' ' + c.HomeAdress + ' ' + c.SchoolName + ' ' + c.Year);
                }
            }
        }
    }
}

/*
4
Аширов Егор Игоревич Ветеринарная_8 32 2004
Киряев Максим Степанович Комсомольская_5А 32 2005
Соловьев Ян Ярославович Ломоносова_21 6 2004
Кукурузный Початок Огороднович Огород_УлПроезжей_дом2 32 2003
 */
