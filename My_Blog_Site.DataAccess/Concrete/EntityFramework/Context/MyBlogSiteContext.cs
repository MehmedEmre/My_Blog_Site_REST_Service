using Microsoft.EntityFrameworkCore;
using My_Blog_Site.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Blog_Site.DataAccess.Concrete.EntityFramework.Context
{
    public class MyBlogSiteContext:DbContext
    {
        public DbSet<Article> ArticleTable { set; get; }
        public DbSet<Category> CategoryTable { set; get; }
        public DbSet<Comment> CommentTable { set; get; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-D6E78MU\\SQLEXPRESS; database=MyBlogSite ;integrated security=true;");
        }

     

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
