using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Test.Interfaces.Repositoies;
using Test.Interfaces.Services;
using Test.Models;

namespace Test.Services
{
    public class ProductService : IProductService
    {
        public IProductRepository _iProductRepository;
        public ProductService(IProductRepository iProductRepository)
        {
            _iProductRepository = iProductRepository;
        }
        public bool Delete(int id)
        {
            var i = _iProductRepository.DeleteProduct(id);
            if (i > 0)
                return true;
            else
                return false;
        }

        public IEnumerable<Product> Get()
        {
            var products = _iProductRepository.GetProducts();
            return products;
        }

        public Product Get(int id)
        {
            var product = _iProductRepository.GetProduct(id);
            return product;
        }

        public bool Post([FromBody] Product product)
        {
            var i = _iProductRepository.AddProduct(product);
            if (i > 0)
                return true;
            else
                return false;
        }

        public bool Put([FromBody] Product product)
        {
            var i = _iProductRepository.UpdateProduct(product);
            if (i > 0)
                return true;
            else
                return false;
        }
    }
}