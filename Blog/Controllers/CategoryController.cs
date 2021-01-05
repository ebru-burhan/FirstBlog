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
    public class CategoryController : Controller
    {
        // GET: Category
        //kullanmıyoz db den direk repodan erişiyoz
        //BlogContext _db = new BlogContext();


        CategoryRepository _categoryRepo = new CategoryRepository();

        public ActionResult Index()
        {
            ListCategoryVm model = new ListCategoryVm()
            {
                Categories = _categoryRepo.GetAll()
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
                return View(new Category());
            }
            _categoryRepo.Add(category);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            CategoryManipulationVm model = new CategoryManipulationVm()
            {
                Category = _categoryRepo.GetById(id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            _categoryRepo.Update(category);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            Category category = _categoryRepo.GetById(id);

            _categoryRepo.Delete(category.ID);
            return RedirectToAction(nameof(Index));
        }

    }
}