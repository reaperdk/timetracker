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
        public ActionResult Index()
        {
            return View(
                _wrapper.GetAllSlots().Select(
                    item => Mapper.Map<Web.Models.SlotModel>(item)
                )
            );
        }

        public ActionResult Create()
        {
            return View( new Web.Models.SlotModel() );
        }

        [HttpPost]
        public ActionResult Create(Web.Models.SlotModel model)
        {
            _wrapper.CreateSlot(Mapper.Map<Model.SlotModel>(model));
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(
               Mapper.Map<Web.Models.SlotModel>(_wrapper.GetSlotById(id))
           );
        }

        [HttpPost]
        public ActionResult Delete(Web.Models.SlotModel slot)
        {
            _wrapper.DeleteSlot(slot.Id);
            return RedirectToAction("Index");
        }
    }
}
