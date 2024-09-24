using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using technical_service_tracking_system.Entity;

namespace technical_service_tracking_system.Repository.Abstract
{
    public interface ISpareItemRepository
    {
        public IQueryable<SpareItem> SpareItems {get;}
        Task<SpareItem?> GetSpareItemByIdAsync(int id);
        Task AddSpareItemAsync(SpareItem spareItem);
        Task UpdateSpareItemAsync(SpareItem spareItem);
        Task DeleteSpareItemAsync(SpareItem spareItem);
    }
}