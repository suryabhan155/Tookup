using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using TookUp.BOL.Utils;

namespace UI.Areas.Common.Controllers
{
    public class BaseController : ApiController
    {
        /// <summary>
        /// Convert object to json for API
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected HttpResponseMessage ToJson(dynamic obj)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return response;
        }

        /// <summary>
        /// Get logged in user ID
        /// </summary>
        protected int UserID
        {
            get
            {
                return User.Identity.IsAuthenticated? User.Identity.Name.ToInteger(-1, CultureInfo.InvariantCulture): -1;
            }
        }

        protected string UserName
        {
            get
            {
                var role = ((ClaimsIdentity)User.Identity).Claims.Where(c => c.Type == Constants.DisplayNameClaim).FirstOrDefault();
                return User.Identity.IsAuthenticated && !string.IsNullOrWhiteSpace(role?.Value)
                    ? role.Value.ToString(CultureInfo.InvariantCulture)
                    : string.Empty;
            }
        }
    }

}
