using System.Web.Mvc;

namespace HotelManagement.Areas.AdminArea
{
    
    public class AdminAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "AdminArea";

        /// <inheritdoc />
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminArea_default",
                "AdminArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}