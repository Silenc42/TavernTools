using Charsheet.Charbuilder.CharModel;
using Charsheet.CommonModel;
using Charsheet.PdfGeneration.PrintModel;

namespace Charsheet.ExampleChars;

public static class FriendsChars
{
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
                Level = 4
            }
        ],
        ImageName = "Zylana.png",
        PlayerName = "Angelina",
        ProficiencyMod = 2,
        Stats = new StatBasedArray(strength: 14, dexterity: 18, constitution: 18, intelligence: 20, wisdom: 16,
            charisma: 12), //ASI:+con+int
        SaveProficiencies = [Stats.Int, Stats.Con],
        SkillProfs =
        [
            (SkillsInGame.Arcana, SkillProficiencyLevel.Proficient), // Artificer
            (SkillsInGame.Perception, SkillProficiencyLevel.Proficient), // Artificer
            (SkillsInGame.Investigation, SkillProficiencyLevel.Proficient), // Artisan
            (SkillsInGame.Persuasion, SkillProficiencyLevel.Proficient), // Artisan
        ],
        Ac = 12 + 4, //studded leather
        Hp = 30 + 16,
        HitDice =
        [
            new HitDie(8, 8),
            new HitDie(6, 8),
            new HitDie(8, 8),
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
                DescriptionShort = "SpellDC: 15, SpellAttack: +7" +
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
                DescriptionShort = "Infusions Known: 4 (Enhanced Defense, Mind Sharpener, Repeating Shot, Returning Weapon)"
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
                DescriptionShort = "Common, Celestial, Orkish" +
                                   "\nTools: Thief, Tinker, Woodcarver, Leatherworker, Smith, Weaver, Alchemist, Carpenter",
                DescriptionLong =
                    "Tools: : Thieves' tools, Tinker's tools, Woodcarver's tools, Leatherworker's tools, Smith's tools, Weaver's tools, Alchemist's tools, Carpenter's tools" +
                    "\nLanguages: Common, Celestial, Orkish",
                IsIntegratedInCalculations = false
            },
        ],
        Attacks =
        [
            new Attack
            {
                Name = "Revolver",
                Damage = "1d8+5p",
                AtkBonus = 7,
                Notes = "60/240ft, loud(500), reload 6"
            },
            new Attack
            {
                Name = "Dagger",
                Damage = "1d4+5p",
                AtkBonus = 7,
                Notes = "thrown 20/60ft"
            },
            new Attack
            {
                Name = "Firebolt",
                AtkBonus = 7,
                Damage = "1d10 fire",
                Notes = "120ft"
            }
        ],
        Inventory = ["Die Handschuhe"],
        BackgroundStory = "Zylana. Alter 42, Größer 5,5 ft (ca 1,70m), Haare schwarz, Augen strahlend blau" +
                          "\nHat das Herstellen mit fast allen tools gelernt. Ihr meister hies Gandalf",
    };
}