using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeTracker.ClassService;

namespace TimeTracker.WebApi.Controllers
{
    public class MembershipsController : BaseApiController
    {
        private readonly IMembershipsService _service;

        public MembershipsController()
        {
            _service = new MembershipsService();
        }
        public MembershipsController(IMembershipsService service)
        {
            _service = service;
        }

        [HttpPut]
        public HttpResponseMessage SetSalt(int id, [FromBody]string value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.SetSalt(id, value);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Model");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
