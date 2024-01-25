using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Practice.Data;
using Practice.Models;

namespace Practice.Areas.Admin.Controllers
{

    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public IActionResult Index()
        {
            var categorylist = _db.Products.ToList();
            return View(categorylist);
        }
        public IActionResult Delete(int id)
        {
            Product? categorydb = _db.Products.Find(id);
            if (categorydb == null)
            {
                return NotFound();
            }
            _db.Products.Remove(categorydb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            _db.Products.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Product? categoryfdb = _db.Products.Find(id);
            if (categoryfdb == null)
            {
                return NotFound();
            }
            return View(categoryfdb);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
