using BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Windows.Forms;
using TookUp.BOL.ViewModels.CommonModels;
using UI.Areas.Chatting.Data;

namespace UI.Areas.Chatting.Controllers
{
    public class CameraController : ApiController
    {
        HttpResponseMessage responsemsg = null;
        ResponseModel response;
        ChattingBs chat_obj;
        //DarrenLee.Media.Camera cameraobj = new DarrenLee.Media.Camera();
        string url = "http://localhost:44377/";
        //string url = "http://tookup.in/";

        #region Render Camera
        [Route("api/Camera/Open1")]
        [HttpPost]
        public HttpResponseMessage OpenCamera()
        {
            try
            {
                response = null;
                if (ModelState.IsValid)
                {
                    
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            responsemsg = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, response);
            return responsemsg;
        }
        // List of Video Devices Available.
        [Route("api/Camera/open")]
        [HttpPost]
        public HttpResponseMessage GetVideoDevice()
        {
            try
            {
                response = null;
                List<string> videodevice = null;
                //videodevice = cameraobj.GetCameraSources();
                if (videodevice.Count == 0)
                {
                    response.message = "No Video Devices";
                    response.data = null;
                    response.success = true;
                }
                else
                {
                    response.message = "List of Video Devices";
                    response.data = videodevice;
                    response.success = true;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.data = "";
                response.success = false;
            }
            responsemsg = Request.CreateResponse(response);
            return responsemsg;
        }

       
        #endregion
    }
}
