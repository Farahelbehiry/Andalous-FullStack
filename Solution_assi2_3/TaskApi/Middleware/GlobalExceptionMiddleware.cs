using Microsoft.AspNetCore.Mvc;
using TaskApi.Exceptions;

namespace TaskApi.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (NotFoundException notfoundexception)
            {
                await WriteProblemDetails(context, 404, "Not Found", notfoundexception.Message);

            }
            catch (ConflictException conflictexception)
            {
                await WriteProblemDetails(context, 409, "conflict", conflictexception.Message);

            }
            catch (Exception ex)
            {
                await WriteProblemDetails(context, 500, "An unhandled exception occured.",
                    "please wait for few seconds");
            }

        }


        public async Task WriteProblemDetails(HttpContext ctx , int status,String title,string detail)
        {
            ctx.Response.StatusCode = status;
            ctx.Response.ContentType = "application/problem+json";
            var problem = new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = detail
            };
            await ctx.Response.WriteAsJsonAsync(problem);

        }
    }

   
}
