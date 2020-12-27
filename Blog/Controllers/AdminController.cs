using Blog.Models.EntityFramework;
using Blog.Models.Manager;
using Blog.Models.ViewsModels;
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
        BlogContext _db = new BlogContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(User user)
        {
 
            BlogContext db = new BlogContext();
            VmUserLogin model = new VmUserLogin()
            {
                User = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password)
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