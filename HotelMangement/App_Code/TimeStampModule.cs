using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelMangement
{
    public class TimeStampModule : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += OnEndRequest; 
            
        }

        

        void OnEndRequest(object sender,EventArgs e)
        {
            if(HttpContext.Current.Handler != null)
            {
                System.Web.Mvc.MvcHandler mvc = HttpContext.Current.Handler as System.Web.Mvc.MvcHandler;

                if(mvc != null)
                {
                    HttpContext.Current.Response.Write("<p>Serverd at "+DateTime.Now+"</p>");
                }
            }
        }
    }
}