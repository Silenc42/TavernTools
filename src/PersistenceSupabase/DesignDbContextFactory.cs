using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PersistenceSupabase;

public class DesignDbContextFactory : IDesignTimeDbContextFactory<DatabaseTables>
{
    public DatabaseTables CreateDbContext(string[] args)
    {
        const string dummyConnection = "Host=localhost;Database=FakeDb;Username=postgres;Password=placeholder;";
        var options = new DbContextOptionsBuilder<DatabaseTables>()
            .UseNpgsql(dummyConnection)
            .Options;

        return new DatabaseTables(options);
    }
}