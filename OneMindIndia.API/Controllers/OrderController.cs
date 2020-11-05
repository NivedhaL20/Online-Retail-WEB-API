using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OneMindIndia.Business.Services;
using OneMindIndia.DataAccess.Entities;
using OneMindIndia.DataModel;

namespace OneMindIndia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // GET: api/<OrderController>
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Order> Get()
        {
            var order = new OrderService();
            return order.GetAll();
        }

        // GET api/<OrderController>/5
        [HttpGet("{orderId}")]
        public Order GetById(Guid orderId)
        {
            var order = new OrderService();
            return order.GetById(orderId);
        }

        // POST api/<OrderController>
        [HttpPost]
        [Route("Create")]
        public bool Create([FromBody] OrderInputData inputData)
        {
            if (inputData.Quantity > 0)
            {
                var order = new OrderService();
                return order.AddOrder(inputData);
            }
            throw new Exception("Please enter the Quantity which should be greater than 0");
        }

        // PUT api/<OrderController>/5
        [HttpPut("{orderId}")]
        public bool Update(Guid orderId, [FromBody] OrderInputData inputData)
        {
            var order = new OrderService();
            return order.UpdateOrderQuantity(orderId, inputData);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{orderId}")]
        public bool Cancel(Guid orderId)
        {
            var order = new OrderService();
            return order.CancelOrder(orderId);
        }
    }
}
