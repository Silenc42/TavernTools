using Charsheet.CommonModel;
using Charsheet.CommonModel.Options;
using Charsheet.PdfGeneration.DocumentComponents;
using Charsheet.PdfGeneration.PrintModel;
using Charsheet.PdfGeneration.Renderers;
using Charsheet.PdfGeneration.Renderers.Dice;
using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Charsheet.PdfGeneration.Typesetters.BlockTypesetters;

public class BlockTypesetter(CellRendererFactory cellRendererFactory)
{
    internal Table AcBlock(CharacterPrintData characterData)
    {
        BorderedTable acTable = new(1);

        Cell cell = new LayoutCell()
            .Add(new Paragraph("AC"))
            .Add(new Paragraph($"{characterData.Ac}"));

        GreyShieldCellRenderer shieldRenderer = cellRendererFactory.CreateGreyShieldCellRenderer(cell);
        cell.SetNextRenderer(shieldRenderer);

        acTable.AddCell(cell)
            .SetBorder(Border.NO_BORDER)
            .SetMarginTop(5)
            .SetMarginBottom(15)
            ;

        return acTable;
    }

    internal Table HpBlock(CharacterPrintData characterData, DiceRenderingStyle diceStyle)
    {
        BorderedTable hpTable = new(1);

        Cell heartCell = new LayoutCell()
                .Add(new Paragraph("Max Hp"))
                .Add(new Paragraph($"{characterData.Hp}"))
            ;
        Cell damageCell = new Cell()
                .Add(new LayoutTable(2)
                    .AddLayoutCell(new Paragraph("Damage Taken").SetFontSize(5).SetFontColor(DeviceGray.GRAY).SetTextAlignment(TextAlignment.LEFT).SetMinHeight(35))
                    .AddLayoutCell(new Paragraph("Temporary Hp").SetFontSize(5).SetFontColor(DeviceGray.GRAY).SetTextAlignment(TextAlignment.RIGHT).SetMinHeight(35))
                    .AddLayoutCell(1, 2, HitDiceDisplay(characterData.HitDice, diceStyle))
                )
                .SetBackgroundColor(DeviceGray.WHITE)
            ;
        HeartCellRenderer heartRenderer = cellRendererFactory.CreateHeartCellRenderer(heartCell);
        heartCell.SetNextRenderer(heartRenderer);

        hpTable
            .AddCell(heartCell)
            .AddCell(damageCell)
            .SetMarginTop(5)
            .SetMarginBottom(15)
            .SetBorder(Border.NO_BORDER)
            ;
        return hpTable;
    }

    private Table HitDiceDisplay(List<HitDie> hitDice, DiceRenderingStyle diceStyle)
    {
        Table table = new Table(UnitValue.CreatePercentArray(5)).UseAllAvailableWidth();
        foreach (HitDie hd in hitDice)
        {
            DiceSides sides = hd.HdSize switch
            {
                4 => DiceSides.Four,
                6 => DiceSides.Six,
                8 => DiceSides.Eight,
                10 => DiceSides.Ten,
                12 => DiceSides.Twelve,
                20 => DiceSides.Twenty,
                _ => DiceSides.Circle
            };

            Cell cell = new LayoutCell()
                    // .SetBorder(new DashedBorder(DeviceCmyk.BLACK, 1))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .Add(new Paragraph($"{hd.Roll}"))
                    //.Add(new Paragraph($"{hd.Roll}/{hd.HdSize}"))
                    .SetMinHeight(15)
                ;
            DieCellRenderer dieRenderer = cellRendererFactory.CreateDieCellRenderer(cell, sides, diceStyle);
            cell.SetNextRenderer(dieRenderer);
            table.AddCell(cell);
        }

        return table;
    }

