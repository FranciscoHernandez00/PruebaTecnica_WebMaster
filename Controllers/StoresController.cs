using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_WebMaster.Data;
using PruebaTecnica_WebMaster.Models;
using PruebaTecnica_WebMaster.Models.ImplementRepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_WebMaster.Controllers
{
    public class StoresController : Controller
    {

        private IStoreRepository storeRepository;

        public StoresController(IStoreRepository storeRepository)
        {
            this.storeRepository = storeRepository;
        }
        public IActionResult Locate()
        {
            ViewBag.ListOfDropdown = "Hola";
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<StoreViewModel> model = storeRepository.GetAllStores().Select(s => new StoreViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Phone = s.Phone,
                Coordinates = $"{s.Longitude}, {s.Latitude}",

            });
            ViewBag.AllStores = storeRepository.GetAllStores().Select(x => x.Longitude).ToList();
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult EditStore(long? id)
        {
            StoreViewModel model = new StoreViewModel();
            if (id.HasValue)
            {
                Store store = storeRepository.GetStore(id.Value);
                if (store != null)
                {
                    model.Id = store.Id;
                    model.Name = store.Name;
                    model.Address = store.Address;
                    model.Phone = store.Phone;
                    model.Longitude = store.Longitude;
                    model.Latitude = store.Latitude;
                }
                
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EditStore(long? id, StoreViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    bool isNew = !id.HasValue;
                    Store store = isNew ? new Store
                    {
                        AddedDate = DateTime.UtcNow
                    } : storeRepository.GetStore(id.Value);
                    store.Name = model.Name;
                    store.Address = model.Address;
                    store.Phone = model.Phone;
                    store.Longitude = model.Longitude;
                    store.Latitude = model.Latitude;
                    store.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    store.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        storeRepository.SaveStore(store);
                    }
                    else
                    {
                        storeRepository.UpdateStore(store);
                    }
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult CreateStore(long? id, StoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;
                Store store = isNew ? new Store
                {
                    AddedDate = DateTime.UtcNow
                } : storeRepository.GetStore(id.Value);
                store.Name = model.Name;
                store.Address = model.Address;
                store.Phone = model.Phone;
                store.Longitude = model.Longitude;
                store.Latitude = model.Latitude;
                store.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                store.ModifiedDate = DateTime.UtcNow;
                storeRepository.SaveStore(store);
            return RedirectToAction("Index");

            }

            return View();
        }

        [HttpPost]
        public IActionResult DeleteStore(long id)
        {
            storeRepository.DeleteStore(id);
            return RedirectToAction("Index");
        }

    }
}
