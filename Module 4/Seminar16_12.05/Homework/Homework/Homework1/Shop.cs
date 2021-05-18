using System;
using System.Text.Json.Serialization;

namespace Homework {

    [Serializable]
    class Shop : IEntity {
        [JsonPropertyName("Id")]
        public long Id { get; }
        [JsonPropertyName("Name")]
        public string Name { get; private set; }
        [JsonPropertyName("City")]
        public string City { get; private set; } = string.Empty;
        [JsonPropertyName("District")]
        public string District { get; private set; } = string.Empty;
        [JsonPropertyName("Country")]
        public string Country { get; private set; } = string.Empty;
        [JsonPropertyName("PhoneNumber")]
        public string PhoneNumber { get; private set; } = string.Empty;
        public Shop(long id, string name) {
            Id = id;
            Name = name;
        }

        public Shop(long id, string name, string city, string district,
            string country, string phoneNumber) : this(id, name) {
            this.City = city;
            this.District = district;
            this.Country = country;
            this.PhoneNumber = phoneNumber;
        }

    }
}
