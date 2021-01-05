using Blog_Data.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Data.Repository
{
    public class PostRepository
    {

        BlogContext _db = new BlogContext();


        public Post GetById(int id)
        {
           return _db.Posts.Find(id);

        }

        public List<Post> GetAll()
        {
            return _db.Posts.ToList();
        }

        public void Add(Post post)
        {
            _db.Entry<Post>(post).State = System.Data.Entity.EntityState.Added;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Post post = _db.Posts.Find(id);

            if (post != null)
            {
                _db.Entry<Post>(post).State = System.Data.Entity.EntityState.Deleted;
                _db.SaveChanges();
            }

           
        }

        public void Update(Post post)
        {

            Post _post = _db.Posts.Find(post.ID);

            if (_post != null)
            {
                _post.Title = post.Title;
                _post.Description = post.Description;
                _post.Category.ID = post.Category.ID;
                _post.ImagesUrl = post.ImagesUrl;
                _post.DateCreated = post.DateCreated;
                //diğer updatelerden farklı çünkü datecreated sıkıntı çıkarıyodu ama gene bu şeklde yapmak en iyisi

                _db.Entry<Post>(_post).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

    }
}
