using System.Reflection;
using Jaroszek.CoderHouse.ScrutorMediator.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Jaroszek.CoderHouse.ScrutorMediator;

/// <summary>
/// Extension methods for setting up ScrutorMediator services in an <see cref="IServiceCollection" />
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds ScrutorMediator services to the specified <see cref="IServiceCollection" />
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to</param>
    /// <param name="lifetime">The lifetime of the mediator service</param>
    /// <param name="assemblies">Assemblies to scan for handlers</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained</returns>
    public static IServiceCollection AddScrutorMediator(
        this IServiceCollection services,
        ServiceLifetime lifetime = ServiceLifetime.Scoped,
        params Assembly[] assemblies)
    {
        // Register the mediator
        services.Add(new ServiceDescriptor(typeof(IMediator), typeof(Mediator), lifetime));

        // Register command handlers
        services.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        // Register query handlers
        services.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}