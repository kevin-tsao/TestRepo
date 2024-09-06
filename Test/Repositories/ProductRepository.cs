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
            _connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Product>("SELECT * FROM dbo.Products");
            }
        }

        public Product GetProduct(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<Product>("SELECT * FROM Products WHERE ProductID = @id", new { id });
            }
        }

        public int AddProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Execute("INSERT INTO Products (ProductName, UnitPrice, UnitsInStock) VALUES (@ProductName, @UnitPrice, @UnitsInStock)", product);
            }
             
        }
        public int UpdateProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Execute("UPDATE Products SET ProductName = @ProductName, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock WHERE ProductID = @ProductID", product);
            }
        }
        public int DeleteProduct(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "DELETE FROM Products WHERE ProductID = @id";
                sql += " DELETE FROM [Order Details] WHERE ProductID = @id";
                var sqltx = connection.BeginTransaction();
                var i = 0;
                try
                {
                    i = connection.Execute(sql, new { id }, sqltx);
                    sqltx.Commit();
                }
                catch (Exception ex)
                {
                    sqltx.Rollback();
                }
                return i;
            }
        }
    }
}