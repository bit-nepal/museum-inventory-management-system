using mims.Data;
using mims.Services;
using mims.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//------------- Custom Services --------- //
builder.Services.AddScoped<IArtifactService, EntityFrameworkCoreArtifactService>();

builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorBootstrap();

//-------------- Database ----------------//
var ArtifactConnectionString = builder.Configuration.GetConnectionString("ArtifactConnectionString");
builder.Services.AddDbContextFactory<ArtifactContext>(
  options =>
       options.UseMySql(ArtifactConnectionString,
                        ServerVersion.AutoDetect(ArtifactConnectionString)));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapBlazorHub();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// app.MapRazorComponents<App>()
//     .AddInteractiveServerRenderMode();
app.Run();
