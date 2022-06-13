using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface IProductServiceAsync
    {
        Task<IEnumerable<ProductResponseModel>> GetAllAsync();
        Task<int> AddProductAsync(ProductRequestModel add);
        Task<ProductResponseModel> GetByIdAsync(int id);
        Task<ProductRequestModel> GetProductForEditAsync(int id);
        Task<int> UpdateProductAsync(ProductRequestModel update);
        Task<int> DeleteProductAsync(int id);
    }
}
