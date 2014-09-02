using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracker.Wrapper;
using TimeTracker.Wrapper.ClassWrappers;

namespace TimeTracker.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersWrapper _usersWrapper;

        public UsersController()
        {
            _usersWrapper = new UsersClassWrapper();
        }
        public UsersController(IUsersWrapper usersWrapper)
        {
            _usersWrapper = usersWrapper;
        }

        public ActionResult Index()
        {
            return View(
                _usersWrapper.GetAllUsers().Select(
                    item => Mapper.Map<Web.Models.UserModel>(item)
                )
            );
        }

        public ActionResult Details(int id)
        {
            return View(
                Mapper.Map<Web.Models.UserModel>(_usersWrapper.GetById(id))
            );
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Web.Models.UserModel model)
        {
            _usersWrapper.Add(
                Mapper.Map<Model.UserModel>(model)
            );
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(
                Mapper.Map<Web.Models.UserModel>(_usersWrapper.GetById(id))
            );
        }

        [HttpPost]
        public ActionResult Edit(int id, Model.UserModel model)
        {
            _usersWrapper.Update(
                Mapper.Map<Model.UserModel>(model)
            );
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(
                Mapper.Map<Web.Models.UserModel>(_usersWrapper.GetById(id))
            );
        }

        [HttpPost]
        public ActionResult Delete(Web.Models.UserModel user)
        {
            _usersWrapper.Remove(user.Id);
            return RedirectToAction("Index");
        }
    }
}
