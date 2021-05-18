using System;
using System.Linq;
using System.Collections.Generic;
namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase db = new DataBase("ShopDataBase");

            db.CreateTable<Good>();
            db.CreateTable<Shop>();
            db.CreateTable<Buyer>();
            db.CreateTable<Sale>();

            db.InsertInto<Shop>(new ShopCreator("Auchan"));
            db.InsertInto<Shop>(new ShopCreator("Magnit"));

            db.InsertInto<Good>(new GoodCreator("Pepsi", 1));
            db.InsertInto<Good>(new GoodCreator("3 korochki", 1));
            db.InsertInto<Good>(new GoodCreator("Ohota", 2));
            db.InsertInto<Good>(new GoodCreator("Lays", 3));

            db.InsertInto<Buyer>(new BuyerCreator("Alexey", "Tropilin"));

            db.InsertInto<Sale>(new SaleCreator(1, 1, 2));
            db.InsertInto<Sale>(new SaleCreator(1, 2, 3));
            // ------------------------------------------------------------------
            // Задание 3:

            /* 1) */
            Console.WriteLine(3.1);
            int maxLengthOfAName = (db[typeof(Buyer)] as List<Buyer>).Max<Buyer>(buyer => buyer.Name.Length);
            IEnumerable<Good> firstQuery = from Buyer buyer in (db[typeof(Buyer)] as List<Buyer>)
                                           from Sale sale in (db[typeof(Sale)] as List<Sale>)
                                           from Good good in (db[typeof(Good)] as List<Good>)
                                           where buyer.Name.Length == maxLengthOfAName && sale.BuyerId == buyer.Id && good.Id == sale.GoodId
                                           select good;
            foreach (Good good in firstQuery) { Console.WriteLine(good.ToString()); }
            Console.WriteLine();

            /* 2) */
            Console.WriteLine(3.2);
            double maxPrice = (db[typeof(Sale)] as List<Sale>).Max<Sale>(sale => sale.Price / sale.Quantity);
            Sale maxPriceSale = (db[typeof(Sale)] as List<Sale>).Aggregate<Sale>((first, second) =>
            ((first.Price / first.Quantity) > (second.Price / second.Quantity)) ? first : second);
            string secondQuery = (db[typeof(Good)] as List<Good>).First<Good>(good => good.Id == maxPriceSale.GoodId).Category;
            Console.WriteLine(secondQuery + Environment.NewLine);

            /* 3) */
            Console.WriteLine(3.3);
            var thirdQuery = (from Sale sale in (db[typeof(Sale)] as List<Sale>)
                              from Shop shop in (db[typeof(Shop)] as List<Shop>)
                              where sale.ShopId == shop.Id
                              group sale by shop.City).OrderBy(groupping => groupping.Sum(sale => sale.Price));
            Console.WriteLine(thirdQuery.First().Key + Environment.NewLine);


            /* 4) */
            Console.WriteLine(3.4);
            Console.WriteLine();

            /* 5) */
            Console.WriteLine(3.5);
            int fifthQuery = (from Shop shop in (db[typeof(Shop)] as List<Shop>)
                             group shop by shop.Country).Min(groupElement => groupElement.Count());
            Console.WriteLine(fifthQuery + Environment.NewLine);
           
            /* 6) */
            Console.WriteLine(3.6);
            IEnumerable <Sale> sixthQuery =   from Sale sale in (db[typeof(Sale)] as List<Sale>)
                                              from Buyer buyer in (db[typeof(Buyer)] as List<Buyer>)
                                              from Shop shop in (db[typeof(Shop)] as List<Shop>)
                                              where sale.ShopId == shop.Id && buyer.District != shop.District
                                              select sale;
            foreach (Sale sale in sixthQuery) { Console.WriteLine(sale.ToString()); }
            Console.WriteLine();


            /* 7) */
            Console.WriteLine(3.7);
            double seventhQuery = (db[typeof(Sale)] as List<Sale>).Sum<Sale>(sale => sale.Price);
            Console.WriteLine($"{seventhQuery}" + Environment.NewLine);
            Console.WriteLine();



            // ------------------------------------------------------------------
            // Задание 2:
            db.SerializeDataBase();
            db.DeserializeDataBase(db.Name);
            Console.ReadKey();
        }
    }
}