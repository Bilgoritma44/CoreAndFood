using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.ViewComponents
{
    public class FoodCategory:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            FoodRepository f = new FoodRepository();
            var list = f.List(x=>x.CategoryID==id);

            return View(list);
        }
    }
}
