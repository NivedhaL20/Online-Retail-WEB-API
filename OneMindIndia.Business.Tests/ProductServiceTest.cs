using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OneMindIndia.Business.Interface;
using OneMindIndia.Business.Services;
using OneMindIndia.DataAccess;
using OneMindIndia.DataModel;
using Xunit;

namespace OneMindIndia.Business.Tests
{
    public class ProductServiceTest
    {
        public IProductService objProductService;
        public DatabaseContext dbContext;        
        private IConfiguration _config;
        public ProductServiceTest()
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(connection).Options;
            this.dbContext = new DatabaseContext(options);
            this.objProductService = new ProductService(dbContext);                        
        }

        public IConfiguration Configuration
        {
            get
            {
                if (_config == null)
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: false);
                    _config = builder.Build();
                }

                return _config;
            }
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
