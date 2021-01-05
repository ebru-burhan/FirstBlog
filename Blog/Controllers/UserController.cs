using Blog.Models.Attributes;
using Blog.Models.ViewsModels;
using Blog_Data.Models.EntityFramework;
using Blog_Data.Repository;
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
        //BlogContext _db = new BlogContext();

        UserRepository _userRepo = new UserRepository();

        [HttpGet]
        public ActionResult Index()
        {
            ListUserVm model = new ListUserVm()
            {
                Users = _userRepo.GetAll()
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


            _userRepo.Add(user);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public ActionResult EditUser(int id)
        {
            UserManipulationVm model = new UserManipulationVm()
            {
                User = _userRepo.GetById(id)
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
                    User = _userRepo.GetById(user.ID)
                };
                return View(model);
            }

            _userRepo.Update(user);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            User user = _userRepo.GetById(id);

            _userRepo.Delete(user.ID);
            return RedirectToAction(nameof(Index));
        }
    }
}