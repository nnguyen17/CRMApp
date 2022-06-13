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
    public class VendorServiceAsync : IVendorServiceAsync
    {
        private readonly IVendorRepositoryAsync vendorRepositoryAsync;
        public VendorServiceAsync(IVendorRepositoryAsync ven)
        {
            vendorRepositoryAsync = ven;
        }

        public async Task<int> AddVendorAsync(VendorModel add)
        {
            Vendor vendor = new Vendor();
            vendor.Name = add.Name;
            vendor.Country = add.Country;
            vendor.City = add.City;
            vendor.EmailId = add.EmailId;
            vendor.Mobile = add.Mobile;
            vendor.IsActive = add.IsActive;
            return await vendorRepositoryAsync.InsertAsync(vendor);
        }

        public async Task<int> DeleteVendorAsync(int id)
        {
            return await vendorRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<VendorModel>> GetAllAsync()
        {
            var collection = await vendorRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<VendorModel> result = new List<VendorModel>();
                foreach (var item in collection)
                {
                    VendorModel model = new VendorModel();
                    model.Name = item.Name;
                    model.Id = item.Id;
                    model.Country = item.Country;
                    model.City = item.City;
                    model.EmailId = item.EmailId;
                    model.Mobile = item.Mobile;
                    model.IsActive = item.IsActive;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<VendorModel> GetByIdAsync(int id)
        {
            var item = await vendorRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                VendorModel model = new VendorModel();
                model.Name = item.Name;
                model.Id = item.Id;
                model.Country = item.Country;
                model.City = item.City;
                model.EmailId = item.EmailId;
                model.Mobile = item.Mobile;
                model.IsActive = item.IsActive;
                return model;
            }
            return null;
        }

        public async Task<VendorModel> GetVendorForEditAsync(int id)
        {
            var item = await vendorRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                VendorModel model = new VendorModel();
                model.Name = item.Name;
                model.Id = item.Id;
                model.Country = item.Country;
                model.City = item.City;
                model.EmailId = item.EmailId;
                model.Mobile = item.Mobile;
                model.IsActive = item.IsActive;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateVendorAsync(VendorModel update)
        {
            Vendor vendor = new Vendor();
            vendor.Name = update.Name;
            vendor.Id = update.Id;
            vendor.Country = update.Country;
            vendor.City = update.City;
            vendor.EmailId = update.EmailId;
            vendor.Mobile = update.Mobile;
            vendor.IsActive = update.IsActive;
            return await vendorRepositoryAsync.UpdateAsync(vendor);
        }
    }
}
