using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.Middlewares
{
    public class OwnHttpStatusTracker
    {
        private readonly RequestDelegate _next;

        public OwnHttpStatusTracker(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            HttpStatusCode statusCode = (HttpStatusCode)context.Response.StatusCode;



            await _next.Invoke(context);
        }
    }
}
