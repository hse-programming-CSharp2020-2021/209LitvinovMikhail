using System;
using System.Collections;
namespace Classwork3 {

    public class Fibbonacci { 

        public IEnumerable FirstMembers(int n) {
            if (n < 2) { throw new ArgumentException("There are at least 2 Fibbonacci numbers in the sequence"); }
            int previous = 1;
            int current = 1;
            yield return previous;
            yield return current;
            for (int i = 2; i < n; ++i) {
                int temp = previous + current;
                previous = current;
                current = temp;
                yield return current;
            }
        }
    }

    class Program { 
        static void Main()
        {

            Fibbonacci fi = new Fibbonacci();

            foreach (int numb in fi.FirstMembers(7))

                Console.Write(numb + "  ");

            Console.WriteLine();

            foreach (int numb in fi.FirstMembers(7))

                Console.Write(numb + "  ");

            Console.WriteLine();

        }

    }
}


