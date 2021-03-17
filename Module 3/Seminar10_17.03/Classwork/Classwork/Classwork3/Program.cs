using System;
using System.IO;
namespace Classwork3
{

    internal struct Rectangle : IComparable<Rectangle> {
        public int Height { get; }
        public int Width { get; }

        public int Area { get => this.Height * this.Width; }

        public Rectangle (int height, int width) {
            this.Height = height;
            this.Width = width;
        }

        int IComparable<Rectangle>.CompareTo(Rectangle other) {
            if (this.Area > other.Area) {
                return 1;
            } else if (this.Area < other.Area) {
                return -11;
            } else {
                return 0;
            } 
        }
    }

    internal class Block3D : IComparable<Block3D>{ 
        public int BrickHeight { get; }
        public Rectangle Foundation { get; }

        public Block3D(int height, Rectangle foundation) {
            this.BrickHeight = height;
            this.Foundation = foundation;
        }

        public string BlockFileInfo() => $"{this.BrickHeight}:{this.Foundation.Height}:{this.Foundation.Width}";

        public override string ToString() => $"Brick has height {this.BrickHeight}, foundation is a rectangle {this.Foundation.Width}x{this.Foundation.Height} (area:{this.Foundation.Area})";

        int IComparable<Block3D>.CompareTo(Block3D other) => (this.Foundation as IComparable<Rectangle>).CompareTo(other.Foundation);
    }

    class Program
    {
        private static Random Generator { get; } = new Random();

        static void Main(string[] args) {
            Block3D[] blocks = new Block3D[10];
            for (int i = 0; i < 10; ++i) {
                blocks[i] = new Block3D(Generator.Next(1, 16), new Rectangle(Generator.Next(10, 16), Generator.Next(10, 16)));
                Console.WriteLine(blocks[i].ToString());
            }
            Console.WriteLine("----------------");
            Array.Sort(blocks);
            using (StreamWriter writer = new StreamWriter(new FileStream("Data.txt", FileMode.Create, FileAccess.ReadWrite))) {
                foreach (Block3D block in blocks)
                {
                    Console.WriteLine(block.ToString());
                    writer.WriteLine(block.BlockFileInfo());    
                }
            }
                Block3D[] newArray = Array.ConvertAll<string, Block3D>(File.ReadAllLines("Data.txt"), delegate (string str)
                {
                    string[] data = str.Split(':');
                    return new Block3D(int.Parse(data[0]), new Rectangle(int.Parse(data[1]), int.Parse(data[2])));

                });
                foreach (Block3D block in newArray) {
                    Console.WriteLine(block.ToString());
                }
            
        }
    }
}
/* Объявить структуру Rectangle, описывающую прямоугольник, заданный длинами сторон. Структура реализует интерфейс IComparable, сравнение структур происходит по величине площади прямоугольника.

Объявить класс Block3D, описывающий «кирпич», заданный основанием и высотой. Основание – объект структуры Rectangle. Класс реализует интерфейс IComparable, сравнивая кирпичи по величине площади основания.

В основной программе протестировать работу методов классов, отсортировав массив элементов типа Block3D. Записать его в файл, а затем восстановить из файла и вывести на экран.*/