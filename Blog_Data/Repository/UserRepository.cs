using Blog_Data.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Data.Repository
{
     public class UserRepository
    {
        BlogContext _db = new BlogContext();

        public User GetById(int id)
        {
            return _db.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public void Add(User user)
        {
            _db.Entry<User>(user).State = System.Data.Entity.EntityState.Added;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = _db.Users.Find(id);
            if (user != null)
            {
                _db.Entry<User>(user).State = System.Data.Entity.EntityState.Deleted;
                _db.SaveChanges();
            }
        }

        public void Update(User user)
        {
            User _user = _db.Users.Find(user.ID);
            if (_user != null)
            {
                _user.UserName = user.UserName;
                _user.Password = user.Password;
                _user.Email = user.Email;
                _db.Entry<User>(_user).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}
