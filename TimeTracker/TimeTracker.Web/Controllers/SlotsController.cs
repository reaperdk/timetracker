using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace TimeTracker.Web.Controllers
{
    public class SlotsController : BaseController
    {
        public ActionResult Index(int? taskId)
        {
            if (taskId == null)
            {
                return View(
                    _wrapper.GetAllSlots().Select(
                        item => Mapper.Map<Web.Models.SlotModel>(item)
                    )
                );
            }
            return View(
               _wrapper.GetAllSlots().Select(
                    item => Mapper.Map<Web.Models.SlotModel>(item)
               ).Where(item => item.TaskId.Equals(taskId))
            );
        }

        public ActionResult Create(int taskId)
        {
            return View(
                new Web.Models.SlotModel
                {
                    TaskId = taskId
                } 
            );
        }

        [HttpPost]
        public ActionResult Create(Web.Models.SlotModel model)
        {
            _wrapper.CreateSlot(Mapper.Map<Model.SlotModel>(model));
            return RedirectToAction("Index", new { taskId = model.TaskId });
        }

        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Web.Models.SlotModel>(_wrapper.GetSlotById(id)));
        }

        [HttpPost]
        public ActionResult Edit(int id, Web.Models.SlotModel model)
        {
            _wrapper.UpdateSlot(
                Mapper.Map<Model.SlotModel>(Mapper.Map<Model.SlotModel>(model))
            );
            return RedirectToAction("Index", new { taskId = model.TaskId });
        }

        public ActionResult Delete(int id)
        {
            return View(
               Mapper.Map<Web.Models.SlotModel>(_wrapper.GetSlotById(id))
           );
        }

        [HttpPost]
        public ActionResult Delete(Web.Models.SlotModel model)
        {
            _wrapper.DeleteSlot(model.Id);
            return RedirectToAction("Index", new { taskId = model.TaskId }); ;
        }
    }
}
