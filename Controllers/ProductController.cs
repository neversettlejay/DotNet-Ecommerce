using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ecommerce.Models;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _dbContext;

        public ProductController(ProductDbContext dbContext)
        {
            //created an instance
            _dbContext = dbContext;
        }

[HttpGet("GetByPrice/{minPrice}/{maxPrice}")]
public ActionResult<IEnumerable<Product>> GetByPriceRange(decimal minPrice, decimal maxPrice)
{
    var products = _dbContext.Products
        .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
        .ToList();

    return Ok(products);
}



        [HttpPost("AddProducts")]
        public IActionResult AddProducts([FromBody] List<Product> products)
        {
            foreach (var product in products)
            {
                if (_dbContext.Products.Any(p => p.Name == product.Name))
                {
                    return Conflict($"Product with name '{product.Name}' already exists.");
                }

                _dbContext.Products.Add(product);
            }

            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
