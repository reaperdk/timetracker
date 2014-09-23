using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace TimeTracker.Web.Controllers
{
    [Authorize]
    public class TasksController : BaseController
    {
        public ActionResult Index()
        {
            return View(
                _wrapper.GetAllTasks().Select(
                    item => Mapper.Map<Web.Models.TaskModel>(item)
                )
            );
        }

        public ActionResult Details(int id)
        {
            Model.TaskModel task = _wrapper.GetTaskById(id);
            task.Project = _wrapper.GetProjectById(task.ProjectId);
            task.AssignedPerson = _wrapper.GetUserById(task.AssignedPersonId);
            task.AssigningPerson = _wrapper.GetUserById(task.AssigningPersonId);
            task.Category = _wrapper.GetCategoryById(task.CategoryId);
            task.Priority = _wrapper.GetPriorityById(task.PriorityId);
            task.Status = _wrapper.GetStatusById(task.StatusId);
            task.Type = _wrapper.GetTypeById(task.TypeId);
            task.Slots = _wrapper.GetAllSlots();
            return View(
                Mapper.Map<Web.Models.TaskModel>(task)
            );
        }

        public ActionResult Create()
        {
            return View(
                new Web.Models.TaskModel
                {
                    Projects = new SelectList(_wrapper.GetAllProjects(), "Id", "Name"),
                    AssignedPersons = new SelectList(_wrapper.GetAllUsers(), "UserId", "UserName"),
                    AssigningPersons = new SelectList(_wrapper.GetAllUsers(), "UserId", "UserName"),
                    Categories = new SelectList(_wrapper.GetAllCategories(), "Id", "Name"),
                    Statuses = new SelectList(_wrapper.GetAllStatuses(), "Id", "Name"),
                    Priorities = new SelectList(_wrapper.GetAllPriorities(), "Id", "Name"),
                    Types = new SelectList(_wrapper.GetAllTypes(), "Id", "Name")
                }
            );
        }

        [HttpPost]
        public ActionResult Create(Web.Models.TaskModel model)
        {
            _wrapper.CreateTask(Mapper.Map<Model.TaskModel>(model));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Web.Models.TaskModel model = Mapper.Map<Web.Models.TaskModel>(_wrapper.GetTaskById(id));
            model.Projects = new SelectList(_wrapper.GetAllProjects(), "Id", "Name");
            model.AssignedPersons = new SelectList(_wrapper.GetAllUsers(), "UserId", "UserName");
            model.AssigningPersons = new SelectList(_wrapper.GetAllUsers(), "UserId", "UserName");
            model.Categories = new SelectList(_wrapper.GetAllCategories(), "Id", "Name");
            model.Statuses = new SelectList(_wrapper.GetAllStatuses(), "Id", "Name");
            model.Priorities = new SelectList(_wrapper.GetAllPriorities(), "Id", "Name");
            model.Types = new SelectList(_wrapper.GetAllTypes(), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, Web.Models.TaskModel model)
        {
            _wrapper.UpdateTask(
                Mapper.Map<Model.TaskModel>(Mapper.Map<Model.TaskModel>(model))
            );
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(
               Mapper.Map<Web.Models.TaskModel>(_wrapper.GetTaskById(id))
           );
        }

        [HttpPost]
        public ActionResult Delete(Web.Models.TaskModel task)
        {
            _wrapper.DeleteTask(task.Id);
            return RedirectToAction("Index");
        }
    }
}
