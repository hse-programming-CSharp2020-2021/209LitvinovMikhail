using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace Classework1 {
    interface IVocal {
        public void DoSound();

    }

    abstract class Animal : IVocal {

        public static int idCounter { get; protected set; } =  1;

        public int ID { get; protected set; }

        public string Name { get; protected set; }

        public bool IsTakenCare { get; protected set; }

        public override string ToString() => $"ID: {this.ID}, Name: {this.Name}, Has a caring person: {this.IsTakenCare}";

        public void DoSound() { }
    }

    class Mammal : Animal, IVocal {

        public int Paws { get; private set; }

        public Mammal(string name, bool hasACaretaker, int pawCount) {
            this.ID = (Animal.idCounter++);
            this.Name = name;
            this.IsTakenCare = hasACaretaker;
            this.Paws = pawCount;
        }

        public override string ToString() => base.ToString() + $", Number of paws: {this.Paws}";

        public new void DoSound() => Console.WriteLine("I am a mammal *bi-bi-bi*");

    }

    class Bird : Animal, IVocal
    {

        public int Speed { get; private set; }

        public Bird(string name, bool hasACaretaker, int speed)
        {
            this.ID = (Animal.idCounter++);
            this.Name = name;
            this.IsTakenCare = hasACaretaker;
            this.Speed = speed;
        }

        public override string ToString() => base.ToString() + $", Fly speed: {this.Speed}";

        public new void DoSound() => Console.WriteLine("I am a bird *pi-pi-pi*");

    }

    class Zoo : IEnumerable<Animal>, IEnumerable{
        public List<Animal> Animals { get; }

        public Zoo() => this.Animals = new List<Animal>();

        IEnumerator IEnumerable.GetEnumerator() => this.Animals.GetEnumerator();
        IEnumerator<Animal> IEnumerable<Animal>.GetEnumerator() => this.Animals.GetEnumerator();

    }

    class Program {

        private static Random rndGen = new Random();

        static void Main(string[] args) {
            Zoo zoo = new Zoo();
            int N = 5;
            for (int i = 0; i < N; ++i) {
                int animalChooser = Program.rndGen.Next(2);
                Animal animalToCreate;
                string name = Program.rndGen.Next(1000).ToString();
                bool hasACaretaker = (Program.rndGen.Next(2) == 0) ? false : true;
                animalToCreate = (animalChooser == 0) ? new Mammal(name, hasACaretaker, Program.rndGen.Next(21)) : new Bird(name, hasACaretaker, Program.rndGen.Next(101));
                Console.WriteLine(animalToCreate.ToString());
                animalToCreate.DoSound();
                zoo.Animals.Add(animalToCreate);
            }
            Console.WriteLine("-----------------------");
            foreach (Animal animal in zoo.Where(a => a is Bird && (a as Bird).IsTakenCare)) { Console.WriteLine(animal.ToString()); }
            Console.WriteLine("-----------------------");
            foreach (Animal animal in zoo.Where(a => a is Mammal && !(a as Mammal).IsTakenCare)) { Console.WriteLine(animal.ToString()); }
        }
        
    }
}




/* Задание
Интерфейс IVocal (вокал), содержащий метод:
void DoSound() – метод, который выводит сообщение. (для всех животных класса Bird анонимный метод, выводящий на экран сообщение «я птичка, пип-пип-пип», а для всех животных класса Mammal на анонимный метод, выводящий на экран сообщение «я млекопитающие, би-би-би»).
Абстрактный класс Animal (животное), реализующий интерфейс IVocal, содержащий автореализуемые свойства:
• Id – целочисленный идентификационный номер животного (должен генерироваться автоматически при создании объекта, начиная с 1 – в конструктор это значение передавать не нужно!);
• Name – имя животного (строка);
• IsTakenCare – отметка о наличии опекуна (переменная логического типа, true – есть опекун, false – иначе).
Необходимо:
• Переопределить метод ToString(), возвращающий информацию об объекте (все его свойства).
Неабстрактный класс Mammal (млекопитающее), являющийся наследником класса Animal и содержащий свойство:
• Paws – количество пар лап (от 1 до 20);
Необходимо:
• Переопределить метод ToString(), возвращающий информацию об объекте (все его свойства).
• Определить конструктор с тремя параметрами (имя животного, отметка о наличии опекуна, число пар лап).

Неабстрактный Класс Bird (птица), являющийся наследником класса Animal и содержащий свойство:
• Speed – целочисленная скорость полета, которая может меняться в течение жизни (от 1 до 100);
Необходимо:
• Переопределить метод ToString(), возвращающий информацию об объекте (все его свойства).
• Определить конструктор с тремя параметрами (имя животного, отметка о наличии опекуна, скорость полета).

Класс Zoo (зоопарк), содержащий автореализуемое свойство:
• Animals – список из объектов класса Animal (животных, живущих в зоопарке).
Необходимо:конструктор, создающий список Animal
----------------------------------------------------------------------------------------------------------------------------------------
В основной программе получить от пользователя целое число N (количество животных). Создать объект zoo класса Zoo, содержащий N животных, заполненный объектами классов Mammal и Bird случайным образом. Значение всех целочисленных свойств сгенерировать случайным образом. Значение имени сгенерировать случайным образом (для упрощения, просто числа).
Вывести на экран информацию об объектах zoo с помощью foreach и запустить событие onSound для всех объектов zoo.
С помощью средств LINQ выделить только птиц (объектов класса Bird), у которых есть опекун. Вывести на экран информацию об объектах из выделенной последовательности.
С помощью средств LINQ выделить только млекопитающих (объектов класса Mammal), у которых нет опекуна.  Вывести на экран информацию об объектах из выделенной последовательности.
*/