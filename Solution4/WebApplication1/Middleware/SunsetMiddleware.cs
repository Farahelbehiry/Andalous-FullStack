namespace WebApplication1.Middleware
{
    public class SunsetMiddleware
    {
        private readonly RequestDelegate _next;

        public SunsetMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/v1"))
            {
                var sunsetTime = DateTime.UtcNow.AddYears(1).ToString("R");
                context.Response.Headers.Append("sunset", sunsetTime);

            }
            await _next(context);
        }
    }
}
