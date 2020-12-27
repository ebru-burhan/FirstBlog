using Blog.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models.ViewsModels
{
    public class PostManipulationVm
    {
        public Post Post { get; set; }

        //dropdowwnList de hepsini göstermemez lazm ondan list 
        public List<Category> Categories { get; set; }
    }
}