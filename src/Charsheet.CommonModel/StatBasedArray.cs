namespace Charsheet.CommonModel;

public class StatBasedArray
{
    private readonly int? _strength;
    private readonly int? _dexterity;
    private readonly int? _constitution;
    private readonly int? _intelligence;
    private readonly int? _wisdom;
    private readonly int? _charisma;

    public StatBasedArray(int? strength = null,
        int? dexterity = null,
        int? constitution = null,
        int? intelligence = null,
        int? wisdom = null,
        int? charisma = null)
    {
        _strength = strength;
        _dexterity = dexterity;
        _constitution = constitution;
        _intelligence = intelligence;
        _wisdom = wisdom;
        _charisma = charisma;
    }

    public StatBasedArray Applying(
        Func<int?, int?> func)
    {
        return new StatBasedArray(
            strength: func(_strength),
            dexterity: func(_dexterity),
            constitution: func(_constitution),
            intelligence: func(_intelligence),
            wisdom: func(_wisdom),
            charisma: func(_charisma));
    }

    public int? this[Stats stat] =>
        stat switch
        {
            Stats.Str => _strength,
            Stats.Dex => _dexterity,
            Stats.Con => _constitution,
            Stats.Int => _intelligence,
            Stats.Wis => _wisdom,
            Stats.Cha => _charisma,
            _ => throw new ArgumentOutOfRangeException(nameof(stat), stat, null)
        };
}
