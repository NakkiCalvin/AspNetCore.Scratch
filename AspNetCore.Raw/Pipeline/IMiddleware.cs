using System.Net;

namespace AspNetCore.Raw.Pipeline
{
    public interface IMiddleware
    {
        Task InvokeAsync(HttpListenerContext context, Func<Task> next);
    }
}
