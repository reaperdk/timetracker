using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracker.Model;

namespace TimeTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly ILog _logger;

        public HomeController()
        {
            _logger = LogManager.GetLogger(this.GetType());
            var r = new Repository.EntitiesRepository<TypeModel>();
            r.Insert(new TypeModel { Name = "twojastara123456789" });
            r.Save();
            var x = r.Get().ToList();
            var r2 = new Repository.EntitiesRepository<UserModel>();
            System.Diagnostics.Debugger.Break();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
