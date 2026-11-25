using System.Diagnostics;

namespace MyFristMVC.CustomMiddleware
{
    public class RequestTimingMiddelWare
    {
        private readonly RequestDelegate _next;
        public RequestTimingMiddelWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var Watch =Stopwatch.StartNew();
            await _next(context);
            Watch.Stop();
            Console.WriteLine($"{context.Request.Path}: {Watch.ElapsedMilliseconds} ms");
        }
    }
}
