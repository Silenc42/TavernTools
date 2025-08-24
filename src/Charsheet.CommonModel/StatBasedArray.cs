using System.Text.Json.Serialization;

namespace Charsheet.CommonModel;

public class StatBasedArray
{
    public int? Strength { get;}
    public int? Dexterity { get;}
    public int? Constitution { get;}
    public int? Intelligence { get;}
    public int? Wisdom { get;}
    public int? Charisma { get;}

    [JsonConstructor]
    public StatBasedArray(int? strength = null,
        int? dexterity = null,
        int? constitution = null,
        int? intelligence = null,
        int? wisdom = null,
        int? charisma = null)
    {
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
    }

    public StatBasedArray Applying(
        Func<int?, int?> func)
    {
        return new StatBasedArray(
            strength: func(Strength),
            dexterity: func(Dexterity),
            constitution: func(Constitution),
            intelligence: func(Intelligence),
            wisdom: func(Wisdom),
            charisma: func(Charisma));
    }

    public int? this[Stats stat] =>
        stat switch
        {
            Stats.Str => Strength,
            Stats.Dex => Dexterity,
            Stats.Con => Constitution,
            Stats.Int => Intelligence,
            Stats.Wis => Wisdom,
            Stats.Cha => Charisma,
            _ => throw new ArgumentOutOfRangeException(nameof(stat), stat, null)
        };
}
