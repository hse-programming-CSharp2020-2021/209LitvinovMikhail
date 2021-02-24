using System;

namespace Classwork2
{
    

    public struct CircleS : IComparable<CircleS>
    {
        public struct PointS {
            public double X { get; }
            public double Y { get; }
            public PointS(double x, double y) {
                this.X = x;
                this.Y = y;
            }
            public static double Distance(PointS firstPoint, PointS secondPoint) =>
                Math.Sqrt(Math.Pow(firstPoint.X - secondPoint.X, 2) + Math.Pow(firstPoint.Y - secondPoint.Y, 2)); 
        }


        public PointS Center { get; }

        public double Radius { get; }

        public CircleS(double x, double y, double radius)
        {
            this.Center = new PointS(x, y);
            this.Radius = radius;
        }

        public override string ToString()
        {
            return $"Center in: ({this.Center.ToString()}), Radius = {this.Radius}";

        }

        int IComparable<CircleS>.CompareTo(CircleS objectToCompare) {
            if (this.Radius > objectToCompare.Radius) {
                return 1;
            } else if (this.Radius < objectToCompare.Radius) {
                return -1;
            } else { return 0; }
        }

    }

    class Program
    {
        static void Main() {
            Console.WriteLine(new CircleS(3, 4, 3));
        }
    }
}
