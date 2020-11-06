
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OneMindIndia.Business.Interface;
using OneMindIndia.Business.Services;
using OneMindIndia.DataAccess;
using OneMindIndia.DataModel;
using Xunit;

namespace OneMindIndia.Business.Tests
{
    public class OrderServiceTest
    {
        public DatabaseContext dbContext;
        public IOrderService objOrderService;
        private IConfiguration _config;

        public OrderServiceTest()
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(connection).Options;
            this.dbContext = new DatabaseContext(options);
            this.objOrderService = new OrderService(dbContext);
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
        public void TestAddOrderExpectException()
        {            
            var order = new OrderInputData()
            {
                ProductId = Guid.Parse("95FEB320-49F1-4343-9DD3-0DB1521A4832"),
                OrderId = Guid.NewGuid(),
                CustomerId = Guid.Parse("fe7d6a2e-cd78-44db-8225-ebd1c1bc592f"),
                Quantity = 11
            };
            Assert.Throws<Exception>(() => objOrderService.AddOrder(order));
        }
        [Fact]
        public void TestAddOrderExpectTrue()
        {            
            var order = new OrderInputData()
            {
                ProductId = Guid.Parse("4A3AF1AA-B6BC-4F2E-85F1-7620672DB1E2"),
                OrderId = Guid.NewGuid(),
                CustomerId = Guid.Parse("fe7d6a2e-cd78-44db-8225-ebd1c1bc592f"),
                Quantity = 10
            };
            Assert.True(objOrderService.AddOrder(order));
        }

        [Fact]
        public void TestUpdateQuantityExpectTrue()
        {            
            var order = new OrderInputData()
            {
                ProductId = Guid.Parse("4A3AF1AA-B6BC-4F2E-85F1-7620672DB1E2"),
                OrderId = Guid.Parse("4A32FC4C-93F1-4E95-838B-16D0900339B8"),
                CustomerId = Guid.Parse("fe7d6a2e-cd78-44db-8225-ebd1c1bc592f"),
                Quantity = 10
            };
            Assert.True(objOrderService.UpdateOrderQuantity(order.OrderId,order));
        }

        [Fact]
        public void TestUpdateQuantityExpectException()
        {           
            var order = new OrderInputData()
            {
                ProductId = Guid.Parse("4A3AF1AA-B6BC-4F2E-85F1-7620672DB1E2"),
                OrderId = Guid.NewGuid(),
                CustomerId = Guid.Parse("fe7d6a2e-cd78-44db-8225-ebd1c1bc592f"),
                Quantity = 10
            };
            Assert.Throws<Exception>(() => objOrderService.UpdateOrderQuantity(order.OrderId, order));
        }

        [Fact]
        public void TestCancelExpectException()
        {            
            var order = new OrderInputData()
            {
                ProductId = Guid.Parse("4A3AF1AA-B6BC-4F2E-85F1-7620672DB1E2"),
                OrderId = Guid.NewGuid(),
                CustomerId = Guid.Parse("fe7d6a2e-cd78-44db-8225-ebd1c1bc592f"),
                Quantity = 10
            };
            Assert.Throws<Exception>(() => objOrderService.CancelOrder(order.OrderId));
        }
    }
}
