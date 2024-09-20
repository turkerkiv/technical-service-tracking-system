using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using technical_service_tracking_system.Entity;
using technical_service_tracking_system.Repository.Abstract;

namespace technical_service_tracking_system.Repository.Concrete
{
    public class EFCustomerProductRepository(TsDbContext context) : ICustomerProductRepository
    {
        readonly TsDbContext _context = context;
        public IQueryable<CustomerProduct> CustomerProducts => _context.CustomerProducts;

        public async Task AddCustomerProductAsync(CustomerProduct customerProduct)
        {
            _context.CustomerProducts.Add(customerProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerProductAsync(CustomerProduct customerProduct)
        {
            _context.CustomerProducts.Remove(customerProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<CustomerProduct?> GetCustomerProductByIdAsync(int id)
        {
            return await _context.CustomerProducts.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateCustomerProductAsync(CustomerProduct customerProduct)
        {
            _context.CustomerProducts.Update(customerProduct);
            await _context.SaveChangesAsync();
        }
    }
}