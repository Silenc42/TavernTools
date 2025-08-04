using Charsheet.Charbuilder.CharModel;
using Charsheet.CommonModel;
using Charsheet.PdfGeneration.PrintModel;

namespace Charsheet.Charbuilder;

public class Mechanics
{
    public Stats SkillsMainStat(SkillsInGame skill)
    {
        return skill switch
        {
            SkillsInGame.Acrobatics => Stats.Dex,
            SkillsInGame.AnimalHandling => Stats.Wis,
            SkillsInGame.Arcana => Stats.Int,
            SkillsInGame.Athletics => Stats.Str,
            SkillsInGame.Deception => Stats.Cha,
            SkillsInGame.History => Stats.Int,
            SkillsInGame.Insight => Stats.Wis,
            SkillsInGame.Intimidation => Stats.Cha,
            SkillsInGame.Investigation => Stats.Int,
            SkillsInGame.Medicine => Stats.Wis,
            SkillsInGame.Nature => Stats.Int,
            SkillsInGame.Perception => Stats.Wis,
            SkillsInGame.Performance => Stats.Cha,
            SkillsInGame.Persuasion => Stats.Cha,
            SkillsInGame.Religion => Stats.Int,
            SkillsInGame.SleightOfHand => Stats.Dex,
            SkillsInGame.Stealth => Stats.Dex,
            SkillsInGame.Survival => Stats.Wis,
            _ => throw new ArgumentOutOfRangeException(nameof(skill), skill, null)
        };
    }

    public StatBasedArray StatsToMods(StatBasedArray stats) => stats.Applying(StatToModifier);

    private int? StatToModifier(int? stat)
    {
        return stat / 2 - 5;
    }
    public StatBasedArray CalculateSaves(CharacterData charData)
    {
        return new StatBasedArray(
            strength: SavingThrow(charData, Stats.Str),
            dexterity: SavingThrow(charData, Stats.Dex),
            constitution: SavingThrow(charData, Stats.Con),
            intelligence: SavingThrow(charData, Stats.Int),
            wisdom: SavingThrow(charData, Stats.Wis),
            charisma: SavingThrow(charData, Stats.Cha));
    }

    private int? SavingThrow(CharacterData charData, Stats stat)
    {
        return charData.SaveProficiencies.Contains(stat)
            ? StatToModifier(charData.Stats[stat]) + charData.ProficiencyMod
            : null;
    }

    public List<SkillDetails> SkillDetails(CharacterData charData) =>
        Enum.GetValuesAsUnderlyingType<SkillsInGame>()
            .Cast<SkillsInGame>()
            .Select(skill => new SkillDetails
            {
                SkillName = skill,
                MainStat = SkillsMainStat(skill),
                Modifiers = charData.SkillProfs.SingleOrDefault(s => s.Item1 == skill).Item2 switch
                {
                    SkillProficiencyLevel.None => StatsToMods(charData.Stats),
                    SkillProficiencyLevel.Proficient => StatsToMods(charData.Stats).Applying(s => s + charData.ProficiencyMod),
                    SkillProficiencyLevel.Expertise => StatsToMods(charData.Stats).Applying(s => s + 2 * charData.ProficiencyMod),
                    _ => throw new ArgumentOutOfRangeException()
                },
                ProficiencyLevel = charData.SkillProfs.SingleOrDefault(s => s.Item1 == skill).Item2
            }).ToList();
}
