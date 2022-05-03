using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository cat = new CategoryRepository();
        Context c = new Context();
        public IActionResult Index(string p)
        {
            if(!string.IsNullOrEmpty(p))
            {
                return View(cat.List(x => x.CategoryName == p));
            }

            return View(cat.List());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category c)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }

            cat.Add(c);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var dgr = c.Categories.Find(id);
            cat.Delete(dgr);

            return RedirectToAction("Index");
        }
        public IActionResult CategoryGetir(int id)
        {
            var dgr = cat.Get(id);
            return View("CategoryGetir", dgr);
        }
        public IActionResult Update(Category c)
        {
            var dgr = cat.Get(c.CategoryID);
            dgr.CategoryName = c.CategoryName;
            dgr.CategoryDescription = c.CategoryDescription;
            cat.Update(dgr);
            return RedirectToAction("Index");
        }
    }
}
