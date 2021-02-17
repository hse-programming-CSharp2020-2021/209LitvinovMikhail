using System;

namespace Classwork3 {

    public interface ICalculation {
        double Perform(double input);
    }

    class Add : ICalculation {

        private double Buf { get; }

        public Add(double input) => this.Buf = input;

        public double Perform(double input) => this.Buf + input;
    }

    class Multiply : ICalculation {

        private double Buf { get; }

        public Multiply(double input) => this.Buf = input;

        public double Perform(double input) => this.Buf * input;
    }
    class Program {

        static double Calculate(double input, ICalculation first, ICalculation second) =>
            second.Perform((first.Perform(input)));

        static void Main() {
            Console.WriteLine(Calculate(1, new Add(2), new Multiply(3)));
        }
    }
}
