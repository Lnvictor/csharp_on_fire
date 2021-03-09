using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductAPI.Entities;
using ProductAPI.Services;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("product")]

    public class ProductController: ControllerBase
    {

        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        
        [HttpGet]
        public IActionResult getProducts()
        {
            var products = _repository.GetProducts();

            var results = new List<Product>();

            foreach(var p in products)
            {
                results.Add(new Product{
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Value = p.Value
                });
            }

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult getProductById(int id)
        {
            return Ok(_repository.GetProductById(id));
        }

        [HttpPost]
        public IActionResult addProduct([FromBody] Product product){
            _repository.AddProduct(product);   
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult updateProduct(int id, [FromBody] Product product)
        {
            if (_repository.GetProductById(id) == null)
            {
                return NotFound();
            }

            _repository.UpdateProduct(
                new Product{
                    Id = id,
                    Name = product.Name,
                    Description = product.Description,
                    Value = product.Value
                }
            );

            return Ok(product);            
        }

        [HttpDelete("{id}")]
        public IActionResult deleteProduct(int id)
        {
            _repository.deleteProduct(id);
            return NotFound();
        }
    }
}