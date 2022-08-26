using BLL;
using BOL.ViewModels;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TookUp.BOL.ViewModels.CommonModels;

namespace UI.Areas.Account.Controllers
{
    
   
    public class ForgetPasswordController : ApiController
    {
        HttpResponseMessage responsemsg = null;
        ResponseModel response;
        ResetPasswordApiCLassBs resetPassword_obj;
        //string url = "http://localhost:44325/";
        string url = "http://tookup.in/";
        public ForgetPasswordController()
        {
            response = new ResponseModel();
            resetPassword_obj = new ResetPasswordApiCLassBs();
        }

        // send resetpassword link
        [Authorize]
        [HttpPost]
        [Route("api/password/reset")]
        public HttpResponseMessage ResetPassword(ResetPass reset)
        {
            try
            {
                response = null;
                if (ModelState.IsValid)
                {
                    response = resetPassword_obj.ForgotPassword(reset);
                }
                
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.Status_Code = 400;
                response.data = new { };
            }
            responsemsg = Request.CreateResponse(response);
            return responsemsg;
        }

        // change password 
        [Authorize]
        [HttpPost]
        [Route("api/password/update")]
        public HttpResponseMessage ForgetPassword(ForgetPassword forget)
        {
            try
            {
                response = null;
                if (ModelState.IsValid)
                {
                    response = resetPassword_obj.ResetPassword(forget);
                }

            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.Status_Code = 400;
                response.data = new { };
            }
            responsemsg = Request.CreateResponse(response);
            return responsemsg;
        }
    }
}
