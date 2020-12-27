using Blog.Models.EntityFramework;
using Blog.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class UserController : Controller
    {
        BlogContext _db = new BlogContext();

        [HttpGet]
        public ActionResult Index()
        {
            ListUserVm model = new ListUserVm()
            {
                Users = _db.Users.ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            UserManipulationVm model = new UserManipulationVm()
            {
                User = new User()
            };

            return View(model);
        }
    }
}