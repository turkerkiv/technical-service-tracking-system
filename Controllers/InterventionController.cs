using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using technical_service_tracking_system.Entity;
using technical_service_tracking_system.Models;
using technical_service_tracking_system.Repository.Abstract;

namespace technical_service_tracking_system.Controllers
{
    public class InterventionController(
        IRequestInterventionRepository requestInterventionRepository,
        ISpareItemRepository spareItemRepository
    ) : Controller
    {
        private readonly IRequestInterventionRepository _requestIntRepo = requestInterventionRepository;
        private readonly ISpareItemRepository _spareItemRepo = spareItemRepository;

        [HttpGet]
        [Authorize(Roles = "Technician, Admin")]
        public async Task<IActionResult> AddIntervention(int requestId)
        {
            return View(new AddInterventionViewModel{
                ServiceRequestId = requestId,
                SpareItems = await _spareItemRepo.SpareItems.ToListAsync(),
            });
        }

        [HttpPost]
        [Authorize(Roles = "Technician, Admin")]
        public async Task<IActionResult> AddIntervention(AddInterventionViewModel addInterventionViewModel)
        {
            if(!ModelState.IsValid)
                return View(addInterventionViewModel);

            await _requestIntRepo.AddRequestInterventionAsync(new Entity.RequestIntervention{
                EndDate = addInterventionViewModel.EndDate.Value,
                InterventionDetails = addInterventionViewModel.InterventionDetails,
                ServiceRequestId = addInterventionViewModel.ServiceRequestId,
                SpareItemUseActivities = addInterventionViewModel.SelectedSpareItemIds.Select(ssii => new SpareItemUseActivity{
                    SpareItemId = ssii
                }).ToList(),
                TechnicianId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                StartDate = addInterventionViewModel.StartDate.Value,
            });

            //to decrease stock but it makes app crashed
            // addInterventionViewModel.SelectedSpareItemIds.ForEach(async ssii => {
            //     var spareItem = await _spareItemRepo.SpareItems.FirstOrDefaultAsync(si => si.Id == ssii);
            //     spareItem.Stock--;
            //     await _spareItemRepo.UpdateSpareItemAsync(spareItem);
            // });

            return RedirectToAction("ServiceRequests", "ServiceRequest");
        }
    }
}