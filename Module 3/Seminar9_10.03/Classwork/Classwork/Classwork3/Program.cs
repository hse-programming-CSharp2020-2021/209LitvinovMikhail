using System;
using System.IO;
namespace Classwork3
{
    class Program
    {
        private static Random Gen { get; } = new Random();

        private static string First = @"..\..\..\..\First.txt";
        private static string Second = @"..\..\..\..\Second.txt";
        private static string Third = @"..\..\..\..\Third.txt";
        private static string Fourth = @"..\..\..\..\Fourth.txt";


        static void Main(string[] args) {
            int[] numbers = new int[10];
            numbers = Array.ConvertAll<int, int>(numbers, (int a) => Program.Gen.Next(0, 1000));
            // Способ 1: FileStream
            using (FileStream fileStream = new FileStream(Program.First, FileMode.Create)) {
                foreach (int number in numbers) {
                    fileStream.Write(BitConverter.GetBytes(number));
                }
                while (fileStream.ReadByte() != -1) {
                    byte[] input = new byte[1];
                    fileStream.Read(input);
                    Console.WriteLine(BitConverter.ToInt32(input));
                }
            }
            // Способ 2: File
            File.WriteAllLines(Program.Second, Array.ConvertAll<int, string>(numbers, (int number) => number.ToString()));
            int[] inputArray = Array.ConvertAll<string, int>(File.ReadAllLines(Program.Second), int.Parse);
            foreach (int element in inputArray) { Console.WriteLine(element); }
            // Способ 3: StreamWriter
            using (StreamWriter streamWriter = new(Program.Third)) {
                foreach (int number in numbers) { streamWriter.WriteLine(number.ToString()); }
            }
            // Способ 4: BinaryWriter
            using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(Program.Fourth, FileMode.Create))) {
                foreach (int number in numbers) { binaryWriter.Write(number);}
            }

            // https://pastebin.com/a77mTb0q

        }
    }
}
