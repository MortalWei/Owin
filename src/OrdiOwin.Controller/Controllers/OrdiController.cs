using System;
using System.Net.Http;
using System.Web.Http;

namespace OrdiOwin.Controller
{
    public class OrdiController : ApiController
    {
        public OrdiController()
        {
        }

        [HttpGet]
        public HttpResponseMessage GetOrdi()
        {
            var result = "";
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }
    }
}
