using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_Data.Models.EntityFramework
{
    public class Category
    {
        public int ID{ get; set; }

        [Required(ErrorMessage ="Bos gecilemez")]
        [StringLength(20, ErrorMessage ="Name i en fazla 20 karakter olabilir")]
        public string Name { get; set; }


    }
}