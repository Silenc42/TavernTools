using Charsheet.CommonModel;

namespace Charsheet.PdfGeneration.PrintModel;

public class CharacterPrintData
{
    public string Name { get; init; } = "";

    /// <summary>
    /// aka. Race or Ancestry
    /// </summary>
    public string Species { get; init; } = "";

    public string Background { get; init; } = "";
    public List<ClassLevel> ClassLevels { get; init; } = [];
    public string? ImageName { get; init; }
    public string? PlayerName { get; init; }

    public StatData Stats { get; init; } = new();
    public List<SkillDetails> Skills { get; init; } = [];

    public int? Ac { get; init; }
    public int? Hp { get; init; }
    public List<HitDie> HitDice { get; init; } = [];
    public int? Init { get; init; }
    public int? Speed { get; init; }
    public bool? HasInspiration { get; init; }
    public int? Gold { get; init; }

    public IEnumerable<ActivePrintAbility> ActiveAbilities { get; init; } = [];
    public IEnumerable<PassivePrintAbility> PassiveAbilities { get; init; } = [];
    public IEnumerable<PrintAbility> AbilitiesWithFullDescription { get; init; } = [];


    public List<Attack> Attacks { get; init; } = [];
    public List<Consumable> Consumables { get; init; } = [];
    public List<Equipment> Equipments { get; init; } = [];

    public string? Inventory { get; init; }

    public string? BackgroundStory { get; init; }
}
