using System;
namespace Homework {

    class ShopCreator : IEntityCreator<Shop> {
        private static long Id { get; set; } = 1;
        private string Name { get; }
        private string City { get;  set; } = string.Empty;
        private string District { get;  set; } = string.Empty;
        private string Country { get;  set; } = string.Empty;
        private string PhoneNumber { get; set; } = string.Empty;
        public ShopCreator(string name) => this.Name = name;
        public ShopCreator(string name, string city, string district, string country, string phoneNumber)
            :this(name) {
            this.City = city;
            this.District = district;
            this.Country = country;
            this.PhoneNumber = phoneNumber;
        }
        public Shop Instance => new Shop(ShopCreator.Id++, this.Name, this.City, this.District, this.Country, this.PhoneNumber);
    }
}
