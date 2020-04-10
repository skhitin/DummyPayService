using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;

namespace DummyPayService.Api
{
    public static class ExceptionHandler
    {
        private const string ContentType = "application/json";

        public static void UseExceptionHandler(this IApplicationBuilder app,
            ILogger logger)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature.Error;

                    var message = $"Exception thrown: {exception.Message} {exception.StackTrace}";
                    logger.LogError(exception, message);

                    context.Response.StatusCode = (int)GetResponseStatusCode(exception);
                    context.Response.ContentType = ContentType;

                    var body = ToErrorMessage(exception);

                    await context.Response.WriteAsync(body);
                });
            });
        }

        private static string ToErrorMessage(Exception exception)
        {
            var errorMessage = new ErrorMessage
            {
                Message = exception.Message
            };

            return JsonConvert.SerializeObject(errorMessage);
        }

        private class ErrorMessage
        {
            public string Message { get; set; }
        }

        private static HttpStatusCode GetResponseStatusCode(Exception exception)
        {
            switch (exception)
            {
                case ArgumentException _:
                    return HttpStatusCode.BadRequest;
                case UnauthorizedAccessException _:
                    return HttpStatusCode.Unauthorized;
            }

            return HttpStatusCode.InternalServerError;
        }
    }
}
