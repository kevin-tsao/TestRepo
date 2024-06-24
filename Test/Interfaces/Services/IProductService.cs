using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Test.Models;

namespace Test.Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<Product> Get();
        Product Get(int id);
        IHttpActionResult Post([FromBody] Product product);
        IHttpActionResult Put(int id, [FromBody] Product product);
        IHttpActionResult Delete(int id);
    }
}