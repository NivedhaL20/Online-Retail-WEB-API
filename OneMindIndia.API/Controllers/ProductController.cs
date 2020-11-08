using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OneMindIndia.Business.Interface;
using OneMindIndia.Business.Services;
using OneMindIndia.DataAccess.Entities;
using OneMindIndia.DataModel;

namespace OneMindIndia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public IProductService product;

        public ProductController(IProductService productService)
        {
            this.product = productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Product> Get()
        {   
            return product.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{productId}")]
        public Product GetById(Guid productId)
        {            
            return product.GetById(productId);
        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("Create")]
        public bool Create([FromBody] ProductInputData inputData)
        {
            if (inputData.Quantity >= 0 && inputData.ProductName != null)
            {                
                return product.AddProduct(inputData);
            }
            throw new Exception("Please enter the Product Name and Quantity should be greater than or equal to 0");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{productId}")]
        public bool Edit(Guid productId, [FromBody] ProductInputData editData)
        {
            if (editData.Quantity >= 0 && editData.ProductName != null)
            {
                return product.EditProduct(productId, editData);
            }
            throw new Exception("Please enter the Product Name and Quantity should be greater than or equal to 0");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{productId}")]
        public bool Delete(Guid productId)
        {            
            return product.DeleteProduct(productId);
        }
    }
}
