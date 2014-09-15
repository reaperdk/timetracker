using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TimeTracker.Wrapper;
using log4net;
using TimeTracker.Common;

namespace TimeTracker.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        readonly ILog _logger;

        public MvcApplication()
        {
            _logger = LogManager.GetLogger(GetType());
        }

        protected void Application_Start()
        {
            try
            {
                XmlConfigurator.Configure();
                _logger.Info("Application is starting...");

                AreaRegistration.RegisterAllAreas();

                WebApiConfig.Register(GlobalConfiguration.Configuration);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                AuthConfig.RegisterAuth();

                MapperConfig.RegisterMapper();
                DatabaseConfig.RegisterDatabase(new ClassWrapper());

                _logger.Info("Application has been configured.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            _logger.Info("Application has started successfully.");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            _logger.Info(LogHelper.FormatLog(Request));
        }

        void Application_EndRequest(object sender, EventArgs e)
        {
            if (Response.StatusCode >= 200 && Response.StatusCode < 300)
            {
                _logger.Info(LogHelper.FormatLog(Response));
            }
            else
            {
                _logger.Warn(LogHelper.FormatLog(Response));
            }
        }
    }
}