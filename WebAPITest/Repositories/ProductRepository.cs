using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Models;

namespace WebAPITest.Repositories
{
    public class ProductRepository : RepositoryBase, IProduct//IProductRepository, IDisposable
    {
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public void DeleteProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByID(int productID)
        {
            Product result = new Product();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);

                SqlCommand command = new SqlCommand("SELECT * FROM Product WHERE id = @ID", sqlConnection);
                command.Parameters.AddWithValue("@ID", productID);

                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    result.ID = Convert.ToInt32(reader["id"]);
                    result.Name = reader["name"].ToString();
                    result.Description = reader["description"].ToString();
                }
            }
            return result;
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
