using Contracts.GuildStash;

namespace GuildStashCore;

public class StashServiceImpl : StashService
{
    private StashRepository _repository;

    public StashServiceImpl(StashRepository repository)
    {
        _repository = repository;
    }

    public List<SeparateItem> CurrentStash()
    {
        return _repository
            .ReadAllItems()
            .Select(itemData => new SeparateItem
            {
                ItemName = itemData.ItemName,
                Reference = itemData.BookReference
            })
            .ToList();
    }
}