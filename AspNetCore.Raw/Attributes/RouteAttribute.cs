namespace AspNetCore.Raw.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RouteAttribute : Attribute
    {
        public RouteAttribute(string route)
        {
            Route = route;
        }

        public string Route { get; }
    }
}
