
using System;
using OneMindIndia.Business.Services;
using OneMindIndia.DataModel;
using Xunit;

namespace OneMindIndia.Business.Tests
{
    public class OrderServiceTest
    {
        [Fact]
        public void TestAddOrderExpectException()
        {
            var objOrderService = new OrderService();
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
            var objOrderService = new OrderService();
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
            var objOrderService = new OrderService();
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
            var objOrderService = new OrderService();
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
            var objOrderService = new OrderService();
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
