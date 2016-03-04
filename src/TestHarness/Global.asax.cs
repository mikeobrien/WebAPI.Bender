using System;
using System.Web.Http;
using WebApi.Bender;

namespace TestHarness
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configuration.UseBender(x => x.UseJsonCamelCaseNaming());
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}