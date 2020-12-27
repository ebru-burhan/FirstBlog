using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models.ViewsModels
{
    public class PostDetailVm
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string CategoryName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}