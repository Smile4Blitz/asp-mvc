using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TheaterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TheaterContext") ?? throw new InvalidOperationException("Connection string 'TheaterContext' not found.")));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
   {
       options.SignIn.RequireConfirmedAccount = true;
       options.Password.RequiredLength = 8;
       options.Password.RequiredUniqueChars = 5;
       options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
       options.Lockout.MaxFailedAccessAttempts = 3;
       options.User.RequireUniqueEmail = true;
   }).AddEntityFrameworkStores<ApplicationDbContext>();

// Globalization supported languages
var supportedCultures = new[] { "nl", "en", "en-US", "nl", "nl-BE" };

builder.Services
    .AddLocalization(options => { options.ResourcesPath = "Resources"; })
    .AddControllersWithViews()
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

var app = builder.Build();

// Globalization use the supported languages
app.UseRequestLocalization(
    new RequestLocalizationOptions()
        .SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures)
    );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=NewsMessages}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
