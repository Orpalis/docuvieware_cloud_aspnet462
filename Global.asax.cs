using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace aspnet_mvc_razor_app
{
    public class MvcApplication : HttpApplication
    {
        private const string SERVEUR_URI = "https://passportpdfapi.com";
        private const string API_KEY = "";

        protected void Application_Start()
        {
            if (string.IsNullOrWhiteSpace(API_KEY))
            {
                throw new System.Exception("Please enter your PassportPDF key into the API_KEY contant.");
            }

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            PassportPDF.Client.GlobalConfiguration.BasePath = SERVEUR_URI;
            PassportPDF.Client.GlobalConfiguration.ApiKey = API_KEY;
        }
    }
}