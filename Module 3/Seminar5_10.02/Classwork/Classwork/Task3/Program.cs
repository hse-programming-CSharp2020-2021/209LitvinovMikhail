/*
Организовать очередь на посадку пассажиров в транспорт. Очередь пассажиров (класс PassengerQueue) реализовать с использованием обобщённой очереди Queue<T>. 
В программе предусмотреть два типа пассажиров: обычный пассажир (класс Passenger) и пассажир с детьми (PassengerWithChildren)
Passenger 
Поля: строковые: имя и фамилия; целочисленное возраст
Свойства 
Для чтения и записи значений полей имени (состоит не более чем из 30 только латинских символов и пробелов, начинается с заглавной буквы) и фамилии (состоит не более чем из 40 только латинских символов и пробелов и тире, начинается с заглавной буквы) 
Автореализуемое IsOld логическое, открытое только для чтения, возвращает true для пассажира старше 65 лет
Переопределённый метод ToString() возвращает строку с данными о пассажире
PassengerWithChildren наследует из класса Passenger
Поля: целочисленной количество детей;
Свойства
Для чтения и записи поля о количестве детей (не менее одного, но не более 40)
Автореализуемое IsNewBorn, логическое, открытое только для чтения, возвращает true для пассажиров с младенцами
Переопределённый метод ToString() возвращает строку с данными о пассажире
PassengerQueue
Поля: две обобщённые очереди ordinaryQueue для обычных пассажиров и priorityQueue для приоритетных. Приоритет имеют пассажиры с младенцами и пассажиры старше 65 лет
Методы:
Открытый метод AddToQueue(), определяющий автоматически очередь, в которую поставить пассажира
Открытый метод StartServingQueue(), запускающий обслуживание очереди. Если в приоритетной очереди три и меньше пассажиров, они обслуживаются первыми, если больше то через одного с обычной очередью.
В основной программе считайте данные о пассажирах и файла csv, продумайте его структуру самостоятельно, считайте, что файл достаточно велик, чтобы не помещаться в память. Распределите пассажиров по очереди, запустите обработку. Интерфейс с пользователем для просмотра пассажиров в очередях продумайте и реализуйте самостоятельно
Для решения задачи можно добавлять дополнительные члены класса
Заготовки для классов и некоторые дополнительные требования ищете на следующих слайдах
 
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace A
{
    /// <summary>
    /// Пассажир
    /// </summary>
    public class Passenger
    {
        string name;
        string lastName;
        uint age;
        public bool IsOld { private set; get; }
        public string Name
        {
            set
            { // only latin simbols and spaces
              // not longer 30 simbols 
              if (value.Length <= 30) {
                    this.name = value;
                }
            }
            get
            {
                return this.name;
            }
        }
        public string LastName
        {
            set { // only latin simbols and spaces
                  // not longer 40 simbols
                if (value.Length <= 30)
                {
                    this.lastName = value;
                }
            }
            get
            {
                return this.lastName;
            }
        }
        public uint Age
        {
            set { 
                if (value > 0) {
                    this.age = value;
                }
            }
            get { return this.age; }
        }
        public override string ToString() {
            return $"{this.Name} {this.LastName}, {this.Age} лет";
        }

        public Passenger(string name, string surname, uint age) {
            this.Name = name;
            this.LastName = surname;
            this.Age = age;
            this.IsOld = (this.Age > 65) ? true : false;
        }
    }
    /// <summary>
    /// Пассажир с детьми
    /// </summary>
    public class PassengerWithChildren : Passenger
    {
        public PassengerWithChildren(string name, string surname, uint age, uint kidsCount, bool withNewborn): base(name, surname, age) {
            this.numberOfChildren = kidsCount;
            this.IsNewBorn = withNewborn;
        }

        uint numberOfChildren;
        public bool IsNewBorn { private set; get; }
        public uint NumberOfChildren
        {
            set { // strictly more then 0
                if (value > 0) {
                    this.Age = value;
                }
            }
            get { return numberOfChildren; }
        }
        public override string ToString() {
            string result = base.ToString() + $" с детьми в количестве {this.NumberOfChildren} штук";
            if (this.IsNewBorn) {
                result += " (имеются новорожденные)";
            }
            return result;
        }
    }
    /// <summary>
    /// Очередь на посадку состоит из двух подочередей: обычной и приоритетной
    /// Пассажиры приоритетной очереди обслуживаются вне очереди
    /// </summary>
    public class PassengerQueue
    {
        // if passenger is ordinary we use ordinaryQueue
        Queue<Passenger> ordinaryQueue = new Queue<Passenger>();
        // if passenger is old or with newborns we use priorityQueue
        Queue<Passenger> priorityQueue = new Queue<Passenger>();

        public void AddToQueue(Passenger newPassenger)
        {
            if (newPassenger.IsOld || newPassenger is PassengerWithChildren && ((PassengerWithChildren)newPassenger).IsNewBorn) priorityQueue.Enqueue(newPassenger);
            else ordinaryQueue.Enqueue(newPassenger);
        }
        public void StartServingQueue() {
            int passengersInd = 1;
            if (priorityQueue.Count <= 3) {
                foreach (Passenger passenger in this.priorityQueue) {
                    Console.WriteLine($"Пассажир №{passengersInd++}: {this.priorityQueue.Dequeue().ToString()}");
                }
                foreach (Passenger passenger in this.ordinaryQueue) {
                    Console.WriteLine($"Пассажир №{passengersInd++}: {this.ordinaryQueue.Dequeue().ToString()}");
                }
            } else {
                while (this.priorityQueue.Count > 0 || this.ordinaryQueue.Count > 0) {
                    if (this.priorityQueue.Count > 0) {
                        Console.WriteLine($"Пассажир №{passengersInd++}: {this.priorityQueue.Dequeue().ToString()}");
                    }
                    if (this.ordinaryQueue.Count > 0) {
                        Console.WriteLine($"Пассажир №{passengersInd++}: {this.ordinaryQueue.Dequeue().ToString()}");
                    }
                }
            }
        }
    }

    class MainClass
    {
        public static void Main() {
            PassengerQueue queue = new PassengerQueue();
            StreamReader streamReader = new StreamReader("cvs.txt");
            while (!streamReader.EndOfStream) {
                string input = streamReader.ReadLine();
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (data.Length == 3) {
                    queue.AddToQueue(new Passenger(data[0], data[1], uint.Parse(data[2])));
                } else if (data.Length == 5) {
                    queue.AddToQueue(new PassengerWithChildren(data[0], data[1], uint.Parse(data[2]), uint.Parse(data[3]),
                        (new Random().Next(0, 2) == 0) ? true : false));
                } else {
                    throw new Exception();
                }
            }
        }
    }
}