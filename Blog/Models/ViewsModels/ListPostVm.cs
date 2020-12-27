using Blog.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models.ViewsModels
{
    public class ListPostVm
    {
        public List<Post> Posts { get; set; }
        
    }
}