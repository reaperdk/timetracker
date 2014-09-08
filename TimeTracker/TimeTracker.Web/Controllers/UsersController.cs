using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracker.Wrapper;

namespace TimeTracker.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IServiceWrapper _wrapper;

        public UsersController()
        {
            _wrapper = new ClassWrapper();
        }
        public UsersController(IServiceWrapper usersWrapper)
        {
            _wrapper = usersWrapper;
        }

        public ActionResult Index()
        {
            return View(
                _wrapper.GetAllUsers().Select(
                    item => Mapper.Map<Web.Models.UserModel>(item)
                )
            );
        }

        public ActionResult Details(int id)
        {
            return View(
                Mapper.Map<Web.Models.UserModel>(_wrapper.GetUserById(id))
            );
        }

        public ActionResult Create()
        {
            return View(
                new Web.Models.UserModel
                {
                    Roles = new SelectList(_wrapper.GetAllRoles(), "RoleId", "RoleName")
                }
            );
        }

        [HttpPost]
        public ActionResult Create(Web.Models.UserModel model)
        {
            _wrapper.CreateUser(Mapper.Map<Model.UserProfile>(model));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Web.Models.UserModel model = Mapper.Map<Web.Models.UserModel>(_wrapper.GetUserById(id));
            model.Roles = new SelectList(_wrapper.GetAllRoles(), "RoleId", "RoleName");
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, Web.Models.UserModel model)
        {
            _wrapper.UpdateUser(
                Mapper.Map<Model.UserProfile>(Mapper.Map<Model.UserProfile>(model))
            );
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(
                Mapper.Map<Web.Models.UserModel>(_wrapper.GetUserById(id))
            );
        }

        [HttpPost]
        public ActionResult Delete(Web.Models.UserModel user)
        {
            _wrapper.RemoveUser(user.Id);
            return RedirectToAction("Index");
        }
    }
}
