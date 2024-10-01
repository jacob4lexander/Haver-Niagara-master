using Haver_Niagara.Data;
using Haver_Niagara.Models;
using Haver_Niagara.Utilities;
using Haver_Niagara.ViewModels;
using IronPdf.Extensions.Mvc.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

//IRON PDF LICENSE FREE TRIAL
License.LicenseKey = "IRONSUITE.DAWAN1.NCSTUDENTS.NIAGARACOLLEGE.CA.19983-E2436A3390-GUKXO-Y6D22O2WS4M6-FNPQMAV7UEUH-45YA4UQZKEFD-IWRMLNAPXJFD-YTM5TTW22GCR-JM4MZWBUGGED-UDGDTV-T3TTNI6KTTOMEA-DEPLOYMENT.TRIAL-VSMLVI.TRIAL.EXPIRES.23.APR.2024";

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDbContext<HaverNiagaraDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddRoles<IdentityRole>() //added from video
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options => //added from video
{
    //password settings
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    //Lock Out Settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(40);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    //user settings
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+^?~";
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(40);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

//Give access to Ihttpcontext for audit data with Iauditable
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

// Register IRazorViewRenderer here
builder.Services.AddSingleton<IRazorViewRenderer, RazorViewRenderer>();

//For email service configuration
builder.Services.AddSingleton<IEmailConfiguration>(builder.Configuration
    .GetSection("EmailConfiguration").Get<EmailConfiguration>());

//For the Identity System
builder.Services.AddTransient<IEmailSender, EmailSender>();

//Email with added methods for production use.
builder.Services.AddTransient<IMyEmailSender, MyEmailSender>();

var app = builder.Build();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

HaverInitializer.Seed(app);
ApplicationDbInitializer.Seed(app);

app.Run();
