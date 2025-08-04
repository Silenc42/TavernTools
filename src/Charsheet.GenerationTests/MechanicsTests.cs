using Charsheet.Charbuilder;
using Charsheet.CommonModel;
using FluentAssertions;

namespace Charsheet.GenerationTests;

public class MechanicsTests
{
    private readonly Mechanics _sut = new();

    [Theory]
    [InlineData(3,-4)]
    [InlineData(6,-2)]
    [InlineData(7,-2)]
    [InlineData(8,-1)]
    [InlineData(9,-1)]
    [InlineData(10,0)]
    [InlineData(11,0)]
    [InlineData(12,1)]
    [InlineData(13,1)]
    [InlineData(14,2)]
    [InlineData(15,2)]
    [InlineData(20,5)]
    [InlineData(23,6)]
    public void StatToModTests(int stat, int expectedMod)
    {
        StatBasedArray input = new(strength: stat);
        StatBasedArray actualMod = _sut.StatsToMods(input);
        actualMod[Stats.Str].Should().Be(expectedMod);
    }

    [Fact]
    public void CheckStats()
    {
        StatBasedArray input = new(
            strength: 18,
            dexterity: 8,
            constitution: 16,
            intelligence: 14,
            wisdom: 10, charisma: 12);
        StatBasedArray expect = new(
            strength: 4,
            dexterity: -1,
            constitution: 3,
            intelligence: 2,
            wisdom: 0, charisma: 1);

        Mechanics mechanics = new();
        StatBasedArray output = mechanics.StatsToMods(input);

        foreach (Stats s in Enum.GetValuesAsUnderlyingType<Stats>())
        {
            output[s].Should().Be(expect[s]);
        }
    }
}
