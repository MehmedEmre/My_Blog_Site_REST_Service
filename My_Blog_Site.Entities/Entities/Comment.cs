using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace My_Blog_Site.Entities.Entities
{
    public class Comment
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [StringLength(50),Required]
        public string Comment_Owner_Name { get; set; }

        [MaxLength, Required]
        public string Comment_Content{ set; get; }

        [Required]
        public DateTime Publish_Date { set; get; }

        public Article _Article { set; get; }

    }
}
