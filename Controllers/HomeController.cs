using Brinquedos_NET6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Brinquedos_NET6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
       
    }
}