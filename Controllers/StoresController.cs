using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_WebMaster.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_WebMaster.Controllers
{
    public class StoresController : Controller
    {
        private readonly PruebaTecnica_WebMasterDbContext _context;

        public StoresController(PruebaTecnica_WebMasterDbContext context)
        {
            _context = context;
        }

        public IActionResult Locate()
        {
            return View();
        }

        public JsonResult GetShopList(int ID)
        {
            var Hola = "Hola";

            return Json(Hola);
        }
    }
}
