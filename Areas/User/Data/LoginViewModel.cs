using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.User.Data
{
    public class LoginViewModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string AccountID { get; set; }
    }
}