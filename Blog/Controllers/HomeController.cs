using Blog.Models.Attributes;
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
    
    public class HomeController : Controller
    {    // kullnamadn oluşmuyor sqlde db, bu yüzden kullandık nasıl kullnaırsan kullan önmli değil
        BlogContext _db = new BlogContext();

        [HttpGet]
        public ActionResult Index()
        {
            ListPostVm model = new ListPostVm
            {
                Posts = _db.Posts.ToList()
            };
            return View(model);

            /*
           List<Post> posts = _db.Posts.Include("Category").ToList();

           // List<Post> posts = db.Posts.ToList();
            return View(posts);
            */
        }

        [UserAuthorize]
        [HttpGet]
        public ActionResult AddPost()
        {
            

            PostManipulationVm model = new PostManipulationVm
            {
                Post = new Post(),
                Categories = _db.Categories.ToList()
            };

            return View(model);
        }


        [UserAuthorize]
        [HttpPost]
        public ActionResult AddPost(Post post)
        {
            //ModelState.IsValid dedigmizde yazdimgiz sartlari karsiliyorsa demis oluyoruz ama basina unlem ! koydugmuzda bu olumsuz oluyor ve verdimgiz sartlar saglanmiyorsa demis oluyoz
            if (!ModelState.IsValid)
            {
                //eger sart saglanmiyorsa ozaman ayni sayfaya ayni bilgilerle donmesini sagliyoruz ve bu sefer sayfa acilirken uyari mesajlari yani validation message'larda calismis olur

                PostManipulationVm model = new PostManipulationVm
                {
                    Post = new Post(),
                    Categories = _db.Categories.ToList()
                };

                return View(model);
            }

            // _db.Posts.Add(post);
            post.DateCreated = DateTime.Now;
            _db.Entry<Post>(post).State = System.Data.Entity.EntityState.Added;
            _db.SaveChanges();

            return RedirectToAction("Index");

            //View ise direkt o view'e gider ve o view calismadan once model'in doldurlmasi gekirse hatali calisir
            //return View();
        }



        [HttpGet]
        public ActionResult PostDetail(int id)
        {
            Post post = _db.Posts.Find(id);
            PostDetailVm model = new PostDetailVm()
            {
                Title = post.Title,
                Description = post.Description,
                CategoryName = post.Category.Name,
                DateCreated = post.DateCreated
            };

            return View(model);
        }

        [UserAuthorize]
        [HttpGet]
        public ActionResult EditPost(int id)
        {
            PostManipulationVm model = new PostManipulationVm()
            {
                Post = _db.Posts.Find(id),
                Categories = _db.Categories.ToList()
            };

            return View(model);
        }

        [UserAuthorize]
        [HttpPost]
        public ActionResult EditPost(Post post)
        {
            Post _post = _db.Posts.Find(post.ID);

            if (!ModelState.IsValid)
            {
                PostManipulationVm model = new PostManipulationVm()
                {
                    Post = _post,
                    Categories = _db.Categories.ToList()
                };

                return View(model);
            }

            //bunu yazmadığımzda datecreated değrini korumuyo edtte default yani null gbi bişi geliyo
            _post.CategoryId = post.CategoryId;
            _post.Title = post.Title;
            _post.ImagesUrl = post.ImagesUrl;
            _post.Description = post.Description;

            _db.Entry<Post>(_post).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



        //[HttpPost]
        //public ActionResult EditPost(Post post)
        //{


        //    if (!ModelState.IsValid)
        //    {
        //        PostManipulationVm model = new PostManipulationVm()
        //        {
        //            Post =_db.Posts.Find(post.ID),
        //        Categories = _db.Categories.ToList()
        //        };

        //        return View(model);
        //    }

        //    //bildiğimz gbi yaptığımızda datetime da null geliyo yani editte add işlemnde elde edilen date tutulamıyo null oluyor
        //    //öncesinde dolu  olan veri edit işlemnde eğer onu editlemiyorsak view de göstermiyorsak edtten sonra null oluyo??? wtf   bunn için yukardaki gbi geleni elle dbdekine atıyoz ve dbdekini savechange ediyoz yukarda bunn için outomapperlar varmş değerleri eşitlesin diye bakmak lazm
        //    _db.Entry<Post>(post).State = System.Data.Entity.EntityState.Modified;
        //    _db.SaveChanges();

        //    return RedirectToAction(nameof(Index));
        //}

        [UserAuthorize]
        [HttpGet]
        public ActionResult DeletePost(int id)
        {
            Post post = _db.Posts.Find(id);

            _db.Entry<Post>(post).State = System.Data.Entity.EntityState.Deleted;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

     
    }
}