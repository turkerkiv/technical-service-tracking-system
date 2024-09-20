using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using technical_service_tracking_system.Entity;
using technical_service_tracking_system.Repository.Abstract;

namespace technical_service_tracking_system.Repository.Concrete
{
    public class EFServiceRequestRepository(TsDbContext context) : IServiceRequestRepository
    {
        readonly TsDbContext _context = context;
        public IQueryable<ServiceRequest> ServiceRequests => _context.ServiceRequests;

        public async Task AddServiceRequestAsync(ServiceRequest serviceRequest)
        {
            _context.ServiceRequests.Add(serviceRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceRequestAsync(ServiceRequest serviceRequest)
        {
            _context.ServiceRequests.Remove(serviceRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<ServiceRequest?> GetServiceRequestByIdAsync(int id)
        {
            return await _context.ServiceRequests.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateServiceRequestAsync(ServiceRequest serviceRequest)
        {
            _context.ServiceRequests.Update(serviceRequest);
            await _context.SaveChangesAsync();
        }
    }
}