using System;
using System.Collections.Generic;
namespace Task2 {
    class Program {
        static void Main() {
            Stack<char> brackets = new Stack<char>();
            string input = Console.ReadLine();
            try
            {
                foreach (char bracket in input)
                {
                    if (bracket == '(')
                    {
                        brackets.Push(bracket);
                    }
                    else if (bracket == ')')
                    {
                        if (brackets.Peek() == '(')
                        {
                            brackets.Pop();
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
                if (brackets.Count !=0 ) {
                    throw new Exception();
                }
            }
            catch (Exception) {
                Console.WriteLine("Введенная последовательность некорректна.");
                return;
            }
            Console.WriteLine("Введенная последовательность корректна.");
            return;
        }
    }
}
