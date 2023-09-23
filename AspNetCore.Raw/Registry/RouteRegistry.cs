using System.Reflection;

using AspNetCore.Raw.Attributes;
using AspNetCore.Raw.Controllers;

namespace AspNetCore.Raw.Registry
{
    public sealed class RouteRegistry
    {
        internal Dictionary<string, (Type Controller, MethodInfo Method)> Routes { get; } = new();

        public RouteRegistry()
        {
            var controllers = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(ControllerBase)));

            foreach (var controller in controllers)
            {
                var methods = controller.GetMethods();
                foreach (var method in methods)
                {
                    var routeAttr = method.GetCustomAttribute<RouteAttribute>();
                    if (routeAttr is not null)
                        Routes.Add(routeAttr.Route, (controller, method));
                }
            }
        }
    }
}
