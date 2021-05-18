using System;
using System.Text.Json.Serialization;

namespace Homework {
    [Serializable]
    class Sale : IEntity {
        [JsonPropertyName("Id")]
        public long Id { get; }
        [JsonPropertyName("BuyerId")]
        public long BuyerId { get; }
        [JsonPropertyName("ShopId")]
        public long ShopId { get; }
        [JsonPropertyName("GoodId")]
        public long GoodId { get; }
        [JsonPropertyName("Quantity")]
        public uint Quantity { get; private set; } = 0;
        [JsonPropertyName("Price")]
        public uint Price { get; private set; } = 0;

        public Sale(long id, long buyerId, long shopId,
            long goodId) {
            this.Id = id;
            this.BuyerId = buyerId;
            this.ShopId = shopId;
            this.GoodId = goodId;
        }
        [JsonConstructor]
        public Sale(long id, long buyerId, long shopId,
            long goodId, uint quantity, uint price)
            :this(id, buyerId, shopId, goodId) {
            this.Quantity = quantity;
            this.Price = price;
        }

    }
}
