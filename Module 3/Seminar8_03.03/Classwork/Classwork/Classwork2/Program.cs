using System;
using System.Collections.Generic;
namespace Classwork2
{

    class ElectronicQueue<QueueElementType> where QueueElementType: struct {

        public Queue<QueueElementType> ObjectQueue { get; } = new Queue<QueueElementType>();

        public ElectronicQueue(QueueElementType[] people) {
            foreach (QueueElementType person in people) {
                this.ObjectQueue.Enqueue(person);
            }
        }

        public void QueueOutput() {
            foreach (QueueElementType person in ObjectQueue)
            {
                Console.WriteLine(person.ToString());
            }
            Console.WriteLine("-----------------------");
        }

        public void AddToQueue(QueueElementType personToAdd) => this.ObjectQueue.Enqueue(personToAdd);

        public void RemoveFromQueue() => this.ObjectQueue.Dequeue();
    }

    struct Person {
        public string Name { get; }
        public string Surname { get;  }
        public uint Age { get; }
        public Person(string name, string surname, uint age) {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }
        public override string ToString() => $"Name - {this.Name}, Surname - {this.Surname}, Age - {this.Age}";
    }

    class Program {

        private static Random Randomgen { get; } = new Random();

        public static string GetRandomName() {
            string result = string.Empty;
            for (int i = 0; i < Program.Randomgen.Next(4, 10); ++i) {
                result += (char)(Program.Randomgen.Next((int)'a', (int)'z' + 1));
            }
            return result;
        }

        static void Main() {
            
        }
    }
}
