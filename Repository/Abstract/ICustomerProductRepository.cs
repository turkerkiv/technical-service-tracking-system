using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using technical_service_tracking_system.Entity;

namespace technical_service_tracking_system.Repository.Abstract
{
    public interface ICustomerProductRepository
    {
        Task<CustomerProduct?> GetCustomerProductByIdAsync(int id);
        Task AddCustomerProductAsync(CustomerProduct customerProduct);
        Task UpdateCustomerProductAsync(CustomerProduct customerProduct);
        Task DeleteCustomerProductAsync(CustomerProduct customerProduct);
    }
}