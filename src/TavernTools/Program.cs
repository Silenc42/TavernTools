using GuildStashCore;
using PersistenceSupabase;
using TavernTools.Components;
using DependencyInjection = PersistenceSupabase.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
    .AddGuildStashCore()
    .AddSupabaseDb(builder.Configuration)
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// using (IServiceScope scope = app.Services.CreateScope())
// {
//     try
//     {
//         DependencyInjection.MigrateDb(scope.ServiceProvider);
//     }
//     catch (Exception ex)
//     {
//         throw new Exception("Database migration failed", ex);
//     }
// }

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();