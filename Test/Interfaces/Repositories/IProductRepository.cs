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
        IEnumerable<Product> Get();
        Product Get(int id);
        IHttpActionResult Post(Product product);
        IHttpActionResult Put(int id, Product product);
        IHttpActionResult Delete(int id);
    }
}