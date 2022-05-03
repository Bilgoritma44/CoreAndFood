using CoreAndFood.Data;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Class> ProList()
        {
            List<Class> cs = new List<Class>();
            cs.Add(new Class()
            {
                proname = "Computer",
                stock = 50

            });
            cs.Add(new Class()
            {
                proname = "LCD",
                stock = 75

            });
            cs.Add(new Class()
            {
                proname = "Usb Disk",
                stock = 100

            });
            return cs;
        }
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult VisualizeFoodResult()
        {
            return Json(FoodList());
        }
        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            using (var c = new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodname = x.Name,
                    stock = x.Stock

                }).ToList();
            }

            return cs2;
        }
        public IActionResult Statistics()
        {
            Context c = new Context();

            var deger1 = c.Foods.Count();
            ViewBag.d1 = deger1;
            
            var deger2 = c.Categories.Count();
            ViewBag.d2 = deger2;

            var foid = c.Categories.Where(x => x.CategoryName == "Sebze").Select(y => y.CategoryID).FirstOrDefault();

            var deger3 = c.Foods.Where(x => x.CategoryID == foid).Count();
            ViewBag.d3 = deger3;

            var foid2 = c.Categories.Where(x => x.CategoryName == "Meyve").Select(y => y.CategoryID).FirstOrDefault();

            var deger4 = c.Foods.Where(x => x.CategoryID == foid2).Count();
            ViewBag.d4 = deger4;

            var deger5 = c.Foods.Sum(x => x.Stock);
            ViewBag.d5 = deger5;

            var foid3 = c.Categories.Where(x => x.CategoryName == "Tahıl").Select(a => a.CategoryID).FirstOrDefault();

            var deger6 = c.Foods.Where(b => b.CategoryID == foid3).Count();
            ViewBag.d6 = deger6;

            var deger7 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d7 = deger7;

            var deger8 = c.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = c.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d9 = deger9;

            var foid4 = c.Categories.Where(x => x.CategoryName == "Tahıl").Select(y => y.CategoryID).FirstOrDefault();

            var deger10 = c.Foods.Where(y => y.CategoryID == foid4).Sum(b => b.Stock);
            ViewBag.d10 = deger10;

            var foid5 = c.Categories.Where(x => x.CategoryName == "Meyve").Select(y => y.CategoryID).FirstOrDefault();

            var deger11 = c.Foods.Where(y => y.CategoryID == foid5).Sum(b => b.Stock);
            ViewBag.d11 = deger11;

            var deger12 = c.Foods.OrderByDescending(y => y.Price).Select(y => y.Name).FirstOrDefault();
            ViewBag.d12 = deger12;



            return View();
        }
    }
}
