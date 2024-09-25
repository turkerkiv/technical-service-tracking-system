using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using technical_service_tracking_system.Entity;
using technical_service_tracking_system.Models;
using technical_service_tracking_system.Repository.Abstract;

namespace technical_service_tracking_system.Controllers
{
    public class ServiceRequestController(
        IServiceRequestRepository serviceRequestRepository,
        ICustomerProductRepository customerProductRepository,
        IStatusRepository statusRepository,
        IFaultTypeRepository faultTypeRepository,
        IRequestInterventionRepository requestInterventionRepository
        ) : Controller
    {
        private readonly IServiceRequestRepository _serviceRequestRepository = serviceRequestRepository;
        private readonly ICustomerProductRepository _customerProductRepository = customerProductRepository;
        private readonly IStatusRepository _statusRepo = statusRepository;
        private readonly IFaultTypeRepository _faultRepo = faultTypeRepository;
        private readonly IRequestInterventionRepository _interventionRepo = requestInterventionRepository;


        [HttpGet]
        public async Task<IActionResult> CreateRequest(int? customerProductId)
        {
            if (customerProductId == null)
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
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> CreateRequest(ServiceRequestViewModel serviceRequestViewModel)
        {
            //TODO add if any customer product already has request add model error and add general model error div for other errors in cshtml
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

        [HttpGet]
        [Authorize(Roles = "Technician, Admin")]
        public async Task<IActionResult> ServiceRequests()
        {
            var serviceRequests = await _serviceRequestRepository
            .ServiceRequests
            .Include(sr => sr.Customer)
            .Include(sr => sr.CustomerProduct)
            .ThenInclude(cp => cp.Product)
            .Include(sr => sr.Status)
            .Include(sr => sr.FaultType)
            .OrderBy(sr => sr.StatusId)
            .ToListAsync();

            return View(serviceRequests.Select(sr => new ListServiceRequestsViewModel
            {
                CustomerName = sr.Customer.Name,
                ProductName = sr.CustomerProduct.Product.Brand + " " + sr.CustomerProduct.Product.Model,
                ServiceRequestId = sr.Id,
                Status = sr.Status.Name,
                FaultType = sr.FaultType?.Name ?? "Not assigned yet.",
                FaultDetails = sr.FaultDetails,
            }).ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Technician, Admin")]
        public async Task<IActionResult> EditRequest(int serviceRequestId)
        {
            var request = await _serviceRequestRepository
            .ServiceRequests
            .Include(sr => sr.Customer)
            .Include(sr => sr.CustomerProduct)
            .ThenInclude(cp => cp.Product)
            .FirstOrDefaultAsync(sr => sr.Id == serviceRequestId);
            if (request == null) return NotFound();

            var interventions = await _interventionRepo
            .RequestInterventions
            .Where(ri => ri.ServiceRequestId == serviceRequestId)
            .Include(ri => ri.Technician)
            .Include(ri => ri.SpareItemUseActivities)
            .ThenInclude(siua => siua.SpareItem)
            .ToListAsync();

            return View(new EditReqInterventionViewModel
            {
                EditRequestViewModel = new EditRequestViewModel
                {
                    ServiceRequestId = serviceRequestId,
                    FaultTypeId = request.FaultTypeId,
                    StatusId = request.StatusId,
                    CustomerName = request.Customer.Name,
                    FaultDetails = request.FaultDetails,
                    ProductName = request.CustomerProduct.Product.Brand + " " + request.CustomerProduct.Product.Model,
                    Statuses = await _statusRepo.Statuss.ToListAsync(),
                    FaultTypes = await _faultRepo.FaultTypes.ToListAsync(),
                },
                InterventionsViewModels = interventions.Select(i => new ListInterventionViewModel
                {
                    EndDate = i.EndDate,
                    StartDate = i.StartDate,
                    InterventionDetails = i.InterventionDetails,
                    TechnicianName = i.Technician.Name,
                    UsedSpareItems = String.Join(", ", i.SpareItemUseActivities.Select(siua => siua.SpareItem.Name)),
                }).ToList(),
            });
        }

        [HttpPost]
        [Authorize(Roles = "Technician, Admin")]
        public async Task<IActionResult> EditRequest(EditRequestViewModel editRequestViewModel)
        {
            if (!ModelState.IsValid)
                return View(editRequestViewModel);

            var request = await _serviceRequestRepository.GetServiceRequestByIdAsync(editRequestViewModel.ServiceRequestId);
            if (request == null) return NotFound();

            request.StatusId = editRequestViewModel.StatusId;
            request.FaultTypeId = editRequestViewModel.FaultTypeId;
            await _serviceRequestRepository.UpdateServiceRequestAsync(request);
            return RedirectToAction("ServiceRequests");
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> ServiceRequestDetails(int customerProductId)
        {
            var request = await _serviceRequestRepository
            .ServiceRequests
            .Where(sr => sr.StatusId != 3)
            .Include(sr => sr.RequestInterventions)
            .ThenInclude(ri => ri.Technician)
            .Include(sr => sr.Status)
            .Include(sr => sr.FaultType)
            .FirstOrDefaultAsync(sr => sr.CustomerProductId == customerProductId);

            if(request == null) return NotFound();

            return View(new RequestDetailsViewModel{
                RequestStatus = request.Status.Name,
                FaultTypeName = request.FaultType?.Name ?? "Not assigned yet." ,
                TicketNumber = request.TicketNumber.ToString(),
                InterventionsViewModels = request.RequestInterventions.Select(ri => new ListInterventionViewModel{
                    EndDate = ri.EndDate,
                    StartDate = ri.StartDate,
                    InterventionDetails = ri.InterventionDetails,
                    TechnicianName = ri.Technician.Name,
                    UsedSpareItems = String.Join(", ", ri.SpareItemUseActivities.Select(siua => siua.SpareItem.Name)),
                }).ToList(),
            });
        }
    }
}
//TODO used items does not show
