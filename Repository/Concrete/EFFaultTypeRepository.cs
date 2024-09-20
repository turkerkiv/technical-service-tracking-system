using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using technical_service_tracking_system.Entity;
using technical_service_tracking_system.Repository.Abstract;

namespace technical_service_tracking_system.Repository.Concrete
{
    public class EFFaultTypeRepository(TsDbContext context) : IFaultTypeRepository
    {
        readonly TsDbContext _context = context;
        public IQueryable<FaultType> FaultTypes => _context.FaultTypes;

        public async Task AddFaultTypeAsync(FaultType faultType)
        {
            _context.FaultTypes.Add(faultType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFaultTypeAsync(FaultType faultType)
        {
            _context.FaultTypes.Remove(faultType);
            await _context.SaveChangesAsync();
        }

        public async Task<FaultType?> GetFaultTypeByIdAsync(int id)
        {
            return await _context.FaultTypes.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateFaultTypeAsync(FaultType faultType)
        {
            _context.FaultTypes.Update(faultType);
            await _context.SaveChangesAsync();
        }
    }
}