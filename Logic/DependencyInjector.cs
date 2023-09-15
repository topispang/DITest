namespace Logic;

using Autofac;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjector
{
    public static void AddLogicDependencies(this IServiceCollection services)
    {
        services.AddScoped<ILogicProvider, LogicProvider>();
    }

    public static void AddLogicDependencies(this ContainerBuilder builder)
    {
        builder.RegisterType<LogicProvider>().As<ILogicProvider>().InstancePerLifetimeScope();
    }
}
