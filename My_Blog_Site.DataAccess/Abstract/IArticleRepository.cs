using My_Blog_Site.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Blog_Site.DataAccess.Abstract
{
    public interface IArticleRepository:IRepository<Article>
    {
    }
}
