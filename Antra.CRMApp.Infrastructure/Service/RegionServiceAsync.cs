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
    public class RegionServiceAsync : IRegionServiceAsync
    {
        private readonly IRegionRepositoryAsync regionRepositoryAsync;
        public RegionServiceAsync(IRegionRepositoryAsync repo)
        {
            regionRepositoryAsync = repo;
        }

        public async Task<int> AddRegionAsync(RegionModel add)
        {
            Region region = new Region();
            region.Name = add.Name;
            return await regionRepositoryAsync.InsertAsync(region);
        }

        public async Task<int> DeleteRegionAsync(int id)
        {
            return await regionRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<RegionModel>> GetAllAsync()
        {
            var collection = await regionRepositoryAsync.GetAllAsync();
            if(collection != null)
            {
                List<RegionModel> result = new List<RegionModel>();
                foreach(var item in collection)
                {
                    RegionModel model = new RegionModel();
                    model.Name = item.Name;
                    model.Id = item.Id;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<RegionModel> GetByIdAsync(int id)
        {
            var item = await regionRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                RegionModel model = new RegionModel();
                model.Name = item.Name;
                model.Id = item.Id;
                return model;
            }
            return null;
        }

        public async Task<RegionModel> GetRegionForEditAsync(int id)
        {
            var item = await regionRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                RegionModel model = new RegionModel();
                model.Name = item.Name;
                model.Id = item.Id;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateRegionAsync(RegionModel update)
        {
            Region region = new Region();
            region.Id = update.Id;
            region.Name = update.Name;
            return await regionRepositoryAsync.UpdateAsync(region);
        }
    }
}
