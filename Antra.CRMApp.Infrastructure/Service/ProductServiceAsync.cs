﻿using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IProductRepositoryAsync productRepositoryAsync;
        public ProductServiceAsync(IProductRepositoryAsync prod)
        {
            productRepositoryAsync = prod;
        }

        public async Task<int> AddProductAsync(ProductRequestModel add)
        {
            Product product = new Product();
            product.Name = add.Name;
            product.VendorId = add.VendorId;
            product.CategoryId = add.CategoryId;
            product.QuantityPerUnit = add.QuantityPerUnit;
            product.UnitPrice = add.UnitPrice;
            product.UnitsInStock = add.UnitsInStock;
            product.UnitsOnOrder = add.UnitsOnOrder;
            product.Discontinued = add.Discontinued;
            product.ReorderLevel = add.ReorderLevel;
            return await productRepositoryAsync.InsertAsync(product);
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            return await productRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllAsync()
        {
            var collection = await productRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<ProductResponseModel> result = new List<ProductResponseModel>();
                foreach (var item in collection)
                {
                    ProductResponseModel model = new ProductResponseModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.UnitsOnOrder = item.UnitsOnOrder;
                    model.Discontinued = item.Discontinued;
                    model.QuantityPerUnit = item.QuantityPerUnit;
                    model.UnitPrice = item.UnitPrice;
                    model.UnitsInStock = item.UnitsInStock;
                    model.UnitsOnOrder = item.UnitsOnOrder;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<ProductResponseModel> GetByIdAsync(int id)
        {
            var item = await productRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ProductResponseModel model = new ProductResponseModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.UnitsOnOrder = item.UnitsOnOrder;
                model.Discontinued = item.Discontinued;
                model.QuantityPerUnit = item.QuantityPerUnit;
                model.UnitPrice = item.UnitPrice;
                model.UnitsInStock = item.UnitsInStock;
                model.UnitsOnOrder = item.UnitsOnOrder;
                return model;
            }
            return null;
        }

        public async Task<ProductRequestModel> GetProductForEditAsync(int id)
        {
            var item = await productRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ProductRequestModel model = new ProductRequestModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.UnitsOnOrder = item.UnitsOnOrder;
                model.Discontinued = item.Discontinued;
                model.QuantityPerUnit = item.QuantityPerUnit;
                model.UnitPrice = item.UnitPrice;
                model.UnitsInStock = item.UnitsInStock;
                model.UnitsOnOrder = item.UnitsOnOrder;
                model.VendorId = item.VendorId;
                model.CategoryId = item.CategoryId;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateProductAsync(ProductRequestModel update)
        {
            Product prod = new Product();
            prod.Id = update.Id;
            prod.Name = update.Name;
            prod.UnitsOnOrder = update.UnitsOnOrder;
            prod.Discontinued = update.Discontinued;
            prod.QuantityPerUnit = update.QuantityPerUnit;
            prod.UnitPrice = update.UnitPrice;
            prod.UnitsInStock = update.UnitsInStock;
            prod.UnitsOnOrder = update.UnitsOnOrder;
            prod.VendorId = update.VendorId;
            prod.CategoryId = update.CategoryId;
            return await productRepositoryAsync.UpdateAsync(prod);
        }
    }
}
