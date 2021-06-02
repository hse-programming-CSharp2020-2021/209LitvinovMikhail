using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Classwork1.Models {
    public class Product {
        public int ID { get; private set; }
        [Required]
        public string Name { get; private set; }
        [Required]
        public decimal Price { get; private set; }

        public Product(int id, string name, decimal price) {
            this.ID = id;
            this.Name = name;
            this.Price = price;
        }

        public void ChangeName(string newName) => this.Name = newName;
        public void ChangePrice(decimal newPrice) => this.Price = newPrice;
    }
}
