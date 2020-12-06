using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using My_Blog_Site.DataAccess.Concrete.EntityFramework.Context;
using My_Blog_Site.Entities.Entities;

namespace My_Blog_Site.Helper.Extensions.Initializer
{
    public static class InitializerDbContext
    {

        public static void InitializerDb(this IApplicationBuilder builder,Boolean value)
        {

            //context.Database.EnsureCreated()
            //EnsureCreated, ilgili context için belirlenmiş database’in var olup olmadığını kontrol eder. Database var ise herhangi bir işlem yapmadan devam eder, eğer database
            //yok ise en güncel şema ile(Context’in son hali ile ilk defa add-migration yapıyormuş gibi ) database’i oluşturur.

            //context.Database.Migrate()
            //Migrate, hazır durumunda bir migration var ise bu migration’i çalıştırır. Ek olarak database’in var olup olmadığı ile de ilgililenir. Eğer hazırda migration yoksa 
            //EnsureCreated gibi Context’in son hali yani tablolarıyla ilgilenmez. Boş olarak veritabanını oluşturur.


            if (value)
            {
                using(var context = new MyBlogSiteContext()){

                    if (context.Database.EnsureCreated())
                    {

                        for(int i = 0; i <= 3; i++)
                        {
                            Category category = new Category()
                            {
                                Name = FakeData.TextData.GetAlphabetical(7)
                            };

                            context.CategoryTable.Add(category);

                            for (int j = 0; j < 5; j++)
                            {

                                Article article = new Article()
                                {
                                    Article_Content = FakeData.TextData.GetSentences(3),
                                    Article_Summary = FakeData.TextData.GetSentence(),
                                    Picture = FakeData.NameData.GetFirstName(),
                                    Publish_Date = DateTime.Now,
                                    Title = FakeData.TextData.GetAlphabetical(5),
                                    View_Count = j,
                                    Category = category

                                };

                                category.Articles.Add(article);

                                context.ArticleTable.Add(article);

                                for (int k = 0; k < 2; k++)
                                {
                                    Comment comment = new Comment()
                                    {
                                        Comment_Content = FakeData.TextData.GetSentences(2),
                                        Comment_Owner_Name = FakeData.NameData.GetFirstName(),
                                        Publish_Date = DateTime.Now,
                                        Article = article
                                    };

                                    article.Comments.Add(comment);
                                
                                    context.CommentTable.Add(comment);
                                }

                            }


                        }

                        context.SaveChanges();

                     }

                }
                

            }

        }

    }
}
