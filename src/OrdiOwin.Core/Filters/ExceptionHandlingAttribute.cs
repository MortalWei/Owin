﻿using System;
using System.Web.Http.Filters;

namespace OrdiOwin.Core.Filters
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
                //Logger.Default.Error("Application_Error", exception);
                Console.Clear();
            base.OnException(actionExecutedContext);
        }
    }
}