using System;
using System.IO;
namespace Classwork2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\..\MyTest.txt";
            using (FileStream fileStream = new FileStream(path, FileMode.Open)) {
                    int input;
                    while ((input = fileStream.ReadByte()) != -1) {
                    Console.Write((input >= '0' && input <= '9') ? $"Found char-num :{(char)input}{Environment.NewLine}" : string.Empty);
                }
                
            }
        }
    }
}
