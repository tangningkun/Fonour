﻿using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TsBlog.AutoMapperConfig.AutoMapper;
using TsBlog.Repositories.PostRepositorys;
using TsBlog.Services.PostAppServices;

namespace TsBlog.Frontend
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);AutofacRegister();

            AutofacRegister();

            AutoMapperRegister();
        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        private void AutofacRegister()
        {
            var builder = new ContainerBuilder();

            //注册MvcApplication程序集中所有的控制器
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //注册仓储层服务
            builder.RegisterType<PostRepository>().As<IPostRepository>();
            //注册服务层服务
            builder.RegisterType<PostAppService>().As<IPostAppService>();

            //注册过滤器
            builder.RegisterFilterProvider();

            var container = builder.Build();

            //设置依赖注入解析器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        /// <summary>
        /// AutoMapper的配置初始化
        /// </summary>
        private void AutoMapperRegister()
        {
            new AutoMapperStartupTask().Execute();
        }
    }
}
