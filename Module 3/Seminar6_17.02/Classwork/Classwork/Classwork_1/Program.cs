using System;

namespace Classwork_1 {

    public interface ISquare {
        double Square();
    }

    public interface IVolume {
        double Volume();
    }

    abstract class Figure {
        public int A { get; private set; }
    }

    class Triangle: Figure, ISquare {
        public double Square() {
            return A * A * Math.Sqrt(3) / 4;
        }
    }

    class Cube: Figure, ISquare, IVolume {
        public double Square() {
            return A * A * 6;
        }

        public double Volume() {
            return A * A * A;
        }
    }

    class Program {
        static void Main() {

            int n = 10;
            Figure[] figure = new Figure[n];
            Random rnd = new Random();


        }
    }
}
