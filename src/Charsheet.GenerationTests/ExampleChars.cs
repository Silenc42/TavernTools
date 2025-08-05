using Charsheet.Charbuilder.CharModel;
using Charsheet.CommonModel;
using Charsheet.PdfGeneration.PrintModel;

namespace Charsheet.GenerationTests;

public static class ExampleChars
{
    public static CharacterData ExampleDataArguszFarkas => new()
    {
        Name = "Árgusz Farkas",
        Species = "Beastfolk (Devil-Wolf)",
        Background = "Soldier",
        ClassLevels =
        [
            new ClassLevel
            {
                ClassName = "Barbarian",
                SubClassName = "Old Gods",
                Level = 3
            }
        ],
        ImageName = "Argusz.png",
        ProficiencyMod = 2,
        Stats = new StatBasedArray(strength: 18, dexterity: 8, constitution: 16, intelligence: 10, wisdom: 14,
            charisma: 12),
        SaveProficiencies = [Stats.Str, Stats.Con],
        SkillProfs =
        [
            (SkillsInGame.Athletics, SkillProficiencyLevel.Proficient), // Soldier
            (SkillsInGame.Intimidation, SkillProficiencyLevel.Expertise), // Barbarian-OldGods (+Soldier)
            (SkillsInGame.Nature, SkillProficiencyLevel.Proficient), // Barbarian
            (SkillsInGame.Survival, SkillProficiencyLevel.Proficient), // Barbarian
            (SkillsInGame.Perception, SkillProficiencyLevel.Proficient), // Barbarian
        ],
        Ac = 18,
        Hp = 39,
        HitDice =
        [
            new HitDie(12, 12),
            new HitDie(8, 12),
            new HitDie(10, 12)
        ],
        Init = -1,
        Speed = 30,
        Gold = null,
        HasInspiration = null,
        AbilitiesFromSpecies =
        [
            new PassiveAbility
            {
                Title = "Wild and Free",
                DescriptionShort = "Advantage on saves against charm.",
                DescriptionLong = "You have advantage on saving throws against being charmed.",
                IsIntegratedInCalculations = false
            },
            new PassiveAbility
            {
                Title = "Extra Arms",
                DescriptionShort = "You have an extra pair of arms.",
                DescriptionLong =
                    "You have one or more additional sets of arms. These additional arms can lift and manipulate objects weighing up to your Strength ability score but cannot properly wield shields or weapons with the heavy property.",
                IsIntegratedInCalculations = false
            },
            new PassiveAbility
            {
                Title = "Natural Armor",
                DescriptionShort = "AC = 13 + Con or Dex, can use shield",
                DescriptionLong =
                    "When you aren’t wearing armor, your AC equals 13 + your Constitution or Dexterity modifier. You can still use a shield and gain this benefit.",
                IsIntegratedInCalculations = true
            },
        ],
        AbilitiesFromClasses =
        [
            new ActiveAbility
            {
                Title = "Rage",
                DescriptionShort = "+2 Damage, Resist p/b/s, Adv. on Str checks and saves",
                DescriptionLong =
                    "You can imbue yourself with a primal power called Rage, a force that grants you extraordinary might and resilience. You can enter it as a Bonus Action if you aren't wearing Heavy armor." +
                    "\nYou can enter your Rage the number of times shown for your Barbarian level in the Rages column of the Barbarian Features table. You regain one expended use when you finish a Short Rest, and you regain all expended uses when you finish a Long Rest." +
                    "\nWhile active, your Rage follows the rules below." +
                    "\nDamage Resistance: You have Resistance to Bludgeoning, Piercing, and Slashing damage." +
                    "\nRage Damage: When you make an attack using Strength - with either a weapon or an Unarmed Strike - and deal damage to the target, you gain a bonus to the damage that increases as you gain levels as a Barbarian, as shown in the Rage Damage column of the Barbarian Features table." +
                    "\nStrength Advantage: You have Advantage on Strength checks and Strength saving throws." +
                    "\nNo Concentration or Spells: You can't maintain Concentration, and you can't cast spells." +
                    "\nDuration: The Rage lasts until the end of your next turn, and it ends early if you don Heavy armor or have the Incapacitated condition. If your Rage is still active on your next turn, you can extend the Rage for another round by doing one of the following:" +
                    "\n - Make an attack roll against an enemy.\n - Force an enemy to make a saving throw.\n - Take a Bonus Action to extend your Rage." +
                    "\nEach time the Rage is extended, it lasts until the end of your next turn. You can maintain a Rage for up to 10 minutes.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 3,
                    Recharges = AbilityRechargeCondition.Longrest
                }
            },
            new ActiveAbility
            {
                Title = "Mastery: Combination",
                DescriptionShort = "Second pugilist hit to a creature deals +prof damage.",
                DescriptionLong =
                    "The second time on your turn that you hit the same creature with an unarmed strike or an attack with a Pugilist weapon, you deal extra damage to it equal to your proficiency bonus.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 0,
                    Recharges = AbilityRechargeCondition.YourTurn
                }
            },
            new ActiveAbility
            {
                Title = "Brute Strength",
                DescriptionShort = "On melee weapon hit, grapple or shove for free.",
                DescriptionLong =
                    "You are relentless in battle, filled with a bloodlust and rage of the Old Gods. You are proficient with improvised weapons. Your unarmed strike and attacks with any melee weapons or improvised weapons that aren’t light deal damage equal to 1d12 plus your Strength modifier." +
                    "\nWhile you are raging, you gain the following benefits:" +
                    "\n - All melee weapons you wield that aren’t light gain the heavy and thrown properties, including improvised weapons. A weapon which doesn’t specify a thrown range gains a range of 30/60 while you are wielding it." +
                    "\n - Once on your turn when you hit a creature within 5 feet of you with a melee weapon attack, you can try to grapple or shove that creature as part of the same attack." +
                    "\n - If your size is Small, you don’t have disadvantage on attack rolls when wielding a heavy weapon.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 1,
                    Recharges = AbilityRechargeCondition.YourTurn
                }
            },
            new ActiveAbility
            {
                Title = "Reckless Attack",
                DescriptionShort =
                    "On first attack, your strength-based attacks and attacks against you get advantage until your next turn.",
                DescriptionLong =
                    "You can throw aside all concern for defense to attack with increased ferocity. When you make your first attack roll on your turn, you can decide to attack recklessly. Doing so gives you Advantage on attack rolls using Strength until the start of your next turn, but attack rolls against you have Advantage during that time.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 0,
                    Recharges = AbilityRechargeCondition.YourTurn
                }
            },
            new PassiveAbility
            {
                Title = "Primal Knowledge",
                DescriptionShort =
                    "While raging, you can use strength for Acrobatics, Intimidation, Perception, Stealth, or Survival.",
                DescriptionLong =
                    "You gain proficiency in another skill of your choice from the skill list available to Barbarians at level 1.\nIn addition, while your Rage is active, you can channel primal power when you attempt certain tasks; whenever you make an ability check using one of the following skills, you can make it as a Strength check even if it normally uses a different ability: Acrobatics, Intimidation, Perception, Stealth, or Survival. When you use this ability, your Strength represents primal power coursing through you, honing your agility, bearing, and senses.",
                IsIntegratedInCalculations = false
            },
            new PassiveAbility
            {
                Title = "Danger Sense",
                DescriptionShort = "Advantage on Dex saving throws unless incapacitated.",
                DescriptionLong =
                    "You gain an uncanny sense of when things aren't as they should be, giving you an edge when you dodge perils. You have Advantage on Dexterity saving throws unless you have the Incapacitated condition.",
                IsIntegratedInCalculations = false
            },
            new PassiveAbility
            {
                Title = "Imbued by the Gods I",
                DescriptionShort = "You have expertise in intimidation.",
                DescriptionLong =
                    "You gain proficiency in Intimidation if you don’t already have\nit, and add twice your proficiency bonus to Intimidation checks.",
                IsIntegratedInCalculations = true
            },
            new PassiveAbility
            {
                Title = "Imbued by the Gods II",
                DescriptionShort = "Larger for carrying; long and high jump doubled",
                DescriptionLong =
                    "You count as one size larger when determining your carrying capacity and the weight you can push, drag, or lift. Your long jump and high jump are doubled.",
                IsIntegratedInCalculations = false
            },
        ],
        AbilitiesFromFeats =
        [
            new ActiveAbility
            {
                Title = "Savage Attacker",
                DescriptionShort = "On a weapon hit, roll the damage twice and use either.",
                DescriptionLong =
                    "You've trained to deal particularly damaging strikes. Once per turn when you hit a target with a weapon, you can roll the weapon's damage dice twice and use either roll against the target.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 1,
                    Recharges = AbilityRechargeCondition.Turn
                }
            },
        ],
        AbilitiesFromItems =
        [
            new ActiveAbility
            {
                Title = "Improved Hookshot (15ft.)",
                DescriptionShort =
                    "Bonus or reaction when falling: shoot at a fixed surface or a creature at least two sizes larger than you.",
                DescriptionLong =
                    "Hookshot: This enhancement consists of a metallic hook or similar tool typically attached to a spool of wire, though rope, chain, or even spidersilk may be used instead.The number in parentheses is the range of the hookshot. If the prosthesis isn’t being used to hold an item, you can shoot the hook at a fixed surface within range as a bonus action, or as a reaction when falling. The hook then attaches to that surface until you use a bonus action to detach the hook and reel the wire back in, or until the wire is destroyed. The wire is an object with AC 19 and 10 hit points; resistance to fire and cold damage; and immunity to lightning, psychic, and poison damage. The AC, price, and other properties of this wire can vary if different materials are used (GM’s discretion)." +
                    "\nAlternatively, you can fire the hook at another creature at least two sizes larger than you, making an attack roll with the prosthesis. You’re considered proficient with the attack, which uses your Strength or Dexterity modifier for the attack roll. On a hit, it deals no damage, but the hook attaches to the target. A creature within 5 feet of the hook can use an action to forcefully detach the hook with a successful DC 10 Strength or Dexterity check." +
                    "\nWhile the hook is attached, you have advantage on ability checks made to move along the wire, such as to climb a vertical surface, swim against a current, or walk against a strong wind, and you can’t move or be moved more than the hookshot’s range away from the point to which the hook is attached. If you’re falling, you stop falling further than the range at which you shot the hookshot and become suspended from the surface the hook is attached to. In addition, until the hook is reeled back in, the prosthesis can’t hold anything or be used to make attacks, and you can’t use or benefit from objects integrated into the prosthesis (such as attacking with a weapon or benefitting from a shield’s bonus to AC)." +
                    "\nImproved Hookshot: This prosthesis uses a shield instead of a hook for its Hookshot property. As an action while the shield is attached to a target, you can reel yourself in. When you do, you move a number of feet up to the item’s Hookshot range in a straight line towards the shield."
            },
        ],
        AbilitiesFromOther =
        [
            new PassiveAbility
            {
                Title = "Language and Tool Proficiencies",
                DescriptionShort = "Lyre/Harp, Common, Infernal, Sign Language",
                DescriptionLong = "Tools: Lyre/Harp,\nLanguages: Common, Infernal, Sign Language",
                IsIntegratedInCalculations = false
            },
        ],
        Attacks =
        [
            new Attack
            {
                Name = "Unarmed Strike",
                AtkBonus = 6,
                Damage = "1d12+4 b",
                Notes = "Rage: +2"
            },
            new Attack
            {
                Name = "Bonus Strike",
                AtkBonus = 6,
                Damage = "1d12 b",
                Notes = "Rage: +2, bonus action"
            },
            new Attack
            {
                Name = "Launching Tarak",
                AtkBonus = 6,
                Damage = "1d6+4 b",
                Notes = "Rage: +2, Thrown 15f."
            },
        ],
        Equipments =
        [
            new Equipment
            {
                Name = "Iron Kasa - \"Tarak\"",
                Notes =
                    "Integrated (shield), Launch (1d6b, 15ft.), Hookshot (15ft.), Improved Hookshot. [Ryoko's p. 254]"
            }
        ],
        Consumables =
        [
            new Consumable
            {
                Name = "Goodberry",
                Amount = 2,
                Notes = "Bonus action: restore 1 hp and nourish for one day"
            }
        ]
    };

