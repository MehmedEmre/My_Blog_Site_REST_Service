using My_Blog_Site.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Blog_Site.Interfaces
{
    public interface IArticleService:IRepositoryService<Article>
    {
    }
}
