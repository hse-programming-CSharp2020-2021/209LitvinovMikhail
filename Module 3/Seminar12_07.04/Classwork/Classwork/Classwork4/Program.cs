using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
namespace Classwork4
{

    [Serializable]
    public class Human
    {
        public string Name { get; set; }
        public Human(string name) => this.Name = name;
        public Human() { }
        public override string ToString() => this.Name;

    }

    [Serializable]
    public class Professor : Human {
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
        public override string ToString() => $"{this.DeptName}: " + string.Join<Human>("; ", this.Staff); 
    }
    [Serializable]
    public class University
    {
        public string UniversityName { get; set; }
        public List<Dept> Departments { get; set; }
        private static Random RndGen { get; } = new Random();
        public University() { }
        public static University GetRandomFilledUniversity() {
            University result = new University();
            result.Departments = new List<Dept>();
            result.UniversityName = University.GetRandomName();
            for(int i = 0; i < University.RndGen.Next(1, 6); ++i) {
                result.Departments.Add(new Dept(University.GetRandomName(), University.GetRandomStaff()));
            }
            return result;
        }

        public override string ToString() => this.UniversityName + Environment.NewLine + string.Join<Dept>(Environment.NewLine, this.Departments);

        private static Human[] GetRandomStaff() {
            Human[] result = new Human[University.RndGen.Next(3, 11)];
            for (int i = 0; i < result.Length; ++i) {
                switch(University.RndGen.Next(0, 2)) {
                    case 0: result[i] = new Human(University.GetRandomName()); break;
                    case 1: result[i] = new Professor(University.GetRandomName()); break;
                    default: break;
                }
            }
            return result;
        }

        public static string GetRandomName() {
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
        static void Main(string[] args) {
            University univ = University.GetRandomFilledUniversity();
            Console.WriteLine(univ.ToString());
            using (FileStream output = new FileStream("MyFile.xml", FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(University), new Type[] { typeof(Human), typeof(Professor), typeof(Dept) });
                serializer.Serialize(output, univ);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("-----------------------------");
            using (FileStream input = new FileStream("MyFile.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer newSerializer = new XmlSerializer(typeof(University), new Type[] { typeof(Human), typeof(Professor), typeof(Dept) });
                University newUniv = newSerializer.Deserialize(input) as University;
                Console.WriteLine(newUniv);
            }


        }
    }
}

/* В программе описать классы:
Human;
Professor (наследник Human);
Department  (композиционно включает список сотрудников – объекты типа Human);
University (агрегационно включает список департаментов).
Создать университет (поля заполнить случайным образом), стерилизовать и десериализовать.

*/

/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
 
namespace Task02_xml
{
    [Serializable]
    public class Human
    {
        public string Name { get; set; }
        public Human() { }
        public Human(string name)
        {
            this.Name = name;
        }
    }
 
    [Serializable]
    public class Professor : Human
    {
        public Professor()
        {
 
        }
        public Professor(string name) : base(name) { }
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
    }
 
    [Serializable]
    public class University
    {
        public University() { }
        public string UniversityName { get; set; }
        public List<Dept> Departments { get; set; }
    }
 

    class Program
    {
        static void Main(string[] args)
        {
            University HSE = new University();
            HSE.UniversityName = "NRU HSE";
 
            Human[] deptStaff = { new Professor("Ivanov"),
                      new Professor("Petrov")
                    };
 
            Dept SE = new Dept("SE", deptStaff);
            HSE.Departments = new List<Dept>();
            HSE.Departments.Add(SE);
 
            University MSU = new University();
            MSU.UniversityName = "MSU";
 
            Human[] deptStaffM = { new Professor("Ivanov"),  new Professor("Chizov"),
                      new Professor("Petrov")
                    };
 
            Dept SEM = new Dept("SEM", deptStaffM);
            MSU.Departments = new List<Dept>();
            MSU.Departments.Add(SEM);
 
            University[] universities = new University[] { HSE, MSU};
 
            XmlSerializer binformatter = new XmlSerializer(typeof(University[]), new Type[] { typeof(Dept),
                typeof(Professor), typeof(Human) });
 
            // Сериализация
            using (Stream file = new FileStream("BinSer.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binformatter.Serialize(file, universities);
            }
 
            // Десериализация
            University[] deserial;
            using (Stream file = File.OpenRead("BinSer.dat"))
            {
                deserial = (University[])binformatter.Deserialize(file);
                Console.WriteLine("XML - " + deserial[0].UniversityName);
                Console.WriteLine("XML - " + deserial[1].UniversityName);
            }
 
            foreach (Dept d in deserial[0].Departments)
                foreach (Human h in d.Staff)
                {
                    if (h is Professor)
                        Console.WriteLine(d.DeptName + " prof.: " + h.Name);
                }
 
            foreach (Dept d in deserial[1].Departments)
                foreach (Human h in d.Staff)
                {
                    if (h is Professor)
                        Console.WriteLine(d.DeptName + " prof.: " + h.Name);
                }
 
            Console.ReadKey();
        }
    }
} */