/*
    public static CharacterData ExampleDataYlfa => new()
    {
        Name = "Ylfa Starborn",
        Species = "Human",
        Background = "Guide",
        ClassLevels =
        [
            new ClassLevel
            {
                ClassName = "Druid",
                SubClassName = "Circle of the Stars",
                Level = 3
            }
        ],
        ImageName = "Ylfa.png",
        ProficiencyMod = 2,
        Stats = new StatBasedArray(strength: 10, dexterity: 16, constitution: 14, intelligence: 12, wisdom: 18,
            charisma: 8),
        SaveProficiencies = [Stats.Int, Stats.Wis],
        SkillProfs =
        [
            (SkillsInGame.AnimalHandling, SkillProficiencyLevel.Proficient),
            (SkillsInGame.Arcana, SkillProficiencyLevel.Proficient),
            (SkillsInGame.Nature, SkillProficiencyLevel.Proficient), // todo +int
            (SkillsInGame.Perception, SkillProficiencyLevel.Proficient),
            (SkillsInGame.Stealth, SkillProficiencyLevel.Proficient),
            (SkillsInGame.Survival, SkillProficiencyLevel.Proficient),
        ],
        Ac = 17,
        Hp = 33,
        HitDice =
        [
            new HitDie(4, 4),
            new HitDie(6, 6),
            new HitDie(8, 8),
            new HitDie(10, 10),
            new HitDie(12, 12),
            new HitDie(20, 20),
            new HitDie(0, 0),

            //new HitDie(8, 8),
            //new HitDie(5, 8),
            //new HitDie(7, 8)
        ],
        Init = 3,
        Speed = 30,
        //Gold = 20,
        //HasInspiration = false,
        AbilitiesFromSpecies =
        [
            new PassiveAbility
            {
                Title = "Wild and Free",
                DescriptionShort = "Advantage on saves against charm.",
                DescriptionLong = "You have advantage on saving throws against being charmed.",
                IsIntegratedInCalculations = false
            },
            new PassiveAbility
            {
                Title = "Extra Arms",
                DescriptionShort = "You have an extra pair of arms.",
                DescriptionLong =
                    "You have one or more additional sets of arms. These additional arms can lift and manipulate objects weighing up to your Strength ability score but cannot properly wield shields or weapons with the heavy property.",
                IsIntegratedInCalculations = false
            },
            new PassiveAbility
            {
                Title = "Natural Armor",
                DescriptionShort = "AC = 13 + Con or Dex, can use shield",
                DescriptionLong =
                    "When you aren’t wearing armor, your AC equals 13 + your Constitution or Dexterity modifier. You can still use a shield and gain this benefit.",
                IsIntegratedInCalculations = true
            },
        ],
        AbilitiesFromClasses =
        [
            new ActiveAbility
            {
                Title = "Rage",
                DescriptionShort = "+2 Damage, Resist p/b/s, Adv. on Str checks and saves",
                DescriptionLong =
                    "You can imbue yourself with a primal power called Rage, a force that grants you extraordinary might and resilience. You can enter it as a Bonus Action if you aren't wearing Heavy armor." +
                    "\nYou can enter your Rage the number of times shown for your Barbarian level in the Rages column of the Barbarian Features table. You regain one expended use when you finish a Short Rest, and you regain all expended uses when you finish a Long Rest." +
                    "\nWhile active, your Rage follows the rules below." +
                    "\nDamage Resistance: You have Resistance to Bludgeoning, Piercing, and Slashing damage." +
                    "\nRage Damage: When you make an attack using Strength - with either a weapon or an Unarmed Strike - and deal damage to the target, you gain a bonus to the damage that increases as you gain levels as a Barbarian, as shown in the Rage Damage column of the Barbarian Features table." +
                    "\nStrength Advantage: You have Advantage on Strength checks and Strength saving throws." +
                    "\nNo Concentration or Spells: You can't maintain Concentration, and you can't cast spells." +
                    "\nDuration: The Rage lasts until the end of your next turn, and it ends early if you don Heavy armor or have the Incapacitated condition. If your Rage is still active on your next turn, you can extend the Rage for another round by doing one of the following:" +
                    "\n - Make an attack roll against an enemy.\n - Force an enemy to make a saving throw.\n - Take a Bonus Action to extend your Rage." +
                    "\nEach time the Rage is extended, it lasts until the end of your next turn. You can maintain a Rage for up to 10 minutes.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 3,
                    Recharges = AbilityRechargeCondition.Longrest
                }
            },
            new ActiveAbility
            {
                Title = "Mastery: Combination",
                DescriptionShort = "Second pugilist hit to a creature deals +prof damage.",
                DescriptionLong =
                    "The second time on your turn that you hit the same creature with an unarmed strike or an attack with a Pugilist weapon, you deal extra damage to it equal to your proficiency bonus.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 0,
                    Recharges = AbilityRechargeCondition.YourTurn
                }
            },
            new ActiveAbility
            {
                Title = "Brute Strength",
                DescriptionShort = "On melee weapon hit, grapple or shove for free.",
                DescriptionLong =
                    "You are relentless in battle, filled with a bloodlust and rage of the Old Gods. You are proficient with improvised weapons. Your unarmed strike and attacks with any melee weapons or improvised weapons that aren’t light deal damage equal to 1d12 plus your Strength modifier." +
                    "\nWhile you are raging, you gain the following benefits:" +
                    "\n - All melee weapons you wield that aren’t light gain the heavy and thrown properties, including improvised weapons. A weapon which doesn’t specify a thrown range gains a range of 30/60 while you are wielding it." +
                    "\n - Once on your turn when you hit a creature within 5 feet of you with a melee weapon attack, you can try to grapple or shove that creature as part of the same attack." +
                    "\n - If your size is Small, you don’t have disadvantage on attack rolls when wielding a heavy weapon.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 1,
                    Recharges = AbilityRechargeCondition.YourTurn
                }
            },
            new ActiveAbility
            {
                Title = "Reckless Attack",
                DescriptionShort =
                    "On first attack, your strength-based attacks and attacks against you get advantage until your next turn.",
                DescriptionLong =
                    "You can throw aside all concern for defense to attack with increased ferocity. When you make your first attack roll on your turn, you can decide to attack recklessly. Doing so gives you Advantage on attack rolls using Strength until the start of your next turn, but attack rolls against you have Advantage during that time.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 0,
                    Recharges = AbilityRechargeCondition.YourTurn
                }
            },
            new PassiveAbility
            {
                Title = "Primal Knowledge",
                DescriptionShort =
                    "While raging, you can use strength for Acrobatics, Intimidation, Perception, Stealth, or Survival.",
                DescriptionLong =
                    "You gain proficiency in another skill of your choice from the skill list available to Barbarians at level 1.\nIn addition, while your Rage is active, you can channel primal power when you attempt certain tasks; whenever you make an ability check using one of the following skills, you can make it as a Strength check even if it normally uses a different ability: Acrobatics, Intimidation, Perception, Stealth, or Survival. When you use this ability, your Strength represents primal power coursing through you, honing your agility, bearing, and senses.",
                IsIntegratedInCalculations = false
            },
            new PassiveAbility
            {
                Title = "Danger Sense",
                DescriptionShort = "Advantage on Dex saving throws unless incapacitated.",
                DescriptionLong =
                    "You gain an uncanny sense of when things aren't as they should be, giving you an edge when you dodge perils. You have Advantage on Dexterity saving throws unless you have the Incapacitated condition.",
                IsIntegratedInCalculations = false
            },
            new PassiveAbility
            {
                Title = "Imbued by the Gods I",
                DescriptionShort = "You have expertise in intimidation.",
                DescriptionLong =
                    "You gain proficiency in Intimidation if you don’t already have\nit, and add twice your proficiency bonus to Intimidation checks.",
                IsIntegratedInCalculations = true
            },
            new PassiveAbility
            {
                Title = "Imbued by the Gods II",
                DescriptionShort = "Larger for carrying; long and high jump doubled",
                DescriptionLong =
                    "You count as one size larger when determining your carrying capacity and the weight you can push, drag, or lift. Your long jump and high jump are doubled.",
                IsIntegratedInCalculations = false
            },
        ],
        AbilitiesFromFeats =
        [
            new ActiveAbility
            {
                Title = "Savage Attacker",
                DescriptionShort = "On a weapon hit, roll the damage twice and use either.",
                DescriptionLong =
                    "You've trained to deal particularly damaging strikes. Once per turn when you hit a target with a weapon, you can roll the weapon's damage dice twice and use either roll against the target.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 1,
                    Recharges = AbilityRechargeCondition.Turn
                }
            },
        ],
        AbilitiesFromItems =
        [
            new ActiveAbility
            {
                Title = "Improved Hookshot (15ft.)",
                DescriptionShort =
                    "Bonus or reaction when falling: shoot at a fixed surface or a creature at least two sizes larger than you.",
                DescriptionLong =
                    "Hookshot: This enhancement consists of a metallic hook or similar tool typically attached to a spool of wire, though rope, chain, or even spidersilk may be used instead.The number in parentheses is the range of the hookshot. If the prosthesis isn’t being used to hold an item, you can shoot the hook at a fixed surface within range as a bonus action, or as a reaction when falling. The hook then attaches to that surface until you use a bonus action to detach the hook and reel the wire back in, or until the wire is destroyed. The wire is an object with AC 19 and 10 hit points; resistance to fire and cold damage; and immunity to lightning, psychic, and poison damage. The AC, price, and other properties of this wire can vary if different materials are used (GM’s discretion)." +
                    "\nAlternatively, you can fire the hook at another creature at least two sizes larger than you, making an attack roll with the prosthesis. You’re considered proficient with the attack, which uses your Strength or Dexterity modifier for the attack roll. On a hit, it deals no damage, but the hook attaches to the target. A creature within 5 feet of the hook can use an action to forcefully detach the hook with a successful DC 10 Strength or Dexterity check." +
                    "\nWhile the hook is attached, you have advantage on ability checks made to move along the wire, such as to climb a vertical surface, swim against a current, or walk against a strong wind, and you can’t move or be moved more than the hookshot’s range away from the point to which the hook is attached. If you’re falling, you stop falling further than the range at which you shot the hookshot and become suspended from the surface the hook is attached to. In addition, until the hook is reeled back in, the prosthesis can’t hold anything or be used to make attacks, and you can’t use or benefit from objects integrated into the prosthesis (such as attacking with a weapon or benefitting from a shield’s bonus to AC)." +
                    "\nImproved Hookshot: This prosthesis uses a shield instead of a hook for its Hookshot property. As an action while the shield is attached to a target, you can reel yourself in. When you do, you move a number of feet up to the item’s Hookshot range in a straight line towards the shield."
            },
        ],
        AbilitiesFromOther =
        [
            new PassiveAbility
            {
                Title = "Language and Tool Proficiencies",
                DescriptionShort = "Lyre/Harp, Common, Infernal, Sign Language",
                DescriptionLong = "Tools: Lyre/Harp,\nLanguages: Common, Infernal, Sign Language",
                IsIntegratedInCalculations = false
            },
        ],
        Attacks =
        [
            new Attack
            {
                Name = "Starry Whisp",
                AtkBonus = 6,
                Damage = "1d8 rad",
                Notes = "target glows"
            },
            new Attack
            {
                Name = "Primal Savagery",
                AtkBonus = 6,
                Damage = "1d10 acid",
                Notes = ""
            }
        ],
        Equipments =
        [
            new Equipment
            {
                Name = "Silvered Spoon",
                //Notes = "Integrated (shield), Launch (1d6b, 15ft.), Hookshot (15ft.), Improved Hookshot. [Ryoko's p. 254]"
            }
        ],
        Consumables =
        [
            new Consumable
            {
                Name = "Goodberry",
                Amount = 2,
                Notes = "Bonus action: restore 1 hp and nourish for one day"
            }
        ]
    };
*/

    public static CharacterData ExampleDataCatsPaw => new()
    {
        Name = "Vaelthir\nThe Cat's Paw",
        Background = "Ruined",
        Species = "Kalashtar",
        ProficiencyMod = 2,
        Stats = new StatBasedArray(18, 3, 18, 6, 14, 11),
        SaveProficiencies = [Stats.Str, Stats.Con],
        Ac = 16,
        SkillProfs =
        [
            (SkillsInGame.Athletics, SkillProficiencyLevel.Proficient), // Pugilist
            (SkillsInGame.Perception, SkillProficiencyLevel.Proficient), // Pugilist
            (SkillsInGame.Stealth, SkillProficiencyLevel.Proficient), // Ruined
            (SkillsInGame.Survival, SkillProficiencyLevel.Proficient), // Ruined
        ],
        ClassLevels =
        [
            new ClassLevel
            {
                Level = 3,
                ClassName = "Pugilist",
                SubClassName = "Rift Hitter"
            }
        ],
        Hp = 34,
        HitDice = [new HitDie(8, 8), new HitDie(8, 8), new HitDie(6, 8)],
        Init = -4,
        Speed = 30,
        AbilitiesFromClasses =
        [
            new PassiveAbility
            {
                Title = "Fisticuffs",
                DescriptionLong =
                    "At 1st level, your years of fighting in back alleys and taverns have given you mastery over combat styles that use unarmed strikes and pugilist weapons, which are simple melee weapons without the two-handed property, whips, and improvised weapons. You can’t use the finesse property of a weapon while using it as a pugilist weapon.You gain the following benefits while you are unarmed or using only pugilist weapons and you are wearing light or no armor and not using a shield:" +
                    "\n» You can roll a d6 in place of the normal damage of your unarmed strike or pugilist weapon. This die changes as you gain pugilist levels, as shown in the Fisticuffs column on the Pugilist table." +
                    "\n» When you use the Attack action on your turn and make only unarmed strikes, attacks with pugilist weapons, shoves, or grapples, you can use a bonus action to make one grapple or unarmed strike.",
                IsIntegratedInCalculations = true
            },
            new PassiveAbility
            {
                Title = "Iron Chin",
                DescriptionLong =
                    "Beginning at 1st level, while you are wearing light or no armor and not wielding a shield, your AC equals 12 + your Constitution modifier",
                IsIntegratedInCalculations = true
            },
            new ActiveAbility
            {
                Title = "Moxie",
                DescriptionLong =
                    "Starting at 2nd level, your experience laying the beat-down on others has given you a moxie you can channel in the midst of battle. This swagger is represented by a number of moxie points. Your pugilist level determines the maximum number of points you have, as shown in the Moxie Points column of the Pugilist table.You can spend these points to fuel various moxie features. You start knowing three such features: Brace Up, The Old One-Two, and Stick and Move. You learn more moxie features as you gain levels in this class. You regain all expended moxie points when you finish a short or long rest.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 2,
                    Recharges = AbilityRechargeCondition.Shortrest
                },
            },
            new ActiveAbility
            {
                Title = "Brace Up",
                DescriptionShort = "1 MP, bAct: 1d6 + 7 temp hp for 1 min",
                DescriptionLong =
                    "You can use a bonus action and spend 1 moxie point to brace for attacks. You gain a number of temporary hit points equal to a roll of your fisticuffs die + your pugilist level + your Constitution modifier. You lose any remaining temporary hit points gained in this way after 1 minute."
            },
            new ActiveAbility
            {
                Title = "The Old One-Two",
                DescriptionShort = "1 MP, bAct: 2 attacks",
                DescriptionLong =
                    "Immediately after you take the Attack action on your turn, you can spend 1 moxie point to make two unarmed strikes as a bonus action."
            },
            new ActiveAbility
            {
                Title = "Stick and Move",
                DescriptionShort = "1 MP, bAct: shove or dash",
                DescriptionLong =
                    "You can use a bonus action and expend 1 moxie point to attempt to shove a creature or take the Dash action."
            },
            new PassiveAbility
            {
                Title = "Street Smart",
                DescriptionShort = "Carousing, shadowboxing, and sparring as light activity",
                DescriptionLong =
                    "Beginning at 2nd level, carousing, shadowboxing, and sparring all count as light activity for the purposes of resting for you. Additionally, once you have caroused in a settlement for 8 hours or more, you know all public locations in the city as if you were born and raised there and you cannot be lost by nonmagical means while within the city.",
                IsIntegratedInCalculations = true
            },
            new ActiveAbility
            {
                Title = "Bloodied but Unbowed",
                DescriptionShort = "On bloodied, react: 9 tempHP and restore MP",
                DescriptionLong =
                    "Starting at 3rd level, when you take damage that reduces you to half your maximum hit points or less, you can use your reaction to gain temporary hit points equal to three times your pugilist level and regain all your expended moxie points. Once you use this feature, you can’t use it again until you finish a short or long rest",
                Charges = new AbilityCharges
                {
                    MaxCharges = 1,
                    Recharges = AbilityRechargeCondition.Shortrest
                }
            },
            new PassiveAbility
            {
                Title = "Portal Kombat - Range", // actually Portal Punching
                DescriptionShort = "30ft range for attacks",
                DescriptionLong =
                    "Starting when you choose this fight club at 3rd level, you’ve learned to think, and fight, with portals. On each of your turns, your unarmed strike and melee attacks made with pugilist weapons have a reach of 30 feet, as you send your attacks through rifts in space.",
                IsIntegratedInCalculations = true
            },
            new ActiveAbility
            {
                Title = "Portal Kombat - Grapple", // actually Portal Punching
                DescriptionShort = "1 MP, bAct: grapple and pull to 5ft",
                DescriptionLong =
                    "In addition, when you take the Attack action and only make unarmed strikes or attacks with pugilist weapons, you can use a bonus action and spend 1 moxie point to grapple one creature you targeted with one of those attacks. If your grapple attempt is successful, you immediately pull the creature to an unoccupied space of your choice within 5 feet of you."
            },
            new ActiveAbility
            {
                Title = "Pocket Dimension",
                DescriptionShort = "bAct: store or get from pocket dimension",
                DescriptionLong =
                    "Also starting at 3rd level, your hands become handier than a haversack. As a bonus action, you can quickly plunge anything you’re holding into a personal demi-plane, akin to a bag of holding. The object cannot be any larger than a 2-foot cube. You can store up to 10 objects this way; storing any more causes the first thing you stored to be lost in the Astral Plane." +
                    "\nYou can use your bonus action to retrieve an object you stowed away, either bringing it onto your person or dropping it at a point you can see within 30 feet of you."
            },
            new ActiveAbility
            {
                Title = "Mastery: Combination",
                DescriptionShort = "Second pugilist hit to a creature deals +prof damage.",
                DescriptionLong =
                    "The second time on your turn that you hit the same creature with an unarmed strike or an attack with a Pugilist weapon, you deal extra damage to it equal to your proficiency bonus.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 0,
                    Recharges = AbilityRechargeCondition.YourTurn
                }
            },
        ],
        AbilitiesFromSpecies =
        [
            new PassiveAbility
            {
                Title = "Dual Mind",
                DescriptionLong = "You have advantage on all Wisdom saving throws.",
                IsIntegratedInCalculations = false,
                DescriptionShort = "Advantage on all Wisdom saves."
            },
            new PassiveAbility
            {
                Title = "Mental Discipline",
                DescriptionLong = "You have resistance to psychic damage.",
                IsIntegratedInCalculations = false,
                DescriptionShort = "Resistance to Psychic."
            },
            new PassiveAbility
            {
                Title = "Mind Link",
                DescriptionLong =
                    "You can speak telepathically to any creature you can see, provided the creature is within a number of feet of you equal to 10 times your level. You don't need to share a language with the creature for it to understand your telepathic utterances, but the creature must be able to understand at least one language." +
                    "\nWhen you're using this trait to speak telepathically to a creature, you can use your action to give that creature the ability to speak telepathically with you for 1 hour or until you end this effect as an action. To use this ability, the creature must be able to see you and must be within this trait's range. You can give this ability to only one creature at a time; giving it to a creature takes it away from another creature who has it.",
                IsIntegratedInCalculations = false,
                DescriptionShort = "Telepathy 30ft."
            },
            new PassiveAbility
            {
                Title = "Severed from Dreams",
                DescriptionLong =
                    "Kalashtar sleep, but they don't connect to the plane of dreams as other creatures do. Instead, their minds draw from the memories of their otherworldly spirit while they sleep. As such, you are immune to spells and other magical effects that require you to dream, like dream, but not to spells and other magical effects that put you to sleep, like sleep.",
                IsIntegratedInCalculations = false,
                DescriptionShort = "Immune to dream magic."
            }
        ],
        AbilitiesFromFeats =
        [
            new ActiveAbility
            {
                Title = "Grappler - Punch and Grab",
                DescriptionShort = "Damage and Grapple as unarmed strike",
                DescriptionLong =
                    "When you hit a creature with an Unarmed Strike as part of the Attack action on your turn, you can use both the Damage and the Grapple option. You can use this benefit only once per turn.",
                Charges = new AbilityCharges
                {
                    MaxCharges = 1,
                    Recharges = AbilityRechargeCondition.Turn
                }
            },
            new PassiveAbility
            {
                Title = "Grappler - Fast & Advantage",
                DescriptionLong =
                    "You have Advantage on attack rolls against a creature Grappled by you. You don't have to spend extra movement to move a creature Grappled by you if the creature is your size or smaller.",
                DescriptionShort = "Adv on attack vs. grappled & move normal speed while grappling.",
                IsIntegratedInCalculations = false
            }
        ],
        AbilitiesFromItems =
        [
            new ActiveAbility
            {
                Title = "Boon of Pawrtal",
                DescriptionLong = "You can cast mage hand at will.",
                DescriptionShort = "Mage hand cantrip"
            },

            new PassiveAbility
            {
                Title = "Curse of Pawrtal",
                DescriptionShort = "DC15 wisSV or push stuff off edges.",
                DescriptionLong =
                    "You loose one attunement slot. Whenever a breakable object appears on a flat surface in your area and you arent otherwise occupied: succeed on a DC15 wisdom saving throw or use mage hand to push it off.",
                IsIntegratedInCalculations = false
            },

            new ActiveAbility
            {
                Title = "Legendary Pawrtal Escape",
                DescriptionLong =
                    "Once per day, automatically succeed on the first imposed dexterity save by accidentally falling through a portal. This moves you 30ft in a random direction and you land prone.",
                DescriptionShort = "Succeed on first DexSv, appear 30ft away, prone",
                Charges = new AbilityCharges
                {
                    MaxCharges = 1,
                    Recharges = AbilityRechargeCondition.Longrest
                }
            },
        ],
        AbilitiesFromOther =
        [
            new PassiveAbility
            {
                Title = "Language and Tool Proficiencies",
                DescriptionShort = "Common, Quori, Infernal, Gnomish, Dice, Three-Dragon Ante",
                DescriptionLong = "Tools: Dice, Three-Dragon Ante ,\nLanguages: Common, Quori, Infernal, Gnomish",
                IsIntegratedInCalculations = false
            },
        ],
        Attacks =
        [
            new Attack
            {
                Name = "Unarmed",
                AtkBonus = 6,
                Damage = "1d6+4",
                Notes = "30ft"
            },
            new Attack
            {
                Name = "Spiked knuckle dusters",
                AtkBonus = 6,
                Damage = "1d8+4",
                Notes = "b/p 30ft"
            }
        ],
        Equipments =
        [
            new Equipment { Name = "Spiked Knuckle Dusters" }
        ],
        Inventory =
        [
            "A cracked hourglass",
            "Set of rusty manacles",
            "Half-empty bottle",
            "Hunting trap",
            "Dice",
            "Three-Dragon Ante",
            "Traveler's clothes",
        ],
        Gold = 13,
        ImageName = "Vaeltyr.png",
    };

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

    public static CharacterData ExampleDataZylana => new()
    {
        Name = "Zylana the A",
        Species = "Aasimar",
        Background = "Artisan",
        ClassLevels =
        [
            new ClassLevel
            {
                ClassName = "Artificer",
                SubClassName = "Artillerist",
                Level = 3
            }
        ],
        ImageName = "Zylana.png",
        PlayerName = "Angelina",
        ProficiencyMod = 2,
        Stats = new StatBasedArray(strength: 14, dexterity: 18, constitution: 17, intelligence: 19, wisdom: 16,
            charisma: 12),
        SaveProficiencies = [Stats.Int, Stats.Con],
        SkillProfs =
        [
            (SkillsInGame.Arcana, SkillProficiencyLevel.Proficient), // Artificer
            (SkillsInGame.Perception, SkillProficiencyLevel.Proficient), // Artificer
            (SkillsInGame.Investigation, SkillProficiencyLevel.Proficient), // Artisan
            (SkillsInGame.Persuasion, SkillProficiencyLevel.Proficient), // Artisan
        ],
        Ac = 12 + 4, //studded leather
        Hp = 22 + 9,
        HitDice =
        [
            new HitDie(8, 8),
            new HitDie(6, 8),
            new HitDie(8, 8),
        ],
        Init = 4,
        Speed = 30,
        AbilitiesFromSpecies =
        [
            new PassiveAbility
            {
                IsIntegratedInCalculations = false,
                Title = "Celestial Resistance",
                DescriptionLong = "You have Resistance to Necrotic damage and Radiant damage.",
                DescriptionShort = "Resistance to Necrotic and Radiant"
            },
            new PassiveAbility
            {
                IsIntegratedInCalculations = false,
                Title = "Darkvision",
                DescriptionLong = "You have Darkvision with a range of 60 feet.",
                DescriptionShort = "Darkvision 60 feet."
            },
            new ActiveAbility
            {
                Title = "Healing Hands",
                DescriptionLong =
                    "As a Magic action, you touch a creature and roll a number of d4s equal to your Proficiency Bonus. The creature regains a number of Hit Points equal to the total rolled. Once you use this trait, you can't use it again until you finish a Long Rest.",
                DescriptionShort = "Act, touch: heal prof * d4",
                Charges = new AbilityCharges
                {
                    MaxCharges = 1,
                    Recharges = AbilityRechargeCondition.Longrest
                }
            },
            new PassiveAbility
            {
                IsIntegratedInCalculations = true,
                Title = "Light Bearer",
                DescriptionLong = "You know the Light cantrip. Charisma is your spellcasting ability for it.",
                DescriptionShort = "Light cantrip"
            },
            new ActiveAbility
            {
                Title = "Celestial Revelation",
                DescriptionLong =
                    "When you reach character level 3, you can transform as a Bonus Action using one of the options below (choose the option each time you transform). The transformation lasts for 1 minute or until you end it (no action required). Once you transform, you can't do so again until you finish a Long Rest." +
                    "\nOnce on each of your turns before the transformation ends, you can deal extra damage to one target when you deal damage to it with an attack or a spell. The extra damage equals your Proficiency Bonus, and the extra damage's type is either Necrotic for Necrotic Shroud or Radiant for Heavenly Wings and Inner Radiance." +
                    "\nHere are the transformation options:" +
                    "\nHeavenly Wings. Two spectral wings sprout from your back temporarily. Until the transformation ends, you have a Fly Speed equal to your Speed." +
                    "\nInner Radiance. Searing light temporarily radiates from your eyes and mouth. For the duration, you shed Bright Light in a 10-foot radius and Dim Light for an additional 10 feet, and at the end of each of your turns, each creature within 10 feet of you takes Radiant damage equal to your Proficiency Bonus." +
                    "\nNecrotic Shroud. Your eyes briefly become pools of darkness, and flightless wings sprout from your back temporarily. Creatures other than your allies within 10 feet of you must succeed on a Charisma saving throw (DC 8 plus your Charisma modifier and Proficiency Bonus) or have the Frightened condition until the end of your next turn.",
                DescriptionShort =
                    "Free: transform for 1 min. 1/turn: +prof dmg. Fly speed, damage aura or frighten aura",
                Charges = new AbilityCharges
                {
                    MaxCharges = 1,
                    Recharges = AbilityRechargeCondition.Longrest
                }
            },
        ],
        AbilitiesFromClasses =
        [
            new PassiveAbility
            {
                IsIntegratedInCalculations = true,
                Title = "Firearm Proficiency",
                DescriptionLong =
                    "The secrets of creating and operating gunpowder weapons have been discovered in various corners of the D&D multiverse. If your Dungeon Master uses the rules on firearms in chapter 9 of the Dungeon Master's Guide and your artificer has been exposed to the operation of such weapons, your artificer is proficient with them.",
                DescriptionShort = "Proficient with firearms"
            },
            new ActiveAbility
            {
                Title = "Magical Tinkering",
                DescriptionLong =
                    "You've learned how to invest a spark of magic into mundane objects. To use this ability, you must have thieves' tools or artisan's tools in hand. You then touch a Tiny nonmagical object as an action and give it one of the following magical properties of your choice:" +
                    "\n- The object sheds bright light in a 5-foot radius and dim light for an additional 5 feet." +
                    "\n- Whenever tapped by a creature, the object emits a recorded message that can be heard up to 10 feet away. You utter the message when you bestow this property on the object, and the recording can be no more than 6 seconds long." +
                    "\n- The object continuously emits your choice of an odor or a nonverbal sound (wind, waves, chirping, or the like). The chosen phenomenon is perceivable up to 10 feet away." +
                    "\n- A static visual effect appears on one of the object's surfaces. This effect can be a picture, up to 25 words of text, lines and shapes, or a mixture of these elements, as you like." +
                    "\nThe chosen property lasts indefinitely. As an action, you can touch the object and end the property early." +
                    "\nYou can bestow magic on multiple objects, touching one object each time you use this feature, though a single object can only bear one property at a time. The maximum number of objects you can affect with this feature at one time is equal to your Intelligence modifier (minimum of one object). If you try to exceed your maximum, the oldest property immediately ends, and then the new property applies.",
                DescriptionShort = "Act: create minor magic item"
            },
            new ActiveAbility
            {
                Title = "Spellcasting",
                DescriptionLong = "Artificer Spellcasting. See Tasha's Cauldron of Everything.",
                DescriptionShort = "SpellDC: 14, SpellAttack: +6" +
                                   "\nCantrips: Light, Prestidigitation, Firebolt" +
                                   "\nAlways: Shield, Thunderwave" +
                                   "\nCan ritual cast prepared spells"
            },
            new ActiveAbility
            {
                Title = "Level 1 Spells",
                Charges = new AbilityCharges
                {
                    MaxCharges = 3,
                    Recharges = AbilityRechargeCondition.Longrest
                }
            },
            new PassiveAbility
            {
                IsIntegratedInCalculations = false,
                Title = "Infuse Item",
                DescriptionLong =
                    "You've gained the ability to imbue mundane items with certain magical infusions, turning those objects into magic items.\nInfusions Known TCE p9\n\nWhen you gain this feature, pick four artificer infusions to learn, choosing from the \"Artificer Infusions\" section at the end of the class's description. You learn additional infusions of your choice when you reach certain levels in this class, as shown in the Infusions Known column of the Artificer table.\n\nWhenever you gain a level in this class, you can replace one of the artificer infusions you learned with a new one.",
                DescriptionShort = "Infusions Known: 4 (todo)"
            },
            new ActiveAbility
            {
                Title = "The Right Tool for the Job",
                DescriptionLong =
                    "You've learned how to produce exactly the tool you need: with thieves' tools or artisan's tools in hand, you can magically create one set of artisan's tools in an unoccupied space within 5 feet of you. This creation requires 1 hour of uninterrupted work, which can coincide with a short or long rest. Though the product of magic, the tools are nonmagical, and they vanish when you use this feature again.",
                DescriptionShort = "1h: create any artisan tool"
            },
            new PassiveAbility
            {
                IsIntegratedInCalculations = false,
                Title = "Tool Proficiency",
                DescriptionLong =
                    "When you adopt this specialization at 3rd level, you gain proficiency with woodcarver's tools. If you already have this proficiency, you gain proficiency with one other type of artisan's tools of your choice.",
                DescriptionShort = "Woodcarver's tools prof"
            },
            new ActiveAbility
            {
                Title = "Eldritch Cannon",
                Charges = new AbilityCharges
                {
                    MaxCharges = 1,
                    Recharges = AbilityRechargeCondition.Longrest
                },
                DescriptionLong =
                    "At 3rd level, you learn how to create a magical cannon. Using woodcarver's tools or smith's tools, you can take an action to magically create a Small or Tiny eldritch cannon in an unoccupied space on a horizontal surface within 5 feet of you. A Small eldritch cannon occupies its space, and a Tiny one can be held in one hand.\n\nOnce you create a cannon, you can't do so again until you finish a long rest or until you expend a spell slot of 1st level or higher. You can have only one cannon at a time and can't create one while your cannon is present.\n\nThe cannon is a magical object. Regardless of size, the cannon has an AC of 18 and a number of hit points equal to five times your artificer level. It is immune to poison damage and psychic damage, and all conditions. If it is forced to make an ability check or a saving throw, treat all its ability scores as 10 (+0). If the mending spell is cast on it, it regains 2d6 hit points. It disappears if it is reduced to 0 hit points or after 1 hour. You can dismiss it early as an action.\n\nWhen you create the cannon, you determine its appearance and whether it has legs. You also decide which type it is, choosing from the options on the Eldritch Cannons table. On each of your turns, you can take a bonus action to cause the cannon to activate if you are within 60 feet of it. As part of the same bonus action, you can direct the cannon to walk or climb up to 15 feet to an unoccupied space, provided it has legs." +
                    "\nFlamethrower. The cannon exhales fire in an adjacent 15-foot cone that you designate. Each creature in that area must make a Dexterity saving throw against your spell save DC, taking 2d8 fire damage on a failed save or half as much damage on a successful one. The fire ignites any flammable objects in the area that aren't being worn or carried." +
                    "\nForce Ballista. Make a ranged spell attack, originating from the cannon, at one creature or object within 120 feet of it. On a hit, the target takes 2d8 force damage, and if the target is a creature, it is pushed up to 5 feet away from the cannon." +
                    "\nProtector. The cannon emits a burst of positive energy that grants itself and each creature of your choice within 10 feet of it a number of temporary hit points equal to 1d8 + your Intelligence modifier (minimum of +1).",
                DescriptionShort = "Act: create cannon:" +
                                   "\n- Flamethrower: 15ft. cone, DexSv or 2d8 fire" +
                                   "\n- Force Ballista: 120ft. atk 2d8 force, 5ft push" +
                                   "\n- Protector: 10ft. 1d8+4 tempHp"
            }
        ],
        AbilitiesFromFeats =
        [
            new PassiveAbility
            {
                Title = "Crafter",
                IsIntegratedInCalculations = false,
                DescriptionLong =
                    " Discount. Whenever you buy a nonmagical item, you receive a 20 percent discount on it.",
                DescriptionShort = "20% discount on nonmagicals"
            },
            new ActiveAbility
            {
                Title = "Crafter",
                DescriptionLong =
                    " Fast Crafting. When you finish a Long Rest, you can craft one piece of gear from the Fast Crafting table, provided you have the Artisan's Tools associated with that item and have proficiency with those tools. The item lasts until you finish another Long Rest, at which point the item falls apart." +
                    "\nCarpenter's Tools\tLadder, Torch" +
                    "\nLeatherworker's Tools\tCrossbow Bolt Case, Map or Scroll Case, Pouch" +
                    "\nMason's Tools\tBlock and Tackle" +
                    "\nPotter's Tools\tJug, Lamp" +
                    "\nSmith's Tools\tBall Bearings, Bucket, Caltrops, Grappling Hook, Iron Pot" +
                    "\nTinker's Tools\tBell, Shovel, Tinderbox" +
                    "\nWeaver's Tools\tBasket, Rope, Net, Tent" +
                    "\nWoodcarver's Tools\tClub, Greatclub, Quarterstaff",
                DescriptionShort = "After LR, craft 1 from Fast Crafting table."
            }
        ],
        AbilitiesFromItems = [],
        AbilitiesFromOther =
        [
            new PassiveAbility
            {
                Title = "Language and Tool Proficiencies",
                DescriptionShort = "Common, Celestial, +1" +
                                   "\nTools: Thief, Tinker, Woodcarver, Leatherworker, Smith, Weaver, Alchemist, Carpenter",
                DescriptionLong =
                    "Tools: : Thieves' tools, Tinker's tools, Woodcarver's tools, Leatherworker's tools, Smith's tools, Weaver's tools, Alchemist's tools, Carpenter's tools" +
                    "\nLanguages: Common, Celestial, +1",
                IsIntegratedInCalculations = false
            },
        ],
        Attacks =
        [
            new Attack
            {
                Name = "Revolver",
                Damage = "1d8+4p",
                AtkBonus = 6,
                Notes = "60/240ft, loud(500), reload 6"
            },
            new Attack
            {
                Name = "Firebolt",
                AtkBonus = 6,
                Damage = "1d10 fire",
                Notes = "120ft"
            }
        ],
        BackgroundStory = "Zylana. Alter 42, Größer 5,5 ft (ca 1,70m), Haare schwarz, Augen strahlend blau",
    };

    public static CharacterData ExampleDataEnkai => new()
    {
        Name = "Enkai",
        Species = "Human",
        Background = "Caravaneer",
        ClassLevels =
        [
            new ClassLevel
            {
                ClassName = "Sorcerer",
                SubClassName = "Reincarnated Warrior",
                Level = 3
            },
            new ClassLevel
            {
                ClassName = "Warlock",
                SubClassName = "Sphinx",
                Level = 1
            }
        ],
        ImageName = "Enkai.png",
        PlayerName = "Ferenc",
        ProficiencyMod = 2,
        Stats = new StatBasedArray(strength: 7, dexterity: 13, constitution: 16, intelligence: 9, wisdom: 12,
            charisma: 17),
        SaveProficiencies = [Stats.Con, Stats.Cha],
        SkillProfs =
        [
            (SkillsInGame.Arcana, SkillProficiencyLevel.Proficient), // Sorcerer
            (SkillsInGame.Intimidation, SkillProficiencyLevel.Proficient), // Sorcerer
            (SkillsInGame.Survival, SkillProficiencyLevel.Proficient), // Caravaneer
            (SkillsInGame.Persuasion, SkillProficiencyLevel.Proficient), // Caravaneer
            (SkillsInGame.Perception, SkillProficiencyLevel.Proficient), // Skillful (Human)
            (SkillsInGame.AnimalHandling, SkillProficiencyLevel.Proficient), // Skilled
            (SkillsInGame.Medicine, SkillProficiencyLevel.Proficient), // Skilled
            // Tinker's Tools // Skilled
        ],
        Ac = 13 + 3 + 2, // Mage Armor, Cha, Shield
        Hp = 24 + 12,
        HitDice =
        [
            new HitDie(6, 6),
            new HitDie(6, 6),
            new HitDie(6, 6),
            new HitDie(6, 8),
        ],
        Init = 1,
        Speed = 30,
        AbilitiesFromSpecies =
        [
            new PassiveAbility
            {
                IsIntegratedInCalculations = false,
                Title = "Resourceful",
                DescriptionLong = "You gain Heroic Inspiration whenever you finish a Long Rest.",
                DescriptionShort = "Heroic inspiration on Long Rest"
            },
            new PassiveAbility
            {
                IsIntegratedInCalculations = true,
                Title = "Versatile",
                DescriptionLong = "You gain an Origin feat of your choice: Prosthesis Fighting",
                DescriptionShort = "Extra Feat: Prosthesis Fighting"
            },
            new PassiveAbility
            {
                IsIntegratedInCalculations = true,
                Title = "Skillful",
                DescriptionLong =
                    "You gain proficiency in one skill of your choice: Perception",
                DescriptionShort = "Extra Skill: Perception"
            }
        ],
        AbilitiesFromClasses =
        [
            new PassiveAbility
            {
                IsIntegratedInCalculations = true, // see active abilities below
                Title = "Pact Magic",
                DescriptionLong =
                    "Through occult ceremony, you have formed a pact with a mysterious entity to gain magical powers. The entity is a voice in the shadows—its identity unclear—but its boon to you is concrete: the ability to cast spells. See chapter 7 for the rules on spellcasting. The information below details how you use those rules with Warlock spells, which appear in the Warlock spell list later in the class's description." +
                    "\n\nCantrips. You know two Warlock cantrips of your choice. Eldritch Blast and Prestidigitation are recommended. Whenever you gain a Warlock level, you can replace one of your cantrips from this feature with another Warlock cantrip of your choice." +
                    "\nWhen you reach Warlock levels 4 and 10, you learn another Warlock cantrip of your choice, as shown in the Cantrips column of the Warlock Features table." +
                    "\n\nSpell Slots. The Warlock Features table shows how many spell slots you have to cast your Warlock spells of levels 1–5. The table also shows the level of those slots, all of which are the same level. You regain all expended Pact Magic spell slots when you finish a Short or Long Rest." +
                    "\nFor example, when you're a level 5 Warlock, you have two level 3 spell slots. To cast the level 1 spell Witch Bolt, you must spend one of those slots, and you cast it as a level 3 spell." +
                    "\n\nPrepared Spells of Level 1+. You prepare the list of level 1+ spells that are available for you to cast with this feature. To start, choose two level 1 Warlock spells. Charm Person and Hex are recommended." +
                    "\nThe number of spells on your list increases as you gain Warlock levels, as shown in the Prepared Spells column of the Warlock Features table. Whenever that number increases, choose additional Warlock spells until the number of spells on your list matches the number in the table. The chosen spells must be of a level no higher than what's shown in the table's Slot Level column for your level. When you reach level 6, for example, you learn a new Warlock spell, which can be of levels 1–3." +
                    "\nIf another Warlock feature gives you spells that you always have prepared, those spells don't count against the number of spells you can prepare with this feature, but those spells otherwise count as Warlock spells for you." +
                    "\n\nChanging Your Prepared Spells. Whenever you gain a Warlock level, you can replace one spell on your list with another Warlock spell of an eligible level." +
                    "\n\nSpellcasting Ability. Charisma is the spellcasting ability for your Warlock spells." +
                    "\n\nSpellcasting Focus. You can use an Arcane Focus as a Spellcasting Focus for your Warlock spells.",
            },
            new PassiveAbility
            {
                IsIntegratedInCalculations = true, // see active abilities below
                Title = "Sorcerer Spellcasting",
                DescriptionLong =
                    "Drawing from your innate magic, you can cast spells. See chapter 7 for the rules on spellcasting. The information below details how you use those rules with Sorcerer spells, which appear in the Sorcerer spell list later in the class's description." +
                    "\n\nCantrips. You know four Sorcerer cantrips of your choice. Light, Prestidigitation, Shocking Grasp, and Sorcerous Burst are recommended. Whenever you gain a Sorcerer level, you can replace one of your cantrips from this feature with another Sorcerer cantrip of your choice." +
                    "\n\nWhen you reach Sorcerer levels 4 and 10, you learn another Sorcerer cantrip of your choice, as shown in the Cantrips column of the Sorcerer Features table." +
                    "\n\nSpell Slots. The Sorcerer Features table shows how many spell slots you have to cast your level 1+ spells. You regain all expended slots when you finish a Long Rest." +
                    "\n\nPrepared Spells of Level 1+. You prepare the list of level 1+ spells that are available for you to cast with this feature. To start, choose two level 1 Sorcerer spells. Burning Hands and Detect Magic are recommended." +
                    "\n\nThe number of spells on your list increases as you gain Sorcerer levels, as shown in the Prepared Spells column of the Sorcerer Features table. Whenever that number increases, choose additional Sorcerer spells until the number of spells on your list matches the number in the Sorcerer Features table. The chosen spells must be of a level for which you have spell slots. For example, if you're a level 3 Sorcerer, your list of prepared spells can include six Sorcerer spells of level 1 or 2 in any combination." +
                    "\n\nIf another Sorcerer feature gives you spells that you always have prepared, those spells don't count against the number of spells you can prepare with this feature, but those spells otherwise count as Sorcerer spells for you." +
                    "\n\nChanging Your Prepared Spells. Whenever you gain a Sorcerer level, you can replace one spell on your list with another Sorcerer spell for which you have spell slots." +
                    "\n\nSpellcasting Ability. Charisma is your spellcasting ability for your Sorcerer spells." +
                    "\n\nSpellcasting Focus. You can use an Arcane Focus as a Spellcasting Focus for your Sorcerer spells.",
            },
            new ActiveAbility
            {
                Title = "Cantrips",
                DescriptionLong = "You know two Warlock cantrips of your choice: Ferocious Strike, Eldritch Blast" +
                                  "\nYou know four Sorcerer cantrips of your choice: Booming Blade, Mage Hand, Control Flames, Mending" // Soften descent
            },
            new ActiveAbility
            {
                Title = "Pact Magic - 1",
                DescriptionLong = "Spells: Hex, Inner Flame",
                DescriptionShort = "Hex, Inner Flame",
                Charges = new()
                {
                    MaxCharges = 1,
                    Recharges = AbilityRechargeCondition.Shortrest
                }
            },
            new ActiveAbility
            {
                Title = "Sorcerer Magic - 1",
                DescriptionLong = "Sorcerer Spells: Mage Armor, Shield, Repulsing Palm, Ice Moon",
                DescriptionShort = "Mage Armor, Shield, Repulsing Palm, Ice Moon",
                Charges = new AbilityCharges
                {
                    MaxCharges = 4,
                    Recharges = AbilityRechargeCondition.Longrest
                },
            },
            new ActiveAbility
            {
                Title = "Sorcerer Magic - 2",
                DescriptionLong = "Sorcerer Spells: Shielding Word, Mirror Image",
                DescriptionShort = "Shielding Word, Mirror Image",
                Charges = new AbilityCharges
                {
                    MaxCharges = 2,
                    Recharges = AbilityRechargeCondition.Longrest
                },
            },
            new PassiveAbility
            {
                IsIntegratedInCalculations = true,
                Title = "Eldritch Invocations",
                DescriptionLong =
                    "You have unearthed Eldritch Invocations, pieces of forbidden knowledge that imbue you with an abiding magical ability or other lessons. You gain one invocation of your choice, such as Pact of the Tome. Invocations are described in the \"Eldritch Invocation Options\" section later in this class's description." +
                    "\n\nPrerequisites. If an invocation has a prerequisite, you must meet it to learn that invocation. For example, if an invocation requires you to be a level 5+ Warlock, you can select the invocation once you reach Warlock level 5." +
                    "\n\nReplacing and Gaining Invocations. Whenever you gain a Warlock level, you can replace one of your invocations with another one for which you qualify. You can't replace an invocation if it's a prerequisite for another invocation that you have." +
                    "\n\nWhen you gain certain Warlock levels, you gain more invocations of your choice, as shown in the Invocations column of the Warlock Features table." +
                    "\n\nYou can't pick the same invocation more than once unless its description says otherwise."
            },
            new PassiveAbility
            {
                IsIntegratedInCalculations = true,
                Title = "Pact of the Blade",
                DescriptionLong =
                    "As a Bonus Action, you can conjure a pact weapon in your hand—a Simple or Martial Melee weapon of your choice with which you bond—or create a bond with a magic weapon you touch; you can't bond with a magic weapon if someone else is attuned to it or another Warlock is bonded with it. Until the bond ends, you have proficiency with the weapon, and you can use it as a Spellcasting Focus." +
                    "\n\nWhenever you attack with the bonded weapon, you can use your Charisma modifier for the attack and damage rolls instead of using Strength or Dexterity; and you can cause the weapon to deal Necrotic, Psychic, or Radiant damage or its normal damage type." +
                    "\n\nYour bond with the weapon ends if you use this feature's Bonus Action again, if the weapon is more than 5 feet away from you for 1 minute or more, or if you die. A conjured weapon disappears when the bond ends."
            },
            new ActiveAbility
            {
                Title = "Innate Sorcery",
                DescriptionLong =
                    "An event in your past left an indelible mark on you, infusing you with simmering magic. As a Bonus Action, you can unleash that magic for 1 minute, during which you gain the following benefits:" +
                    "\n\n- The spell save DC of your Sorcerer spells increases by 1." +
                    "\n- You have Advantage on the attack rolls of Sorcerer spells you cast." +
                    "\n\nYou can use this feature twice, and you regain all expended uses of it when you finish a Long Rest.",
                DescriptionShort = "bAct, 1min, sorc: +1 Sav DC, Adv spell atks",
                Charges = new AbilityCharges
                {
                    MaxCharges = 2,
                    Recharges = AbilityRechargeCondition.Longrest
                }
            },
            new ActiveAbility
            {
                Title = "Font of Magic",
                DescriptionLong =
                    "You can tap into the wellspring of magic within yourself. This wellspring is represented by Sorcery Points, which allow you to create a variety of magical effects." +
                    "\n\nYou have 2 Sorcery Points, and you gain more as you reach higher levels, as shown in the Sorcery Points column of the Sorcerer Features table. You can't have more Sorcery Points than the number shown in the table for your level. You regain all expended Sorcery Points when you finish a Long Rest." +
                    "\n\nYou can use your Sorcery Points to fuel the options below, along with other features, such as Metamagic, that use those points." +
                    "\n\nConverting Spell Slots to Sorcery Points. You can expend a spell slot to gain a number of Sorcery Points equal to the slot's level (no action required)." +
                    "\n\nCreating Spell Slots. As a Bonus Action, you can transform unexpended Sorcery Points into one spell slot. The Creating Spell Slots table shows the cost of creating a spell slot of a given level, and it lists the minimum Sorcerer level you must be to create a slot. You can create a spell slot no higher than level 5." +
                    "\n\nAny spell slot you create with this feature vanishes when you finish a Long Rest." +
                    "\n\nCreating Spell Slots lvl1:2sp, lvl2:3sp, lvl3:5sp, lvl4:6sp, lvl5:7sp",
                DescriptionShort = "Lvl x -> xSP; 2SP -> Lvl1, 3SP -> Lvl2"
            },
            new ActiveAbility
            {
                Title = "Metamagic",
                DescriptionLong = "Quickened Spell" +
                                  "\tCost: 2 Sorcery Points" +
                                  "\n\nWhen you cast a spell that has a casting time of an action, you can spend 2 Sorcery Points to change the casting time to a Bonus Action for this casting. You can't modify a spell in this way if you've already cast a level 1+ spell on the current turn, nor can you cast a level 1+ spell on this turn after modifying a spell in this way." +
                                  "\n\n" +
                                  "\n\nSeeking Spell" +
                                  "\tCost: 1 Sorcery Point" +
                                  "\n\nIf you make an attack roll for a spell and miss, you can spend 1 Sorcery Point to reroll the d20, and you must use the new roll." +
                                  "\n\nYou can use Seeking Spell even if you've already used a different Metamagic option during the casting of the spell.",
                DescriptionShort = "Quickened, 2SP: act>bAct\nSeeking, 1SP: reroll spell atk"
            },
            new PassiveAbility
            {
                IsIntegratedInCalculations = false,
                Title = "Soul of Endurance",
                DescriptionLong =
                    "Starting at 1st level, your body and soul sing when you are engaged in battle, granting you immense resilience. You gain the following benefits:" +
                    "\n» While you wear no armor or you are under the effects of the mage armor spell, you can use your Charisma modifier, instead of your Dexterity modifier, to calculate your Armor Class. You can use a shield and still gain this benefit." +
                    "\n» Whenever you would take damage while you are conscious and within 5 feet of a hostile creature, you reduce the amount of damage you take by 1. The reduction increases when you reach certain levels in this class, increasing to 2 at 5th level, 3 at 10th level, 4 at 15th level, and 5 at 20th level.",
                DescriptionShort = "5ft to hostile: dmg taken -1"
            },
            new PassiveAbility
            {
                IsIntegratedInCalculations = false,
                Title = "Martial Inheritance",
                DescriptionLong =
                    "Also starting at 1st level, you are supernaturally talented with martial implements. You are proficient with all melee weapons and with shields." +
                    "\nOnce you reach 2nd level in this class, you can spend 1 sorcery point as a bonus action to make a weapon you’re holding a conduit for your magic for 10 minutes or until it leaves your hand. For the duration, you can use the weapon as a spellcasting focus for your sorcerer spells, and it is considered magical for the purpose of overcoming resistance and immunity to nonmagical attacks and damage.",
                DescriptionShort = "10min, 1sp: wpn spell focus & magical"
            }
        ],
        AbilitiesFromFeats =
        [
            new PassiveAbility
            {
                Title = "Skilled",
                IsIntegratedInCalculations = true,
                DescriptionLong =
                    "You gain proficiency in any combination of three skills or tools of your choice." +
                    "\nAnimalHandling, Medicine, Tinker's Tools"
            },
            new PassiveAbility
            {
                Title = "Prosthesis Fighting",
                IsIntegratedInCalculations = true,
                DescriptionLong =
                    "You are a master of wielding prostheses in battle, granting you the following benefits:" +
                    "\n• The range of attacks you make using a prosthesis’ Blast or Launch property increases by 10 feet." +
                    "\n• The reach of any melee attacks you make using prostheses with the Melee property increases by 5 feet." +
                    "\n• You deal one extra die of damage when you hit a target using a prosthesis’ Blast, Launch, or Melee property."
            }
        ],
        AbilitiesFromItems = [],
        AbilitiesFromOther =
        [
            new PassiveAbility
            {
                Title = "Language and Tool Proficiencies",
                DescriptionShort = "Common, Sign Language, Elvish; Tinker's Tools",
                DescriptionLong =
                    "\nLanguages: Common, Common Sign Language, Elvish" +
                    "Tools: Tinker's tools",
                IsIntegratedInCalculations = false
            },
        ],
        Attacks =
        [
            new Attack
            {
                Name = "Ferocious arm",
                Damage = "1d4+1d6+3",
                AtkBonus = 5,
                Notes = "bl,nec,rad,psy" +
                        "\n10ft. melee or 30ft. ranged"
            }
        ],
        Equipments =
        [
            new Equipment
            {
                Name = "Combat Arm",
                Notes = "Melee (1d6), Launch (1d6, 30ft.), Hookshot (20ft.)"
            },
            new Equipment
            {
                Name = "Basic Arm",
                Notes = "Integrated (shield)"
            }
        ],
        BackgroundStory = "Abstract" +
                          "\nBorn Ankhai, a skilled caravaneer destined for peace, his life was shattered when a temporal beast—a remnant of a forgotten battle—tore through time to find him. Gravely wounded and left limbless, he was saved by the enigmatic sphinx Ainokhet the Unwinding, who glimpsed the echo of his past life: Zahutek the Blazing Fang, a sorcerer-warrior blessed by a phoenix and once the beast’s bane. Guided east by prophecy, Ankhai learned to forge explosive prostheses at the Hanabi Engineering College, earning the nickname Enkai, the Sea of Flame, for the fiery brilliance of his inventions." +
                          "\n\nTo reach the fabled Loot Tavern, where master crafters and monster hunters awaited, Enkai ventured into Hell to steal the rare Teleport-ale. He escaped by detonating his own limbs, hijacking a devil’s summoning circle to return topside, where he joined adventurers in a toast that warped them all to the Tavern. Now, Enkai rebuilds himself stronger than ever—drawing power from a life he no longer remembers, burning brighter with every reinvention." +
                          "\n\n\n" +
                          "Full" +
                          "\nEnkai, the Sea of Flame\n\nBorn Ankhai. Reforged in fire. Remembered in riddles.\n\nHe was born Ankhai, and he was meant to live a life of peace.\n\nHis soul had earned it. In a past age, in a life now sealed behind lifetimes, he had been Zahutek the Blazing Fang—a warrior-sorcerer who danced with flame and fate, blessed by a dying phoenix whose essence nested in his spirit. Zahutek’s final battle had been waged not for glory, but for time itself. A temporal beast, a paradox predator, had slipped through the cracks of causality. Zahutek banished it, shattering its form across millennia—and then scattered his own soul into the slow current of time, destined for a quiet reincarnation.\n\nThat soul awoke in Ankhai, a caravaneer of great charm, competence, and calm. He was a master organizer, a born leader who navigated sandstorms and trade politics with equal ease. He laughed easily, fought rarely, and lived well.\n\nBut peace is brittle when monsters remember you.\n\nIt came one night under a sky so clear it should’ve been an omen. The air rippled. A seam in time split open like rotten fruit, and the temporal beast—or perhaps something like it, drawn to the echo of its old enemy—emerged.\n\nIt remembered Zahutek, even if Ankhai did not.\n\nThe battle was chaos. The beast struck in flashes—past and future folding into every blow. Ankhai fought back. He remembers it, even now. He struck the thing. He knows he did. But it took from him in return. One arm. Then a leg. Then the other arm. His blood soaked the sands, his body broken.\n\nTime, impossibly, flowed on.\n\nHe should have died. Instead, she found him.\n\nShe came with no footsteps and eyes like distant horizons: Ainokhet the Unwinding, a sphinx older than secrets. She did not marvel at his wounds, nor mourn his pain. She peered through the cracks of his spirit and saw the blaze beneath—the echo of Zahutek, banked like coals beneath ash.\n\nShe healed him, but not completely. The damage the beast had done existed across timelines—beyond her ability to rewind. But she left him a riddle and a direction:\n\n    “You are not whole. But you are not finished. Seek the Yokai. Forge anew.”\n\nHe crossed continents. Past whispering tombs and thunder-laced jungles, into the far eastern lands known as the Yokai Realms. There, amid fireworks and sacred steel, stood the Hanabi Engineering College—a place where science flirted with sorcery. He apprenticed under Bombuku, an eccentric genius with fire in his eyes and blueprints in his tea leaves.\n\nAnkhai rebuilt himself.\n\nNot as he was, but as he would be. His new limbs—arcane prostheses—burned with innovation. One housed a combustion core; another released concussive shockwaves with every strike. Fire and thunder became his weapons. Explosions followed his movements like punctuation. The students, hearing his name through thick accents and louder fireworks, began calling him Enkai.\n\n    “The Sea of Flame.”\n\nHe kept it. It fit.\n\nBombuku saw more in him. \"To master creation,\" he said, \"you must master the world. Go to the Loot Tavern. There, you will find L’Arsene Upin, whose hands teach metal to dance, and Heliana, the legendary huntress who teaches you to kill the monsters you must one day build from.\"\n\nBut the Loot Tavern could not be reached by map. It floated between worlds, anchored only by rumor—and reachable only by a substance as rare as mercy in Hell:\n\n    Teleport-ale.\n\nOnce more, Ainokhet came to him—this time in a dream of smoke and riddles.\n\n    “What opens doors but pours like truth? What burns like lies but flows like proof?”\n\nHell. Of course it was Hell.\n\nEnkai descended.\n\nHe bluffed, he bartered, he brawled. He solved the contracts of devils and the bureaucracy of soul-deep registrars. Eventually, he got what he came for: a six-pack of Teleport-ale, still cold, somehow.\n\nThey caught him as he was leaving. A summoning had begun—someone on the surface was calling a devil through a half-open portal. Enkai was to be the sacrifice.\n\nBut he had other plans.\n\nHe ripped off his own prostheses, primed their cores, and used them as bombs. The explosion stalled the summoning—and in the chaos, Enkai leapt through the portal instead of the devil.\n\nOn the other side: chaos. The summoner had been defeated by a band of adventurers, bruised and wild-eyed. Enkai, still smoking, shared his prize. One ale each. Six hands raised.\n\nA toast. A shimmer. A crash of light.\n\nAnd suddenly—they stood at the door of the Loot Tavern.\n\nNow, Enkai builds again.\n\nHe is crafting new limbs from the ground up—smarter, faster, more beautiful. His sorcery burns brighter than ever, fed by a past life he does not remember but which burns in his blood all the same. He trains under L’Arsene, learning to shape the impossible. He tracks monsters alongside Heliana, gathering the rarest of components. He studies, he tinkers, he reinvents.\n\n    Another rebirth. Another improvement. Another self-made man.\n\nHe does not remember the name Zahutek. He does not need to.\n\nHe is Enkai.\nAnd this time, he is ready.",
    };
}
