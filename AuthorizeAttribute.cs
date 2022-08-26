using BOL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace UI
{
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                base.HandleUnauthorizedRequest(actionContext);
            else
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var currentIdentity = System.Threading.Thread.CurrentPrincipal.Identity;
            if (!currentIdentity.IsAuthenticated)
            {
                // redirect to access denied page
            }

            var userName = currentIdentity.Name;
            // step 1 : retrieve user object

            // step 2 : retrieve user permissions

            // step 3 : match user permission(s) agains class/method's required premissions

            // step 4 : continue/redirect to access denied page
        }
        protected override Boolean IsAuthorized(HttpActionContext actionContext)
        {
            var currentIdentity = actionContext.RequestContext.Principal.Identity;
            if (!currentIdentity.IsAuthenticated)
                return false;

            var userName = currentIdentity.Name;
            using (var context = new TookupDBEntities())
            {
                //var userStore = new UserStore<AppUser>(context);
                //var userManager = new UserManager<AppUser>(userStore);
                //var user = userManager.FindByName(userName);

                //if (user == null)
                //    return false;

                //foreach (var role in permissionActions)
                //    if (!userManager.IsInRole(user.Id, Convert.ToString(role)))
                //        return false;

                return true;
            }
        }
    }
}