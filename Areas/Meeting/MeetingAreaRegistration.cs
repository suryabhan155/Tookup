using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Meeting
{
    public class MeetingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Meeting";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Meeting_default",
                "Meeting/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}