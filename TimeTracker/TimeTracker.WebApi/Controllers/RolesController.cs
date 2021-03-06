﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeTracker.ClassService;
using TimeTracker.Model;

namespace TimeTracker.WebApi.Controllers
{
    public class RolesController : BaseApiController
    {
        private readonly IRolesService _service;

        public RolesController()
        {
            _service = new RolesService();
        }
        public RolesController(IRolesService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return JsonNonCyclic(_service.GetAll());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return JsonNonCyclic(_service.GetById(id));
        }

        //[HttpPut]
        //public HttpResponseMessage Put([FromBody]UserModel value)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _service.Update(value);
        //            return Request.CreateResponse(HttpStatusCode.OK);
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Model");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}

        //[HttpPut]
        //public HttpResponseMessage UpdateCreated([FromBody]UserModel value)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _service.UpdateCreated(value);
        //            return Request.CreateResponse(HttpStatusCode.OK);
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Model");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}
    }
}
