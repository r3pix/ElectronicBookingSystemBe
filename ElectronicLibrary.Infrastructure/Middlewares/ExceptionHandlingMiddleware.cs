using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ElectronicLibrary.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace ElectronicLibrary.Infrastructure.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
                //await next(context);
            }
            catch (Exception ex)
            {
                await HandleError(context, ex);
            }
        }

        private async Task HandleError(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(JsonSerializer.Serialize(new Response<string>()
            {
                IsError = true,
                Code = HttpStatusCode.InternalServerError,
                Message = ex.StackTrace,
                Result = ex.Message
            }));
        }
    }
}
