using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.Interfaces.Services;
using Test.Models;

namespace Test.Controllers
{
    [RoutePrefix("api/Produc")]
    public class ProductController : ApiController
    {
        public IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET api/products
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.Get();
        }

        // GET api/products/5
        [HttpGet]
        [AllowAnonymous]
        public Product Get(int id)
        {
            return _productService.Get(id);
        }

        // POST api/products
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Post([FromBody] Product product)
        {
            return Ok(_productService.Post(product));
        }

        // PUT api/products/5
        [HttpPut]
        [AllowAnonymous]
        public IHttpActionResult Put(int id, [FromBody] Product product)
        {
            return Ok(_productService.Put(id, product));
        }

        // DELETE api/products/5
        [HttpDelete]
        [AllowAnonymous]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_productService.Delete(id));
        }
    }
}
