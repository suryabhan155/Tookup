using System.Web.Http;
using WebActivatorEx;
using UI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace UI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
              .EnableSwagger(c =>
              {
                  c.SingleApiVersion("v1", "UI");
                  c.IncludeXmlComments(string.Format(@"{0}\bin\UI.XML",
                                       System.AppDomain.CurrentDomain.BaseDirectory));
              })
              .EnableSwaggerUi();
        }
    }
}
