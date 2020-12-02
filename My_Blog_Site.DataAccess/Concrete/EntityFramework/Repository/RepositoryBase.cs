using My_Blog_Site.DataAccess.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Blog_Site.DataAccess.Concrete.EntityFramework.Repository
{
    public class RepositoryBase
    {
        protected static MyBlogSiteContext db;
        private static object _lockSync = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            if(db == null)
            {
                lock (_lockSync)
                {
                    db = new MyBlogSiteContext();
                }               
            }
        }

    }
}
