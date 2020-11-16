using System;
using System.Linq;
using System.Collections.Generic;
namespace ProductWarehouse {

    /// <summary>
    /// Основной класс, отражающий общую работу программы.
    /// </summary>
    class Program {

        /// <summary>
        /// Вспомогательный метод, использующийся для ожидания нажатия пользователем клавиши [Backspace].
        /// </summary>
        public static void WaitingForBackspace() {
            ConsoleKeyInfo key;
            // Нажатие клавиши до тех пор, пока не будет введен [Backspace].
            do {
                key = Console.ReadKey(true);
                Console.Write("\r \r");
            } while (key.Key != ConsoleKey.Backspace);
        }

        /// <summary>
        /// Вспомогательный метод, использующийся для ожидания нажатия пользователем клавиши [Space].
        /// </summary>
        public static void WaitingForSpace() {
            ConsoleKeyInfo key;
            // Нажатие клавиши до тех пор, пока не будет введен [Space].
            do {
                key = Console.ReadKey(true);
                Console.Write("\r \r");
            } while (key.Key != ConsoleKey.Spacebar);
        }

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// <summary>
        /// Вспомогательный метод, реализующий отображение сообщений
        /// под конец работы приложения.
        /// </summary>
        private static void Exit(bool inFileOrNot) {
            Console.Clear();
            Console.WriteLine($" Благодарим вас за использование{System.Environment.NewLine} программного обеспечения" +
                $" по мониторингу состояния продуктовых складов!");
            if (inFileOrNot) {
               // Program.WriteInFile(); !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }

            // Цикл для вывода отсчета до выхода из программы.
            for (int i = 5; i > 0; --i) {
                Console.Write($" {i} секунд до завершения работы приложения...");
                System.Threading.Thread.Sleep(1000);
                Console.Write("\r");
            }
            System.Console.Clear();
            // Завершение программы.
            return;
        }

        static void WorkingWithConsole() {
            (string name, uint capacity, double cost) parameters = Warehouse.GetParams();
            Warehouse warehouse = new Warehouse(parameters.name, parameters.capacity, parameters.cost);
            do {
                Console.Clear();
                Console.WriteLine($"Вы находитесь в меню выбора опций для работы со складом - для выбора интересующей {Environment.NewLine}" +
                    $"вас опции выберите ее с помощью стрелочек навигации на клавиатуре, {Environment.NewLine}" +
                    $"и для подтверждения выбора нажмите [Space]. Если вы хотите закончить работать {Environment.NewLine}" +
                    $"со складом - нажмите [Backspace]:{Environment.NewLine}");
                Console.WriteLine($"На данный момент на складе {warehouse.Name} (макс. вместимость {warehouse.Capacity}) имеется {warehouse.GetContainersCount} контейнеров, {Environment.NewLine}" +
                    $"причем стоимость хранения каждого обходится примерно в {Math.Round(warehouse.CostPerContainer, 2)} единиц стоимости -");
                sbyte option = Menu.GetOption(Menu.DrawMenuOrOptions("MenuOptions", 11).Length, 11);
                switch (option){
                    //case 0: warehouse.AddContainer; break;
                    //case 1: warehouse.RemoveContainer; break;
                    default: return;
                }
            } while (true);
        }


        /// <summary>
        /// Основной метод, с которого начинается работа программы.
        /// </summary>
        static void Main() {
            Console.Clear();
            Console.WriteLine($"Добро пожаловать в экспериментальное приложение по управлению мониторингу содержимого продуктовых складов!{Environment.NewLine}{Environment.NewLine}" +
                $"В данный момент вам предлагается с помощью стрелок навигации клавиатуры и клавиши [Space] выбрать{Environment.NewLine}" +
                $"предпочтительный способ ввода/вывода информации: с помощью консоли приложения или через прочтение трех файлов{Environment.NewLine}" +
                $"заданного типа. В случае, если вы хотите выйти из приложения - нажмите клавишу [Backspace]:");
            sbyte inputType = Menu.GetOption(Menu.DrawMenuOrOptions("InputOptions", 7).Length, 7);
            bool inFileOrNot;
            switch(inputType) {
                case 0: inFileOrNot = false; break;
                case 1: inFileOrNot = true; break;
                default: Program.Exit(false); return ;
            }
            Console.Clear();
            switch (inFileOrNot) {
                case false: Program.WorkingWithConsole(); break;
                //case true: Program.WorkingWithFiles(); break;
            }
            Program.Exit(inFileOrNot);
            return;
        }
    }
}

