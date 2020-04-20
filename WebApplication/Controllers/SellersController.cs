using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}