using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using TookUp.BOL.Utils;

namespace UI.Token_RelatedRepository
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            string password = context.Password;
            string username = context.UserName;
            var data = await context.Request.ReadFormAsync();

            // Authentication code here
            //Reset Password
            if (string.IsNullOrEmpty(context.Password))
            {
                //using (var manageUser = new ManageUser())
                //{
                //    bool isEmailSend = manageUser.ForgotPassword(context.UserName);
                //    context.Response.ReasonPhrase = "Success";
                //    return;
                //}
            }
            using (UserMasterRepository _repo = new UserMasterRepository())
            {
                var userdetails = UserMasterRepository.ValidateUser(username, password);
                if (userdetails == null)
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(Constants.DisplayNameClaim, userdetails.DisplayName));
                identity.AddClaim(new Claim(ClaimTypes.Name, userdetails.UserId.ToString()));
                //identity.AddClaim(new Claim("Email", userdetails.Email));

                context.Validated(identity);
            }
        }
    }
}
