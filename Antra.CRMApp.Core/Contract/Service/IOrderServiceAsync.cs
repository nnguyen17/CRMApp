using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface IOrderServiceAsync
    {
        Task<IEnumerable<OrderModel>> GetAllAsync();
        Task<int> AddOrderAsync(OrderModel add);
        Task<OrderModel> GetByIdAsync(int id);
        Task<OrderModel> GetOrderForEditAsync(int id);
        Task<int> UpdateOrderAsync(OrderModel update);
        Task<int> DeleteOrderAsync(int id);
    }
}
