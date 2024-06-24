using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Test.Interfaces.Repositoies;
using Test.Models;

namespace Test.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;



        public ProductRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Product>("SELECT * FROM Products");
            }
        }
    }
}