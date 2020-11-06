using System;
using System.Collections.Generic;
using System.Linq;
using OneMindIndia.Business.Interface;
using OneMindIndia.DataAccess;
using OneMindIndia.DataAccess.Entities;
using OneMindIndia.DataModel;

namespace OneMindIndia.Business.Services
{
    public class ProductService : IProductService
    {
        public DatabaseContext dbContext;
        public ProductService(DatabaseContext databaseContext)
        {
            this.dbContext = databaseContext;
        }

        public Product GetById(Guid productId)
        {            
            return dbContext.Products.FirstOrDefault(x => x.ProductId == productId);
        }

        public List<Product> GetAll()
        {            
            return dbContext.Products.ToList();
        }

        public bool AddProduct(ProductInputData productInputData)
        {            
            var pro = dbContext.Products.FirstOrDefault(x => x.ProductName == productInputData.ProductName);
            if (pro != null) throw new Exception("Product name already exists");
            var product = new Product()
            {
                ProductId = Guid.NewGuid(),
                ProductName = productInputData.ProductName,
                Quantity = productInputData.Quantity
            };
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return true;
        }

        public bool EditProduct(Guid productId, ProductInputData updatedInputData)
        {            
            var product = dbContext.Products.FirstOrDefault(x => x.ProductId == productId);
            if (product == null) throw new Exception("Invalid Product Id");
            
            var pro = dbContext.Products.FirstOrDefault(x => x.ProductName == updatedInputData.ProductName);            
            if(pro != null) throw new Exception("Product name already exists");

            product.Quantity = (updatedInputData.Quantity != 0) ? updatedInputData.Quantity : product.Quantity;
            product.ProductName = (updatedInputData.ProductName != null) ? updatedInputData.ProductName : product.ProductName;
            dbContext.Products.Update(product);
            dbContext.SaveChanges();
            return true;
        }

        public bool DeleteProduct(Guid productId)
        {         
            var product = dbContext.Products.FirstOrDefault(x => x.ProductId == productId);
            if (product == null) throw new Exception("Invalid Product Id");
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return true;
        }
    }
}
