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
            return View(
                _wrapper.GetAllTasks().Select(
                    item => Mapper.Map<Web.Models.TaskModel>(item)
                ) 
            );
        }

        //
        // GET: /Tasks/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tasks/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tasks/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Tasks/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tasks/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Tasks/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
