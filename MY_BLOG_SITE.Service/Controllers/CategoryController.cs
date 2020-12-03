using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Blog_Site.Entities.Entities;
using My_Blog_Site.Interfaces;

namespace MY_BLOG_SITE.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _ICategoryService;

        public CategoryController(ICategoryService ICategoryService)
        {
            _ICategoryService = ICategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            List<Category> categoryList = await _ICategoryService.GetAll();

            return Ok(categoryList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            Category category = await _ICategoryService.Get(id);

            if (category != null)
            {
                return Ok(category);
            }

            return NotFound();
        }


    }
}
