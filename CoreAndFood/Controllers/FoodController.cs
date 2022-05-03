using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository fd = new FoodRepository();
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {

            return View(fd.List("Category").ToPagedList(page, 3));
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> deger = (from x in c.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();

            ViewBag.dgr = deger;

            return View();
        }
        [HttpPost]
        public IActionResult Add(Food f)
        {

            fd.Add(f);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var dgr = c.Foods.Find(id);
            fd.Delete(dgr);
            return RedirectToAction("Index");
        }
        public IActionResult FoodGetir(int id)
        {
            List<SelectListItem> deger = (from x in c.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();

            ViewBag.dgr = deger;

            var dgr = fd.Get(id);
            return View("FoodGetir", dgr);
        }
        public IActionResult Update(Food f)
        {
            var x = fd.Get(f.FoodID);
            x.Name = f.Name;
            x.ShortDescription = f.ShortDescription;
            x.Price = f.Price;
            x.ImageUrl = f.ImageUrl;
            x.Stock = f.Stock;
            x.CategoryID = f.CategoryID;

            fd.Update(x);
            return RedirectToAction("Index");
        }
    }
}
