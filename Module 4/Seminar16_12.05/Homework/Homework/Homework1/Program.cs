// !!!!!!!!!!!!!!!!!!!ПРОСЬБА ПЕРЕД ПРОВЕРКОЙ ПРОЧЕСТЬ README В Seminar16_12.05!!!!!!!!!!!!!!!!!!!
// !!!!!!!!!!!!!!!!!!!ПРОСЬБА ПЕРЕД ПРОВЕРКОЙ ПРОЧЕСТЬ README В Seminar16_12.05!!!!!!!!!!!!!!!!!!!
// !!!!!!!!!!!!!!!!!!!ПРОСЬБА ПЕРЕД ПРОВЕРКОЙ ПРОЧЕСТЬ README В Seminar16_12.05!!!!!!!!!!!!!!!!!!!

using System;
using System.Linq;
using System.Collections.Generic;
namespace Homework {
    class Program {
        static void Main(string[] args) {

            DataBase db = new DataBase("ShopDataBase");

            db.CreateTable<Good>();
            db.CreateTable<Shop>();
            db.CreateTable<Buyer>();
            db.CreateTable<Sale>();

            db.InsertInto<Shop>(new ShopCreator("Auchan", "Moscow", "Arbat street", "Russia", "6"));
            db.InsertInto<Shop>(new ShopCreator("Magnit", "St.Petersburg", "Marat's street", "Russia", "5"));

            db.InsertInto<Good>(new GoodCreator("Pepsi", 1, "Drink", "bepis"));
            db.InsertInto<Good>(new GoodCreator("3 korochki", 1, "Snack", "neploho"));
            db.InsertInto<Good>(new GoodCreator("Ohota", 2, "Drink", "ploho"));
            db.InsertInto<Good>(new GoodCreator("Lays", 3, "Snack", "normalno"));

            db.InsertInto<Buyer>(new BuyerCreator("Alexey", "Gambozhapov", "Street", "Moscow", "District", "Russia", 117100));

            db.InsertInto<Sale>(new SaleCreator(1, 1, 2, 4, 3, 200));
            db.InsertInto<Sale>(new SaleCreator(1, 2, 3, 1, 1, 30));
            // ------------------------------------------------------------------
            Console.WriteLine("Задание 3: ");

            /* 1) */
            Console.WriteLine("3.1");
            int maxLengthOfAName = (db[typeof(Buyer)] as List<Buyer>).Max<Buyer>(buyer => buyer.Name.Length);
            IEnumerable<Good> firstQuery = from Buyer buyer in (db[typeof(Buyer)] as List<Buyer>)
                                           from Sale sale in (db[typeof(Sale)] as List<Sale>)
                                           from Good good in (db[typeof(Good)] as List<Good>)
                                           where buyer.Name.Length == maxLengthOfAName && sale.BuyerId == buyer.Id && good.Id == sale.GoodId
                                           select good;
            foreach (Good good in firstQuery) { Console.WriteLine(good.ToString()); }
            Console.WriteLine();

            /* 2) */
            Console.WriteLine("3.2");
            Sale maxPriceSale = (db[typeof(Sale)] as List<Sale>).Aggregate<Sale>((first, second) =>
            ((first.Price / first.Quantity) > (second.Price / second.Quantity)) ? first : second);
            string secondQuery = (db[typeof(Good)] as List<Good>).First<Good>(good => good.Id == maxPriceSale.GoodId).Category;
            Console.WriteLine(secondQuery + Environment.NewLine);

            /* 3) */
            Console.WriteLine("3.3");
            var thirdQuery = (from Sale sale in (db[typeof(Sale)] as List<Sale>)
                              from Shop shop in (db[typeof(Shop)] as List<Shop>)
                              where sale.ShopId == shop.Id
                              group sale by shop.City).OrderBy(groupping => groupping.Sum(sale => sale.Price));
            Console.WriteLine(thirdQuery.First().Key + Environment.NewLine);

            /* 4) */
            Console.WriteLine("3.4");
            string mostPopularGoodName =
                     (from Sale sale in (db[typeof(Sale)] as List<Sale>)
                     from Good good in (db[typeof(Good)] as List<Good>)
                     where sale.GoodId == good.Id
                     group sale by good.Name into gr
                     select (gr.Key, gr.Sum(sale => sale.Quantity))).Aggregate((first, second) => 
                     (first.Item2 > second.Item2) ? first : second).Key;
            IEnumerable<string> fourthQuery = from Sale sale in (db[typeof(Sale)] as List<Sale>)
                                              from Buyer buyer in (db[typeof(Buyer)] as List<Buyer>)
                                              from Good good in (db[typeof(Good)] as List<Good>)
                                              where sale.BuyerId == buyer.Id && sale.GoodId == good.Id && good.Name == mostPopularGoodName
                                              select buyer.Surname;
            foreach (string surname in fourthQuery) { Console.WriteLine(surname); }
            Console.WriteLine();

            /* 5) */
            Console.WriteLine("3.5");
            int fifthQuery = (from Shop shop in (db[typeof(Shop)] as List<Shop>)
                             group shop by shop.Country).Min(groupElement => groupElement.Count());
            Console.WriteLine(fifthQuery + Environment.NewLine);
           
            /* 6) */
            Console.WriteLine("3.6");
            IEnumerable<Sale> sixthQuery =   from Sale sale in (db[typeof(Sale)] as List<Sale>)
                                              from Buyer buyer in (db[typeof(Buyer)] as List<Buyer>)
                                              from Shop shop in (db[typeof(Shop)] as List<Shop>)
                                              where sale.ShopId == shop.Id && sale.BuyerId == buyer.Id && buyer.City != shop.City
                                              select sale;
            foreach (Sale sale in sixthQuery) { Console.WriteLine(sale.ToString()); }
            Console.WriteLine();


            /* 7) */
            Console.WriteLine("3.7");
            double seventhQuery = (db[typeof(Sale)] as List<Sale>).Sum<Sale>(sale => sale.Price);
            Console.WriteLine($"{seventhQuery}" + Environment.NewLine);
            Console.WriteLine();



            // ------------------------------------------------------------------
            // Задание 2:
            db.WriteDatabaseData();
            Console.WriteLine("-------------------------------------------------");
            db.SerializeDataBase();
            Console.WriteLine("-------------------------------------------------");
            db.DeserializeDataBase(db.Name);
            db.WriteDatabaseData();
            Console.ReadKey();
        }
    }
}