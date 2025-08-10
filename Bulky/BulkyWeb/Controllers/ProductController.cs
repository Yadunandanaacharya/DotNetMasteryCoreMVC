using BulkyWeb.Data;
using BulkyWeb.Models;
using BulkyWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository db)
        {
            _productRepo = db;
        }

        public IActionResult Index()
        {
            List<Product> objCategoryList = _productRepo.GetAll().ToList();
            return View(objCategoryList);
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
                _productRepo.Add(obj);
                _productRepo.Save(obj); 
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Product? prodFromDb = _productRepo.Get(u => u.Id == id);
            //Product? categoryFromDb1 = _productRepo.Categories.FirstOrDefault(u=> u.Id == id);
            //Product? categoryFromDb2 = _productRepo.Categories.Where(u => u.Id == id).FirstOrDefault();
            if(prodFromDb == null)
            {
                return NotFound();
            }

            return View(prodFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            
            if (ModelState.IsValid)
            {
                _productRepo.Update(obj);
                _productRepo.Save(obj);
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Product? prodFromDb = _productRepo.Get(u => u.Id == id);
            if (prodFromDb == null)
            {
                return NotFound();
            }

            return View(prodFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = _productRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _productRepo.Remove(obj);
            _productRepo.Save(obj);
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }


    }
}
