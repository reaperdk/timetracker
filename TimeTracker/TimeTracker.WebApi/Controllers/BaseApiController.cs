using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace TimeTracker.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        protected JsonResult<T> JsonNonCyclic<T>(T content)
        {
            return Json(content, GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings);
        }
    }
}