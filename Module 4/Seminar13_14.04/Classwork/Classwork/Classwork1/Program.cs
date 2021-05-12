using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace Classwork1
{
    [Serializable]
    public class Human
    {
        public string Name { get; set; }
        public Human(string name) => this.Name = name;
        public Human() { }
        public override string ToString() => $"{this.GetType().Name} {this.Name}";

    }

    [Serializable]
    public class Professor : Human
    {
        public Professor(string name) : base(name) { }
        public Professor() { }
        public override string ToString() => base.ToString();
    }

    [Serializable]
    public class Dept
    {
        public string DeptName { get; set; }
        List<Human> staff;
        public List<Human> Staff { get { return staff; } set { staff = value; } }
        public Dept() { }
        public Dept(string name, Human[] staffList)
        {
            this.DeptName = name;
            staff = new List<Human>(staffList);
        }
        public override string ToString() => $"Department {this.DeptName}: " + string.Join<Human>("; ", this.Staff);
    }
    [Serializable]
    public class University
    {
        public string UniversityName { get; set; }
        public List<Dept> Departments { get; set; }
        private static Random RndGen { get; } = new Random();
        public University() { }
        public static University GetRandomFilledUniversity()
        {
            University result = new University();
            result.Departments = new List<Dept>();
            result.UniversityName = University.GetRandomName();
            for (int i = 0; i < University.RndGen.Next(1, 6); ++i)
            {
                result.Departments.Add(new Dept(University.GetRandomName(), University.GetRandomStaff()));
            }
            return result;
        }

        public override string ToString() => this.UniversityName + Environment.NewLine + string.Join<Dept>(Environment.NewLine, this.Departments);

        private static Human[] GetRandomStaff()
        {
            Human[] result = new Human[University.RndGen.Next(3, 11)];
            for (int i = 0; i < result.Length; ++i)
            {
                switch (University.RndGen.Next(0, 2))
                {
                    case 0: result[i] = new Human(University.GetRandomName()); break;
                    case 1: result[i] = new Professor(University.GetRandomName()); break;
                    default: break;
                }
            }
            return result;
        }

        public static string GetRandomName()
        {
            string result = ((char)University.RndGen.Next('A', 'Z' + 1)).ToString();
            for (int i = 0; i < University.RndGen.Next(3, 6); ++i)
            {
                result += ((char)University.RndGen.Next('a', 'z' + 1)).ToString();
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            University univ = University.GetRandomFilledUniversity();
            Console.WriteLine(univ.ToString());
            using (StreamWriter output = new StreamWriter("MyFile.json")) {
                output.Write(JsonSerializer.Serialize<University>(univ));
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("-----------------------------");
            using (StreamReader input = new StreamReader("MyFile.json"))
            {
                University newUniv = JsonSerializer.Deserialize<University>(input.ReadToEnd());
                Console.WriteLine(newUniv);
            }


        }
    }
}
