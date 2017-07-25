using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Newtonsoft.Json;
using System.Web.SessionState;

namespace HotelManagement
{

    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Application_Init()
        {

        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }



        protected void Session_Start()
        {
                
        }
        protected void Application_End()
        {
            
        }

        protected void Application_AuthenticateRequest()
        {

        }


        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var cookie = Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if(cookie !=null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                var hotelPrincipal = JsonConvert.DeserializeObject(ticket.UserData);

            }
           

        }
        protected void Application_Error()
        {
            log4net.Config.XmlConfigurator.Configure();
            ILog log = LogManager.GetLogger("log");
            var error = Server.GetLastError();
            StringBuilder builder = new StringBuilder();
            builder.Append(error.Message + "" + Environment.NewLine);
            builder.Append(error.HResult + "" + Environment.NewLine);
            builder.Append(error.HelpLink + "" + Environment.NewLine);
            builder.Append(error.Data + "" + Environment.NewLine);
            builder.Append(error.Source + "" + Environment.NewLine);
            builder.Append("------------------------------------------------------------------" + Environment.NewLine);
            builder.Append(error.StackTrace + "" + Environment.NewLine);
            log.Error(builder);

        }
    }
}
