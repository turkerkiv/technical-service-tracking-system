using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using technical_service_tracking_system.Entity;

namespace technical_service_tracking_system.Repository.Abstract
{
    public interface IServiceRequestRepository
    {
        Task<ServiceRequest?> GetServiceRequestByIdAsync(int id);
        Task AddServiceRequestAsync(ServiceRequest serviceRequest);
        Task UpdateServiceRequestAsync(ServiceRequest serviceRequest);
        Task DeleteServiceRequestAsync(ServiceRequest serviceRequest);
    }
}