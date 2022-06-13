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
    public class EmployeeServiceAsync : IEmployeeServiceAsync
    {
        private readonly IEmployeeRepositoryAsync employeeRepositoryAsync;
        public EmployeeServiceAsync(IEmployeeRepositoryAsync _emp)
        {
            employeeRepositoryAsync = _emp;
        }

        public async Task<int> AddEmployeeAsync(EmployeeRequestModel add)
        {
            Employee emp = new Employee();
            emp.Address = add.Address;
            emp.RegionId = add.RegionId;
            emp.BirthDate = add.BirthDate;
            emp.ReportsTo = add.ReportsTo;
            emp.PhotoPath = add.PhotoPath;
            emp.City = add.City;
            emp.Country = add.Country;
            emp.FirstName = add.FirstName;
            emp.LastName = add.LastName;
            emp.Phone = add.Phone;
            emp.HireDate = add.HireDate;
            emp.PostalCode = add.PostalCode;
            emp.Title = add.Title;
            emp.TitleOfCourtesy = add.TitleOfCourtesy;
            return await employeeRepositoryAsync.InsertAsync(emp);
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            return await employeeRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllAsync()
        {
            var collection = await employeeRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<EmployeeResponseModel> result = new List<EmployeeResponseModel>();
                foreach (var item in collection)
                {
                    EmployeeResponseModel model = new EmployeeResponseModel();
                    model.Id = item.Id;
                    model.Phone = item.Phone;
                    model.PhotoPath = item.PhotoPath;
                    model.Title = item.Title;
                    model.BirthDate = item.BirthDate;
                    model.Address = item.Address;
                    model.City = item.City;
                    model.FullName = item.FirstName + " " + item.LastName;
                    model.TitleOfCourtesy = item.TitleOfCourtesy;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<EmployeeResponseModel> GetByIdAsync(int id)
        {
            var item = await employeeRepositoryAsync.GetByIdAsync(id);
            if(item != null)
            {
                EmployeeResponseModel model = new EmployeeResponseModel();
                model.Id = item.Id;
                model.Phone = item.Phone;
                model.PhotoPath = item.PhotoPath;
                model.Title = item.Title;
                model.BirthDate = item.BirthDate;
                model.Address = item.Address;
                model.City = item.City;
                model.FullName = item.FirstName + " " + item.LastName;
                model.TitleOfCourtesy = item.TitleOfCourtesy;
                return model;
            }
            return null;
        }

        public async Task<EmployeeRequestModel> GetEmployeeForEditAsync(int id)
        {
            var item = await employeeRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                EmployeeRequestModel model = new EmployeeRequestModel();
                model.Id = item.Id;
                model.Phone = item.Phone;
                model.PhotoPath = item.PhotoPath;
                model.Title = item.Title;
                model.BirthDate = item.BirthDate;
                model.Address = item.Address;
                model.City = item.City;
                model.FirstName = item.FirstName;
                model.LastName = item.LastName;
                model.TitleOfCourtesy = item.TitleOfCourtesy;
                model.RegionId = item.RegionId;
                model.PostalCode = item.PostalCode;
                model.Country = item.Country;
                model.ReportsTo = item.ReportsTo;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateEmployeeAsync(EmployeeRequestModel update)
        {
            Employee emp = new Employee();
            emp.Id = update.Id;
            emp.Address = update.Address;
            emp.RegionId = update.RegionId;
            emp.BirthDate = update.BirthDate;
            emp.ReportsTo = update.ReportsTo;
            emp.PhotoPath = update.PhotoPath;
            emp.City = update.City;
            emp.Country = update.Country;
            emp.FirstName = update.FirstName;
            emp.LastName = update.LastName;
            emp.Phone = update.Phone;
            emp.HireDate = update.HireDate;
            emp.PostalCode = update.PostalCode;
            emp.Title = update.Title;
            emp.TitleOfCourtesy = update.TitleOfCourtesy;
            return await employeeRepositoryAsync.UpdateAsync(emp);
        }
    }
}
