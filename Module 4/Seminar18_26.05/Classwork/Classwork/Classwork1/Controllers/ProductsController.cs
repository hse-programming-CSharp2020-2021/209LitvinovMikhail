using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Classwork1.Models;
namespace Classwork1.Controllers {
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase {

        internal static List<Product> Products { get; } = new List<Product>(new Product[] {
        new Product(1, "Notebook", 100000), new Product(2, "Car", 2000000), new Product(3, "Apple", 30  )});

        [HttpGet]
        public IEnumerable<Product> Get() => ProductsController.Products;

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            Product selectedProduct = ProductsController.Products.SingleOrDefault(p => p.ID == id);
            if (selectedProduct == default(Product)) { return this.NotFound(); }
            return Ok(selectedProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            ProductsController.Products.Remove(ProductsController.Products.SingleOrDefault(p => p.ID == id));
            return Ok();
        }

    }
}
