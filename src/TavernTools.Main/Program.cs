using GuildStashCore;
using PersistenceSupabase;
using TavernTools.UI;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
    .AddGuildStashCore()
    .AddSupabaseDb(builder.Configuration)
    ;
WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<MainApp>()
    .AddAdditionalAssemblies(RazorDependencies.UiDependencies)
    .AddInteractiveServerRenderMode()
    ;

app.Run();