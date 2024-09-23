using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using technical_service_tracking_system.Models;
using technical_service_tracking_system.Repository.Abstract;

namespace technical_service_tracking_system.Controllers
{
    public class ProductController(IProductRepository productRepository, ICustomerProductRepository customerProductRepository) : Controller
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ICustomerProductRepository _customerProductRepository = customerProductRepository;

        [HttpGet]
        public async Task<IActionResult> MyProducts()
        {
            //Customers can view their products here
            int userId = 2; //This will be replaced with the actual user id
            var customerProducts = await _customerProductRepository.CustomerProducts.Where(cp => cp.CustomerId == userId).Include(cp => cp.Product).ToListAsync();
            var productsOfUser = customerProducts.Select(cp => new CustomerProductViewModel
            {
                Id = cp.Id,
                ProductName = cp.Product.Brand + " " + cp.Product.Model,
                SerialNumber = cp.Product.SerialNumber,
                WarrantyStartDate = cp.WarrantyStartDate,
                WarrantyEndDate = cp.WarrantyEndDate,
                HasWarranty = cp.HasWarranty
            });

            return View(productsOfUser.ToList());
        }
    }
}