using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace TimeTracker.Web.Controllers
{
    [Authorize]
    public class ProjectsController : BaseController
    {

        public ActionResult Index()
        {
            return View(
                _wrapper.GetAllProjects().Select(
                    item => Mapper.Map<Web.Models.ProjectModel>(item)
                )
            );
        }

        public ActionResult Details(int id)
        {
            return View(
                Mapper.Map<Web.Models.ProjectModel>(_wrapper.GetProjectById(id))
            );
        }
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View(new Web.Models.ProjectModel());
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Web.Models.ProjectModel model)
        {
            Mapper.Map<Model.ProjectModel>(model);
            _wrapper.CreateProject(Mapper.Map<Model.ProjectModel>(model));
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Web.Models.ProjectModel model = Mapper.Map<Web.Models.ProjectModel>(_wrapper.GetProjectById(id));
            return View(model);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id, Web.Models.ProjectModel model)
        {
            _wrapper.UpdateProject(
                Mapper.Map<Model.ProjectModel>(Mapper.Map<Model.ProjectModel>(model))
            );
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            return View(
                Mapper.Map<Web.Models.ProjectModel>(_wrapper.GetProjectById(id))
            );
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(Web.Models.ProjectModel project)
        {
            _wrapper.DeleteProject(project.Id);
            return RedirectToAction("Index");
        }
    }
}
