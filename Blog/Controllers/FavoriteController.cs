using Blog.Models.Attributes;
using Blog.Models.EntityFramework;
using Blog.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    [UserAuthorize]
    public class FavoriteController : Controller
    {

        BlogContext _db = new BlogContext();

        [HttpGet]
        public ActionResult Index()
        {
            //bu şuan null instance almadık
            FavoritePostManager favoritePostManager;
            if (Session["favPost"] != null)
            {
                favoritePostManager = Session["favPost"] as FavoritePostManager;
            }
            else
            {
                favoritePostManager = new FavoritePostManager();
            }

            List<Post> favorilerim = favoritePostManager.Favorites;
            return View(favorilerim);
        }



        //-------------------------------favorileme işelmleri-------------------------------


        [HttpGet]
        public ActionResult AddPostToFavorites(int id)
        {
            FavoritePostManager favoritePostManager;
            if (Session["favPost"] != null)
            {
                favoritePostManager = Session["favPost"] as FavoritePostManager;
            }
            else
            {
                favoritePostManager = new FavoritePostManager();
            }
            Post post = _db.Posts.Find(id);

            favoritePostManager.AddPostToFavorite(post);
            Session["favPost"] = favoritePostManager;

            return RedirectToAction("Index", "Home");
            //nameof la dene
        }

        [HttpGet]
        public ActionResult DeletePostFromFavorites(int id)
        {
            FavoritePostManager favoritePostManager;
            if (Session["favPost"] != null)
            {
                favoritePostManager = Session["favPost"] as FavoritePostManager;
            }
            else
            {
                favoritePostManager = new FavoritePostManager();
            }
            Post post = favoritePostManager.Favorites.FirstOrDefault(x => x.ID == id);
            if (post != null)
            {
                favoritePostManager.DeletePostToFavorite(post);
            }
            Session["favPost"] = favoritePostManager;
            return RedirectToAction(nameof(Index));
        }
        ///////////////////////////////////////////////////////////////////////////////////////

    }
}