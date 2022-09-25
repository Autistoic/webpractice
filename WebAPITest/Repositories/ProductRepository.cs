﻿using Microsoft.Extensions.Configuration;
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
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);

                SqlCommand command = new SqlCommand("DELETE FROM Product WHERE id = @ID", sqlConnection);
                command.Parameters.AddWithValue("@id", productID);
                command.ExecuteNonQuery();
            }
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
            List<Product> products = new List<Product>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);
                SqlCommand command = new SqlCommand("SELECT id, name, description FROM Product", sqlConnection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Name = reader["name"].ToString(),
                            Description = reader["description"].ToString()
                        });
                    }
                }
                CloseConnection(sqlConnection);
            }

            return products;
        }

        public void InsertProduct(Product product)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);

                SqlCommand command = new SqlCommand("INSERT INTO Product (name, description) VALUES (@name, @description)", sqlConnection);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@description", product.Description);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                OpenConnection(sqlConnection);

                SqlCommand command = new SqlCommand("UPDATE Product SET name = @name, description = @description WHERE id = @ID", sqlConnection);
                command.Parameters.AddWithValue("@id", product.ID);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@description", product.Description);
                command.ExecuteNonQuery();
            }
        }
    }
}
