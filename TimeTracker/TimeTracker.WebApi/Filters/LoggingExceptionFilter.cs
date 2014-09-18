using System.Web.Mvc;
using log4net;

namespace TimeTracker.WebApi.Filters
{
    class LoggingExceptionFilter : IExceptionFilter
    {
        private readonly IExceptionFilter _filter;
        private readonly ILog _logger;
        public LoggingExceptionFilter(IExceptionFilter filter, ILog logger)
        {
            _filter = filter;
            _logger = logger;
        }
        public void OnException(ExceptionContext filterContext)
        {
            _logger.Error(filterContext.Exception);
            _filter.OnException(filterContext);
        }
    }
}
