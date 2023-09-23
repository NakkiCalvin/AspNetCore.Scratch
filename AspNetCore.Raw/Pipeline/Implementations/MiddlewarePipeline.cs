using System.Net;

namespace AspNetCore.Raw.Pipeline.Implementations
{
    public sealed class MiddlewarePipeline
    {
        private readonly IReadOnlyList<IMiddleware> _middlewares;

        public MiddlewarePipeline(IReadOnlyList<IMiddleware> middlewares)
        {
            _middlewares = middlewares;
        }

        public Task InvokeAsync(HttpListenerContext context)
        {
            var index = -1;

            Func<Task>? nextMiddleware = null;
            nextMiddleware = () =>
            {
                index++;
                return index < _middlewares.Count
                    ? _middlewares[index].InvokeAsync(context, nextMiddleware!)
                    : Task.CompletedTask;
            };

            return nextMiddleware();
        }
    }
}
