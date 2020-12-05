using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using My_Blog_Site.Buisness.Concrete;
using My_Blog_Site.DataAccess.Abstract;
using My_Blog_Site.DataAccess.Concrete.EntityFramework.Context;
using My_Blog_Site.DataAccess.Concrete.EntityFramework.Repository;
using My_Blog_Site.Interfaces;

namespace MY_BLOG_SITE.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //CORS Configuration
            services.AddCors(c => {

                c.AddDefaultPolicy(x => {

                    x.SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                    //Tüm originlere -- Tüm headerlara -- Tüm metod isteklerine(put post) -- Tüm kimlik doðrulama yöntemlerine(Örn:JWT)
                    //izin ver

                });

            });
            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();

            services.AddSingleton<ICommentService, CommentManager>();
            services.AddSingleton<ICommentRepository, CommentRepository>();

            services.AddSingleton<IArticleService, ArticleManager>();
            services.AddSingleton<IArticleRepository, ArticleRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //CORS Configuration
            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
