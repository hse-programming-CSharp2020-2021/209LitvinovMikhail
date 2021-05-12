using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

/*
Сериализацию можно представить как процесс сохранения состояния объекта в среду хранения. 
Во время этого процесса открытые и закрытые поля объекта и имя класса, включая сборку с классом, 
преобразуются в поток байтов, который затем записывается в поток данных. После десериализации 
объекта создается точная копия исходного объекта. 
https://docs.microsoft.com/ru-ru/dotnet/standard/serialization/binary-serialization
https://docs.microsoft.com/ru-ru/dotnet/standard/serialization/basic-serialization
*/

namespace Example02
{
    [Serializable]
    public class Student {

        private static Random RndGen { get; } = new Random();
        public string Surname { get; private set; }

        public uint CourseNumber { get; private set; }

        public Student(string surname, uint courseNumber) {
            this.Surname = surname;
            this.CourseNumber = courseNumber;
        }

        public Student() {
            this.Surname = Student.GetRandomStudentName();
            this.CourseNumber = (uint)Student.RndGen.Next(1, 5);
        }

        private static string GetRandomStudentName() {
            string result = ((char)Student.RndGen.Next('A', 'Z' + 1)).ToString();
            for (int i = 0; i < Student.RndGen.Next(3, 6); ++i) {
                result += ((char)Student.RndGen.Next('a', 'z' + 1)).ToString();
            }
            return result;
        }

        public override string ToString() => $"{this.Surname}, course {this.CourseNumber}";
    }



    class Program
    {
        static void Main(string[] args) {
            Student[] students = new Student[10];
            for (int i = 0; i < students.Length; ++i) {
                students[i] = new Student();
                Console.WriteLine(students[i].ToString());
            }
            Console.WriteLine("------------------------------");
            using (FileStream output = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write)) {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(output, students);
            }
            using (FileStream input = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read)) {
                BinaryFormatter newFormatter = new BinaryFormatter();
                Student[] newStudents = newFormatter.Deserialize(input) as Student[];
                foreach (Student student in newStudents) {
                    Console.WriteLine(student.ToString());
                }
            }

        }
    }
}