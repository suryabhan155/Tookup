using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.Chatting.Data
{
    public class SimpleMessage
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("body")]
        public dynamic Body { get; set; }
        [JsonProperty("sessionId")]
        public Guid SessionId { get; set; }
    }
}