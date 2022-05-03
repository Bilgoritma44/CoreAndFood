using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.ViewComponents
{

    public class CategoryList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository c = new CategoryRepository();

            var cat = c.List();
            return View(cat);
        }
    }
}
