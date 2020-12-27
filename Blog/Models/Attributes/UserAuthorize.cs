using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Models.Attributes
{
    public class UserAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["loginUser"] != null)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/Admin/Login");
                return false;
            }
        }
    }
}