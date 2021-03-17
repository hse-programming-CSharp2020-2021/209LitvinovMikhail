using System;
using System.IO;
namespace Classwork2
{
    class Program
    {
        private static Random generator = new Random();

        private const int Iterations =  10;

        static void Main(string[] args) {
            // --------------Задание 1-------------------------
            using (BinaryWriter writer = new BinaryWriter(new FileStream("Numbers.txt", FileMode.Create, FileAccess.ReadWrite))) {
                for(int i = 0; i < Program.Iterations; ++i) {
                    writer.Write(Program.generator.Next(1, 101));
                }
                writer.BaseStream.Seek(0, SeekOrigin.Begin);
                // -----------------Задание 2-----------------------
                // Разница между каждым новым считываемым числом и number. 
                int delta = int.MaxValue;
                int bytePos = 0;
                int number = 0;
                do { } while (int.TryParse(Console.ReadLine(), out number) || number < 1 || number > 100);
                using (BinaryReader reader = new BinaryReader(new FileStream("Numbers.txt", FileMode.Open, FileAccess.ReadWrite))) {
                    // Вывод + поиск ближайшего по значению числа.
                    int counter = 0;
                    while (reader.PeekChar() != -1) {
                        int input = reader.ReadInt32();
                        if (Math.Abs(number - input) < delta) {
                            delta = Math.Abs(number - input);
                            bytePos = counter;
                        }
                        Console.WriteLine(input + " ");
                        ++counter;
                    }
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    writer.Seek(bytePos, SeekOrigin.Begin);
                    writer.Write(number);
                    // Просто вывод. 
                    while (reader.PeekChar() != -1) {
                        Console.WriteLine(reader.ReadInt32() + " ");
                    }
                }
            }
        }
    }
}


/*В первом проекте, создать бинарный файл Numbers и записать в него средствами класса BinaryWriter 10 целых чисел, случайно 
 * выбранных из интервала [1;100].

 

Во втором проекте вывести на экран числа из файла Numbers, а затем заменять в  
этом файле на введенное пользователем целое значение число, ближайшее по значению к тому, 
которое ввел пользователь, и вновь выводить числа из файла на экран. Вводимые числа, 
не принадлежащие интервалу [1;100],  игнорировать. */