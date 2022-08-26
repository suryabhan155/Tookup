using BLL;
using BOL;
using BOL.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TookUp.BOL.Utils;

namespace UI.Areas.Account.Controllers
{
    public class ResetPasswordController : Controller
    {
        private ResetPasswordBs resetPassword;
        public ResetPasswordController()
        {
            resetPassword = new ResetPasswordBs();
        }
        // GET: Account/ResetPassword
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Index(ResetPass reset)
        {
            var result="";
            bool Ismail;
            try
            {
                if (ModelState.IsValid)
                {
                    Ismail = resetPassword.ForgotPassword(reset);
                    if (Ismail == true)
                    {
                        result = reset.Email;

                    }
                    else
                    {
                        result = "2";
                    }

                }
                ModelState.AddModelError("", "Error");
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ForgetPassword(string id)
        {
            try
            {
                string idd = Encryption.DecryptString(id);
                int userid = Convert.ToInt32(idd);
                using (var db = new TookupDBEntities())
                {
                    BOL.User user = db.Users.Find(userid);
                    var getuser = db.Users.FirstOrDefault(p => p.UserID == userid);
                    if (user == null)
                    {
                        return HttpNotFound();
                    }
                    return View(user);
                }
            }
            catch (Exception ex)
            { 
            
            }
            return View();
        }
        [HttpPost]
        public JsonResult ForgetPassword(ForgetPassword forgetPassword)
        {
            var result = "";
            try
            {
                if (ModelState.IsValid)
                {
                    result = resetPassword.ResetPassword(forgetPassword);
                }
            }
            catch (Exception ex)
            {
                result = "4";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [HttpGet]
        public ActionResult Setup()
        {
            return View();
        }
    }
}