using My_Blog_Site.Buisness.Abstract;
using My_Blog_Site.DataAccess.Abstract;
using My_Blog_Site.DataAccess.Concrete.EntityFramework.Repository;
using My_Blog_Site.Entities.Entities;
using My_Blog_Site.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace My_Blog_Site.Buisness.Concrete
{
    public class CategoryManager:ManagerBase<Category>, ICategoryService
    {

        private readonly ICategoryRepository _ICategoryRepository;

        public CategoryManager(ICategoryRepository ICategoryRepository) :base(ICategoryRepository)
        {
            _ICategoryRepository = ICategoryRepository;
            
        }

    }
}
