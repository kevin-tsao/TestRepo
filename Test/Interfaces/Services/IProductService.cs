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
        bool Post([FromBody] Product product);
        bool Put([FromBody] Product product);
        bool Delete(int id);
    }
}