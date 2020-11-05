using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OneMindIndia.Business.Services;
using OneMindIndia.DataAccess.Entities;
using OneMindIndia.DataModel;

namespace OneMindIndia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Product> Get()
        {
            var product = new ProductService();
            return product.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{productId}")]
        public Product GetById(Guid productId)
        {
            var product = new ProductService();
            return product.GetById(productId);
        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("Create")]
        public bool Create([FromBody] ProductInputData inputData)
        {
            if (inputData.Quantity >= 0 && inputData.ProductName != null)
            {
                var product = new ProductService();
                return product.AddProduct(inputData);
            }
            throw new Exception("Please enter the Product Name and Quantity should be greater than or equal to 0");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{productId}")]
        public bool Edit(Guid productId, [FromBody] ProductInputData editData)
        {
            var product = new ProductService();
            return product.EditProduct(productId, editData);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{productId}")]
        public bool Delete(Guid productId)
        {
            var product = new ProductService();
            return product.DeleteProduct(productId);
        }
    }
}
