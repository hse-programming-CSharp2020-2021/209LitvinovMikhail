using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Classwork2
{
    [Serializable]
    public class Student
    {

        private static Random RndGen { get; } = new Random();
        public string Surname { get; private set; }

        public uint CourseNumber { get; private set; }

        public Student(string surname, uint courseNumber)
        {
            this.Surname = surname;
            this.CourseNumber = courseNumber;
        }

        public Student()
        {
            this.Surname = Student.GetRandomStudentName();
            this.CourseNumber = (uint)Student.RndGen.Next(1, 5);
        }

        private static string GetRandomStudentName()
        {
            string result = ((char)Student.RndGen.Next('A', 'Z' + 1)).ToString();
            for (int i = 0; i < Student.RndGen.Next(3, 6); ++i)
            {
                result += ((char)Student.RndGen.Next('a', 'z' + 1)).ToString();
            }
            return result;
        }

        public override string ToString() => $"{this.Surname}, course {this.CourseNumber}";
    }

    [Serializable]
    public class Group {
        public string GroupName { get; private set; }
        public Student[] Students { get; private set; }
        private static Random RndGen { get; set; } = new Random();
        public Group() {
            this.GroupName = Group.GetRandomGroupName();
            this.Students = new Student[Group.RndGen.Next(3, 11)];
            for(int i = 0; i < this.Students.Length; ++i) {
                this.Students[i] = new Student();
            }
        }
        private static string GetRandomGroupName()
        {
            string result = ((char)Group.RndGen.Next('A', 'Z' + 1)).ToString();
            for (int i = 0; i < Group.RndGen.Next(3, 6); ++i)
            {
                result += ((char)Group.RndGen.Next('a', 'z' + 1)).ToString();
            }
            return result;
        }

        public override string ToString() => this.GroupName + Environment.NewLine + string.Join<Student>(Environment.NewLine, this.Students);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Group group1 = new Group();
            Console.WriteLine(group1.ToString());
            Console.WriteLine("-----------------------------");
            Group group2 = new Group();
            Console.WriteLine(group2.ToString());
            using (FileStream output = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(output, group1);
                formatter.Serialize(output, group2);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("-----------------------------");
            using (FileStream input = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter newFormatter = new BinaryFormatter();
                Group newGroup1 = newFormatter.Deserialize(input) as Group;
                Console.WriteLine(newGroup1.ToString());
                Group newGroup2 = newFormatter.Deserialize(input) as Group;
                Console.WriteLine(newGroup2.ToString());
                
            }
        }
    }
}
