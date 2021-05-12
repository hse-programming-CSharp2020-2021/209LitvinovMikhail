using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
namespace Classwork1
{
    class Program {
        static void Main(string[] args) {
            int[] numbers = { 0, 1353, 242, 34, 41, -65, -623 };
            IEnumerable<int> result1_first = from number in numbers
                                      select number * number;
            IEnumerable<int> result1_second = numbers.Select(number => number * number);
            foreach (int num in result1_first) { Console.WriteLine(num); }
            foreach (int num in result1_second) { Console.WriteLine(num); }
            // ---------------------------------------------------------------------------
            IEnumerable<int> result2_first = from number in numbers
                                             where number >= 10 && number < 100
                                             select number;
            IEnumerable<int> result2_second = numbers.Where(number => number >= 10 && number < 100);
            foreach (int num in result2_first) { Console.WriteLine(num); }
            foreach (int num in result2_second) { Console.WriteLine(num); }
            // ---------------------------------------------------------------------------
            IEnumerable<int> result3_first = from number in numbers
                                             where number % 2 == 0
                                             orderby number descending
                                             select number;
            IEnumerable<int> result3_second = numbers.Where(number => number % 2 == 0).OrderByDescending(number => number);
            foreach (int num in result3_first) { Console.WriteLine(num); }
            foreach (int num in result3_second) { Console.WriteLine(num); }
            // ---------------------------------------------------------------------------
            var result4_first = from number in numbers
                                group number by number.ToString().Length into gr
                                select new { Length = gr.Key, Numbers = gr };
           // var result4_second = numbers.GroupBy<int, int>(number => number.ToString().Length);
           // foreach (var num in result4_first) { Console.WriteLine($"{num.Key} {num}"); }
           // foreach (var num in result4_second) { Console.WriteLine($"{num.Key} {num}"); }
        }
    }
}
