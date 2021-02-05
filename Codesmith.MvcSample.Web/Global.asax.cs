﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Codesmith.MvcSample.Web.Core.Infrastructure;
using Codesmith.MvcSample.Services;

namespace Codesmith.MvcSample.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //System.Web.Http.GlobalConfiguration.Configure((config) =>
           // {
           //     GlobalConfiguration.Configuration = config;
           //     WebApiConfig.Register(config);
           // });

            // Create the container as usual.
            var container = new Container();
            RegisterIoCContainer(container);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void RegisterIoCContainer(Container container)
        {
            container.Options.ResolveUnregisteredConcreteTypes = true;
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            // Injectable service
            container.Register<IUserService, UserService>(Lifestyle.Scoped);

            // Automapper
            container.RegisterSingleton(() => GetMapper(container));

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
        }

        private AutoMapper.IMapper GetMapper(Container container)
        {
            var mp = container.GetInstance<AutoMapperProvider>();
            return mp.GetMapper();
        }

    }
}