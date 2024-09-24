using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using technical_service_tracking_system.Entity;

namespace technical_service_tracking_system.Repository.Abstract
{
    public interface IFaultTypeRepository
    {
        public IQueryable<FaultType> FaultTypes { get; }
        Task<FaultType?> GetFaultTypeByIdAsync(int id);
        Task AddFaultTypeAsync(FaultType faultType);
        Task UpdateFaultTypeAsync(FaultType faultType);
        Task DeleteFaultTypeAsync(FaultType faultType);
    }
}