using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using technical_service_tracking_system.Entity;

namespace technical_service_tracking_system.Repository.Abstract
{
    public interface ISpareItemUseActivityRepository
    {
        Task<SpareItemUseActivity?> GetSpareItemUseActivityByIdAsync(int id);
        Task AddSpareItemUseActivityAsync(SpareItemUseActivity spareItemUseActivity);
        Task UpdateSpareItemUseActivityAsync(SpareItemUseActivity spareItemUseActivity);
        Task DeleteSpareItemUseActivityAsync(SpareItemUseActivity spareItemUseActivity);
    }
}