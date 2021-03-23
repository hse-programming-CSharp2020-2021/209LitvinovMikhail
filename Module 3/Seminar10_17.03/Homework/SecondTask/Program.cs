using System;
using System.IO;
// Вспомогательная библиотека, упомянутая в задании. 
using MagicLibrary;
namespace SecondTask {
    class Program { 

        /// <summary>
        /// Основной массив улиц, описанный в задании. 
        /// </summary>
        private static Street[] StreetsArray { get; set; }

        /// <summary>
        /// Основная точка старта программы. 
        /// </summary>
        static void Main() {
            int linesCount = 0;
            try
            {
                Street.ValidateFile(Street.outputFile, out linesCount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Program.StreetsArray = new Street[linesCount];
            using (StreamReader reader = new StreamReader(Street.outputFile)) {
                for (int i = 0; i < linesCount; ++i) {
                    Program.StreetsArray[i] = new Street(reader.ReadLine());
                    // Проверка условия "волшебности" конкретной улицы. 
                    if (Program.StreetsArray[i].IsMagic) {
                        Console.WriteLine("Волшебная " + Program.StreetsArray[i].ToString());
                    }
                }
            }
        }

    }
}
