using Blog.Models.Manager;
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
    
    public class AdminController : Controller
    {
        // GET: Admin
        //BlogContext _db = new BlogContext();
        UserRepository _userRepo = new UserRepository();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(User user)
        {

            VmUserLogin model = new VmUserLogin()
            {
                User = _userRepo.GetAll().FirstOrDefault(z => z.UserName == user.UserName && z.Password == user.Password)
        };

            if (model.User != null)
            {
                Session["loginUser"] = model.User;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //ViewBag.LoginError = "Hatalı kullancı veya şifre girişi";
                ModelState.AddModelError("", "Kullanıcı adı veya sifre yanlıstir");
                return View();
            }
            
        }


        [HttpGet]
        public ActionResult Logout()
        {
            if (Session["loginUser"] != null)
            {
                Session.Remove("loginUser");
            }

            return View("Login");
        }


    }
}