using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using technical_service_tracking_system.Entity;
using technical_service_tracking_system.Repository.Abstract;

namespace technical_service_tracking_system.Repository.Concrete
{
    public class EFSpareItemRepository(TsDbContext context) : ISpareItemRepository
    {
        readonly TsDbContext _context = context;
        public IQueryable<SpareItem> SpareItems => _context.SpareItems;

        public async Task AddSpareItemAsync(SpareItem spareItem)
        {
            _context.SpareItems.Add(spareItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSpareItemAsync(SpareItem spareItem)
        {
            _context.SpareItems.Remove(spareItem);
            await _context.SaveChangesAsync();
        }

        public async Task<SpareItem?> GetSpareItemByIdAsync(int id)
        {
            return await _context.SpareItems.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateSpareItemAsync(SpareItem spareItem)
        {
            _context.SpareItems.Update(spareItem);
            await _context.SaveChangesAsync();
        }
    }
}