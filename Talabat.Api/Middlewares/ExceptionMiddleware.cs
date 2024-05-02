using System.Net;
using System.Text.Json;
using Talabat.Api.Errors;

namespace Talabat.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;
        private readonly ILogger _logger;

        //Handling internal Server error 
        public ExceptionMiddleware(RequestDelegate Next , ILogger<ExceptionMiddleware> logger ,IHostEnvironment env)
        {
            _next = Next;
            this._env = env;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
               await _next.Invoke(context);

            } catch (Exception ex)
            {
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                context.Response.ContentType= "application/Json";
               
                ////Development
                //if(_env.IsDevelopment())
                //{
                //    var Response = new ApiExceptionResponse(500,ex.Message,ex.StackTrace);
                //}
                ////Production => log in database
                //else
                //{
                //    var Response = new ApiExceptionResponse(500);
                //}

                var Response = _env.IsDevelopment() ? new ApiExceptionResponse(500, ex.Message, ex.StackTrace) : new ApiExceptionResponse(500);

                var SerializedResponse = JsonSerializer.Serialize(Response);
                 await context.Response.WriteAsync(SerializedResponse);
            }


        }
    }
}
