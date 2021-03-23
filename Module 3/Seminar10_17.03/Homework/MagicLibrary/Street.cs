using System;
using System.Text;
using System.IO;

namespace MagicLibrary {

    /// <summary>
    /// Основной класс объекта типа "Улица", описанный в главной части задания. 
    /// </summary>
    public class Street {

        /// <summary>
        /// Вспомогательное перечисление, отображающее способ получения данных об улицах. 
        /// </summary>
        public enum ReadArrayMethod : int {
            RandomValues, ReadFromFile
        }

        /// <summary>
        /// Вспомогательная константа, представляющая неизменяемое название файла ввода.
        /// </summary>
        public const string inputFile = @"data.txt";

        /// <summary>
        /// Вспомогательная константа, представляющая неизменяемое название файла вывода.
        /// </summary>
        public const string outputFile = @"out.txt";

        /// <summary>
        /// Вспомогательное автореализуемое свойство, представляющее название улицы. 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Основное автореализуемое свойство - массив номеров домов, прилегающих к улице. 
        /// </summary>
        public int[] Houses { get; private set; }

        /// <summary>
        /// Вспомогательное автореализуемое свойство, предоставляющее функционал генерации случайных чисел. 
        /// </summary>
        private static Random RndGen { get; } = new Random();

        /// <summary>
        /// Вспомогательное свойство с аксессором get, показывающее, является ли улица "волшебной". 
        /// </summary>
        public bool IsMagic {
            get => (~this % 2 == 1) && !this;
        }

        /// <summary>
        /// Вспомогательное свойство с аксессором get, предоставляющее нотацию улицы аналогично входному файлу. 
        /// </summary>
        public string GetStreetNotation {
            get => $"{this.Name} " + string.Join(" ", this.Houses); 
        }

        /// <summary>
        /// Конструктор, предоставляющий возможность случайной генерации данных об улице. 
        /// </summary>
        public Street() {
            this.Name = Street.GenerateName();
            this.Houses = new int[RndGen.Next(2, 10)];
            for (int i = 0; i < ~this; ++i) {
                this.Houses[i] = RndGen.Next(1, 101);
            }
        }

        /// <summary>
        /// Основной конструктор, предоставляющий возможность считывания данных об улице по заданной строке.
        /// </summary>
        /// <param name="input"> Входная строка с информацией о улице. </param>
        public Street(string input) {
            string[] elements = input.Split(' ');
            if (elements.Length < 2) { throw new FormatException("Одна из заданных строк задана в некорректном формате."); }
            string[] houseNumbers = new string[elements.Length - 1];
            for (int i = 0; i < houseNumbers.Length; ++i) { houseNumbers[i] = elements[i + 1]; }
            this.Name = elements[0];
            this.Houses = Array.ConvertAll<string, int>(houseNumbers,
                delegate (string element) {
                    if (!int.TryParse(element, out int buf) || buf < 0) {
                        throw new FormatException("Одна из заданных строк задана в некорректном формате.");
                    }
                    return buf;
                });
        }

        /// <summary>
        /// Вспомогательный метод, позволяющий генерировать случайное название для улицы. 
        /// </summary>
        /// <returns></returns>
        private static string GenerateName() {
            StringBuilder builder = new StringBuilder(RndGen.Next(3, 11));
            builder[0] = char.ToUpper((char)RndGen.Next((int)'a', (int)'z' + 1));
            for (int i = 1; i < builder.Length; ++i) {
                builder[i] = (char)RndGen.Next((int)'a', (int)'z' + 1);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Вспомогательный перегруженный оператор, представляющий количество элементов в массиве номеров домов. 
        /// </summary>
        /// <param name="street"> Улица, для которой считается количество домов. </param>
        /// <returns> Возвращает количество домов на заданной улице. </returns>
        public static int operator ~(Street street) => street.Houses.Length;

        /// <summary>
        /// Вспомогательный перегруженный оператор, представляющий выполнение условия наличия дома с номером, содержащим 7. 
        /// </summary>
        /// <param name="street"> Улица, для которой выполняется проверка. </param>
        /// <returns> Возвращает true, если заданная улица удовлетворяет условию наличия дома с номером, содержащим 7, и false 
        /// в ином случае. </returns>
        public static bool operator !(Street street) {
            foreach (int houseNumber in street.Houses) {
                if (houseNumber.ToString().Contains(7.ToString())) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Вспомогательный метод, отображающий информацию об улице и домах на ней. 
        /// </summary>
        /// <returns> Возвращает строку с информацией об улице: ее название и список номером домов, прилегающих к ней. </returns>
        public override string ToString() => $"Улица {this.Name} имеет {~this} домов : " +
            string.Join(", ", this.Houses);

        /// <summary>
        /// Вспомогательный метод, позволяющий проверить корректность читаемого файла ввода.
        /// </summary>
        /// <param name="filePath"> Путь к файлу, подлежащему рассмотрению. </param>
        /// <param name="linesCount"> Параметр "на выход" с количеством непустых строк в файле. </param>
        /// <returns> Возвращает true, если файл полностью удовлетворяет заданным условиям, 
        /// в противном случае генерируя соответствующее сообщение об ошибке. </returns>
        public static bool ValidateFile(string filePath, out int linesCount) {
            if (!File.Exists(filePath)) { throw new FileNotFoundException("Указанного файла не существует."); }
            using (StreamReader reader = new StreamReader(filePath)) {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length == 0) { throw new FormatException("Указанный файл пуст."); }
                foreach (string line in lines) {
                    Street tryToCreateStreet = new Street(line);
                }
                linesCount = lines.Length;
                return true;
            }
        }
    }
}
