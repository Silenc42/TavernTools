using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PersistenceSupabase;

public class DesignDbContextFactory : IDesignTimeDbContextFactory<DatabaseTables>
{
    public DatabaseTables CreateDbContext(string[] args)
    {

        var options = new DbContextOptionsBuilder<DatabaseTables>()
            .UseNpgsql("Host=localhost;Database=FakeDb;Username=postgres;Password=placeholder;")
            .Options;

        return new DatabaseTables(options);
    }
}