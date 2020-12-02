using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using My_Blog_Site.Interfaces;


namespace My_Blog_Site.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _ICategoryService;

        CategoryController(ICategoryService ICategoryService)
        {
            _ICategoryService = ICategoryService;
        }

        public IActionResult Index()
        {
      
            return View();
        }
    }
}
