using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/Usuario/Index");

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

var app = builder.Build();

app.MapControllerRoute
    (
        name: "default",
        pattern: "{controller=Usuario}/{action=Index}/{id?}"
    );

app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();

app.Run();
