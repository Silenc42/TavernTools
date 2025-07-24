using Microsoft.EntityFrameworkCore;

namespace PeristanceSupabase;

public class DatabaseTables : DbContext
{
    public DatabaseTables(DbContextOptions<DatabaseTables> options) : base(options)
    {
    }
    public DbSet<PocEntity> Pocs { get; set; }
}