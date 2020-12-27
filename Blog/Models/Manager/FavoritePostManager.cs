using Blog.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models.Manager
{
    public class FavoritePostManager
    {
        //aynı işlemleri tekrar tekrar yapmamak için kullandığımz ve favori ekleme db ye gtmeyeceğinden ve controllerda save change edemeyeceğimzden veriyi nasıl tuttcaz bu yüzden manager
        //1. db deymiş gbi verileri tutacağimz bi favori listesi yapalm
        //private yapaılm ki müdahale edlmesn sadece favori post manager müdahae etsn
        private Dictionary<int, Post> _favoritePosts = new Dictionary<int, Post>();

        // public List<Post> Favorites { get; private set; }
        //bunun kolay yolu 
        public List<Post> Favorites => _favoritePosts.Values.ToList();


        public void AddPostToFavorite(Post post)
        {
            //dictionry de gelen postun ıd sine uyan bi id yoksa postu bu dictinry e ekle dedk
            
            if (_favoritePosts.ContainsKey(post.ID) == false)
            {
                _favoritePosts.Add(post.ID, post);
            }
        }

        public void DeletePostToFavorite(Post post)
        {
            //eğer postun id si dictionry de varsa dictonaryden sil postu dedik
            if (_favoritePosts[post.ID] != null)
            {
                _favoritePosts.Remove(post.ID);
            }
        }
    }
}