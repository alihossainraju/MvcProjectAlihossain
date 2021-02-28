using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using AutoMapper;
using MvcProjectAli.Models;
using MvcProjectAli.ViewModels;

namespace MvcProjectAli
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(config =>
            {
                config.CreateMap<ChefVB, Chef>();
                config.CreateMap<Chef, ChefVB>();
            });
        }
    }
}
