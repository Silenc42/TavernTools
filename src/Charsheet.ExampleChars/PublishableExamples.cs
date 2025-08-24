using Charsheet.Charbuilder.CharModel;
using Charsheet.CommonModel;
using Charsheet.PdfGeneration.PrintModel;

namespace Charsheet.ExampleChars;

public static class PublishableExamples
{
    public static CharacterData ExampleDataGloryon => new()
    {
        Name = "Gloryon Gloryborn",
        Species = "Human",
        Background = "Folk hero (he claims)",
        ClassLevels =
        [
            new ClassLevel
            {
                ClassName = "Fighter",
                SubClassName = "Eldritch Knight",
                Level = 5
            }
        ],
        ImageName = "Glorion.jpg",
        ProficiencyMod = 3,
        Stats = new StatBasedArray(strength: 18, dexterity: 14, constitution: 16, intelligence: 8, wisdom: 8,
            charisma: 10),
        SaveProficiencies = [Stats.Str, Stats.Con],
        SkillProfs =
        [
            (SkillsInGame.Athletics, SkillProficiencyLevel.Proficient), // Fighter
            (SkillsInGame.Acrobatics, SkillProficiencyLevel.Proficient), // Fighter
            (SkillsInGame.AnimalHandling, SkillProficiencyLevel.Proficient), // Folk Hero
            (SkillsInGame.Survival, SkillProficiencyLevel.Proficient), // Folk Hero
            (SkillsInGame.Intimidation, SkillProficiencyLevel.Proficient), // Human
        ],
        Ac = 16,
        Hp = 47 + 15,
        HitDice =
        [
            new HitDie(10, 10),
            new HitDie(7, 10),
            new HitDie(10, 10),
            new HitDie(10, 10),
            new HitDie(10, 10)
        ],
        Init = 2,
        Speed = 30,
        Gold = null,
        HasInspiration = null,
        AbilitiesFromSpecies =
            [],
        AbilitiesFromClasses =
        [
            new PassiveAbility
            {
                Title = "Great Weapon Fighting",
                DescriptionShort = "Reroll 1 or 2 on damage die.",
                DescriptionLong =
                    "When you roll a 1 or 2 on a damage die for an attack you make with a melee weapon that you are wielding with two hands, you can reroll the die and must use the new roll, even if the new roll is a 1 or a 2. The weapon must have the two-handed or versatile property for you to gain this benefit.",
                IsIntegratedInCalculations = false
            },
            new ActiveAbility
            {
                Title = "Second Wind",
                DescriptionShort = "bAct: heal 1d10+5.",
                DescriptionLong =
                    "You can throw aside all concern for defense to attack with increased ferocity. When you make your first attack roll on your turn, you can decide to attack recklessly. Doing so gives you Advantage on attack rolls using Strength until the start of your next turn, but attack rolls against you have Advantage during that time.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 1,
                    Recharges = AbilityRechargeCondition.Shortrest
                }
            },
            new ActiveAbility
            {
                Title = "Action Surge",
                DescriptionShort = "On your turn, you can take one additional action.",
                DescriptionLong =
                    "Starting at 2nd level, you can push yourself beyond your normal limits for a moment. On your turn, you can take one additional action.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 1,
                    Recharges = AbilityRechargeCondition.Shortrest
                }
            },
            new ActiveAbility
            {
                Title = "Cantrip - Mage Hand",
                DescriptionShort = "act, 1min, 30ft, 10 pounds",
                DescriptionLong =
                    "A spectral, floating hand appears at a point you choose within range. The hand lasts for the duration. The hand vanishes if it is ever more than 30 feet away from you or if you cast this spell again.\n\nWhen you cast the spell, you can use the hand to manipulate an object, open an unlocked door or container, stow or retrieve an item from an open container, or pour the contents out of a vial.\n\nAs a Magic action on your later turns, you can control the hand thus again. As part of that action, you can move the hand up to 30 feet.\n\nThe hand can't attack, activate magic items, or carry more than 10 pounds."
            },
            new ActiveAbility
            {
                Title = "Cantrip - True Strike",
                DescriptionShort = "act, inst, next turn: adv on first attack",
                DescriptionLong =
                    "A spectral, floating hand appears at a point you choose within range. The hand lasts for the duration. The hand vanishes if it is ever more than 30 feet away from you or if you cast this spell again.\n\nWhen you cast the spell, you can use the hand to manipulate an object, open an unlocked door or container, stow or retrieve an item from an open container, or pour the contents out of a vial.\n\nAs a Magic action on your later turns, you can control the hand thus again. As part of that action, you can move the hand up to 30 feet.\n\nThe hand can't attack, activate magic items, or carry more than 10 pounds."
            },
            new ActiveAbility
            {
                Title = "Spellcasting",
                DescriptionShort =
                    "Mage Hand, True Strike; Shield, Magic Missile, Feather Fall, Protection from Evil and Good",
                DescriptionLong =
                    "Cantrips. You learn two cantrips of your choice from the wizard spell list. You learn an additional wizard cantrip of your choice at 10th level. Spell Slots. The Eldritch Knight Spellcasting table shows how many spell slots you have to cast your wizard spells of 1st level and higher. To cast one of these spells, you must expend a slot of the spell's level or higher. You regain all expended spell slots when you finish a long rest.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 3,
                    Recharges = AbilityRechargeCondition.Longrest
                }
            },
            new ActiveAbility
            {
                Title = "Spell - Shield",
                DescriptionShort = "react when attacked, self",
                DescriptionLong =
                    "+5 AC until start of your next turn."
            },
            new ActiveAbility
            {
                Title = "Spell - Magic Missile",
                DescriptionShort = "act, 120ft.",
                DescriptionLong =
                    "3 darts: 1d4+1 each"
            },
            new ActiveAbility
            {
                Title = "Spell - Feather Fall",
                DescriptionShort = "react when falling, 60ft., 1min",
                DescriptionLong =
                    "Up to five falling creatures; descent slows to 60 feet per round"
            },
            new ActiveAbility
            {
                Title = "Spell - Protection from Evil and Good",
                DescriptionShort = "act, touch, 10min, concentration",
                DescriptionLong =
                    "aberrations, celestials, elementals, fey, fiends, and undead: dAdv. on attacks against target. No charm, fright, possessed + adv. on saves vs. ongoing."
            },
            new ActiveAbility
            {
                Title = "Weapon Bond",
                DescriptionShort = "No Disarm, bAct: summon",
                DescriptionLong =
                    "At 3rd level, you learn a ritual that creates a magical bond between yourself and one weapon. You perform the ritual over the course of 1 hour, which can be done during a short rest. The weapon must be within your reach throughout the ritual, at the conclusion of which you touch the weapon and forge the bond. Once you have bonded a weapon to yourself, you can't be disarmed of that weapon unless you are incapacitated. If it is on the same plane of existence, you can summon that weapon as a bonus action on your turn, causing it to teleport instantly to your hand. You can have up to two bonded weapons, but can summon only one at a time with your bonus action. If you attempt to bond with a third weapon, you must break the bond with one of the other two.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 3,
                    Recharges = AbilityRechargeCondition.Longrest
                }
            },
            new PassiveAbility
            {
                Title = "Extra Attack",
                DescriptionShort = "Attack Twice. Gloriously!",
                DescriptionLong =
                    "Beginning at 5th level, you can attack twice, instead of once, whenever you take the Attack action on your turn.",
                IsIntegratedInCalculations = false
            },
        ],
        AbilitiesFromFeats =
        [
            new ActiveAbility
            {
                Title = "Great Weapon Master",
                DescriptionShort = "On Crit or Kill, bAct: attack; Power Attack at -5/+10",
                DescriptionLong =
                    "You've learned to put the weight of a weapon to your advantage, letting its momentum empower your strikes. You gain the following benefits: On your turn, when you score a critical hit with a melee weapon or reduce a creature to 0 hit points with one, you can make one melee weapon attack as a bonus action. Before you make a melee attack with a heavy weapon that you are proficient with, you can choose to take a -5 penalty to the attack roll. If the attack hits, you add +10 to the attack's damage.",
            },
        ],
        AbilitiesFromItems = [],
        AbilitiesFromOther =
        [
            new PassiveAbility
            {
                Title = "Language and Tool Proficiencies",
                DescriptionShort = "Common",
                DescriptionLong = "Tools: Yes, he is,\nLanguages: Common",
                IsIntegratedInCalculations = false
            },
        ],
        Attacks =
        [
            new Attack
            {
                Name = "Greatsword",
                AtkBonus = 7,
                Damage = "2d6+4 s",
                Notes = "GWM, style"
            },
            new Attack
            {
                Name = "Longbow",
                AtkBonus = 5,
                Damage = "1d8+2 p",
                Notes = "150/600"
            },
            new Attack
            {
                Name = "Throwing Knife",
                AtkBonus = 7,
                Damage = "1d4+2 p",
                Notes = "20/60"
            },
        ],
        Equipments =
        [
            new Equipment
            {
                Name = "Greatsword of Destiny",
                Notes =
                    "It is magical, sentient and it talks! Really! You are just not glorious enought to hear it!"
            }
        ],
        Consumables =
        [
        ],
        BackgroundStory =
            "Gloryon, as a child, suffered under the heels of an oppressive tyrant. One day, a noble knight came to help him. The knight gave him a sword and showed him how to hold it. Gloryon fought off the tyrant and freed the other children. He would later become a great warrior and often recount the story of his first victory. Few realize that the tyrant was the matron of the orphanage he grew up in.\nGloryon is not very bright, but he is convinced that he is a great and brave warrior who fights evil monsters, like orcs. He is, of course, far too brave to spare the women or children. That would lessen the glory he earns!\nAs is right and proper, he made his way through the temple of certain doom and acquired the Sword of Destiny. This magical blade is sentient and encourages Gloryon in his quest for more glory, typically through slaughter. For some reason, others seem not to hear when it talks. But who would care about that.\nBy some twist of destiny, Gloryon finds himself in Barovia. Someone told him that there is a powerful and evil vampire around. But when he looked in the big castle, there was only a polite lord who was announcing his engagement. But they heard about a winery that is overrun with monsters. Exactly the place, where destiny would take a brave knight. So he journeys and quests ever onward to more glory!"
    };
}