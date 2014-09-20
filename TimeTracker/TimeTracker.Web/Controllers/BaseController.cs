using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using TimeTracker.Wrapper;

namespace TimeTracker.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly ILog _logger;
        protected readonly IServiceWrapper _wrapper;

        public BaseController()
        {
            _logger = LogManager.GetLogger(GetType());
            _wrapper = new ClassWrapper();
            //_wrapper = new WebApiWrapper();
        }
        public BaseController(IServiceWrapper usersWrapper)
        {
            _wrapper = usersWrapper;
        }
    }
}
