using Contracts.GuildStash;
using GuildStashCore;

namespace GuildStashCoreTests;

public class StashServiceTests
{
    [Test]
    public void Test1()
    {
        // Arrange
        StashRepository repo = new StashRepositoryFake(new List<SeparateItemData>());
        StashServiceImpl sut = new StashServiceImpl(repo);

        // Act
        List<SeparateItem> actual = sut.CurrentStash();

        // Assert
        Assert.That(actual, Is.Not.Null);
    }
}