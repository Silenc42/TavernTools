using Contracts.GuildStash;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PeristanceSupabase;

public static class DependencyInjection
{
    public static IServiceCollection AddSupabaseDb(
        this IServiceCollection services,
        IConfiguration config)
    {
        services
            .AddTransient<StashRepository, StashRepositoryImpl>();

        services.AddDbContext<DatabaseTables>(options =>
        {
            string? connectionString = config.GetConnectionString("SupabaseDbConnection");
            if (connectionString is null)
            {
                throw new Exception("No connection string found for SupabaseDbConnection");
            }

            options.UseNpgsql(connectionString);
        });

        return services;
    }

    public static void MigrateDb(IServiceProvider provider)
    {
        DatabaseTables db = provider.GetRequiredService<DatabaseTables>();
        db.Database.Migrate();
    }
}