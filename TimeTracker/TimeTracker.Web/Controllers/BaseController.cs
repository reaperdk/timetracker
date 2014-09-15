using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracker.Wrapper;

namespace TimeTracker.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IServiceWrapper _wrapper;

        public BaseController()
        {
            _wrapper = new ClassWrapper();
            //_wrapper = new WebApiWrapper();
        }
        public BaseController(IServiceWrapper usersWrapper)
        {
            _wrapper = usersWrapper;
        }
    }
}
