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
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        private readonly ICustomerRepositoryAsync customerRepositoryAsync;
        public CustomerServiceAsync(ICustomerRepositoryAsync cus)
        {
            customerRepositoryAsync = cus;
        }

        public async Task<int> AddCustomerAsync(CustomerRequestModel add)
        {
            Customer customer = new Customer();
            customer.Address = add.Address;
            customer.RegionId = add.RegionId;
            customer.City = add.City;
            customer.Country = add.Country;
            customer.Name = add.Name;
            customer.Phone = add.Phone;
            customer.PostalCode = add.PostalCode;
            customer.Title = add.Title;
            return await customerRepositoryAsync.InsertAsync(customer);
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            return await customerRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllAsync()
        {
            var collection = await customerRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<CustomerResponseModel> result = new List<CustomerResponseModel>();
                foreach (var item in collection)
                {
                    CustomerResponseModel model = new CustomerResponseModel();
                    model.Id = item.Id;
                    model.Phone = item.Phone;
                    model.Title = item.Title;
                    model.Address = item.Address;
                    model.City = item.City;
                    model.Name = item.Name;
                    model.Country = item.Country;
                    model.PostalCode = item.PostalCode;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<CustomerResponseModel> GetByIdAsync(int id)
        {
            var item = await customerRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CustomerResponseModel model = new CustomerResponseModel();
                model.Id = item.Id;
                model.Phone = item.Phone;
                model.Title = item.Title;
                model.Address = item.Address;
                model.City = item.City;
                model.Name = item.Name;
                model.Country = item.Country;
                model.PostalCode = item.PostalCode;
                return model;
            }
            return null;
        }

        public async Task<CustomerRequestModel> GetCustomerForEditAsync(int id)
        {
            var item = await customerRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CustomerRequestModel model = new CustomerRequestModel();
                model.Id = item.Id;
                model.Phone = item.Phone;
                model.Title = item.Title;
                model.Address = item.Address;
                model.City = item.City;
                model.Name = item.Name;
                model.Country = item.Country;
                model.PostalCode = item.PostalCode;
                model.RegionId = item.RegionId;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateCustomerAsync(CustomerRequestModel update)
        {
            Customer cus = new Customer();
            cus.Id = update.Id;
            cus.Phone = update.Phone;
            cus.Title = update.Title;
            cus.Address = update.Address;
            cus.City = update.City;
            cus.Name = update.Name;
            cus.Country = update.Country;
            cus.PostalCode = update.PostalCode;
            cus.RegionId = update.RegionId;
            return await customerRepositoryAsync.UpdateAsync(cus);
        }
    }
}
