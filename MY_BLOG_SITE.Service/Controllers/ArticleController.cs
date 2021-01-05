﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Blog_Site.Entities.Entities;
using My_Blog_Site.Entities.ModelView;
using My_Blog_Site.Interfaces;

namespace MY_BLOG_SITE.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _IArticleService;
        private readonly ICategoryService _ICategoryService;
        private readonly ICommentService _ICommentService;



        public ArticleController(IArticleService IArticleService, ICategoryService ICategoryService, ICommentService ICommentService)
        {
            _IArticleService = IArticleService;
            _ICategoryService = ICategoryService;
            _ICommentService = ICommentService;
        }


        [HttpGet]
        [Route("{page}/{pageSize}")]
        public async Task<IActionResult> GetArticle(int page = 1, int pageSize = 5)
        {
            try
            {
                List<Article> articleList = await _IArticleService.GetAllArticleModel();

                int totalCount = articleList.Count();

                List<ArticleViewModel> response = articleList.Skip(pageSize * (page - 1)).Take(pageSize).ToList()
                                                  .Select(x => new ArticleViewModel()
                                                  {

                                                      Id = x.Id,
                                                      Title = x.Title,
                                                      Article_Content = x.Article_Content,
                                                      Article_Summary = x.Article_Summary,
                                                      Picture = x.Picture,
                                                      Publish_Date = x.Publish_Date,
                                                      View_Count = x.View_Count,
                                                      Comment_Count = x.Comments.Count,
                                                      Category = new CategoryViewModel()
                                                      {
                                                          Id = x.Category.Id,
                                                          Name = x.Category.Name
                                                      }

                                                  }).ToList();

                var result = new { TotalCount = totalCount, Response = response };

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            List<Article> articleList =  await _IArticleService.GetAllArticleModel();

            Article article = articleList.Find(x => x.Id == id);

            if(article != null)
            {
                ArticleViewModel articleViewModel = new ArticleViewModel()
                {
                    Id = article.Id,
                    Title = article.Title,
                    Article_Summary = article.Article_Summary,
                    Article_Content = article.Article_Content,
                    Picture = article.Picture,
                    Publish_Date = article.Publish_Date,
                    View_Count = article.View_Count,
                    Category = new CategoryViewModel()
                    {
                        Id = article.Category.Id,
                        Name = article.Category.Name
                    },
                    Comment_Count = article.Comments.Count
                };
                return Ok(articleViewModel);
            }

            return NotFound();

        }


    }
}
