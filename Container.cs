using System;
using System.Collections.Generic;

namespace ProductWarehouse {

    /// <summary>
    /// Основной класс, отражающий работу с "контейнерами" - экземплярами класса.
    /// </summary>
    class Container {

        //----------------------------------------------------------------------------------
        // Поля и свойства класса:


        /// <summary>
        /// Автореализуемое свойство (доступно только для чтения), предоставляющее
        /// случайно - сгенерированное ограничение по допустимой массе контейнера.
        /// </summary>
        private ushort MassRestriction { get; }

        /// <summary>
        /// Список экземпляров типа "ящик" - содержимого контейнера.
        /// </summary>
        private List<Crate> crates;

        /// <summary>
        /// Вспомогательное свойство, предоставляющее итоговое количество ящиков внутри 
        /// </summary>
        private int CountCrates { get { return this.crates.Count; } }

        /// <summary>
        /// Вспомогательное свойство, предоставляющее итоговую массу всех
        /// ящиков внутри контейнера.
        /// </summary>
        public ushort CountCratesMass {
            get {
                ushort massSum = 0;
                foreach (Crate crate in this.crates) {
                    massSum += crate.MassInKGs;
                }
                return massSum;
            }
        }


        //----------------------------------------------------------------------------------
        // Методы и утилитарные средства класса:


        /// <summary>
        /// Индексатор, упрощающий обращение к конкретному ящику в контейнере.
        /// </summary>
        /// <param name="index"> Индекс (номер - 1)  ящика в контейнере. </param>
        /// <returns> Возвращает ссылку на соответствующий ящик внутри контейнера. </returns>
        public Crate this[int index] {
            get {
                return this.crates[index];
            }
            set {
                this.crates[index] = value;
            }
        }
        
        /// <summary>
        /// Основной конструктор, инициализирующий основные поля/свойства класса и
        /// использующийся в других конструкторах. 
        /// </summary>
        public Container() {
            this.MassRestriction = 1000;
            this.crates = new List<Crate>();
        }

        /// <summary>
        /// Вспомогательный конструктор, создающий "контейнер" по списку ящиков и ограничению
        /// суммарной массы ящиков.
        /// </summary>
        /// <param name="crateList"> Список ящиков, которые потенциально будут добавлены в контейнер. </param>
        /// <param name="restriction"> Величина, ограничивающая суммарную массу ящиков в контейнере. </param>
        public Container(ref List<Crate> crateList , ushort restriction) : this() {
            Console.Clear();
            this.MassRestriction = restriction;
            Random damageGen = new Random();
            // Просчет целостности содержимого контейнера.
            double containerIntegrity = 1.0 - damageGen.NextDouble() / 2;
            Console.WriteLine($"Конечная стоимость продукции в ящиках контейнера изменится в{Environment.NewLine}" +
                $"соответствие доли целостности контейнера в {containerIntegrity} от стартовой:");
            for (int i = 0; i < crateList.Count; ++i ) {
                this[i].PricePerKG *= containerIntegrity;
                // Заполнение "контейнера" ящиками из параметров, причем проверяется
                // соответствие ограничениям по суммарной массе ящиков в контейнере.
                if (this.CountCratesMass + this[i].MassInKGs > this.MassRestriction) {
                    Console.WriteLine($"Контейнер не был заполнен до конца, поскольку при {System.Environment.NewLine}" +
                        $"добавлении очередного ящика был превышен лимит по массе ящиков {System.Environment.NewLine}" +
                        $"внутри контейнера - нажмите [Space] для продолжения...");
                    Program.WaitingForSpace();
                    Console.Clear();
                    return;
                } else {
                    this.crates.Add(this[i]);
                    Console.WriteLine($"Ящик номер {i + 1} был успешно добавлен в контейнер");
                }
            }
            Console.WriteLine($"Контейнер был успешно заполнен до конца -{System.Environment.NewLine}" +
                        $"нажмите [Space] для продолжения...");
            Program.WaitingForSpace();
            Console.Clear();
        }

        /// <summary>
        /// Вспомогательный перегруженный метод, конвертирующий информацию о контейнере 
        /// и его содержимом в строковый тип.
        /// </summary>
        /// <returns> Возвращает строку, содержащую основную информацию о контейнере и
        /// дополнительную информацию о каждом ящике (его массу и стоимость/кг). </returns>
        public override string ToString() {
            string result = $"контейнер допускает максимальную массу в {this.MassRestriction} и содержит {this.CountCrates} ящиков: {Environment.NewLine}";
            for (int i = 0; i < this.CountCrates; ++i) {
                result += $"{i + 1}ый контейнер: {this[i].ToString()} {Environment.NewLine}";
            }
            return result;
        }


        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------
    }
}
