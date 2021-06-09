using System;
using System.Text.RegularExpressions;
namespace Classwork2 {
    class Program {
        static void Main(string[] args) {
            string pattern = @"#Goods[[Code\d*;?]*]";
            string firstTest = "#Goods[Code5;Code64] Code2#Goods[Code1] #Goods[Code100]";
            foreach (Match match in (new Regex(pattern)).Matches(firstTest)) {
                Console.WriteLine(match.Value);
            }
        }
    }
}
