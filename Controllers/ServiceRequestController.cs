using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using technical_service_tracking_system.Entity;
using technical_service_tracking_system.Models;
using technical_service_tracking_system.Repository.Abstract;

namespace technical_service_tracking_system.Controllers
{
    public class ServiceRequestController(IServiceRequestRepository serviceRequestRepository, ICustomerProductRepository customerProductRepository) : Controller
    {
        private readonly IServiceRequestRepository _serviceRequestRepository = serviceRequestRepository;
        private readonly ICustomerProductRepository _customerProductRepository = customerProductRepository;

        [HttpGet]
        public async Task<IActionResult> CreateRequest(int? customerProductId)
        {
            if(customerProductId == null)
            {
                return NotFound();
            }

            var customerProduct = await _customerProductRepository.CustomerProducts.Include(cp => cp.Product).FirstOrDefaultAsync(cp => cp.Id == customerProductId.Value);
            if (customerProduct == null)
            {
                return NotFound();
            }

            return View(new ServiceRequestViewModel
            {
                CustomerProductId = customerProduct.Id,
                ProductName = customerProduct.Product.Brand + " " + customerProduct.Product.Model,
                SerialNumber = customerProduct.Product.SerialNumber,
                WarrantyStartDate = customerProduct.WarrantyStartDate,
                WarrantyEndDate = customerProduct.WarrantyEndDate,
                HasWarranty = customerProduct.HasWarranty,
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(ServiceRequestViewModel serviceRequestViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceRequestViewModel);
            }

            var serviceRequest = new ServiceRequest
            {
                CustomerProductId = serviceRequestViewModel.CustomerProductId,
                FaultDetails = serviceRequestViewModel.FaultDetails,
                RequestDate = DateOnly.FromDateTime(DateTime.Now),
                StatusId = 1,
                CustomerId = 2, //This will be replaced with the actual user id
            };

            await _serviceRequestRepository.AddServiceRequestAsync(serviceRequest); 
            
            serviceRequest.TicketNumber = 100000 + serviceRequest.Id;
            await _serviceRequestRepository.UpdateServiceRequestAsync(serviceRequest);

            return RedirectToAction("MyProducts", "Product");
        }
    }
}

//TODO register and login in the home page instead of navbar 
//TODO add adding new product