using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UI.Hubs;

namespace UI.Areas.Chatting.Controllers
{
    public class SignalRController : ApiController
    {
        public IHubContext _hubContext { get; }
        public IHubProxy hubProxy { get; }
        public HubConnection connection { get; }
        private string url = "http://localhost:8080/signalchat";
        public MyHub testHub;
        //IHubContext<TestHub> _hubContext;
        public SignalRController()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            testHub = new MyHub();
        }
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _hubContext.Clients.All.Send("AddMessage", "get all called");
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [Route("api/SignalR/{id}")]
        [HttpGet]
        public string Get(string connectionId)
        {
            _hubContext.Clients.Client(connectionId).SendAsync("AddMessage", "get called");
            return "value";
        }

        // POST api/<controller>
        [Route("api/SignalR/Send")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _hubContext.Clients.All.BroadcastMessage(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}