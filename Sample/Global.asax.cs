using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Backbone.Validation.Metadata;
using Sample.Models;

namespace Sample
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BackboneValidationMetadataProvider.AddModelType<NoteViewModel>("note");
        }
    }
}