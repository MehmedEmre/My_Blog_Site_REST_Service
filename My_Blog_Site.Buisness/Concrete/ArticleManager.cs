using My_Blog_Site.Buisness.Abstract;
using My_Blog_Site.DataAccess.Abstract;
using My_Blog_Site.Entities.Entities;
using My_Blog_Site.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Blog_Site.Buisness.Concrete
{
    public class ArticleManager:ManagerBase<Article>,IArticleService
    {

        private readonly IArticleRepository _IArticleRepository;

        public ArticleManager(IArticleRepository IArticleRepository):base(IArticleRepository)
        {
            _IArticleRepository = IArticleRepository;
        }

    }
}
