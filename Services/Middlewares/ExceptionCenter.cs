using Microsoft.AspNetCore.Http;
using Services.Middlewares.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Middlewares
{
    public class ExceptionCenter
    {
        private readonly RequestDelegate _next;

        public ExceptionCenter(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                //O sıra tetiklenen request yapsıında bir istisna (hata) oluşursa burası tetikleir, oluşmazsa sıradaki requeste geçer.
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleAsync(context, ex);
            }
        }

        private static async Task HandleAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ExceptionResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
                StackTrace = ex.StackTrace
            }.ToString());
        }
    }
}
