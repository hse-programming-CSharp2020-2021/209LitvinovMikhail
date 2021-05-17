using System;
using System.Text.Json.Serialization;
using System.Runtime.Serialization.Json;

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
        public string Address { get; }
        [JsonPropertyName("City")]
        public string City { get; }
        [JsonPropertyName("Distract")]
        public string District { get; }
        [JsonPropertyName("Country")]
        public string Country { get; }
        [JsonPropertyName("PostIndex")]
        public uint PostIndex { get; }

        public Buyer(long id, string name, string surname, string address, 
            string city, string district, string country, uint postIndex) {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Address = address;
            this.City = city;
            this.District = district;
            this.Country = country;
            this.PostIndex = postIndex;
        }

    }
}
