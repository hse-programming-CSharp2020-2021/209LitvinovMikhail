using System;

namespace Homework {
    class Good : IEntity {
        public long Id { get; }

        public string Name { get; }

        public long ShopId { get; }

        public Good(long id, string name, long shopId) {
            Id = id;
            Name = name;
            ShopId = shopId;
        }
    }
}
