using System;
using System.Linq;

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
            db.InsertInto(new GoodCreator("3 korochki", 1));
            db.InsertInto(new GoodCreator("Ohota", 2));
            db.InsertInto(new GoodCreator("Lays", 3));

            //var auchanId = (from shop in db.Table<Shop>()
            //                where shop.Name == "Auchan"
            //                select shop.Id).First();

            //var allAuchanGoods = from good in db.Table<Good>()
            //                     where good.ShopId == auchanId
            //                     select good.Name;

            //foreach (var goodName in allAuchanGoods)
            //{
            //    Console.WriteLine(goodName);
            //}

            db.SerializeDataBase();
            db.DeserializeDataBase("ShopDataBase");
            Console.ReadKey();
        }
    }
}