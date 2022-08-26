using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.User.Data
{
    public class UserViewModel
    {
        public int UserID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        public string AccountID { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Telephone { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Photo { get; set; }
        public string Body { get; set; }
        public bool Status { get; set; }

        public int ModifiedBy { get; set; }
        public DateTime CreateByDate { get; set; }
    }
}