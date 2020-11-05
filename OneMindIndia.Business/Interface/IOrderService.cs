using OneMindIndia.DataAccess.Entities;
using OneMindIndia.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMindIndia.Business.Interface
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order GetById(Guid orderId);
        bool AddOrder(OrderInputData inputData);
        bool UpdateOrderQuantity(Guid orderId, OrderInputData inputData);
        bool CancelOrder(Guid orderId);
    }
}
