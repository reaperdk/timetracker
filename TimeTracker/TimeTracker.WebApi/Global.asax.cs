using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using TimeTracker.Common;

namespace TimeTracker.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        readonly ILog _logger;

        public WebApiApplication()
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
                GlobalConfiguration.Configure(WebApiConfig.Register);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);

                DatabaseConfig.RegisterDatabase();

                GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

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
