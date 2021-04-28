using System;
using System.Collections.Generic;
using System.Collections;

namespace Classwork2 {

    public class RandomCollection : IEnumerable<int> {

        public int[] Numbers { get; private set; }

        public int Count { get => this.Numbers.Length; }

        public IEnumerator<int> GetEnumerator() => new RandomEnumerator(this.Numbers);

        IEnumerator IEnumerable.GetEnumerator() => new RandomEnumerator(this.Numbers);

        public RandomCollection(int n) {
            this.Numbers = new int[n];
            Random rndGen = new Random();
            for (int i = 0; i < this.Count; ++i) {
                this.Numbers[i] = rndGen.Next();
            }
        }

        private class RandomEnumerator : IEnumerator<int> {



            public int[] Data { get; private set; }

            public RandomEnumerator(int[] data) => this.Data = data;

            public int CurrentPosition { get; private set; } = -1;

            public int Current { get => this.Data[this.CurrentPosition]; }

            public bool MoveNext() => ++(this.CurrentPosition) < this.Data.Length;

            public void Reset() => this.CurrentPosition = -1;

            public void Dispose() => this.Reset();

            object IEnumerator.Current { get => this.Data[this.CurrentPosition]; }

        }


    }



    class Program {
        static void Main(string[] args) {
            RandomCollection rcollection = new RandomCollection(5);
            foreach (int element in rcollection) { Console.WriteLine(element); }
        }
    }
}


/* Есть класс RandomCollection, реализующий свою коллекцию из n случайных целых чисел
 * (числа будут разные при каждом обходе). Класс RandomCollection реализует интерфейс IEnumerable<int>. 
 * Нам надо предоставить возможность обходить элементы коллекции через foreach. Для того, чтобы это было возможно, 
 * необходимо определить закрытый класс RandomEnumerator, реализующий доступ к отдельным элементам коллекции 
 * (реализует интерфейс IEnumerator<int>).

Создать программу, демонстрирующую работу.

*/