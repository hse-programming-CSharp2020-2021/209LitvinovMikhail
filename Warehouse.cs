using System;
using System.Collections.Generic;
using System.Text;

namespace ProductWarehouse {

    /// <summary>
    /// Основной класс, отражающий работу с единственным "складом" - экземпляром класса.
    /// </summary>
    class Warehouse {

        //----------------------------------------------------------------------------------
        // Поля и свойства класса:

        public string Name { get; }

        /// <summary>
        /// Максимальная вместимость склада (определяется как максимальное допустимое количество контейнеров).
        /// </summary>
        public uint Capacity { get; }

        /// <summary>
        /// Стоимость содержания одного контейнера на складе.
        /// </summary>
        public double CostPerContainer { get; }

        /// <summary>
        /// Список всех контейнеров, содержащихся на складе.
        /// </summary>
        private List<Container> containers;

        public int GetContainersCount { get { return this.containers.Count; } }

        /// <summary>
        /// Вспомогательное свойство, предоставляющее итоговую массу всех
        /// контейнеров на складе.
        /// </summary>
        public ushort CountContainersMass {
            get {
                ushort massSum = 0;
                foreach (Container container in this.containers) {
                    massSum += container.CountCratesMass;
                }
                return massSum;
            }
        }


        //----------------------------------------------------------------------------------
        // Методы и утилитарные средства класса:


        /// <summary>
        /// Индексатор, упрощающий обращение к конкретному контейнеру на складе.
        /// </summary>
        /// <param name="index"> Индекс (номер - 1)  контейнера на складе. </param>
        /// <returns> Возвращает ссылку на соответствующий контейнер внутри склада. </returns>
        public Container this[int index] {
            get {
                return this.containers[index];
            }
            private set {
                this.containers[index] = value;
            }
        }

        public static (string, uint, double) GetParams() {
            Console.WriteLine($"!!! ВНИМАНИЕ: при вводе вещественных чисел могут возникать проблемы с восприятием приложением разделителей - {Environment.NewLine}" +
                    $"!!! в случае ошибки некорректного ввода вещ. числа попробуйте попытку с ',' (запятой) в качестве разделителя!{Environment.NewLine}");
            uint capacity = 0;
            double price = 0;
            Console.WriteLine($"Введите, пожалуйста, желаемое имя склада, которое будет использоваться в меню опций/при выводе: {Environment.NewLine}");
            string name = Console.ReadLine();
            Console.WriteLine($"Введите, пожалуйста, максимальную вместимость склада: {Environment.NewLine}" +
                $"(Неотрицательное ненулевое целое число)");
            bool isCorrect = true;
            do {
                Console.WriteLine(!isCorrect ? $"Введенное число невозможно преобразовать в нетрицательное целое число - {Environment.NewLine}" +
                    $"пожалуйста, повторите попытку:" : "");
                isCorrect = uint.TryParse(Console.ReadLine(), out capacity) && capacity > 0;
            } while (!isCorrect);

            Console.WriteLine($"Введите, пожалуйста, стоимость хранения одного ящика: {Environment.NewLine}" +
                $"(Неотрицательное ненулевое целое или вещественное число");
            // isCorrect уже равно true - нет необходимости явно переопределять его под true.
            do {
                Console.WriteLine(!isCorrect ? $"Введенное число невозможно преобразовать в неотрицательное целое/вещ. число - {Environment.NewLine}" +
                    $"пожалуйста, повторите попытку:" : "");
                isCorrect = double.TryParse(Console.ReadLine(), out price) && price > 0;
            } while (!isCorrect);
            return (name, capacity, price);
        }

        /// <summary>
        /// Основной (но скрытый) конструктор экземпляров типа "склад".
        /// </summary>
        private Warehouse() {
            this.Name = string.Empty;
            this.containers = new List<Container>();
        }

        /// <summary>
        /// Основной конструктор экземпляров типа "склад", вместимость и стоимость 
        /// хранения контейнера для которого задается пользователем
        /// </summary>
        /// <param name="capacity"> Вместимость склада. </param>
        /// <param name="costPerCont"> Стоимость хранения одного контейнера. </param>
        public Warehouse(string name, uint capacity, double costPerCont) : this() {
            this.Name = name;
            this.Capacity = capacity;
            this.CostPerContainer = costPerCont;
            Console.WriteLine($"Вами был успешно организован продуктовый склад \"{this.Name}\" на {this.Capacity} контейнеров, {Environment.NewLine}" +
                $"причем хранение одного контейнера будет обходиться {Environment.NewLine}" +
                $"владельцам примерно в {Math.Round(this.CostPerContainer, 2)} единиц стоимости - {Environment.NewLine}" +
                $"нажмите [Space] для продолжения...");
            Program.WaitingForSpace();
        }

       // void AddContainer 

        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------
    }
}