    internal Table InitAndSpeedBlock(CharacterPrintData characterData)
    {
        BorderedTable initSpdTable = new(3);

        initSpdTable
            .AddCell(new Paragraph("Init"))
            .AddCell(new Paragraph("Speed"))
            .AddCell(new Paragraph("Prof"))
            .AddCell(new Paragraph($"{characterData.Init}"))
            .AddCell(new Paragraph($"{characterData.Speed}"))
            .AddCell(new Paragraph(characterData.Stats.Prof.AsSignedString()))
            ;

        return initSpdTable;
    }

    internal Table StatsAndProfBlock(CharacterPrintData characterData)
    {
        LayoutTable statsTable = new(6);

        statsTable
            .AddLayoutCell(1, 2, StatBlock(characterData, Stats.Str))
            .AddLayoutCell(1, 2, StatBlock(characterData, Stats.Dex))
            .AddLayoutCell(1, 2, StatBlock(characterData, Stats.Con))
            .AddLayoutCell(1, 2, StatBlock(characterData, Stats.Int))
            .AddLayoutCell(1, 2, StatBlock(characterData, Stats.Wis))
            .AddLayoutCell(1, 2, StatBlock(characterData, Stats.Cha))
            ;

        return statsTable;
    }

    private Table StatBlock(CharacterPrintData characterData, Stats stat)
    {
        int? statValue = characterData.Stats.StatScores[stat];
        int? mod = characterData.Stats.StatMods[stat];
        int? saveMod = characterData.Stats.Saves[stat];

        BorderedTable statTable = new(1);

        statTable
            .AddLayoutCell(1, 1, new Paragraph(stat.StatDisplayText()))
            .AddLayoutCell(1, 1, new Paragraph($"{statValue}"));


        Paragraph modText = new Paragraph("Mod")
            .SetFontSize(5)
            .SetFontColor(DeviceGray.GRAY)
            .SetRotationAngle(double.Pi / 2);
        Paragraph saveText = new Paragraph("Save")
            .SetFontSize(5)
            .SetFontColor(DeviceGray.GRAY)
            .SetRotationAngle(3 * double.Pi / 2);
        Paragraph modValue = new(mod.AsSignedString());

        if (saveMod == null)
        {
            statTable.AddLayoutCell(modValue);
        }
        else
        {
            Paragraph saveValue = new(saveMod.AsSignedString());
            LayoutTable modAndSaveRow = new([2,3,3,2]);
            modAndSaveRow
                .AddLayoutCell(1, 1, modText)
                .AddLayoutCell(1, 1, modValue)
                .AddLayoutCell(1, 1, saveValue)
                .AddLayoutCell(1, 1, saveText)
                ;

            statTable.AddLayoutCell(modAndSaveRow);
        }

        return statTable;
    }

    internal Table? FillerBlock(string title, string? smallContent = null, string? normalContent = null)
    {
        Table fillerTable = BuildListingTable([""], 1, (_, _) => { }, title)!
            .SetExtendBottomRow(true);
        if (smallContent is not null)
        {
            fillerTable.AddLayoutCell(new Paragraph(smallContent)
                .SetFontSize(5)
                .SetFontColor(DeviceGray.GRAY)
                .SetTextAlignment(TextAlignment.LEFT)
            );
        }

        if (normalContent is not null)
        {
            fillerTable.AddLayoutCell(new Paragraph(normalContent)
                .SetFontSize(7)
                .SetTextAlignment(TextAlignment.LEFT)
            );
        }

        return fillerTable;
    }

    internal Table? SkillsBlock(CharacterPrintData characterData, ListingSkillOption opt)
    {
        return opt switch
        {
            ListingSkillOption.All => BuildListingTable(characterData.Skills, [2.5f, 0.4f, 0.56f], DisplaySkillWithAllProf, "Skills"),
            ListingSkillOption.ProficientOnly => BuildListingTable(characterData.Skills.Where(s => s.IsProficient), [3, 1], DisplaySkill, "Skills"),
            _ => throw new ArgumentOutOfRangeException(nameof(opt), opt, null)
        };
    }

