using System.Web;
using System.Web.Http;

namespace Correct.Storage.RestApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            LogConfig.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(DependencyConfig.Configure);
        }
    }
}
