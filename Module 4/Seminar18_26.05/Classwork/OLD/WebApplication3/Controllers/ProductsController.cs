using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
namespace WebApplication3.Controllers {
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase {

        private static List<Product> products = new List<Product>(new[] {
                new Product() { Id = 1, Name = "Notebook", Price = 100000 },
                new Product() { Id = 2, Name = "Car", Price = 2000000 },
                new Product() { Id = 3, Name = "Apple", Price = 30 },
                });


        [HttpGet]
        public IEnumerable<Product> Get() => ProductsController.products;


    }
}
