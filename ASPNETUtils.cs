using System.Collections.Generic;
using System.IO;
using System.Web;


namespace aspnet_mvc_razor_app
{
    public static class ASPNETUtils
    {
        private const string APP_GUID = "54E9058A-EB0E-4A93-A8C5-035AA21F1E43";

        public static string GetSessionID()
        {
            if (HttpContext.Current.Session.Contents["dvinit"] == null)
            {
                HttpContext.Current.Session.Contents["dvinit"] = true;
            }
            return HttpContext.Current.Session.SessionID;
        }


        public static string GetCacheDirectory()
        {
            return Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data\\cache");
        }


        public static string GetDocuViewareSessionID()
        {
            return APP_GUID + ASPNETUtils.GetSessionID();
        }


        public static List<string> GetUserLanguages()
        {
            return new List<string>(HttpContext.Current.Request.UserLanguages);
        }


        public static string GetUserHostAddress()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }
    }
}