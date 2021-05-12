using System;
using System.Collections;
using System.Collections.Generic;
namespace Classwork4 {

    public class Fibbonacci
    {

        public IEnumerable<int> FirstFibNumbers(int n)
        {
            if (n < 1) { throw new ArgumentException("There is at least 1 Fibbonacci number in the sequence"); }
            int previous = 1;
            int current = 1;
            yield return previous;
            if (n > 1) {
                yield return current;
            }
            for (int i = 2; i < n; ++i)
            {
                int temp = previous + current;
                previous = current;
                current = temp;
                yield return current;
            }
        }
    }

    public class TriangleNums {

        public IEnumerable<int> FirstTrigNumbers(int n) {
            if (n < 1) { throw new ArgumentException("There is at least one triag. number in the sequence"); }
            for (int i = 0; i < n; ++i) {
                yield return ((i) * (i + 1)) / 2;
            }
        }
    }


    class Program
    {
        static void Main(string[] args) {
            int n = (new Random()).Next(1, 6);
            IEnumerator<int> fibs = (new Fibbonacci()).FirstFibNumbers(n).GetEnumerator();
            IEnumerator<int> trigs = (new TriangleNums()).FirstTrigNumbers(n).GetEnumerator();
            while (fibs.MoveNext() && trigs.MoveNext()) {
                Console.WriteLine($"{fibs.Current} {trigs.Current} { fibs.Current + trigs.Current}");
            }
        }
    }
}
