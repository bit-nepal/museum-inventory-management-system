
using mims.Data;
using mims.Services;
using mims.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using mims.Authorization.Constants;
using Microsoft.AspNetCore.Identity;
using mims.Models;
using mims.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Custom Services
builder.Services.AddScoped<IArtifactService, EntityFrameworkCoreArtifactService>();
builder.Services.AddScoped<ILoginService<ApplicationUserLoginDTO>, EFLoginService>();
builder.Services.AddScoped<IAccountService, EFAccountService>();
builder.Services.AddScoped<IRegisterService<ApplicationUserRegisterDTO>, EFRegisterService>();
builder.Services.AddScoped<MediaService>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorBootstrap();

// Authentication and Authorization
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
  .AddCookie(IdentityConstants.ApplicationScheme, options =>
  {
    options.LoginPath = "/Admin/Account/Login";
    options.AccessDeniedPath = "/Admin/Account/Login";
  });

builder.Services.AddAuthorization(options =>
{
  options.AddPolicy(ApplicationPolicy.Administrators,
                     policy => policy.RequireClaim(ApplicationClaims.Role, ApplicationRoles.Admin));
});

builder.Services
   .AddIdentityCore<ApplicationUser>(options =>
   {
     options.User.RequireUniqueEmail = true;
   })
    .AddEntityFrameworkStores<ArtifactContext>()
    .AddApiEndpoints();

// Database configuration
var ArtifactConnectionString = builder.Configuration.GetConnectionString("ArtifactConnectionString");
builder.Services.AddDbContextFactory<ArtifactContext>(
      options =>
      {
        options.UseMySql(
            ArtifactConnectionString,
            ServerVersion.AutoDetect(ArtifactConnectionString),
            mySqlOptions =>
            {
              mySqlOptions.EnableRetryOnFailure(
                  maxRetryCount: 20,
                  maxRetryDelay: TimeSpan.FromSeconds(10),
                  errorNumbersToAdd: null
              );
            }
          );
      }
    );

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // Ensure routing is done before authentication

app.UseAuthentication(); // Authentication must be added before Authorization
app.UseAuthorization();

app.MapBlazorHub();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

