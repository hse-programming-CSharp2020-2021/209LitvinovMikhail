using System;
namespace Homework {
    class GoodFactory : IEntityFactory<Good> {
        private static long Id { get; set; } = 0;
        private string Name { get; set; }
        private long ShopId { get; set; }

        public GoodFactory(string name, long shopId)
        {
            Name = name;
            ShopId = shopId;
        }

        public Good Instance => new Good(Id++, Name, ShopId);
    }
}
