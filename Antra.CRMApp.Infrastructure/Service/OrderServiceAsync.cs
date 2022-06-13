using Antra.CRMApp.Core.Contract.Repository;
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
    public class OrderServiceAsync : IOrderServiceAsync
    {
        private readonly IOrderRepositoryAsync orderRepositoryAsync;
        public OrderServiceAsync(IOrderRepositoryAsync ord)
        {
            orderRepositoryAsync = ord;
        }

        public async Task<int> AddOrderAsync(OrderModel add)
        {
            Order order = new Order();
            order.Id = add.Id;
            return await orderRepositoryAsync.InsertAsync(order);
        }

        public async Task<int> DeleteOrderAsync(int id)
        {
            return await orderRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            var collection = await orderRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<OrderModel> result = new List<OrderModel>();
                foreach (var item in collection)
                {
                    OrderModel model = new OrderModel();
                    model.Id = item.Id;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<OrderModel> GetByIdAsync(int id)
        {
            var item = await orderRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                OrderModel model = new OrderModel();
                model.Id = item.Id;
                return model;
            }
            return null;
        }

        public async Task<OrderModel> GetOrderForEditAsync(int id)
        {
            var item = await orderRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                OrderModel model = new OrderModel();
                model.Id = item.Id;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateOrderAsync(OrderModel update)
        {
            Order order = new Order();
            order.Id = update.Id;
            return await orderRepositoryAsync.UpdateAsync(order);
        }
    }
}
