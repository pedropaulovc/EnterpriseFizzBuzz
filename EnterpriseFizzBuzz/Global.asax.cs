﻿using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using EnterpriseBuzzBuzz.Services;
using EnterpriseFizzBuzz.Services;
using FizzBuzzCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EnterpriseFizzBuzz
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Register your MVC controllers. (WebApiApplication is the name of
            // the class in Global.asax.)
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            // Register types
            builder.RegisterModule<FizzBuzzModule>();
            builder
                .RegisterType<FizzService>()
                .AsImplementedInterfaces();

            builder
                .RegisterType<BuzzService>()
                .AsImplementedInterfaces();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
