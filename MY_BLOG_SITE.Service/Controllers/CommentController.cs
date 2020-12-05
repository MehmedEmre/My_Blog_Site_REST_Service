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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _ICommentService;

        public CommentController(ICommentService ICommentService)
        {
            _ICommentService = ICommentService;
        }

    }
}
