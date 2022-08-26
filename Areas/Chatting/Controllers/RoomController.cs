using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TookUp.BOL.ViewModels.CommonModels;

namespace UI.Areas.Chatting.Controllers
{
    public class RoomController : ApiController
    {
        HttpResponseMessage responsemsg = null;
        ResponseModel response;
        ChattingBs chat_obj;
        //string url = "http://localhost:44377/";
        string url = "http://tookup.in/";
        public RoomController()
        {
            response = new ResponseModel();
            chat_obj = new ChattingBs();
        }

        #region Meeting
        /// <summary>
        /// create a new room
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost]
        public HttpResponseMessage CreateRoom(MeetingRoom meeting)
        {
            try
            {
                response = null;
                if (ModelState.IsValid)
                {
                    response = chat_obj.CreateRoom(meeting);
                }
            }
            catch (Exception ex)
            {
                //throw new HttpResponseException(HttpStatusCode.InternalServerError);
                response.message = ex.Message;
            }
            responsemsg = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, response);
            return responsemsg;
        }
        /// <summary>
        /// join the created room
        /// </summary>
        /// <param name="participant"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage JoinMeeting(ParticipantDetail participant)
        {
            try
            {
                response = null;
                if (ModelState.IsValid)
                {
                    response = chat_obj.JoinMeeting(participant);
                }
            }
            catch (Exception ex)
            {
                //throw new HttpResponseException(HttpStatusCode.InternalServerError);
                response.message = ex.Message;
            }
            responsemsg = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, response);
            return responsemsg;
        }

        #endregion

        /// <summary>
        /// post session description protocols
        /// </summary>
        /// <param name="sdp"></param>
        /// <returns></returns>
        #region SDP Messages

        [HttpPost]
        public HttpResponseMessage PostSDP(SdpMessage sdp)
        {
            try
            {
                if (sdp.MeetingId != "" && sdp.SenderId != "" && sdp.Sdp != "" && sdp.MeetingId != null && sdp.SenderId != null && sdp.Sdp != null)
                {
                    response = null;
                    if (ModelState.IsValid)
                    {
                        response = chat_obj.PostSDP(sdp);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }
            responsemsg = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, response);
            return responsemsg;
        }

        /// <summary>
        /// get session description protocols
        /// </summary>
        /// <param name="sdp"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetSDP(SdpMessage sdp)
        {
            try
            {
                if (sdp.MeetingId != "" && sdp.SenderId != "" && sdp.Sdp != "" && sdp.MeetingId != null && sdp.SenderId != null && sdp.Sdp != null)
                {
                    response = null;
                    response = chat_obj.GetSDP(sdp);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }
            responsemsg = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, response);
            return responsemsg;
        }

        #endregion

        /// <summary>
        /// post ice candidate
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        #region ICE Candidates

        [HttpPost]
        public HttpResponseMessage PostICE(CandidateTable candidate)
        {
            try
            {
                if (candidate.SenderId != "" && candidate.SenderId != null && candidate.MeetingId != "" && candidate.MeetingId != null)
                {
                    response = null;
                    response = chat_obj.PostICE(candidate);
                }
            }
            catch (Exception ex) 
            {
                response.message = ex.Message;
            }
            responsemsg = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, response);
            return responsemsg;
        }

        /// <summary>
        /// get ice candidate
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>

        [HttpPost]
        public HttpResponseMessage GetICE(CandidateTable candidate)
        {
            try
            {
                if (candidate.SenderId != "" && candidate.SenderId != null && candidate.MeetingId != "" && candidate.MeetingId != null)
                {
                    response = null;
                    response = chat_obj.GetICE(candidate);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }
            responsemsg = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, response);
            return responsemsg;
        }

        #endregion

        // list of participant in the meeting
        [HttpPost]
        public HttpResponseMessage GetParticipants(ParticipantDetail participant)
        {
            try
            {
                response = null;
                response = chat_obj.GetParticipants(participant);
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }
            responsemsg = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, response);
            return responsemsg;
        }
    }
}
