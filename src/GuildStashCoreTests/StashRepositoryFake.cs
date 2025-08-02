using Contracts.GuildStash;

namespace GuildStashCoreTests;

internal class StashRepositoryFake(List<SeparateItemData> items) : StashRepository
{
    public List<SeparateItemData> ReadAllItems() => items;

    public List<PersistantPoC> AllPersistantPoCs()
    {
        throw new NotImplementedException();
    }

    public void PersistPoC(string persistantPoC)
    {
        throw new NotImplementedException();
    }
}