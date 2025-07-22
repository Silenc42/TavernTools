using Contracts.GuildStash;

namespace GuildStashCoreTests;

internal class StashRepositoryFake(List<SeparateItemData> items) : StashRepository
{
    public List<SeparateItemData> ReadAllItems() => items;
}