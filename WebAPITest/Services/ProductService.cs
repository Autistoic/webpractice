using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Models;
using WebAPITest.Repositories;
using WebAPITest.Services.Interfaces;

namespace WebAPITest.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository productRepository;

        public ProductService(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product GetProduct(int id)
        {
            return this.productRepository.GetProductByID(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.productRepository.GetProducts();
        }

        public void InsertProduct(Product product)
        {
            this.productRepository.InsertProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            this.productRepository.UpdateProduct(product);
        }
    }
}
