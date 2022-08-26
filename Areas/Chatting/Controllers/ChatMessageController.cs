using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.RightsManagement;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.WebSockets;
using UI.Classes;

namespace UI.Areas.Chatting.Controllers
{
    //[RoutePrefix("api/messages")]
    public class ChatMessageController : ApiController
    {
        private readonly SimpleWebSocketHandler _webSocketHandler;
        public ChatMessageController(SimpleWebSocketHandler webSocketHandler)
        {
            _webSocketHandler = webSocketHandler;
        }

        [HttpGet]
        [Route("api/ChatMessage/GetMessages")]
        public async Task<HttpResponseMessage> Messages()
        {
            var currentContext = HttpContext.Current;
            return await Task.Run(() =>
            {
                if (currentContext.IsWebSocketRequest || currentContext.IsWebSocketRequestUpgrading)
                {
                    currentContext.AcceptWebSocketRequest(ProcessWebSocketRequest);
                    return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            });
        }
        private async Task ProcessWebSocketRequest(AspNetWebSocketContext context)
        {
            var sessionCookie = context.Cookies["SessionId"];
            if (sessionCookie != null)
            {
                await _webSocketHandler.ProcessWebSocketRequestAsync(context);
            }
        }

        /// <summary>
        /// connect to the chat using WebSockets
        /// </summary>
        /// <returns></returns>
        [Route("api/ChatMessage/connect")]
        [HttpPost]
        public HttpResponseMessage connecttoserver()
        {
            if (HttpContext.Current.IsWebSocketRequest)
            {
                //HttpContext.Current.AcceptWebSocketRequest(ChatServerSocketConnection.Join(AuthenticationUtility.GetAuthenticatedId()));
            }
            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }

        /// <summary>
        /// join to the chat, alerting all current users and getting an array of online participants
        /// </summary>
        /// <returns></returns>
        //[Route("api/chat/join")]
        //[HttpGet]
        //public HttpResponseMessage JoinChat()
        //{
        //    return ResponseMessage;
        //}
    }
}

