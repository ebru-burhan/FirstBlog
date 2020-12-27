using Blog.Models.Attributes;
using Blog.Models.EntityFramework;
using Blog.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    [UserAuthorize]
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

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                UserManipulationVm model = new UserManipulationVm()
                {
                    User = new User()
                };

                return View(model);
            }


            _db.Entry<User>(user).State = System.Data.Entity.EntityState.Added;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public ActionResult EditUser(int id)
        {
            UserManipulationVm model = new UserManipulationVm()
            {
                User = _db.Users.Find(id)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (!ModelState.IsValid)
            {
                UserManipulationVm model = new UserManipulationVm()
                {
                    User = _db.Users.Find(user.ID)
                };
                return View(model);
            }

            _db.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            User user = _db.Users.Find(id);

            _db.Entry<User>(user).State = System.Data.Entity.EntityState.Deleted;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}