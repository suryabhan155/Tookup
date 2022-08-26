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
    public class ResetPasswordApiCLassBs
    {
        private ResetPasswordApiCLassDb resetpassword_obj;
        public ResetPasswordApiCLassBs()
        {
            resetpassword_obj = new ResetPasswordApiCLassDb();
        }
        public ResponseModel ForgotPassword(ResetPass reset)
        {
            return resetpassword_obj.ForgotPassword(reset);
        }
        public ResponseModel ResetPassword(ForgetPassword password)
        {
            return resetpassword_obj.ResetPassword(password);
        }
    }
}
