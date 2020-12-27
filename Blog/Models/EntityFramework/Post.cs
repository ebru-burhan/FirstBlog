using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//required veya stringlenght lerin yazılması için gerekli dataannotations
using System.Linq;
using System.Web;

namespace Blog.Models.EntityFramework
{
    public class Post
    {
        public int ID { get; set; }
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Bos gecilemez")]
        [StringLength(20, MinimumLength =2 , ErrorMessage = "20den fazla veya 2 den az olamaz")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagesUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Category Category { get; set; }

    }
}