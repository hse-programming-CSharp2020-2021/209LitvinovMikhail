using System;
namespace Homework {
    class GoodCreator : IEntityCreator<Good> {
        private static long Id { get; set; } = 1;
        private string Name { get; set; }
        private long ShopId { get; set; }
        private string Category { get;  set; } = string.Empty;
        private string Description { get; set; } = string.Empty;
        public GoodCreator(string name, long shopId) {
            Name = name;
            ShopId = shopId;
        }
        public GoodCreator(string name, long shopId, string category, string description) :this(name, shopId) {
            this.Category = category;
            this.Description = description;
        }
        public Good Instance => new Good(GoodCreator.Id++, this.Name, this.ShopId, this.Category, this.Description);
    }
}
