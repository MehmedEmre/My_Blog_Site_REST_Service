using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Blog_Site.Entities.Entities
{
    public class Article
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(500), Required]
        public string Article_Summary { get; set; }

        [MaxLength, Required]
        public string Article_Content { get; set; }

        [Required]
        public DateTime Publish_Date { set; get; }

        [StringLength(300)]
        public string Picture { set; get; }

        [Required]
        public int View_Count { set; get; }

        public Category Category { set; get; }

        public List<Comment> Comments { set; get; }

        public Article()
        {
            Comments = new List<Comment>();
        }

    }
}
