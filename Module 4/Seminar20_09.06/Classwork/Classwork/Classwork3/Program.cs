using System;
using System.Text.RegularExpressions;
namespace Classwork3 {
    class Program {
        static void Main(string[] args) {
            string input = Console.ReadLine();
            string pattern = @"[a-h][1-8]-[a-h][1-8]";
            foreach (Match match in (new Regex(pattern, RegexOptions.IgnoreCase)).Matches(input)) {
                string caseRedacted = match.Value.Replace(match.Value[0], char.ToUpper(match.Value[0]))
                    .Replace(match.Value[3], char.ToUpper(match.Value[3]));
                Console.WriteLine(caseRedacted);
            }
        }
    }
}
