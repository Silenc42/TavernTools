namespace Charsheet.CommonModel;

public class Consumable
{
    public required string Name { get; init; }
    public required string Notes { get; init; }
    public int Amount { get; init; }
}
