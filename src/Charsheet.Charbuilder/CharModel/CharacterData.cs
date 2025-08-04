using Charsheet.CommonModel;
using Charsheet.PdfGeneration.PrintModel;

namespace Charsheet.Charbuilder.CharModel;

public class CharacterData
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

    public int ProficiencyMod { get; init; }
    public required StatBasedArray Stats { get; init; } //todo: allow nulls
    public List<Stats> SaveProficiencies { get; init; } = [];
    public List<(SkillsInGame, SkillProficiencyLevel)> SkillProfs { get; init; } = [];

    public int? Ac { get; init; }
    public int? Hp { get; init; }
    public List<HitDie> HitDice { get; init; } = [];
    public int? Init { get; init; }
    public int? Speed { get; init; }
    public bool? HasInspiration { get; init; }
    public int? Gold { get; init; }

    public List<Ability> AbilitiesFromSpecies { get; init; } = [];
    public List<Ability> AbilitiesFromClasses { get; init; } = [];
    public List<Ability> AbilitiesFromFeats { get; init; } = [];
    public List<Ability> AbilitiesFromItems { get; init; } = [];
    public List<Ability> AbilitiesFromOther { get; init; } = [];

    public List<Attack> Attacks { get; init; } = [];
    public List<Consumable> Consumables { get; init; } = [];
    public List<Equipment> Equipments { get; init; } = [];
    public List<string> Inventory { get; init; } = [];
    public string? BackgroundStory { get; init; }
}

public class SkillProficiency // TODO
{
    public SkillsInGame Skill { get; init; }
    public SkillProficiencyLevel ProficiencyLevel { get; init; }
    public Func<CharacterData, int, int> AdditionalModifications { get; init; } = (_, mod) => mod;
}
