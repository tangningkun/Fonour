
using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.WebApi;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TsBlog.AutoMapperConfig.AutoMapper;
using TsBlog.Repositories.Dependency;
using TsBlog.WebApi.App_Start;

namespace TsBlog.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacWebApiConfig.Run();//依赖注入&&AutoMapper的配置初始化
        }
        
    }
}
