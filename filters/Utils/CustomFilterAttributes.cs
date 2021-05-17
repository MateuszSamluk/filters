using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.HttpOverrides;

namespace filters.Utils
{
    public class CustomFilterAttributes : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();  //Request.Host.ToString();
            var result = (PageResult)context.Result;
            result.ViewData["IpAddress"] = ipAddress;
            await next.Invoke();
        }
    }
}
