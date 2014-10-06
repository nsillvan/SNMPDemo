using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Quartz;
using Quartz.Impl;

namespace SNMPDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        // Static variables for scheduling purposes
        public static ISchedulerFactory SchedulerFactory;
        public static IScheduler Scheduler;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Construct a scheduler factory
            SchedulerFactory = new StdSchedulerFactory();
            // Get a scheduler
            Scheduler = SchedulerFactory.GetScheduler();
            // Start the scheduler
            Scheduler.Start();
        }
    }
}
