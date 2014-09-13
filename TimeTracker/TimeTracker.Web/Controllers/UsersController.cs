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
    [Authorize]
    public class UsersController : BaseController
    {
        public ActionResult Index()
        {
            return View(
                _wrapper.GetAllUsers().Select(
                    item => Mapper.Map<Web.Models.UserModel>(item)
                ).Where(item => !item.UserName.Equals(User.Identity.Name))
            );
        }

        public ActionResult Details(int id)
        {
            return View(
                Mapper.Map<Web.Models.UserModel>(_wrapper.GetUserById(id))
            );
        }

        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public ActionResult Create(Web.Models.UserModel model)
        {
            string salt = WebSecurityService.GetSalt();
            WebSecurity.CreateUserAndAccount(model.UserName, model.UserName + "_Tt" + salt);
            _wrapper.UpdateCreatedUser(Mapper.Map<Model.UserModel>(model), salt);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Web.Models.UserModel model = Mapper.Map<Web.Models.UserModel>(_wrapper.GetUserById(id));
            model.Roles = new SelectList(_wrapper.GetAllRoles(), "RoleId", "RoleName");
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id, Web.Models.UserModel model)
        {
            _wrapper.UpdateUser(
                Mapper.Map<Model.UserModel>(Mapper.Map<Model.UserModel>(model))
            );
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            return View(
                Mapper.Map<Web.Models.UserModel>(_wrapper.GetUserById(id))
            );
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(Web.Models.UserModel user)
        {
            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(user.UserName);
            ((SimpleMembershipProvider)Membership.Provider).DeleteUser(user.UserName, true);
            return RedirectToAction("Index");
        }
    }
}
