using OneMindIndia.DataAccess.Entities;
using OneMindIndia.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMindIndia.Business.Interface
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(Guid productId);
        bool AddProduct(ProductInputData inputData);
        bool EditProduct(Guid productId, ProductInputData editData);
        bool DeleteProduct(Guid productId);
    }
}
