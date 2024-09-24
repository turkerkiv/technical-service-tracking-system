using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using technical_service_tracking_system.Entity;
using technical_service_tracking_system.Models;
using technical_service_tracking_system.Repository.Abstract;

namespace technical_service_tracking_system.Controllers
{
    public class ProductController(
        IProductRepository productRepository,
        ICustomerProductRepository customerProductRepository,
        ISpareItemRepository spareItemRepository
        ) : Controller
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ICustomerProductRepository _customerProductRepository = customerProductRepository;
        private readonly ISpareItemRepository _spareItemRepo = spareItemRepository;

        [HttpGet]
        public async Task<IActionResult> MyProducts()
        {
            //Customers can view their products here
            int userId = 2; //This will be replaced with the actual user id
            var customerProducts = await _customerProductRepository.CustomerProducts.Where(cp => cp.CustomerId == userId).Include(cp => cp.Product).ToListAsync();
            var productsOfUser = customerProducts.Select(cp => new ServiceRequestViewModel
            {
                CustomerProductId = cp.Id,
                ProductName = cp.Product.Brand + " " + cp.Product.Model,
                SerialNumber = cp.Product.SerialNumber,
                WarrantyStartDate = cp.WarrantyStartDate,
                WarrantyEndDate = cp.WarrantyEndDate,
                HasWarranty = cp.HasWarranty,
            });

            return View(productsOfUser.ToList());
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductViewModel addProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addProductViewModel);
            }

            var product = new Product
            {
                Brand = addProductViewModel.Brand,
                Model = addProductViewModel.Model,
                ImageName = "1.jpg",
                SerialNumber = addProductViewModel.SerialNumber,
            };

            var customerProduct = new CustomerProduct
            {
                CustomerId = 2,
                Product = product,
                WarrantyEndDate = addProductViewModel.WarrantyEndDate,
                WarrantyStartDate = addProductViewModel.WarrantyStartDate,
            };

            await _customerProductRepository.AddCustomerProductAsync(customerProduct);
            return RedirectToAction("MyProducts", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> SpareItems()
        {
            var items = await _spareItemRepo.SpareItems.ToListAsync();
            return View(items.Select(i => new ListSpareItemViewModel {
                SpareItemId = i.Id,
                SpareItemName = i.Name,
                Stock = i.Stock,
            }).ToList());
        }

        [HttpGet]
        public IActionResult AddSpareItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSpareItem(ListSpareItemViewModel listSpareItemViewModel)
        {
            if(!ModelState.IsValid) return View(listSpareItemViewModel);

            await _spareItemRepo.AddSpareItemAsync(new SpareItem{
                Name = listSpareItemViewModel.SpareItemName,
                Stock = listSpareItemViewModel.Stock,
            });

            return RedirectToAction("SpareItems");
        }

        [HttpGet]
        public async Task<IActionResult> EditSpareItem(int spareItemId)
        {
            var spareItem = await _spareItemRepo.GetSpareItemByIdAsync(spareItemId);
            if(spareItem == null) return NotFound();
            return View(new ListSpareItemViewModel{
                SpareItemId = spareItem.Id,
                SpareItemName = spareItem.Name,
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditSpareItem(ListSpareItemViewModel listSpareItemViewModel)
        {
            if(!ModelState.IsValid) return View(listSpareItemViewModel);

            var spareItem = await _spareItemRepo.GetSpareItemByIdAsync(listSpareItemViewModel.SpareItemId);
            if(spareItem == null) return NotFound();

            spareItem.Stock = listSpareItemViewModel.Stock;
            spareItem.Name = listSpareItemViewModel.SpareItemName;
            await _spareItemRepo.UpdateSpareItemAsync(spareItem);

            return RedirectToAction("SpareItems");
        }
    }
}

//TODO when i use spare item in intervention decrease stock