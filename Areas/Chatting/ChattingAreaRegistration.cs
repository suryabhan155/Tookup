using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Chatting
{
    public class ChattingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Chatting";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Chatting_default",
                "Chatting/{controller}/{action}/{id}",
                new { action = "CreateRoom", id = UrlParameter.Optional }
            );
        }
    }
}