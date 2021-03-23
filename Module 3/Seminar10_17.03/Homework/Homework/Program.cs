using System;
using System.IO;
// Вспомогательная библиотека, упомянутая в задании. 
using MagicLibrary;
namespace Homework {
    class Program {
        /// <summary>
        /// Индикатор типа enum, определяющий способ получения данных об улицах (из файла или с помощью рандомной генерации).
        /// </summary>
        private static Street.ReadArrayMethod ReadingMethod { get; set; }

        /// <summary>
        /// Основной массив улиц, описанный в задании. 
        /// </summary>
        private static Street[] StreetsArray { get; set; }

        /// <summary>
        /// Основная точка старта программы. 
        /// </summary>
        public static void Main() {
            // Параметр, отвечающий за количество считанных из файла строк заданного формата
            // (используется для сравнения со значением, вводимым с клавиатуры).
            int linesCount = 0;
            try {
                Street.ValidateFile(Street.inputFile, out linesCount);
                Console.WriteLine($"Заданный файл полностью удовлетворяет условиям чтения информации {Environment.NewLine}{Environment.NewLine}");
                Program.ReadingMethod = Street.ReadArrayMethod.ReadFromFile;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message + $" -{Environment.NewLine} значения будут получены случайным образом{Environment.NewLine}{Environment.NewLine}");
                Program.ReadingMethod = Street.ReadArrayMethod.RandomValues;
            }
            int N;
            bool flag = false;
            // Ввод пользовательского значения N - размера массива улиц. 
            Console.WriteLine("Введите желаемое количество строк, которое будет считано из файла (введенное значение должно быть целым и больше нуля)");
            do {
                if (flag) {
                    Console.WriteLine("Введенное значение должно быть целым и больше нуля");
                }
                flag = !int.TryParse(Console.ReadLine(), out N) || N <= 0;
            } while (flag);
            // Обработка случая linesCount(он же MAX из условия) < N.
            N = Math.Min(N, linesCount);
            Program.StreetsArray = new Street[N];
            using (StreamReader reader = new StreamReader(Street.inputFile)) {
                using (StreamWriter writer = new StreamWriter(Street.outputFile)) {
                    // Вспомогательный адаптер записи в файл для второго задания. 
                    using (StreamWriter writerToTask2 = new StreamWriter(new FileStream(@"..\..\..\..\SecondTask\bin\Debug\net5.0\" + Street.outputFile, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                        for (int i = 0; i < N; ++i)
                        {
                            Program.StreetsArray[i] = (Program.ReadingMethod == Street.ReadArrayMethod.ReadFromFile) ?
                                new Street(reader.ReadLine()) :
                                new Street();
                            Console.WriteLine(Program.StreetsArray[i].ToString());
                            writer.WriteLine(Program.StreetsArray[i].GetStreetNotation);
                            // Запись в одноименный файл второго задания. 
                            writerToTask2.WriteLine(Program.StreetsArray[i].GetStreetNotation);
                        }
                }
            }
        }
    }
}
