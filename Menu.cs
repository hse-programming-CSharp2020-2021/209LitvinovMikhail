using System;
using System.Collections.Generic;
using System.Text;

namespace ProductWarehouse {

    /// <summary>
    /// Основной класс, отражающий работу с пользовательским меню программы.
    /// </summary>
    static class Menu {

        //----------------------------------------------------------------------------------
        // Поля и свойства класса:


        private static string[] menuOptions = {"Добавить контейнер на склад", "Удалить контейнер со склада"};
        private static string[] inputOptions = { "Использовать ручной ввод через консоль", "Использовать ввод с помощью чтения трех файлов" };
        


        //----------------------------------------------------------------------------------
        // Методы и утилитарные средства класса:


        /// <summary>
        /// Вспомогательный метод, реализующий отображение возможных опций в разных
        /// разделах меню.
        /// </summary>
        /// <param name="option"> Строка, отвечающая за то, какие опции необходимо вывести. </param>
        /// <param name="pos"> (номер_строки - 1) консоли, с которой начинается вывод. </param>
        /// <returns> Возвращает набор выведенных опций в виде массива строк. </returns>
        public static string[] DrawMenuOrOptions(string option, ushort pos = 4) {
            // Набор элементов меню, которые необходимо отрисовать.
            string[] options = null;
            switch (option) {
                case "InputOptions": options = Menu.inputOptions; break;
                case "MenuOptions": options = Menu.menuOptions; break;
                case "ContainersList": ; break;  // ДОБАВИТЬ ОБРАЩЕНИЕ К СПИСКУ !!!!!!!!!!!!!!!!!
            }
            // Отрисовка элементов меню.
            for (int i = 0; i < options.Length; ++i) {
                Console.SetCursorPosition(3, pos + i);
                Console.Write(options[i]);
            }
            return options;
        }

        /// <summary>
        /// Вспомогательный метод, отрисовывающий маркер ">>" в строчке line.
        /// </summary>
        /// <param name="line"> Строка, в которую вставляется маркер. </param>
        private static void DrawMarker(int line)
        {
            Console.SetCursorPosition(0, line);
            Console.Write(">>");
        }

        /// <summary>
        /// Вспомогательный универсальный метод, реализующий выбор той или иной опции меню/подменю.
        /// </summary>
        /// <param name="size"> Количество возможных опций. </param>
        /// <param name="start_position"> Стартовая позиция, с которой были отрисованы опции. </param>
        /// <returns> Возвращает (номер-1) операции, подлежащей выполнению. </returns>
        public static sbyte GetOption(int size, sbyte start_position = 4) {
            sbyte position = start_position;
            // Отрисовка маркера '>>' относительно стартовой позиции.
            Menu.DrawMarker(position);
            ConsoleKeyInfo key;
            // Цикл, выполняемый до нажатия корректной клавиши.
            do {
                key = Console.ReadKey(true);
                // Затирание возможной нажатой клавиши.
                Console.Write("\r  \r");
                switch (key.Key) {
                    case ConsoleKey.UpArrow:
                        position = (sbyte)((position == start_position) ? start_position + size - 1 : --position);
                        Menu.DrawMarker(position); break;
                    case ConsoleKey.DownArrow:
                        position = (sbyte)((position == start_position + (size - 1)) ? start_position : ++position);
                        Menu.DrawMarker(position); break;
                    case ConsoleKey.Backspace: return -1; // break;
                    default: Menu.DrawMarker(position); break;
                }
            } while (key.Key != ConsoleKey.Spacebar);
            // Возврат (номера - 1) выбранной опции
            return (sbyte)(position - start_position);
        }




        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------


    }
}
