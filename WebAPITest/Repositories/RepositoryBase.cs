using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Repositories
{
    public class RepositoryBase
    {
        protected string _connectionString;
        protected SqlConnection _context;
        protected SqlTransaction _transaction;

        public RepositoryBase(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        protected SqlCommand CreateCommand(string query)
        {
            return new SqlCommand(query, _context, _transaction);
        }

        protected void OpenConnection(IDbConnection dbConnection)
        {
            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Open();
            }
        }

        protected void CloseConnection(IDbConnection dbConnection)
        {
            if (dbConnection.State == ConnectionState.Open)
            {
                dbConnection.Close();
            }
        }
    }
}
