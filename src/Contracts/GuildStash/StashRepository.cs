namespace Contracts.GuildStash;

public interface StashRepository
{
    List<SeparateItemData> ReadAllItems();
    
    List<PersistantPoC> AllPersistantPoCs();
    void PersistPoC(string persistantPoC);
}