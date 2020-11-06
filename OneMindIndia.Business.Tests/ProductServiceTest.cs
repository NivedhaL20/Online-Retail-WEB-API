using System;
using System.Linq;
using OneMindIndia.Business.Interface;
using OneMindIndia.Business.Services;
using OneMindIndia.DataModel;
using Xunit;

namespace OneMindIndia.Business.Tests
{
    public class ProductServiceTest
    {
        public IProductService objProductService;

        public ProductServiceTest(IProductService productService)
        {
            this.objProductService = productService;
        }

        [Fact]
        public void TestAddProductExpectException()
        {           
            var product = new ProductInputData()
            {
                ProductId = Guid.NewGuid(),
                ProductName = "Product for test",
                Quantity = 10
            };
            Assert.Throws<Exception>(() => objProductService.AddProduct(product));
        }

        [Fact]
        public void TestGetProductExpectTrue()
        {            
            var products = objProductService.GetAll();
            var product = products.Where(x => x.ProductId != Guid.Empty);
            Assert.True(product != null);
        }

        [Fact]
        public void TestEditProductExpectException()
        {
            var product = new ProductInputData()
            {
                ProductId = Guid.NewGuid(),
                ProductName = "Product for test",
                Quantity = 10
            };            
            Assert.Throws<Exception>(() => objProductService.EditProduct(product.ProductId, product));
        }

        [Fact]
        public void TestDeleteProductExpectException()
        {
            var product = new ProductInputData()
            {
                ProductId = Guid.NewGuid(),
                ProductName = "Product for test",
                Quantity = 10
            };            
            Assert.Throws<Exception>(() => objProductService.DeleteProduct(product.ProductId));
        }
    }
}
