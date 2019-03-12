using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using TsBlog.AutoMapperConfig.AutoMapper;
using TsBlog.Repositories.Dependency;
using TsBlog.Repositories.PostRepositorys;
using TsBlog.Services.PostAppServices;

namespace TsBlog.WebApi.App_Start
{
    /// <summary>
    /// 依赖注入&&AutoMapper的配置初始化
    /// </summary>
    public class AutofacWebApiConfig
    {
        /// <summary>
        /// 执行起始
        /// </summary>
        public static void Run()
        {
            AutofacRegister();
            AutoMapperRegister();
        }
        /// <summary>
        /// 依赖注入
        /// </summary>
        private static void AutofacRegister()
        {
            //得到你的HttpConfiguration.
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();

            //注册控制器
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);


            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>()
                .Where(
                    assembly =>
                        assembly.GetTypes().FirstOrDefault(type => type.GetInterfaces().Contains(typeof(IDependency))) !=
                        null
                );

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .AsImplementedInterfaces()
                .InstancePerDependency();

            //注册过滤器
            builder.RegisterWebApiFilterProvider(configuration);
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            var container = builder.Build();

            //设置依赖注入解析器
            //注册api容器需要使用
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        /// <summary>
        /// AutoMapper的配置初始化
        /// </summary>
        private static void AutoMapperRegister()
        {
            new AutoMapperStartupTask().Execute();
        }
    }
}