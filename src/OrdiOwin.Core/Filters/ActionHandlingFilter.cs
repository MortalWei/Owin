using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OrdiOwin.Core.Filters
{
    public class ActionHandlingFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Console.WriteLine(actionContext.ActionArguments);
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Console.WriteLine(actionExecutedContext.Request.Content.ReadAsStreamAsync().Result);
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
