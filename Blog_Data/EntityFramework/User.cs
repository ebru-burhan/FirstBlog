using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_Data.Models.EntityFramework
{
    public class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Can not be empty")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Can not be empty")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Can not be empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}