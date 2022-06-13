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
    public class CategoryServiceAsync : ICategoryServiceAsync
    {
        private readonly ICategoryRepositoryAsync categoryRepositoryAsync;
        public CategoryServiceAsync(ICategoryRepositoryAsync cate)
        {
            categoryRepositoryAsync = cate;
        }

        public async Task<int> AddCategoryAsync(CategoryModel add)
        {
            Category category = new Category();
            category.Name = add.Name;
            category.Description = add.Description;
            return await categoryRepositoryAsync.InsertAsync(category);
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            return await categoryRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            var collection = await categoryRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<CategoryModel> result = new List<CategoryModel>();
                foreach (var item in collection)
                {
                    CategoryModel model = new CategoryModel();
                    model.Name = item.Name;
                    model.Id = item.Id;
                    model.Description = item.Description;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            var item = await categoryRepositoryAsync.GetByIdAsync(id);
            if(item != null)
            {
                CategoryModel model = new CategoryModel();
                model.Name = item.Name;
                model.Id = item.Id;
                model.Description = item.Description;
                return model;
            }
            return null;
        }

        public async Task<CategoryModel> GetCategoryForEditAsync(int id)
        {
            var item = await categoryRepositoryAsync.GetByIdAsync(id);
            if(item !=null)
            {
                CategoryModel model = new CategoryModel();
                model.Name = item.Name;
                model.Id = item.Id;
                model.Description = item.Description;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateCategoryAsync(CategoryModel update)
        {
            Category category = new Category();
            category.Id = update.Id;
            category.Name = update.Name;
            category.Description = update.Description;
            return await categoryRepositoryAsync.UpdateAsync(category);
        }
    }
}
