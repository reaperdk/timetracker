using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracker.Wrapper;
using WebMatrix.WebData;
using TimeTracker.Web.Services;
using System.Web.Security;

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
        [ValidateAntiForgeryToken]
        public ActionResult Create(Web.Models.UserModel model)
        {
            string salt = WebSecurityService.GetSalt();
            WebSecurity.CreateUserAndAccount(model.UserName, model.UserName + "_Tt" + salt);
            _wrapper.UpdateCreatedUser(Mapper.Map<Model.UserModel>(model), salt);
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
                Mapper.Map<Model.UserModel>(Mapper.Map<Model.UserModel>(model))
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
            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(user.UserName);
            ((SimpleMembershipProvider)Membership.Provider).DeleteUser(user.UserName, true);
            return RedirectToAction("Index");
        }
    }
}
