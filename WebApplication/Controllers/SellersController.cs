using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Service;

namespace WebApplication.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _service;

        public SellersController(SellerService service) => _service = service;

        public IActionResult Index()
        {
            return View(_service.FindAll());
        }

        public IActionResult Create()
        {
            return View(new Seller());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _service.Insert(seller);

            return RedirectToAction(nameof(Index));
        }
    }
}