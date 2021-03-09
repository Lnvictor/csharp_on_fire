using System.Collections.Generic;
using ProductAPI.Entities;

namespace ProductAPI.Services
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();

        public Product GetProductById(int ProductId);

        public void AddProduct(Product product);

        public void UpdateProduct(Product product);

        public void deleteProduct(int id);

        bool Save();
    }
}

