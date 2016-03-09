using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace BookingTek.API.Filters
{
    public class AllowCrossDomainRequestsAttribute : ActionFilterAttribute
    {



        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            if (actionExecutedContext.Response != null)
            {
                KeyValuePair<string, IEnumerable<string>> originHeader = actionExecutedContext.Request.Headers.FirstOrDefault(h => h.Key == "Origin");
                IEnumerable<string> allowOriginHeader = new[] { "*" };
                if (originHeader.Value != null && originHeader.Value.Any())
                {
                    allowOriginHeader = originHeader.Value;
                }
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", allowOriginHeader);
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Method", new[] { "GET", "POST" });
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "content-type", "X-Requested-With" }); //, "Access-Control-Request-Method", "Access-Control-Request-Headers
            }
            //if (actionExecutedContext.Request.Method == HttpMethod.Options)
            //{
            //    HttpContext.Current.Response.StatusCode = 200;
            //    HttpContext.Current.Response.Flush();
            //    HttpContext.Current.Response.End();
            //}
        }


    }
}