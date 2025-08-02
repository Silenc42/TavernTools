using Contracts.GuildStash;

namespace PersistenceSupabase;

public class StashRepositoryImpl : StashRepository
{
    private readonly DatabaseTables _tables;

    public StashRepositoryImpl(DatabaseTables tables)
    {
        _tables = tables;
    }

    public List<SeparateItemData> ReadAllItems()
    {
        throw new NotImplementedException();
    }

    public List<PersistantPoC> AllPersistantPoCs()
    {
        return _tables.Pocs.Select(p => new PersistantPoC { Name = p.Name }).ToList();
    }

    public void PersistPoC(string content)
    {
        _tables.Pocs.Add(new PocEntity
        {
            Name = content,
            Id = Guid.NewGuid(),
        });
        _tables.SaveChanges();
    }
}