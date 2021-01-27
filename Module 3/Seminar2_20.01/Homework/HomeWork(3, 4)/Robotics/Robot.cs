using System;

namespace Robotics {
    public class Robot {

        // -------------------------------
        // Поля класса: 


        /// <summary>
        /// Приватное поле класса, соответствующее фиксированной высоте рамки экрана. 
        /// </summary>
        private uint height;
        /// <summary>
        /// Приватное поле класса, соответствующее фиксированной ширине рамки экрана. 
        /// </summary>
        private uint width;

        /// <summary>
        /// Публично-приватное свойство класса, соответствующее изменяемой координате по оси X для исходного Робота.
        /// </summary>
        public uint x { get; private set; } = 1;
        /// <summary>
        /// Публично-приватное свойство класса, соответствующее изменяемой координате по оси Y для исходного Робота.
        /// </summary>
        public uint y { get; private set; } = 1;


        // -------------------------------
        // Методы класса: 

        /// <summary>
        /// Стандартный конструктор объекта типа "Робот", задающий размеры рамки консоли. 
        /// </summary>
        /// <param name="height"> Высота рамки консоли. </param>
        /// <param name="width"> Ширина рамки консоли. </param>
        public Robot (uint height, uint width) {
            this.height = height;
            this.width = width;
        }

        /// <summary>
        /// Вспомогательный метод, реализующий передвижение Робота по координате вправо. 
        /// </summary>
        public void Right() {
            Console.SetCursorPosition((int)x, (int)y);
            Console.Write("+", ConsoleColor.Gray);
            ++x;
            if (x == width + 1) {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Вспомогательный метод, реализующий передвижение Робота по координате влево.
        /// </summary>
        public void Left() {
            Console.SetCursorPosition((int)x, (int)y);
            Console.Write("+", ConsoleColor.Gray);
            --x;
            if (x == 0) {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Вспомогательный метод, реализующий передвижение Робота по координате вверх. 
        /// </summary>
        public void Forward() {
            Console.SetCursorPosition((int)x, (int)y);
            Console.Write("+", ConsoleColor.Gray);
            --y; 
            if (y == 0) {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Вспомогательный метод, реализующий передвижение Робота по координате вниз. 
        /// </summary>
        public void Backward() {
            Console.SetCursorPosition((int)x, (int)y);
            Console.Write("+", ConsoleColor.Gray);
            ++y;
            if (y == height + 1) {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Вспомогательный метод, отображающий информацию о текущей позиции Робота на плоскости. 
        /// </summary>
        /// <returns></returns>
        public string Position() {
            return String.Format("координаты x = {0}, y = {1}", x, y);
        }

        // -------------------------------
        // -------------------------------
    }
}
