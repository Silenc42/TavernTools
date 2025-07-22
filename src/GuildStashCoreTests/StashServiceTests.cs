using Contracts.GuildStash;
using GuildStashCore;

namespace GuildStashCoreTests;

public class StashServiceTests
{
    [Test]
    public void EmptyRepository_EmptyResponse()
    {
        // Arrange
        StashRepository repo = new StashRepositoryFake([]);
        StashServiceImpl sut = new StashServiceImpl(repo);

        // Act
        List<SeparateItem> actual = sut.CurrentStash();

        // Assert
        Assert.That(actual, Is.Empty);
    }
    
    [Test]
    public void NonEmptyRepository_NonEmptyResponse()
    {
        // Arrange
        StashRepository repo = new StashRepositoryFake([new SeparateItemData{BookReference = "ref", ItemName = "name"}]);
        StashServiceImpl sut = new StashServiceImpl(repo);

        // Act
        List<SeparateItem> actual = sut.CurrentStash();

        // Assert
        Assert.That(actual, Has.Count.EqualTo(1));
        Assert.That(actual.Single().ItemName, Is.EqualTo("name")); 
        Assert.That(actual.Single().Reference, Is.EqualTo("ref")); 
    }
}