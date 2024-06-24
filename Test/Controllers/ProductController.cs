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
    [RoutePrefix("api/Product")]
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
            return Ok(_productService.Post(product)? "新增成功" : "新增失敗");
        }

        // PUT api/products/5
        [HttpPut]
        [AllowAnonymous]
        public IHttpActionResult Put([FromBody] Product product)
        {
            return Ok(_productService.Put(product) ? "更新成功" : "更新失敗");
        }

        // DELETE api/products/5
        [HttpDelete]
        [AllowAnonymous]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_productService.Delete(id) ? "刪除成功" : "刪除失敗");
        }
    }
}
