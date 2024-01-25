using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Practice.Data;
using Practice.Models;

namespace Practice.Areas.Admin.Controllers
{

    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public IActionResult Index()
        {
            var categorylist = _db.Categories.ToList();
            return View(categorylist);
        }
        public IActionResult Delete(int id)
        {
            Category? categorydb = _db.Categories.Find(id);
            if (categorydb == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categorydb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Category? categoryfdb = _db.Categories.Find(id);
            if (categoryfdb == null)
            {
                return NotFound();
            }
            return View(categoryfdb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
