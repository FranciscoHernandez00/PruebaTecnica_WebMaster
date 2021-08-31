using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_WebMaster.Data;
using PruebaTecnica_WebMaster.Models;
using PruebaTecnica_WebMaster.Models.ImplementRepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using PruebaTecnica_WebMaster.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace PruebaTecnica_WebMaster.Controllers
{
    [Authorize(Roles = "Administrador, Normal")]
    public class StoresController : Controller
    {


        private IStoreRepository storeRepository;
        private readonly UserManager<PruebaTecnica_WebMasterUser> _userManager;

        public StoresController(IStoreRepository storeRepository, UserManager<PruebaTecnica_WebMasterUser> userManager)
        {
            _userManager = userManager;
            this.storeRepository = storeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = User.FindFirstValue(ClaimTypes.Name);
            var create = _userManager.Users.Where(x => x.UserName == user).Select(x => x.Create).FirstOrDefault();
            var edit = _userManager.Users.Where(x => x.UserName == user).Select(x => x.Edit).FirstOrDefault();
            var delete = _userManager.Users.Where(x => x.UserName == user).Select(x => x.Delete).FirstOrDefault();
            var details= _userManager.Users.Where(x => x.UserName == user).Select(x => x.Details).FirstOrDefault();
            
            ViewBag.Create = create;
            ViewBag.Edit = edit;
            ViewBag.Delete = delete;
            ViewBag.Details = details;

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

        [HttpGet]
        public IActionResult StoreDetails(long? id)
        {
            var user = User.FindFirstValue(ClaimTypes.Name);
            var edit = _userManager.Users.Where(x => x.UserName == user).Select(x => x.Edit).FirstOrDefault();

            ViewBag.Edit = edit;

            var stores = storeRepository.GetStore(id.Value);
            var lat = stores.Latitude;
            var lon = stores.Longitude;
            ViewBag.Latitude = lat;
            ViewBag.Longitude = lon;
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

    }
}
