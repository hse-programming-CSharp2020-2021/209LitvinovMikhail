using System;
using System.Text.Json.Serialization;

namespace Homework {

    [Serializable]
    class Good : IEntity {

        [JsonPropertyName("Id")]
        public long Id { get; }
        [JsonPropertyName("Name")]
        public string Name { get; }
        [JsonPropertyName("ShopId")]
        public long ShopId { get; }

        public Good(long id, string name, long shopId) {
            Id = id;
            Name = name;
            ShopId = shopId;
        }
    }
}
