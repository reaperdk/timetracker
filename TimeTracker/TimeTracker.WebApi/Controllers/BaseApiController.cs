using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using log4net;

namespace TimeTracker.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        protected readonly ILog _logger;

        public BaseApiController()
        {
            _logger = LogManager.GetLogger(GetType());
        }

        protected JsonResult<T> JsonNonCyclic<T>(T content)
        {
            return Json(content, GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings);
        }
    }
}