using System;
using System.Collections.Generic;
namespace Task1
{
    class Program {
        static void Main() {
            int number;
            do
            {
                Console.WriteLine("Введите желаемое целое число:");

            } while (!int.TryParse(Console.ReadLine(), out number));
            LinkedList<int> digits = new LinkedList<int>();
            if (number == 0) {
                digits.AddFirst(0);
            } else {
                while (number > 0) {
                    digits.AddFirst(number % 10);
                    number /= 10;
                }
            }
            while (digits.Count != 0) {
                Console.WriteLine(digits.First.Value);
                digits.RemoveFirst();
            }
            Console.WriteLine("-----------------------------");
            number = 0;
            do
            {
                Console.WriteLine("Введите желаемое целое число:");

            } while (!int.TryParse(Console.ReadLine(), out number));
            Stack<int> digits_stack = new Stack<int>();
            if (number == 0)
            {
                digits_stack.Push(0);
            }
            else
            {
                while (number > 0)
                {
                    digits_stack.Push(number % 10);
                    number /= 10;
                }
            }
            while (digits_stack.Count != 0) {
                Console.WriteLine(digits_stack.Pop());
            }
        }
    }
}
