using System;
namespace Homework {

    class ShopFactory : IEntityFactory<Shop> {
        private static long Id { get; set; } = 1;
        private string Name { get; set; }

        public ShopFactory(string name) => this.Name = name;
        public Shop Instance => new Shop(Id++, this.Name);
    }
}
