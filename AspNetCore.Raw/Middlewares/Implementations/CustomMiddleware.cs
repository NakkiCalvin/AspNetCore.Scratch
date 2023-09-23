using System.Net;

using AspNetCore.Raw.Pipeline;

namespace AspNetCore.Raw.Middlewares.Implementations
{
    public class CustomMiddleware : IMiddleware
    {
        public CustomMiddleware() { }

        public async Task InvokeAsync(HttpListenerContext context, Func<Task> next)
        {
            Console.WriteLine("Before invoking next");
            await next();
            Console.WriteLine("After invoking next");
        }
    }
}