    private void DisplaySkill(Table table, SkillDetails skill)
    {
        string expertiseSuffix = skill.ProficiencyLevel == SkillProficiencyLevel.Expertise ? " X" : "";
        table.AddLayoutCell(
            new Paragraph(skill.SkillName.AsDisplayString() + expertiseSuffix).SetTextAlignment(TextAlignment.LEFT),
            cell => cell.SetVerticalAlignment(VerticalAlignment.MIDDLE).SetPaddingLeft(4)
        );

        table.AddLayoutCell(
            new Paragraph(skill.Modifiers[skill.MainStat].AsSignedString()).SetTextAlignment(TextAlignment.RIGHT),
            cell => cell.SetVerticalAlignment(VerticalAlignment.MIDDLE).SetPaddingRight(4)
        );
    }

    private void DisplaySkillWithAllProf(Table table, SkillDetails skill)
    {
        string proficiencyPrefix = skill.ProficiencyLevel switch
        {
            SkillProficiencyLevel.None => "- ",
            SkillProficiencyLevel.Proficient => "+ ",
            SkillProficiencyLevel.Expertise => "X ",
            _ => throw new ArgumentOutOfRangeException()
        };
        table.AddLayoutCell(
            new Paragraph(proficiencyPrefix + skill.SkillName.AsDisplayString())
                .SetTextAlignment(TextAlignment.LEFT),
            cell => cell.SetVerticalAlignment(VerticalAlignment.MIDDLE).SetPaddingLeft(4)
        );
        table.AddLayoutCell(
            new Paragraph(skill.MainStat.StatDisplayText())
                .SetFontSize(5)
                .SetFontColor(DeviceGray.GRAY)
                .SetTextAlignment(TextAlignment.CENTER).SetRotationAngle(3 * double.Pi / 2),
            cell => cell.SetVerticalAlignment(VerticalAlignment.MIDDLE).SetPaddingLeft(4)
        );
        table.AddLayoutCell(
            new Paragraph(skill.Modifiers[skill.MainStat].AsSignedString())
                .SetTextAlignment(TextAlignment.RIGHT),
            cell => cell.SetVerticalAlignment(VerticalAlignment.MIDDLE).SetPaddingRight(4)
        );
    }

    internal Table? AttacksBlock(CharacterPrintData characterData)
    {
        return BuildListingTable(characterData.Attacks, [30, 10, 25, 25], DisplayAttack, "Attacks");
    }

    private void DisplayAttack(Table table, Attack attack)
    {
        table
            .AddLayoutCell(new Paragraph(attack.Name),
                cell => cell.SetVerticalAlignment(VerticalAlignment.MIDDLE))
            .AddLayoutCell(new Paragraph(attack.AtkBonus.AsSignedString()),
                cell => cell.SetVerticalAlignment(VerticalAlignment.MIDDLE))
            .AddLayoutCell(new Paragraph(attack.Damage),
                cell => cell.SetVerticalAlignment(VerticalAlignment.MIDDLE))
            .AddLayoutCell(new Paragraph(attack.Notes).SetFontSize(7),
                cell => cell.SetVerticalAlignment(VerticalAlignment.MIDDLE))
            ;
    }

    internal Table? ActiveAbilitiesBlock(CharacterPrintData characterData)
    {
        return BuildListingTable(characterData.ActiveAbilities, [1.5f, 1], DisplayActiveAbility, "Active Abilities");
    }

