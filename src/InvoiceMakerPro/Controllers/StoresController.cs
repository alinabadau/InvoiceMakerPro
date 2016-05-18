using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using InvoiceMakerPro.Models;
using System;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace InvoiceMakerPro.Controllers
{
    public class StoresController : Controller
    {
        private ApplicationDbContext _context;

        public StoresController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Stores
        public IActionResult Index()
        {
            return View(_context.Store.ToList());
        }

        // GET: Stores/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Store store = _context.Store.Single(m => m.StoreId == id);
            if (store == null)
            {
                return HttpNotFound();
            }

            return View(store);
        }

        // GET: Stores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                store.StoreId = Guid.NewGuid();
                _context.Store.Add(store);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        // GET: Stores/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Store store = _context.Store.Single(m => m.StoreId == id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                _context.Update(store);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Store store = _context.Store.Single(m => m.StoreId == id);
            if (store == null)
            {
                return HttpNotFound();
            }

            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            Store store = _context.Store.Single(m => m.StoreId == id);
            _context.Store.Remove(store);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetStores([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_context.Store.ToDataSourceResult(request));
        }
    }
}
