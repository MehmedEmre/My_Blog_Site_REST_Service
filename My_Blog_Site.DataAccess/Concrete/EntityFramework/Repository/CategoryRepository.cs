﻿using My_Blog_Site.DataAccess.Abstract;
using My_Blog_Site.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace My_Blog_Site.DataAccess.Concrete.EntityFramework.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository()
        {
        
        }

       
    }
}
