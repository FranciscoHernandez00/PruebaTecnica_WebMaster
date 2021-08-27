using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTecnica_WebMaster.Models;
using PruebaTecnica_WebMaster.Models.ImplementRepositoryPattern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_WebMaster.Controllers
{
    [Authorize(Roles = "Administrador, Normal")]
    public class HomeController : Controller
    {
        private IStoreRepository storeRepository;

        public HomeController(IStoreRepository storeRepository)
        {
            this.storeRepository = storeRepository;
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
