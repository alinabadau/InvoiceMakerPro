using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using InvoiceMakerPro.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace InvoiceMakerPro.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuppliesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Supplies
        public IActionResult Index()
        {
            return View(_context.Article.ToList());
        }

        public JsonResult GetArticles([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_context.Article.ToDataSourceResult(request));
        }


        // GET: Supplies/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Article article = _context.Article.Single(m => m.ArticleId == id);
            if (article == null)
            {
                return HttpNotFound();
            }

            return View(article);
        }

        // GET: Supplies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Article.Add(article);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Supplies/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Article article = _context.Article.Single(m => m.ArticleId == id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Supplies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Update(article);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Supplies/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Article article = _context.Article.Single(m => m.ArticleId == id);
            if (article == null)
            {
                return HttpNotFound();
            }

            return View(article);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            Article article = _context.Article.Single(m => m.ArticleId == id);
            _context.Article.Remove(article);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
