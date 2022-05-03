using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.ViewComponents
{
    public class FoodList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FoodRepository f = new FoodRepository();
            var list = f.List();

            return View(list);
        }
    }
}
