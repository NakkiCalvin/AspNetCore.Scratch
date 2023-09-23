using System.Net;

using Microsoft.Extensions.DependencyInjection;

using AspNetCore.Raw.Extensions;
using AspNetCore.Raw.Registry;
using AspNetCore.Raw.Middlewares.Implementations;
using AspNetCore.Raw.Pipeline;
using AspNetCore.Raw.Pipeline.Implementations;

var serviceProvider = new ServiceCollection()
    .AddSingleton<RouteRegistry>()
    .AddControllers()
    .AddMiddleware<CustomMiddleware>()
    .AddMiddleware<RoutingMiddleware>()
    .BuildServiceProvider();

var middlewares = serviceProvider.GetServices<IMiddleware>().ToList();

var pipeline = new MiddlewarePipeline(middlewares);

var httpListener = new HttpListener();
httpListener.Prefixes.Add("http://localhost:5001/");
httpListener.Start();

Console.WriteLine("Server is starting to listen...");

while (true)
{
    // block main thread due to some request comes in.
    var context = httpListener.GetContext();
    // request handling
    await pipeline.InvokeAsync(context);
    context.Response.Close();
}