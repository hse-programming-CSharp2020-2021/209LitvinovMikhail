using System;


namespace Homework {
    class BuyerCreator : IEntityCreator<Buyer> {
        private static long Id { get; set; } = 1;
        private string Name { get; }
        private string Surname { get; }
        private string Address { get;  set; } = string.Empty;
        private string City { get;  set; } = string.Empty;
        private string District { get;  set; } = string.Empty;
        private string Country { get;  set; } = string.Empty;
        private uint PostIndex { get;  set; } = 0;

        public BuyerCreator(long id, string name, string surname) {
            this.Name = name;
            this.Surname = surname;
        }

        public BuyerCreator(long id, string name, string surname, string address,
            string city, string district, string country, uint postIndex) : this(id, name, surname)
        {
            this.Address = address;
            this.City = city;
            this.District = district;
            this.Country = country;
            this.PostIndex = postIndex;
        }

        public Buyer Instance => new Buyer(BuyerCreator.Id++, this.Name, this.Surname, this.Address, this.City,
            this.District, this.Country, this.PostIndex);
    }
}
