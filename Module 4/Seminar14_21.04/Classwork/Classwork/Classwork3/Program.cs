#pragma warning disable IDE0090
using System;

namespace Classwork3 {

    public class Matrix2 {

        public decimal[][] Data { get; private set; }

        public Matrix2() {
            this.Data = new decimal[2][];
            for (int i = 0; i < this.Data.Length; ++i) {
                this.Data[i] = new decimal[2];
                for (int j = 0; j < this.Data[i].Length; ++j) {
                    this[i, j] = 0;
                }
            }
        }

        public decimal this[int firstIndex, int secondIndex] { 
            get => this.Data[firstIndex][secondIndex];  private set => this.Data[firstIndex][secondIndex] = value;
        }

        public Matrix2(decimal element1_1, decimal element1_2, decimal element2_1, decimal element2_2) : this() {
            this[0, 0] = element1_1;
            this[0, 1] = element1_2;
            this[1, 0] = element2_1;
            this[1, 1] = element2_2;

        }
        public Matrix2(Matrix2 matrixToCopy) : this() {
            this[0, 0] = matrixToCopy[0, 0];
            this[0, 1] = matrixToCopy[0, 1];
            this[1, 0] = matrixToCopy[1, 0];
            this[1, 1] = matrixToCopy[1, 1];
        }

        public Matrix2 Transpose() {
            Matrix2 result = new Matrix2();
            result[0, 0] = this[0, 0];
            result[0, 1] = this[1, 0];
            result[1, 0] = this[0, 1];
            result[1, 1] = this[1, 1];
            return result;
        }

        public decimal Det { get => this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0]; }

        public Matrix2 Inverse() {
            Matrix2 result = new Matrix2();
            decimal det = this.Det;
            if (det == 0) { throw new NotSupportedException("Для заданной матрицы не существует обратной"); }
            result[0, 0] = this[1, 1] / det;
            result[0, 1] = (-1) * this[0, 1] / det;
            result[1, 0] = (-1) * this[1, 0] / det;
            result[1, 1] = this[0, 0] / det;
            return result;
        }

        public static Matrix2 operator +(Matrix2 first, Matrix2 second) =>
            new Matrix2(first[0, 0] + second[0, 0], first[0, 1] + second[0, 1],
                first[1, 0] + second[1, 0], first[1, 1] + second[1, 1]);

        public static Matrix2 operator -(Matrix2 first, Matrix2 second) =>
            new Matrix2(first[0, 0] - second[0, 0], first[0, 1] - second[0, 1],
                first[1, 0] - second[1, 0], first[1, 1] - second[1, 1]);

        public static Matrix2 operator *(Matrix2 first, Matrix2 second) =>
            new Matrix2(first[0, 0] * second[0, 0] + first[0, 1] * second[1, 0],
                first[0, 0] * second[0, 1] + first[0, 1] * second[1, 1],
                first[1, 0] * second[0, 0] + first[1, 1] * second[1, 0],
                first[1, 0] * second[0, 1] + first[1, 1] * second[1, 1]);

        public static Matrix2 operator *(Matrix2 matrix, decimal value) =>
            new Matrix2(matrix[0, 0] * value, matrix[0, 1] * value,
                matrix[1, 0] * value, matrix[1, 1] * value);

        public static Matrix2 operator *(decimal value, Matrix2 matrix) =>
            new Matrix2(matrix[0, 0] * value, matrix[0, 1] * value,
                matrix[1, 0] * value, matrix[1, 1] * value);

        public override string ToString() => $"{this[0, 0]}\t{this[0, 1]}" + Environment.NewLine +
            $"{this[1, 0]}\t{this[1, 1]}";
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((new Matrix2(1, 0, 0, 1) * new Matrix2(1, 2, 4, 6)).Det);
        }
    }
}
