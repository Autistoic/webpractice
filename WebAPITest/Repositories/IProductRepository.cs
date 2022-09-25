using System;
using System.Collections.Generic;
using WebAPITest.Models;

namespace WebAPITest.Repositories
{
    public interface IProduct
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int productID);
        void InsertProduct(Product product);
        void DeleteProduct(int productID);
        void UpdateProduct(Product product);
        void Save();
    }
}
