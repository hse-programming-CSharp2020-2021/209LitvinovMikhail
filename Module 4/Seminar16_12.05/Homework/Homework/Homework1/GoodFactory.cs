using System;

namespace Homework
{
    class GoodFactory : IEntityFactory<Good>
    {
        private static long _id = 0;

        private string _name;

        private long _shopId;

        public GoodFactory(string name, long shopId)
        {
            _name = name;
            _shopId = shopId;
        }

        public Good Instance => new Good(_id++, _name, _shopId);
    }
}
