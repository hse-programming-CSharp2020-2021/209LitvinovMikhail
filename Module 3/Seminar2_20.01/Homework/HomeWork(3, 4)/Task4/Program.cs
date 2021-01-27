using System;
using Robotics;
namespace Task4 {
    class Program {

        public delegate void Steps();

        /// <summary>
        /// Вспомогательный метод, позволяющий отрисовывать произвольный символ в определенной точки плоскости консоли.
        /// </summary>
        /// <param name="symbol"> Символ, подлежащий отображению. </param>
        /// <param name="x"> Координата по оси, соответствующей горизонтальному вектору. </param>
        /// <param name="y"> Координата по оси, соответствующей вертикальному вектору. </param>
        static void DrawSymbol(char symbol, uint x, uint y) {
            Console.SetCursorPosition((int)x, (int)y);
            Console.Write(symbol);
        }

        /// <summary>
        /// Вспомогательный метод, производящий отрисовку области консоли по заданным размерам начиная с координаты (0, 0).
        /// </summary>
        /// <param name="height"> Высота рамки. </param>
        /// <param name="width"> Ширина рамки. </param>
        static void DrawField(uint height, uint width) {
            DrawSymbol('*', 0, 0);
            for (uint i = 1; i <= height; ++i) {
                DrawSymbol('|', 0, i);
            }
            DrawSymbol('*', 0, height + 1);
            for (uint i = 1; i <= width; ++i) {
                DrawSymbol('-', i, height + 1);
            }
            DrawSymbol('*', width + 1, height + 1);
            for (uint i = height; i > 0; --i) {
                DrawSymbol('|', width + 1, i);
            }
            DrawSymbol('*', width + 1, 0);
            for (uint i = width; i > 0; --i) {
                DrawSymbol('-', i, 0);
            }
        }

        static void Main() {
            /*Robot robot = new Robot();
            Steps[] trace = { new Steps(robot.Forward), new Steps(robot.Backward), new Steps(robot.Left) };
            Console.WriteLine("Starting position: " + robot.Position());

            foreach(Steps step in trace) {
                Console.WriteLine("Method = {0}, Target = {1}", step.Method, step.Target);
                step?.Invoke();
            }

            Console.WriteLine("Finishing position: " + robot.Position());
            */
            Console.WriteLine($"Задача #4: {Environment.NewLine}");
            uint height;
            uint width;
            do
            {
                Console.Write("Введите высоту поля, по которому будет передвигаться робот(>3): ");
            } while (!uint.TryParse(Console.ReadLine(), out height) || height < 3);
            do {
                Console.Write("Введите ширину поля, по которому будет передвигаться робот(>3): ");
            } while (!uint.TryParse(Console.ReadLine(), out width) || width < 3);
            // ---------------------------------------------------------------------------
            
            Console.WriteLine($"Введите последовательность выполнения команд для робота в формате {Environment.NewLine}" +
                $"строки, состоящей из букв \'R\', \'L\', \'F\', \'B\' в любом из регистров(Right, Left, Forward, Backward соотвественно): {Environment.NewLine}");
            Console.WriteLine("P.s Некорректные символы не меняют поведения робота.");
            string input = Console.ReadLine();
            Robot robot = new Robot(height, width);
            Steps movements = null;
            Console.WriteLine($"{Environment.NewLine}Начальная позиция робота: " + robot.Position());
            foreach (char element in input) {

                switch(char.ToUpper(element)) {
                    case 'R': movements += robot.Right; break;
                    case 'L': movements += robot.Left; break;
                    case 'F': movements += robot.Forward; break;
                    case 'B': movements += robot.Backward; break;
                }
            }
            try
            {
                Console.Clear();
                Program.DrawField(height, width);
                movements?.Invoke();
            }
            catch (ArgumentOutOfRangeException) {
                DrawSymbol('*', robot.x, robot.y);
                Console.SetCursorPosition(0, (int)height + 5);
                Console.Write("Робот вышел за границы поля! Программа прекращает свою работу...");
                return;
            }
            //Console.SetCursorPosition((int)robot.y, (int)robot.x);
            //Console.Write("*", ConsoleColor.Red);
            DrawSymbol('*', robot.x, robot.y);
            Console.SetCursorPosition(0, (int)height + 5);
            Console.WriteLine("Конечная позиция робота: " + robot.Position(), ConsoleColor.Gray);
        }
    }
}
