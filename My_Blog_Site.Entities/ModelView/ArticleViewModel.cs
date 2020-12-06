using System;
using System.Collections.Generic;
using System.Text;

namespace My_Blog_Site.Entities.ModelView
{
    public class ArticleViewModel
    {
        public int Id { set; get; }

        public string Title { get; set; }

        public string Article_Summary { get; set; }

        public string Article_Content { get; set; }

        public DateTime Publish_Date { set; get; }

        public string Picture { set; get; }

        public int View_Count { set; get; }

        public int Comment_Count { set; get; }

        public CategoryViewModel Category { set; get; }

    }
}
