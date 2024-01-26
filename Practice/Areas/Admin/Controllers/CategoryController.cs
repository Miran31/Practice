using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Practice.Data;
using Practice.Models;
using Practice.Repository.IRepository;

namespace Practice.Areas.Admin.Controllers
{

    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _productRepository;
        public CategoryController(ICategoryRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var categorylist = _productRepository.GetAll();
            return View(categorylist);
        }
        public IActionResult Delete(int id)
        {
            Category? categorydb = _productRepository.Get(u => u.Id == id);
            if (categorydb == null)
            {
                return NotFound();
            }
            _productRepository.Remove(categorydb);
            _productRepository.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            _productRepository.Add(obj);
            _productRepository.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Category? categoryfdb = _productRepository.Get(u => u.Id == id);
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
                _productRepository.Update(obj);
                _productRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
