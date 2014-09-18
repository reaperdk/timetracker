using System.Web;
using System.Web.Mvc;
using log4net;
using TimeTracker.WebApi.Filters;

namespace TimeTracker.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoggingExceptionFilter(new HandleErrorAttribute(), LogManager.GetLogger("ExceptionLogger")));
        }
    }
}
