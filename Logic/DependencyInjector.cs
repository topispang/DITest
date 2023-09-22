namespace Logic;

using Autofac;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjector
{
    private static readonly List<(Type, Type, string)> Tuples = new()
    {
        (typeof(ILogicProvider), typeof(LogicProvider), "Scoped"),
        (typeof(IGlobalLogging), typeof(GlobalLogging), "Scoped")
    };

    public static void RegisterMsdi(this IServiceCollection services)
    {
        foreach (var valueTuple in Tuples.Where(t => t.Item3 == "Scoped"))
        {
            services.AddScoped(valueTuple.Item1, valueTuple.Item2);
        }
    }

    public static void RegisterAf(this ContainerBuilder builder)
    {
        foreach (var valueTuple in Tuples.Where(t => t.Item3 == "Scoped"))
        {
            builder.RegisterType(valueTuple.Item2).As(valueTuple.Item1).InstancePerLifetimeScope();
        }
    }
}
