using Blog_Data.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Data.Repository
{
    public class CategoryRepository
    {
        BlogContext _db = new BlogContext();

        public Category  GetById(int id)
        {
            return _db.Categories.Find(id);
        }

        public List<Category> GetAll()
        {
            return _db.Categories.ToList();
        }

        public void Add(Category category)
        {
            _db.Entry<Category>(category).State = System.Data.Entity.EntityState.Added;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = _db.Categories.Find(id);
            if (category != null)
            {
                _db.Entry<Category>(category).State = System.Data.Entity.EntityState.Deleted;
                _db.SaveChanges();
            }        
        }

        public void Update(Category category)
        {
            Category _category = _db.Categories.Find(category.ID);
            if (_category != null)
            {
                _category.Name = category.Name;
                _db.Entry<Category>(_category).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

    }
}
