using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using UI.Token_RelatedRepository;

[assembly: OwinStartup(typeof(UI.Startup))]

namespace UI
{
    // In this class we will Configure the OAuth Authorization Server.
    public class Startup
    {
        //public void Configuration(IAppBuilder app)
        //{
        //    // Enable CORS (cross origin resource sharing) for making request using browser from different domains
        //    app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

        //    OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
        //    {
        //        AllowInsecureHttp = true,
        //        //The Path For generating the Toekn
        //        TokenEndpointPath = new PathString("/token"),
        //        //Setting the Token Expired Time (24 hours)
        //        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        //        //MyAuthorizationServerProvider class will validate the user credentials
        //        Provider = new MyAuthorizationServerProvider()
        //    };
        //    //Token Generations
        //    app.UseOAuthAuthorizationServer(options);
        //    app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        //    HttpConfiguration config = new HttpConfiguration();
        //    WebApiConfig.Register(config);
        //    //app.UseWebApi(config);

        //}


        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            
            ConfigureOAuth(app);
            app.MapSignalR("/signalr", new Microsoft.AspNet.SignalR.HubConfiguration());
            //app.MapSignalR();
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
           
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            // Enable CORS (cross origin resource sharing) for making request using browser from different domains
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                //The Path For generating the Toekn
                TokenEndpointPath = new PathString("/token"),
                //Setting the Token Expired Time (24 hours)
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                //MyAuthorizationServerProvider class will validate the user credentials
                Provider = new MyAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthBearerTokens(OAuthServerOptions);
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
