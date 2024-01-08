using System;
using System.Text;
using System.IO;
using System.Linq;

namespace мяу
{
    class Program
    {
        struct Student
        {
            public string Name;
            public string Surname;
            public string HomeAdress;
            public string SchoolName;
            public int Year;

            public Student(string Name, string Surname, string HomeAdress, string SchoolName, int Year)
            {
                this.Name = Name;
                this.Surname = Surname;
                this.HomeAdress = HomeAdress;
                this.SchoolName = SchoolName;
                this.Year = Year;
            }
        }

        static void Main()
        {
            using (StreamReader fileIn = new StreamReader("C:\\Users\\reziapovrr\\source\\repos\\ConsoleApp3\\ConsoleApp3\\bin\\Debug\\input.txt"))
            {
                int n = int.Parse(fileIn.ReadLine());
                Student[] students = new Student[n];
                string schoolFilter = "School51";

                for (int i = 0; i < n; i++)
                {
                    string[] st = fileIn.ReadLine().Split(' ');
                    students[i] = new Student(st[0], st[1], st[2], st[3], int.Parse(st[4]));
                }

                var sortStudents = students
                    .Where(s => s.SchoolName == schoolFilter)
                    .OrderBy(s => s.Year);

                using (StreamWriter fileOut = new StreamWriter("C:\\Users\\reziapovrr\\source\\repos\\ConsoleApp3\\ConsoleApp3\\bin\\Debug\\output.txt"))
                {
                    foreach (Student c in sortStudents)
                        fileOut.WriteLine(c.Name + ' ' + c.Surname + ' ' + c.HomeAdress + ' ' + c.SchoolName + ' ' + c.Year);
                }
            }
        }

    }
}
