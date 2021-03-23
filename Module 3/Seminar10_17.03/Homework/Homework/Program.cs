using System;
using System.IO;
using MagicLibrary;
namespace Homework
{
    class Program
    {

        private static Street.ReadArrayMethod ReadingMethod { get; set; }

        private static Street[] StreetsArray { get; set; }

        public static void Main() {
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
            do {
                if (flag) {
                    Console.WriteLine("Введенное значение должно быть целым и больше нуля");
                }
                flag = !int.TryParse(Console.ReadLine(), out N) || N <= 0;
            } while (flag);
            N = Math.Min(N, linesCount);
            Program.StreetsArray = new Street[N];
            using (StreamReader reader = new StreamReader(Street.inputFile)) {
                using (StreamWriter writer = new StreamWriter(Street.outputFile)) {
                    for (int i = 0; i < N; ++i) {
                        Program.StreetsArray[i] = (Program.ReadingMethod == Street.ReadArrayMethod.ReadFromFile) ?
                            new Street(reader.ReadLine()) :
                            new Street();
                        Console.WriteLine(Program.StreetsArray[i].ToString());
                        writer.WriteLine(Program.StreetsArray[i].GetStreetNotation);
                    }
                }
            }
        }
    }
}
