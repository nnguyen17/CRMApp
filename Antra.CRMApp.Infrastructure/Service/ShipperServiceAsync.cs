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
    public class ShipperServiceAsync : IShipperServiceAsync
    {
        private readonly IShipperRepositoryAsync shipperRepositoryAsync;
        public ShipperServiceAsync(IShipperRepositoryAsync ship)
        {
            shipperRepositoryAsync = ship;
        }

        public async Task<int> AddShipperAsync(ShipperModel add)
        {
            Shipper shipper = new Shipper();
            shipper.Name = add.Name;
            shipper.Phone = add.Phone;
            return await shipperRepositoryAsync.InsertAsync(shipper);
        }

        public async Task<int> DeleteShipperAsync(int id)
        {
            return await shipperRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ShipperModel>> GetAllAsync()
        {
            var collection = await shipperRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<ShipperModel> result = new List<ShipperModel>();
                foreach (var item in collection)
                {
                    ShipperModel model = new ShipperModel();
                    model.Name = item.Name;
                    model.Id = item.Id;
                    model.Phone = item.Phone;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<ShipperModel> GetByIdAsync(int id)
        {
            var item = await shipperRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ShipperModel model = new ShipperModel();
                model.Name = item.Name;
                model.Id = item.Id;
                model.Phone = item.Phone;
                return model;
            }
            return null;
        }

        public async Task<ShipperModel> GetShipperForEditAsync(int id)
        {
            var item = await shipperRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ShipperModel model = new ShipperModel();
                model.Name = item.Name;
                model.Id = item.Id;
                model.Phone= item.Phone;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateShipperAsync(ShipperModel update)
        {
            Shipper shipper = new Shipper();
            shipper.Id = update.Id;
            shipper.Name = update.Name;
            shipper.Phone = update.Phone;
            return await shipperRepositoryAsync.UpdateAsync(shipper);
        }
    }
}
