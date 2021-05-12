using System;

namespace Classwork1 {

    class Bread
    {
        public int Weight { get; set; } 
    }

   
    class Butter
    {
        public int Weight { get; set; }

        public static Sandwich operator +(Bread bread, Butter butter) => new Sandwich { Weight = bread.Weight + butter.Weight };
    }



   
    class Sandwich {
        public int Weight { get; set; } 
    }


    class Program
    {
        static void Main(string[] args)
        {
            Bread bread = new Bread { Weight = 80 };
            Butter butter = new Butter { Weight = 20 };
            Sandwich sandwich = bread + butter;
            Console.WriteLine(sandwich.Weight); // 100
        }
    }
}



/*
 * Как известно, неотъемлемыми компонентами бутерброда являются хлеб и масло. Допустим, у нас есть следующие классы:
// хлеб
class Bread
{
public int Weight { get; set; } // масса
}



// масло
class Butter
{
public int Weight { get; set; } // масса
}



// бутерброт
class Sandwich
{
public int Weight { get; set; } // масса
}



Добавьте в один из классов оператор сложения, чтобы при объединении хлеба и масла получался бутерброд, и, тем самым, компилировался и выполнялся без ошибок следующий код:
Bread bread = new Bread { Weight = 80 } ;
Butter butter = new Butter { Weight = 20 } ;
Sandwich sandwich = bread + butter;
Console.WriteLine(sandwich.Weight); // 100
 * 
 * 
 * 
 * 
 * */