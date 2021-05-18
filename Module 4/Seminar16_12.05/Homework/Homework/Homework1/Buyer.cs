using System;
using System.Text.Json.Serialization;

namespace Homework {

    [Serializable]
    class Buyer : IEntity {

        [JsonPropertyName("ID")]
        public long Id { get; }
        [JsonPropertyName("Name")]
        public string Name { get; }
        [JsonPropertyName("Surname")]
        public string Surname { get; }
        [JsonPropertyName("Address")]
        public string Address { get; private set; } = string.Empty;
        [JsonPropertyName("City")]
        public string City { get; private set; } = string.Empty;
        [JsonPropertyName("Distract")]
        public string District { get; private set; } = string.Empty;
        [JsonPropertyName("Country")]
        public string Country { get; private set; } = string.Empty;
        [JsonPropertyName("PostIndex")]
        public uint PostIndex { get; private set; } = 0;

        public Buyer(long id, string name, string surname) {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
        }

        [JsonConstructor]
        public Buyer(long id, string name, string surname, string address, 
            string city, string district, string country, uint postIndex) : this(id, name, surname) {
            this.Address = address;
            this.City = city;
            this.District = district;
            this.Country = country;
            this.PostIndex = postIndex;
        }

    }
}
