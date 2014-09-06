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
            Model.UserProfile user = Mapper.Map<Model.UserProfile>(model);
            user.webpages_Roles.Add(_wrapper.GetRoleById(model.RoleId));
            _wrapper.CreateUser(Mapper.Map<Model.UserProfile>(model));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(
                Mapper.Map<Web.Models.UserModel>(_wrapper.GetUserById(id))
            );
        }

        [HttpPost]
        public ActionResult Edit(int id, Model.UserProfile model)
        {
            _wrapper.UpdateUser(
                Mapper.Map<Model.UserProfile>(model)
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
