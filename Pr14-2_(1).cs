/* 
Решить задачу, разработав собственную структуру для хранения информации
Замечания:
 Во всех задачах данного раздела подразумевается, что исходная информация хранится в
текстовом файле input.txt, каждая строка которого содержит полную информацию о некотором
объекте; результирующая информация должна быть записана в файл output.txt.
 Для хранения данных внутри программы организовать массив структур.
 Сортировку данных реализовать, реализуя метод CompareTo(T) стандартного интерфейса
IComparable<in T>

На основе данных входного файла составить список студентов группы, включив
следующие данные: ФИО, год рождения, домашний адрес, какую школу окончил.
Вывести в новый файл информацию о студентах, окончивших заданную школу,
отсортировав их по году рождения.
 */


using System;
using System.IO;
namespace ConsoleApp1
{
    class Program
    {

        /* Стандартный интерфейс public interface IComparable<in T> возвращающий
        результат сравнения двух экземпляров – текущего и переданного ему в качестве параметра.
        Используется с целью упорядочивания и сортировки экземпляров пользовательских типов
        данных.
        */
        struct Student : IComparable<Student>
        {
            //Поля структуры
            public string Name;
            public string HomeAdress;
            public string SchoolName;
            public int Year;
            
            //конструктор структуры (для инициализация полей в мэйне)
            public Student(string Name, string HomeAdress, string SchoolName, int Year)
            {
                this.Name = Name;
                this.HomeAdress = HomeAdress;
                this.SchoolName = SchoolName;
                this.Year = Year;
            }
            
            //Метод сортирует по году рождения
            public int CompareTo(Student stud)
            {
                if (this.Year == stud.Year)
                    return 0;
                else
                {
                    if (this.Year < stud.Year)
                        return 1;
                    else
                        return -1;
                }
            }
        }

        static void Main()
        {
            using (StreamReader fileIn = new StreamReader("input.txt"))
            {
                int n = int.Parse(fileIn.ReadLine()); // считывание кол-во
                Student[] student = new Student[n]; // создание массива
                string schoolFilter = "School51";//школа для отбора
                int count = 0; // кол-во студентов, прошедшие сортировку


                for (int i = 0; i < n; i++)
                {
                    string[] st = fileIn.ReadLine().Split(' ');
                    student[i] = new Student(st[0], st[1], st[2], int.Parse(st[3]));
                    if (st[2] == schoolFilter)
                        count++;
                }

                Student[] sortStudent = new Student[count]; // массив для прошедших фильтр
                int k = 0;
                foreach (Student s in student)
                {
                    if (s.SchoolName == schoolFilter)
                    {
                        sortStudent[k] = s; // заполнение массива подходящими 
                        k++;
                    }
                }
                Array.Sort(sortStudent); // сортировка

                // запись в файл
                using (StreamWriter fileOut = new StreamWriter("output.txt"))
                {
                    foreach (Student c in sortStudent)
                        fileOut.WriteLine(c.Name + ' ' + c.HomeAdress + ' ' + c.SchoolName + ' ' + c.Year);
                }
            }
        }

    }
}
