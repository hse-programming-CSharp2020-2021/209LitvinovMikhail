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
        public double Price { get; private set; } = 0;

        public override string ToString() => $"ID: {this.Id}, BuyerID: {this.BuyerId}, ShopID: {this.ShopId}, " +
            $"GoodID: {this.GoodId}, Quantity: {this.Quantity}, Price: {this.Price}";

        public Sale(long id, long buyerId, long shopId,
            long goodId) {
            this.Id = id;
            this.BuyerId = buyerId;
            this.ShopId = shopId;
            this.GoodId = goodId;
        }
        [JsonConstructor]
        public Sale(long id, long buyerId, long shopId,
            long goodId, uint quantity, double price)
            :this(id, buyerId, shopId, goodId) {
            this.Quantity = quantity;
            this.Price = price;
        }

    }
}
