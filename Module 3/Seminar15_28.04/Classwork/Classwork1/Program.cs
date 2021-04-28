using System;
using System.Collections;
namespace Classwork1 {

    internal class Alphabet : IEnumerable {

        public IEnumerator GetEnumerator() => new AlphabetEnumerator();

        public class AlphabetEnumerator : IEnumerator {

            public const int LetterCount = 26; 

            public int Position { get; private set; } = -1;

            public object Current => (char)('A' + this.Position);

            public bool MoveNext() => ++(this.Position) < AlphabetEnumerator.LetterCount;

            public void Reset() => this.Position = -1;

        }

    }



    class Program
    {
        static void Main(string[] args) {
            IEnumerator alphabetEnumerator = (new Alphabet()).GetEnumerator();
            while (alphabetEnumerator.MoveNext()) {
                Console.WriteLine(alphabetEnumerator.Current);
            } 
        }
    }
}


/* Определить класс Alphabet, который представляет английский алфавит
 * с начальным символом А и длиной 26.

Задать свою собственную логику перебора объектов (А, B, С, D, и т. д.).
Для этого определите класс Alphabet Enumerator, который реализует интерфейс IEnumerator.
(Класс Alphabet должен использовать не встроенный перечислитель, а Alphabet Enumerator,
который реализует IEnumerator).

Создать программу, демонстрирующую работу.
*/