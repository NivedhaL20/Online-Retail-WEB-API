﻿using OneMindIndia.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using OneMindIndia.DataAccess.Entities;
using OneMindIndia.DataModel;

namespace OneMindIndia.Business.Services
{
    public class OrderService
    {
        private readonly Guid _customerId = Guid.Parse("fe7d6a2e-cd78-44db-8225-ebd1c1bc592f");
        public Order GetById(Guid orderId)
        {
            using var dbContext = new DatabaseContext();
            return dbContext.Orders.FirstOrDefault(x => x.OrderId == orderId);
        }

        public List<Order> GetAll()
        {
            using var dbContext = new DatabaseContext();
            return dbContext.Orders.ToList();
        }
        public bool AddOrder(OrderInputData orderInputData)
        {
            var order = new Order()
            {
                OrderId = Guid.NewGuid(),
                ProductId = orderInputData.ProductId,
                Quantity = orderInputData.Quantity,
                CustomerId = _customerId
            };
            using var dbContext = new DatabaseContext();
            dbContext.Orders.Add(order);

            var product = dbContext.Products.Find(order.ProductId);
            if (product == null || order.Quantity > product.Quantity) 
                throw new Exception("Product unavailable");
            product.Quantity -= order.Quantity;
            dbContext.SaveChanges();
            return true;
        }

        public bool UpdateOrderQuantity(Guid orderId, OrderInputData orderInputData)
        {
            var isCancelled = CancelOrder(orderId);
            return isCancelled && AddOrder(orderInputData);
        }

        public bool CancelOrder(Guid orderId)
        {
            using var dbContext = new DatabaseContext();
            var order = dbContext.Orders.FirstOrDefault(x => x.OrderId == orderId);
            if (order == null) throw new Exception("Order Id does not exist");
            order.IsCancelled = true;
            //dbContext.Orders.Remove(order);

            var product = dbContext.Products.Find(order.ProductId);
            product.Quantity += order.Quantity;
            dbContext.SaveChanges();
            return true;
        }


    }
}
