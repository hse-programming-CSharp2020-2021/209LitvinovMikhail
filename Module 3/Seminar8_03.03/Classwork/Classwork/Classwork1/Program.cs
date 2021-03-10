using System;

namespace Classwork1
{

    interface IFigure {
        double AreaValue { get; }
    }

    class SquareFigure : IFigure {
        public double Side { get; }
        public double AreaValue { get => Math.PI * Math.Pow(this.Side, 2); }
        public SquareFigure(double side) => this.Side = side;
        public override string ToString() => $"Square with side {this.Side} has area-value {this.AreaValue:F2}";
    }

    class CircleFigure : IFigure {
        public double Radius { get;  }

        public double AreaValue { get => 2 * Math.PI * this.Radius; }

        public CircleFigure(double radius) => this.Radius = radius;

        public override string ToString() => $"Circle with radius {this.Radius} has area-value {this.AreaValue:F2}";
    }


    class Program {

        public static void ArrayOut<InputType>(InputType[] input, double border) where InputType : IFigure {
            for (int i = 0; i < input.Length; ++i) {
                if (input[i].AreaValue <= border ) { continue; } 
                Console.WriteLine($"Figure #{i + 1}: " + input[i].ToString());
            }
        }


        static void Main() {
            Random rndGen = new Random();
            int size = rndGen.Next(1, 11);
            IFigure[] figures = new IFigure[size];
            for (int i = 0; i < size; ++i) {
                switch (rndGen.Next(0, 2)) {
                    case 0: figures[i] = new CircleFigure(rndGen.Next(10, 30) + rndGen.NextDouble()); break;
                    default: figures[i] = new SquareFigure(rndGen.Next(10, 30) + rndGen.NextDouble()); break;
                }
            }
            ArrayOut<IFigure>(figures, 0);
            ArrayOut<IFigure>(figures, 4.34);
        }
    }
}
