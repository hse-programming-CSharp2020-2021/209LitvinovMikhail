using System;

namespace Classwork2 {

    public interface ISequence {
        double GetElement(byte number);
    }

    public class ArithmeticProgression : ISequence {

        public int Start { get; }

        public int Delta { get; }

        public ArithmeticProgression(int start, int delta) {
            this.Start = start;
            this.Delta = delta;
        }

        public double GetElement(byte number) {
            return this.Start + number * this.Delta;
        }
    }

    public class GeometricProgression : ISequence {
        public int Start { get; }

        public int Delta { get; }

        public GeometricProgression(int start, int delta)
        {
            this.Start = start;
            this.Delta = delta;
        }

        public double GetElement(byte number)
        {
            return this.Start * Math.Pow(this.Delta , (int)number);
        }
    }



    class Program {
        
        static double Sum(ArithmeticProgression progression, int count) {
            double result = 0;
            for (byte i = 1; i <= count; ++i) {
                result+=progression.GetElement(i);
            }
            return result;
        }

        static double Sum(GeometricProgression progression, int count)
        {
            double result = 0;
            for (byte i = 1; i <= count; ++i)
            {
                result+=progression.GetElement(i);
            }
            return result;
        }

        static void Main(string[] args) {
            Console.WriteLine(Sum(new ArithmeticProgression(3, 5), 10));
            Console.WriteLine(Sum(new GeometricProgression(2, 3), 2));
        }
    }
}
