using System;
using System.Text;
using System.IO;

namespace MagicLibrary {
    public class Street {

        public string Name { get; private set; }

        public int[] Houses { get; private set; }

        private static Random RndGen { get; } = new Random();

        public Street() {
            this.Name = Street.GenerateName();
            this.Houses = new int[RndGen.Next(2, 10)];
            for (int i = 0; i < ~this; ++i) {
                this.Houses[i] = RndGen.Next(1, 101);
            }
        }

        public Street (string input) {
            string[] elements = input.Split(' ');
            if (elements.Length < 2) { throw new FormatException("Одна из заданных строк задана в некорректном формате."); }
            string[] houseNumbers = null;
            elements.CopyTo(houseNumbers, 1);
            this.Name = elements[0];
            this.Houses = Array.ConvertAll<string, int>(houseNumbers,
                delegate (string element) {
                    if (!int.TryParse(element, out int buf) || buf < 0) {
                        throw new FormatException("Одна из заданных строк задана в некорректном формате.");
                    }
                    return buf;
                });
        }

        private static string GenerateName() {
            StringBuilder builder = new StringBuilder(RndGen.Next(3, 11));
            builder[0] = char.ToUpper((char)RndGen.Next((int)'a', (int)'z' + 1));
            for (int i = 1; i < builder.Length; ++i) {
                builder[i] = (char)RndGen.Next((int)'a', (int)'z' + 1);
            }
            return builder.ToString();
        }

        public static int operator ~(Street street) => street.Houses.Length;

        public static bool operator !(Street street) {
            foreach (int houseNumber in street.Houses) {
                if (houseNumber.ToString().Contains(7.ToString())) {
                    return true;
                }
            }
            return false;
        }

        public override string ToString() => $"Street {this.Name} has {~this} houses :" +
            string.Join(", ", this.Houses);

        public static bool ValidateFile(string filePath, out int linesCount) {
            using (StreamReader reader = new StreamReader(filePath)) {
                if (!File.Exists(filePath)) { throw new FileNotFoundException("Указанного файла не существует."); }
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
