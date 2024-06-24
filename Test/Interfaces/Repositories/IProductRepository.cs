using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Test.Models;

namespace Test.Interfaces.Repositoies
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        int AddProduct(Product product);
        int UpdateProduct(Product product);
        int DeleteProduct(int id);
    }
}