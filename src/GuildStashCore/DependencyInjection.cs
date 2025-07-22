using Contracts.GuildStash;
using Microsoft.Extensions.DependencyInjection;

namespace GuildStashCore;

public static class DependencyInjection
{
    public static IServiceCollection AddGuildStashCore(this IServiceCollection services)
    {
        services
            .AddTransient<StashService, StashServiceImpl>();
        return services;
    }
}