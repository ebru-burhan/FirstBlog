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
    public class CategoryController : Controller
    {
        // GET: Category

        BlogContext _db = new BlogContext();

        public ActionResult Index()
        {
            ListCategoryVm model = new ListCategoryVm()
            {
                Categories = _db.Categories.ToList()
            };
            return View(model);
        }



        [HttpGet]
        public ActionResult AddCategory()
        {

            return View(new Category());
        }


        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                Category c = new Category();
                return View(c);
            }
            _db.Entry<Category>(category).State = System.Data.Entity.EntityState.Added;
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}