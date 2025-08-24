namespace TavernTools.UI;

public static class RazorDependencies
{
    public static System.Reflection.Assembly[] UiDependencies => [
        typeof(GuildStash.UI.Main).Assembly,
        typeof(Charsheet.UI.Main).Assembly
    ];
}