using Charsheet.Charbuilder.CharModel;
using Charsheet.PdfGeneration.PrintModel;

namespace Charsheet.Charbuilder;

public class ToPrintConverter(Mechanics mechanics)
{
    public CharacterPrintData Convert(CharacterData charData) => new()
    {
        Name = charData.Name,
        Species = charData.Species,
        Background = charData.Background,
        ClassLevels = charData.ClassLevels,
        ImageName = charData.ImageName,
        PlayerName = charData.PlayerName,
        Stats = new StatData
        {
            Prof = charData.ProficiencyMod,
            StatScores = charData.Stats,
            StatMods = mechanics.StatsToMods(charData.Stats),
            Saves = mechanics.CalculateSaves(charData)
        },
        Skills = mechanics.SkillDetails(charData),
        Ac = charData.Ac,
        Hp = charData.Hp,
        HitDice = charData.HitDice,
        Init = charData.Init,
        Speed = charData.Speed,
        HasInspiration = charData.HasInspiration,
        Gold = charData.Gold,
        Attacks = charData.Attacks,
        ActiveAbilities = AllAbilities(charData).Where(a => a is ActiveAbility).Cast<ActiveAbility>().Select(a => new ActivePrintAbility
        {
            Title = a.Title,
            Description = a.DescriptionShort,
            Charges = a.Charges
        }),
        PassiveAbilities = AllAbilities(charData).Where(a => a is PassiveAbility).Cast<PassiveAbility>().Select(a => new PassivePrintAbility
        {
            Title = a.Title,
            Description = a.DescriptionShort,
            IsIntegratedInCalculations = a.IsIntegratedInCalculations
        }),
        AbilitiesWithFullDescription = AllAbilities(charData).Select(a => new PrintAbility
        {
            Title = a.Title,
            Description = a.DescriptionLong
        }),
        Equipments = charData.Equipments,
        Inventory = charData.Inventory.Count == 0 ? null : string.Join(", ", charData.Inventory),
        Consumables = charData.Consumables,
        BackgroundStory = charData.BackgroundStory,
    };

    private List<Ability> AllAbilities(CharacterData charData) =>
    [
        ..charData.AbilitiesFromFeats,
        ..charData.AbilitiesFromClasses,
        ..charData.AbilitiesFromSpecies,
        ..charData.AbilitiesFromItems,
        ..charData.AbilitiesFromOther,
    ];
}
