using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Test.Interfaces.Services;
using Test.Models;

namespace Test.Services
{
    public class ProductService : IProductService
    {
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get()
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Post([FromBody] Product product)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Put(int id, [FromBody] Product product)
        {
            throw new NotImplementedException();
        }
    }
}