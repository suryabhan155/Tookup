using BLL;
using BOL.ViewModels;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Web.Http;
using TookUp.BOL.ViewModels.CommonModels;
using UI.Areas.Common.Controllers;
using UI.Areas.User.Data;

namespace UI.Areas.User.Controllers
{
    public class LoginController : ApiController
    {
        HttpResponseMessage responsemsg = null;
        ResponseModel response;
        UserBs user_obj;
        //string url = "http://localhost:44325/";
        string url = "http://tookup.in/";
        public LoginController()
        {
            response = new ResponseModel();
            user_obj = new UserBs();
        }

        [HttpPost]
        [Route("api/user/login")]
        public HttpResponseMessage LoginUser(LoginViewModel model)
        {
            Dictionary<string, string> tokenDetails = null;
            try
            {
                using (var client = new HttpClient())
                {
                    var login = new Dictionary<string, string>
                    {
                       {"grant_type", "password"},
                       {"username",model.Username},
                       {"password", model.Password},
                    };
                    var resp = client.PostAsync(url + "token", new FormUrlEncodedContent(login));
                    resp.Wait(TimeSpan.FromSeconds(10));
                    tokenDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(resp.Result.Content.ReadAsStringAsync().Result);
                    
                    if (resp.Result.StatusCode == HttpStatusCode.OK)
                    {
                        response.success = true;
                        response.message = "SUCCESS";
                        response.data = new { tokenDetails, model.Username};
                        response.Status_Code = 200;
                        responsemsg = Request.CreateResponse(response);
                    }
                    else
                    {
                        response.success = false;
                        response.message = "Invalid Email ID or Password.";
                        response.data = new { tokenDetails, model.Username };
                        response.Status_Code = 3;
                        responsemsg = Request.CreateResponse(response);
                    }
                    return responsemsg;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.Status_Code = 400;
                response.data = new { };
                responsemsg = Request.CreateResponse(response);
            }
            //return ToJson(new { tokenDetails = tokenDetails });
            return responsemsg;
        }

        [Route("api/user/add")]
        [HttpPost]
        public HttpResponseMessage AddUser(BOL.User user)
        {
            try
            {
                response = null;
                if (ModelState.IsValid)
                {
                    response = user_obj.Insert(user);
                }
                ModelState.AddModelError("", "Error");
            }
            catch (HttpResponseException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent(ex.Message) });
            }
            responsemsg = Request.CreateResponse(response);
            return responsemsg;
            //return ToJson(response);
        }
        // send otp to mail
        [Route("api/user/sendotpmail")]
        [HttpPost]
        public HttpResponseMessage Sendotpmail(OTP model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    response = user_obj.SendMail(model);
                }
                else
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Please check something is wrong") });
                }
            }
            catch (HttpResponseException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent(ex.Message) });
            }
            responsemsg = Request.CreateResponse(response);
            return responsemsg;
        }

        // send otp to mobile
        [Route("api/user/sendsmsotp")]
        [HttpPost]
        public HttpResponseMessage Sendsmsotp(OTP model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    response = user_obj.SendSMS(model);
                }
            }
            catch (Exception ex)
            {
                response.message= ex.Message;
                response.data = new { };
            }
            responsemsg = Request.CreateResponse(response);
            return responsemsg;
        }

        //get user info
        [Route("api/user/userinfo/{id}")]
        [HttpGet]
        public HttpResponseMessage UserInfo(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    response = user_obj.GetUserInfo(id);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.data = new { };
            }
            responsemsg = Request.CreateResponse(response);
            return responsemsg;
        }

        //get user list
        [Route("api/user/userlist")]
        [HttpGet]
        public HttpResponseMessage UserList()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    response = user_obj.GetUserList();
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.data = new { };
            }
            responsemsg = Request.CreateResponse(response);
            return responsemsg;
        }
    }
}
