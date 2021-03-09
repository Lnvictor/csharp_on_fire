using System;
using System.Collections.Generic;
using System.Linq;
using ProductAPI.Contexts;
using ProductAPI.Entities;
using ProductAPI.Controllers;
using ProductAPI.Services;

namespace ProductAPI.Services
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProductInfoContext _context;

        public ProductRepository(ProductInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddProduct(Product product)
        {
            _context.products.Add(product);
            Save();
        }

        public void deleteProduct(int id)
        {
            _context.products.Remove(GetProductById(id));
            Save();
        }

        public Product GetProductById(int ProductId)
        {
            return _context.products.Where(c => c.Id == ProductId).FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.products.OrderBy(c => c.Name);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateProduct(Product product)
        {
            var prod = _context.products.Where(o => o.Id == product.Id).FirstOrDefault();
            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.Value = product.Value;
            Save();
        }
    }
}