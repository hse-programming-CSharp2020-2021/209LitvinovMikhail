using System;

namespace Classwork1
{
    struct Coords
    {
        public double x;
        public double y;
        public Coords(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public override string ToString() {
            return $"Coord. x = {this.x}, Coord.y = {this.y}";
        }
    }

    class Circle {

        public double Radius { get; }

        public Coords Center { get; }

        public Circle(double x, double y, double radius) {
            this.Center = new Coords(x, y);
            this.Radius = radius;
        }

        public double Square() => Math.PI * Math.Pow(this.Radius, 2);

        public double Length() => Math.PI * 2 * this.Radius;

        public override string ToString() {
            return $"Center in: ({this.Center.ToString()}), Radius = {this.Radius}, Square = {this.Square()}, Length = {this.Length()}";

        }


    }

    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine(new Circle(2, 3, 4));
        }
    }
}
