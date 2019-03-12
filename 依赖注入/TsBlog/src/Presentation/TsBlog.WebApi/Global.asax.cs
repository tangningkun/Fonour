
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
            //注册ASP.NET MVC应用程序中的所有区域
            AreaRegistration.RegisterAllAreas();
            //配置WebApi
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //注册过滤器
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //注册路由配置
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //依赖注入&&AutoMapper的配置初始化
            AutofacWebApiConfig.Run();
        }
        
    }
}
