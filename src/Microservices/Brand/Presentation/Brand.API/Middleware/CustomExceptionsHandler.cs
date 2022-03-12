using Brand.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Brand.API.Middleware
{
    /// <summary>
    /// Middleware for exception handling
    /// </summary>
    public class CustomExceptionsHandler
    {
        private readonly RequestDelegate _next;

        public CustomExceptionsHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exception)
            {
                case BadDataException badDataException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(badDataException.Errors);
                    break;
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(notFoundException.Errors);
                    break;
                case Exception exc:
                    result = string.IsNullOrWhiteSpace(exc.Message) ? "Internal error" : exc.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "appliation/json";

            context.Response.StatusCode = (int)code;

            if (result == "null")
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}