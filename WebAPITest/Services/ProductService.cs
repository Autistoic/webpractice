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

        public Product getProduct(int id)
        {
            return this.productRepository.GetProductByID(id);
        }
    }
}
