using Microsoft.Extensions.DependencyInjection;

namespace Charsheet.Charbuilder;

public static class DependencyInjection
{
    public static IServiceCollection AddCharbuilderDependencies(this IServiceCollection services)
    {
        return services
                .AddTransient<CharBuilderMain>()
                .AddTransient<Mechanics>()
                .AddTransient<ToPrintConverter>()
            ;
    }
}