    private void DisplayActiveAbility(Table table, ActivePrintAbility ability)
    {
        if (ability.Charges != null)
        {
            table.AddLayoutCell(new Paragraph(ability.Title)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetMarginLeft(6));

            string counter = ability.Charges.Recharges switch
            {
                AbilityRechargeCondition.Shortrest or AbilityRechargeCondition.Longrest or AbilityRechargeCondition.Dawn or AbilityRechargeCondition.Dusk
                    => new string('O', ability.Charges.MaxCharges),

                AbilityRechargeCondition.Turn or AbilityRechargeCondition.YourTurn or AbilityRechargeCondition.Round
                    => $"{ability.Charges.MaxCharges}",

                _ => throw new ArgumentOutOfRangeException(nameof(ability.Charges.Recharges),
                    "Recharge Condition not handled during rendering")
            };

            string rechargeCondition = ability.Charges.Recharges.AsDisplayString();
            string chargeText = ability.Charges.MaxCharges == 0
                ? $"{rechargeCondition}"
                : $"{counter} / {rechargeCondition}";

            table.AddLayoutCell(new Paragraph(chargeText)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetMarginRight(6));
        }
        else
        {
            table
                .AddLayoutCell(1, 2,
                    new Paragraph(ability.Title)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetMarginLeft(6));
        }

        table.AddLayoutCell(1, 2, new Paragraph(ability.Description)
            .DescriptionStyle());
    }

    public Table? PassiveAbilitiesBlock(CharacterPrintData characterData)
    {
        return BuildListingTable(characterData.PassiveAbilities.Where(a => !a.IsIntegratedInCalculations), 1, DisplayPassiveAbility, "Passive Abilities");
    }

    private void DisplayPassiveAbility(Table table, PassivePrintAbility ability)
    {
        table
            .AddLayoutCell(
                new Paragraph(ability.Title)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetMarginLeft(6));

        table.AddLayoutCell(new Paragraph(ability.Description)
            .DescriptionStyle());
    }

    internal Table? ConsumablesBlock(CharacterPrintData characterData)
    {
        return BuildListingTable(characterData.Consumables, [2f, 1], DisplayConsumable, "Consumables");
    }

    private void DisplayConsumable(Table table, Consumable consumable)
    {
        table
            .AddLayoutCell(new Paragraph(consumable.Name)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetMarginLeft(6))
            .AddLayoutCell(new Paragraph(new string('O', consumable.Amount)))
            .AddLayoutCell(1, 2, new Paragraph(consumable.Notes).DescriptionStyle())
            ;
    }

    internal Table? EquipmentBlock(CharacterPrintData characterData)
    {
        return BuildListingTable(characterData.Equipments, 1, DisplayEquipment, "Equipment");
    }

    private void DisplayEquipment(Table table, Equipment equip)
    {
        table.AddLayoutCell(new Paragraph(equip.Name));

        if (equip.Notes is not null)
        {
            table.AddLayoutCell(new Paragraph(equip.Notes).DescriptionStyle());
        }
    }

    private BorderedTable? BuildListingTable<T>(IEnumerable<T> displayItems, int innerTableColSize,
        Action<Table, T> addElementToTable,
        string? blockHeading)
    {
        return BuildListingTable(displayItems.ToList(), addElementToTable, blockHeading,
            () => new BorderedInnerTable(innerTableColSize));
    }

    private BorderedTable? BuildListingTable<T>(IEnumerable<T> displayItems, float[] pointColumnWidths,
        Action<Table, T> addElementToTable, string? blockHeading)
    {
        return BuildListingTable(displayItems.ToList(), addElementToTable, blockHeading,
            () => new BorderedInnerTable(pointColumnWidths));
    }

    private BorderedTable? BuildListingTable<T>(List<T> displayItems, Action<Table, T> addElementToTable,
        string? blockHeading, Func<BorderedInnerTable> innerTableCtor)
    {
        if (displayItems.Count == 0)
        {
            return null;
        }

        BorderedTable blockTable = new(1);

        if (blockHeading is not null)
        {
            blockTable.AddHeaderCell(new Paragraph(blockHeading).SetTextAlignment(TextAlignment.CENTER));
        }

        foreach ((T item, int i) in displayItems.Select((x, i) => (x, i)))
        {
            BorderedInnerTable table = innerTableCtor();
            if (i == 0)
            {
                table.SetBorderTop(Border.NO_BORDER);
            }

            addElementToTable(table, item);
            blockTable.AddLayoutCell(table);
        }

        return blockTable;
    }
}
