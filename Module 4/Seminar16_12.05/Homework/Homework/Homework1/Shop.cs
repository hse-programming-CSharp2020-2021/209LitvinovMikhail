using System;
using System.Text.Json.Serialization;

namespace Homework {

    [Serializable]
    class Shop : IEntity {
        [JsonPropertyName("Id")]
        public long Id { get; }
        [JsonPropertyName("Name")]
        public string Name { get; }

        public Shop(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
