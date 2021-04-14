using System;
using System.IO;
using System.Runtime.Serialization;
using System.Collections.Generic;
namespace Classwork2
{
    [DataContract]
    public class Human
    {
        [DataMember]
        public string Name { get; set; }
        public Human(string name) => this.Name = name;
        public Human() { }
        public override string ToString() => $"{this.GetType().Name} {this.Name}";

    }

    [DataContract]
    public class Professor : Human
    {
        public Professor(string name) : base(name) { }
        public Professor() { }
        public override string ToString() => base.ToString();
    }

    [DataContract]
    public class Dept
    {
        [DataMember]
        public string DeptName { get; set; }
        [DataMember]
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
    [DataContract]
    public class University
    {
        [DataMember]
        public string UniversityName { get; set; }
        [DataMember]
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
            DataContractSerializer serializer = new DataContractSerializer(typeof(University), new Type[] { typeof(Human), typeof(Professor), typeof(Dept) });
            using (FileStream output = new FileStream("file.xml", FileMode.Create, FileAccess.Write))
            {
                serializer.WriteObject(output, univ);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("-----------------------------");
            using (FileStream input = new FileStream("file.xml", FileMode.Open, FileAccess.Read))
            {
                University newUniv = serializer.ReadObject(input) as University;
                Console.WriteLine(newUniv);
            }


        }
    }
}
