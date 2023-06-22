using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using TouristicRental.Data;


var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<IGoodService, GoodService>();


builder.Services.AddIdentity<IdentityUser, IdentityRole>(
        options =>
        {
            options.SignIn.RequireConfirmedAccount = false;

            //Other options go here
        }
        )
    .AddEntityFrameworkStores<TouristicRentalContext>()
    .AddRoles<IdentityRole>();


builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    //options.Cookie.Expiration 

    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
    //options.ReturnUrlParameter=""
});

builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TouristicRentalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TouristicRentalContext") ?? throw new InvalidOperationException("Connection string 'TouristicRentalContext' not found.")));


//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<TouristicRentalContext>();


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
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
