using Microsoft.AspNetCore.Http;
using Services.Middlewares.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Middlewares
{
    public class RequestedInformationCheck
    {
        private readonly RequestDelegate _next;

        public RequestedInformationCheck(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            var clientIdCheck = context.Request.Headers.Keys.Contains("client-id");
            var clientSecretCheck = context.Request.Headers.Keys.Contains("client-secret");
            var clientSecretKeyCheck = context.Request.Headers.Keys.Contains("client-secret-key");

            if (!clientIdCheck || !clientSecretCheck || !clientSecretKeyCheck)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(new HttpStatusResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Missing request information!",
                    IsException = true
                }.ToString());
                return;//Bir sonraki middleware geçişini durdurur. Bu sayede tam engel sağlanır.
            }
            else
            {
                //Tüm bilgiler sağlanırsa bu alan çalışır.
            }

            await _next.Invoke(context);
        }


    }
}
