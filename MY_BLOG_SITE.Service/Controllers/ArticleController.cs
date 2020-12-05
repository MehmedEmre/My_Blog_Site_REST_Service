using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Blog_Site.Interfaces;

namespace MY_BLOG_SITE.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _IArticleService;

        public ArticleController(IArticleService IArticleService)
        {
            _IArticleService = IArticleService;
        }


    }
}
