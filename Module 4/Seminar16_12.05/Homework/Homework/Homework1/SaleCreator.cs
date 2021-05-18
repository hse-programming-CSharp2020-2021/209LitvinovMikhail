using System;


namespace Homework {
    class SaleCreator : IEntityCreator<Sale> {
        private static long Id { get; set; } = 1;
        private long BuyerId { get; }
        private long ShopId { get; }
        private long GoodId { get; }
        private uint Quantity { get; set; } = 0;
        private uint Price { get; set; } = 0;

        public SaleCreator(long buyerId, long shopId,
            long goodId) {
            this.BuyerId = buyerId;
            this.ShopId = shopId;
            this.GoodId = goodId;
        }

        public SaleCreator(long id, long buyerId, long shopId,
            long goodId, uint quantity, uint price)
            : this(buyerId, shopId, goodId) {
            this.Quantity = quantity;
            this.Price = price;
        }

        public Sale Instance => new Sale(SaleCreator.Id++, this.BuyerId, this.ShopId,
            this.GoodId, this.Quantity, this.Price);
    }
}
