namespace Contracts.GuildStash;

public interface StashRepository
{
    List<SeparateItemData> ReadAllItems();
}