using System;
using System.Text.Json.Serialization;

namespace Homework {

    [Serializable]
    class Good : IEntity {

        [JsonPropertyName("Id")]
        public long Id { get; }
        [JsonPropertyName("Name")]
        public string Name { get; private set; }
        [JsonPropertyName("ShopId")]
        public long ShopId { get; private set; }
        [JsonPropertyName("Category")]
        public string Category { get; private set; } = string.Empty;
        [JsonPropertyName("Description")]
        public string Description { get; private set; } = string.Empty;
        public Good(long id, string name, long shopId) {
            Id = id;
            Name = name;
            ShopId = shopId;
        }

        [JsonConstructor]
        public Good(long id, string name, long shopId,
            string category, string description) : this(id, name, shopId) {
            this.Category = category;
            this.Description = description;
        }

    }
}
