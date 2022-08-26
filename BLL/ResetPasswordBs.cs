using BOL.ViewModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TookUp.BOL.ViewModels.CommonModels;

namespace BLL
{
    public class ResetPasswordBs
    {
        private ResetPasswordDb resetPassword;
        public ResetPasswordBs()
        {
            resetPassword = new ResetPasswordDb();
        }
        public bool ForgotPassword(ResetPass reset)
        {
           return resetPassword.ForgotPassword(reset);
        }

        public string ResetPassword(ForgetPassword forgetPassword)
        {
           return resetPassword.ResetPassword(forgetPassword);
        }
    }
}
