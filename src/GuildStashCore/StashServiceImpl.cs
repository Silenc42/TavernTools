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
        return new List<SeparateItem>();
    }
}