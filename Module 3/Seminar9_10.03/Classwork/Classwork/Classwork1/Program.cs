using System;
using System.Collections.Generic;
using System.IO;

namespace Classwork1
{
    class ColorPoint
    {
        public static string[] colors = { "Red", "Green", "DarkRed", "Magenta",
            "DarkSeaGreen", "Lime", "Purple", "DarkGreen", "DarkOrange", "Black",
            "BlueViolet", "Crimson", "Gray", "Brown", "CadetBlue" };
        public double x, y;
        public string color;
        public override string ToString()
        {
            string format = "{0:F3}    {1:F3}    {2}";
            return string.Format(format, x, y, color);
        }
    }

    class Program
    {
        static Random gen = new Random();
        public static void Main()
        {
            string path = @"..\..\..\..\MyTest.txt";
            int.TryParse(Console.ReadLine(), out int N);
            List<ColorPoint> list = new List<ColorPoint>();
            ColorPoint one;
            for (int i = 0; i < N; i++)
            {
                one = new ColorPoint();
                one.x = gen.NextDouble();
                one.y = gen.NextDouble();
                int j = gen.Next(0, ColorPoint.colors.Length);
                one.color = ColorPoint.colors[j];
                list.Add(one);
            }
            string[] arrData = Array.ConvertAll(list.ToArray(),
                         (ColorPoint cp) => cp.ToString());
            string[] newInput = new string[arrData.Length];
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                foreach (string line in arrData) { byte[] output = System.Text.Encoding.Default.GetBytes(line); fileStream.Write(output); } 
                Console.WriteLine("Записаны {0} строк в текстовый файл: \n{1}", N, path);
            }

            using (FileStream fileStream1 = new FileStream(path, FileMode.Open)) {
                for (int i = 0; i < newInput.Length; ++i) {
                    byte[] input = new byte[fileStream1.Length];
                    fileStream1.Read(input, 0, input.Length);
                    newInput[i] = System.Text.Encoding.Default.GetString(input);
                    Console.WriteLine($"Input data: {newInput[i]}");
                }
            }
        }
    }
}