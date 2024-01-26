using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;
using Practice.Data;
using Practice.Models;
using Practice.Repository.IRepository;
using Practice.ViewModel;
namespace Practice.Areas.Admin.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
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
            Product? categorydb = _productRepository.Get(u=>u.Id==id);
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
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(obj);
                _productRepository.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int id)
        {
            Product? categoryfdb = _productRepository.Get(u => u.Id == id);
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
                _productRepository.Update(obj);
                _productRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
