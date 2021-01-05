using Blog_Data.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models.ViewsModels
{
    public class ListUserVm
    {
        public List<User> Users { get; set; }
    }
}