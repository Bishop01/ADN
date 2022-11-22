using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BloodDonate.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        [Route("api/groups")]
        [HttpGet]
        public HttpResponseMessage Index()
        {
            var data = GroupServices.GetGroups();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}